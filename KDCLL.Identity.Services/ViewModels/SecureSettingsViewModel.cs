using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDCLLC.Identity.Services.Infrastructure;

namespace KDCLLC.Identity.Services.ViewModels
{
    public class SecureSettingsViewModel
    {
        #region Azure AD OpenId
        [DisplayName("ida:ClientId")]
        [Encryption]
        public string OpenIDClientId { get; set; }

        [DisplayName("ida:AADInstance")]
        [Encryption]
        public string OpenIDAADInstance { get; set; }

        [DisplayName("ida:Tenant")]
        [Encryption]
        public string OpenIDTenant { get; set; }

        [DisplayName("ida:PostLogoutRedirectUri")]
        [Encryption]
        public string OpenIDPostLogoutRedirectUrl { get; set; }
        
        #endregion

        #region SMS 
        [DisplayName("sms:PhoneNumber")]
        [Encryption]
        public string SmsPhoneNumber { get; set; }

        [DisplayName("sms:AccountSid")]
        [Encryption]
        public string SmsAccountSid { get; set; }

        [DisplayName("sms:AuthToken")]
        [Encryption]
        public string SmsAuthToken { get; set; }
        #endregion

        #region Microsoft Sign-In Account
        [DisplayName("ms:clientId")]
        [Encryption]
        public string MsClientId { get; set; }

        [DisplayName("ms:clientSecret")]
        [Encryption]
        public string MsClientSecret { get; set; }
              
        #endregion

        #region Google Sign-In Account
        [DisplayName("google:clientId")]
        [Encryption]
        public string GoogleClientId { get; set; }

        [DisplayName("google:clientSecret")]
        [Encryption]
        public string GoogleClientSecret { get; set; }

        #endregion

        #region Smtp Account Setup
        [DisplayName("smtp:Host")]
        [Encryption]
        public string SmtpHost { get; set; }

        [DisplayName("smtp:Port")]
        [Encryption]
        public string SmtpPort { get; set; }

        [DisplayName("smtp:UserName")]
        [Encryption]
        public string SmtpUserName { get; set; }

        [DisplayName("smtp:Password")]
        [Encryption]
        public string SmtpPassword { get; set; }

        [DisplayName("smtp:From")]
        [Encryption]
        public string SmtpFrom { get; set; }
        #endregion

        #region ConnectionString 
        [DisplayName("IdenityConnection")]
        [Encryption]
        public string IdenityConnection { get; set; }

        #endregion
    }
}
