using System.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Twilio;

namespace KDCLLC.Identity.Services.Services
{
    public class SmsTwilioService
    {
        private const string phoneKey = "sms:PhoneNumber";
        private const string authTokenKey = "sms:AccountSid";
        private const string accountSidKey = "sms:AuthToken";

        public Task SendAsync(IdentityMessage message)
        {
            string AccountSid = ConfigurationManager.AppSettings[phoneKey];
            string AuthToken = ConfigurationManager.AppSettings[authTokenKey];
            string twilioPhoneNumber = ConfigurationManager.AppSettings[accountSidKey];

            var twilio = new TwilioRestClient(AccountSid, AuthToken);

            twilio.SendSmsMessage(twilioPhoneNumber, message.Destination, message.Body);
            // Plug in your sms service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
