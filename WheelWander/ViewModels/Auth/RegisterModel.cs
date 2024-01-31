using System.ComponentModel.DataAnnotations;

namespace WheelWander.ViewModels.Auth;

public class RegisterModel
{
    [Required, StringLength(50)]
    public string Username { get; set; }

    [Required, StringLength(128)]
    public string Email { get; set; }

    [Required, StringLength(256)]
    public string Password { get; set; }
    
    [Required, RegularExpression(@"^(?:(?:\+|00)20)?(10|11|12|13|14|15|16|17|18|19)[0-9]{8}$", ErrorMessage = "Invalid phone number")]
    public string PhoneNumber { get; set; }
}