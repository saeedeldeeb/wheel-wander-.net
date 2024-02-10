using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WheelWander.Helpers;
using WheelWander.ViewModels.Auth;

namespace WheelWander.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly JWT _jwt;
    private readonly ISmsService _smsService;
    private readonly IMemoryCache _memoryCache;

    public AuthService(UserManager<IdentityUser> userManager, IOptions<JWT> jwt, ISmsService smsService,
        IMemoryCache memoryCache)
    {
        _userManager = userManager;
        _jwt = jwt.Value;
        _smsService = smsService;
        _memoryCache = memoryCache;
    }

    public async Task<AuthModel> RegisterAsync(RegisterModel model)
    {
        if (await _userManager.FindByEmailAsync(model.Email) is not null)
            return new AuthModel { Message = "Email is already registered!" };

        if (await _userManager.FindByNameAsync(model.Username) is not null)
            return new AuthModel { Message = "Username is already registered!" };

        var user = new IdentityUser
        {
            UserName = model.Username,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            var errors = result.Errors.Aggregate(string.Empty, (current, error) => current + $"{error.Description},");

            return new AuthModel { Message = errors };
        }

        await _userManager.AddToRoleAsync(user, "User");

        var jwtSecurityToken = await CreateJwtToken(user);

        var verificationCode = new Random().Next(1000, 9999);
        var smsResult = _smsService.Send(user.PhoneNumber, $"Your verification code is: {verificationCode}");
        _memoryCache.Set(user.PhoneNumber, verificationCode, TimeSpan.FromMinutes(5));

        if (!string.IsNullOrEmpty(smsResult.ErrorMessage))
            return new AuthModel { Message = smsResult.ErrorMessage };

        return new AuthModel
        {
            Email = user.Email,
            ExpiresOn = jwtSecurityToken.ValidTo,
            IsAuthenticated = true,
            Roles = new List<string> { "User" },
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            Username = user.UserName
        };
    }

    public async Task<AuthModel> GetTokenAsync(LoginModel model)
    {
        var authModel = new AuthModel();

        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
        {
            authModel.Message = "Email or Password is incorrect!";
            return authModel;
        }

        if (!await _userManager.IsPhoneNumberConfirmedAsync(user))
        {
            authModel.Message = "Phone number is not confirmed!";
            return authModel;
        }

        var jwtSecurityToken = await CreateJwtToken(user);
        var rolesList = await _userManager.GetRolesAsync(user);

        authModel.IsAuthenticated = true;
        authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        authModel.Email = user.Email;
        authModel.Username = user.UserName;
        authModel.ExpiresOn = jwtSecurityToken.ValidTo;
        authModel.Roles = rolesList.ToList();

        return authModel;
    }

    public async Task<AuthModel> VerifyPhoneNumberAsync(VerifyPhoneNumberModel model)
    {
        var authModel = new AuthModel();

        if (!_memoryCache.TryGetValue(model.PhoneNumber, out int verificationCode))
        {
            authModel.Message = "Verification code is expired!";
            return authModel;
        }

        if (verificationCode != model.VerificationCode)
        {
            authModel.Message = "Verification code is incorrect!";
            return authModel;
        }

        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user is null)
        {
            authModel.Message = "User not found!";
            return authModel;
        }

        user.PhoneNumberConfirmed = true;
        await _userManager.UpdateAsync(user);

        authModel.Message = "Phone number is confirmed!";
        authModel.IsAuthenticated = true;
        return authModel;
    }

    private async Task<JwtSecurityToken> CreateJwtToken(IdentityUser user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);
        var roleClaims = new List<Claim>();

        foreach (var role in roles)
            roleClaims.Add(new Claim("roles", role));

        var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            expires: DateTime.Now.AddDays(_jwt.DurationInDays),
            signingCredentials: signingCredentials);

        return jwtSecurityToken;
    }
}