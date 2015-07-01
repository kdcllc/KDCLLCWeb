using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using KDCLLC.Identity.Services.Infrastructure.Configuration;
using Microsoft.AspNet.Identity;
using Postal;
using System.Configuration;
using System.Web;

namespace KDCLLC.Identity.Services
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            Postal.EmailService emailService = new Postal.EmailService(ViewEngines.Engines);


            var fromEmail = SecureSettings.GetValue("smtp:From");
            var host = SecureSettings.GetValue("smtp:Host");
            if (!string.IsNullOrEmpty(host))
            {
                emailService = new Postal.EmailService(ViewEngines.Engines, () => CreateMySmtpClient());
            }

           

            dynamic email = new Email("IdentityMessageService");
            email.To = message.Destination;
            if (!string.IsNullOrEmpty(fromEmail))
            { 
                email.From = fromEmail; 
            }
            else
            {
                fromEmail = ConfigurationManager.AppSettings["NoReplyEmail"];
                if (string.IsNullOrEmpty(fromEmail)) fromEmail = "no-reply@microsoft.com";
                email.From = fromEmail;
            }

            email.Subject = message.Subject;
            email.Body = message.Body;

            return emailService.SendAsync(email);

           // return email.SendAsync();

            //return Task.FromResult(0);
        }

        
        private SmtpClient CreateMySmtpClient()
        {
            var host = SecureSettings.GetValue("smtp:Host");

           

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;

            var user = SecureSettings.GetValue("smtp:UserName");
            if (!string.IsNullOrEmpty(user))
            {
                var password = SecureSettings.GetValue("smtp:Password");
                NetworkCredential basicCredential = new NetworkCredential(user, password);
                client.Credentials = basicCredential;
            }


            client.Host = host;
            int port = 0;
            int.TryParse(SecureSettings.GetValue("smtp:Port"), out port);
            if (port != 0) client.Port = port;

          

            return client;
        }
    }
}
