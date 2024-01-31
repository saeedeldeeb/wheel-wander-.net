using System.ComponentModel.DataAnnotations;

namespace WheelWander.ViewModels.Auth;

public class LoginModel
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}