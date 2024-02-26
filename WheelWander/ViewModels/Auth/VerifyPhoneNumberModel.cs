namespace WheelWander.ViewModels.Auth;

public class VerifyPhoneNumberModel
{
    public string PhoneNumber { get; set; }
    public int VerificationCode { get; set; }
    public string Email { get; set; }
}