using Twilio.Rest.Api.V2010.Account;

namespace WheelWander.Services;

public interface ISmsService
{
    MessageResource Send(string mobileNumber, string body);
}