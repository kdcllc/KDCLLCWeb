using System.Configuration;
using System.Threading.Tasks;
using KDCLLC.Identity.Services.Infrastructure.Configuration;
using Microsoft.AspNet.Identity;
using Twilio;

namespace KDCLLC.Identity.Services
{
    public class SmsService : IIdentityMessageService
    {
        private const string phoneKey = "sms:PhoneNumber";
        private const string authTokenKey = "sms:AccountSid";
        private const string accountSidKey = "sms:AuthToken";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public Task SendAsync(IdentityMessage message)
        {
            var log = new LoggingService();

            string twilioPhoneNumber = SecureSettings.GetValue(phoneKey);
            string AuthToken = SecureSettings.GetValue(authTokenKey);
            string AccountSid = SecureSettings.GetValue(accountSidKey);

            SharpVoice.Voice v = new SharpVoice.Voice(AuthToken, AccountSid);
 
            var result = v.SendSMS(message.Destination, message.Body);

            log.Info(result);

            // Plug in your sms service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
