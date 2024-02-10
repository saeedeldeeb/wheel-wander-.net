using WheelWander.ViewModels.Auth;

namespace WheelWander.Services;

public interface IAuthService
{
    Task<AuthModel> RegisterAsync(RegisterModel model);
    Task<AuthModel> GetTokenAsync(LoginModel model);
    Task<AuthModel> VerifyPhoneNumberAsync(VerifyPhoneNumberModel model);
}