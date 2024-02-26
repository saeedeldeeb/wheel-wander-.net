using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using WheelWander.Helpers;

namespace WheelWander.Services;

public class SmsService : ISmsService
{
    private readonly TwilioSettings _twilio;

    public SmsService(IOptions<TwilioSettings> twilio)
    {
        _twilio = twilio.Value;
    }

    public MessageResource Send(string mobileNumber, string body)
    {
        TwilioClient.Init(_twilio.AccountSID, _twilio.AuthToken);

        var result = MessageResource.Create(
            body: body,
            from: new Twilio.Types.PhoneNumber(_twilio.TwilioPhoneNumber),
            to: mobileNumber
        );

        return result;
    }
}