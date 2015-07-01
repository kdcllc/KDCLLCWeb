using System;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;
using KDCLLC.Identity.Services.ViewModels;

namespace KDCLLC.Identity.Services.Infrastructure.Configuration
{
    public static class SecureSettings 
    {
        private static string EncryptionKey = "YeshuaIs4Israel1948";

        static SecureSettings()
        {
            if (System.Web.HttpContext.Current != null)
                _config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            else
                _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        }
        private static System.Configuration.Configuration _config;
        public static System.Configuration.Configuration Provider
        {
            get { return _config; }
            set { _config = value; }
        }

        public static SecureSettingsViewModel CreateViewModel()
        {
            var model = new SecureSettingsViewModel();
            model.IdenityConnection = SecureSettings.GetConnectionValue("IdenityConnection");

            foreach (string key in ConfigurationManager.AppSettings)
            {

                string value = ConfigurationManager.AppSettings[key];

                PropertyInfo[] properties = model.GetType().GetProperties();

                foreach (var prop in properties)
                {
                    DisplayNameAttribute attr = (DisplayNameAttribute)Attribute.GetCustomAttribute(prop, typeof(DisplayNameAttribute));

                    if (attr.DisplayName == key)
                    {
                        EncryptionAttribute attrEncryption = (EncryptionAttribute)Attribute.GetCustomAttribute(prop, typeof(EncryptionAttribute));
                        if (attrEncryption != null) value = SecureSettings.GetValue(key);
                        prop.SetValue(model, value);
                    }

                }
            }
            return model;
        }

        public static void SaveViewModel(SecureSettingsViewModel model)
        {
            PropertyInfo[] properties = model.GetType().GetProperties();

            SecureSettings.SetConnectionValue("IdenityConnection", model.IdenityConnection);

            foreach (var prop in properties)
            {
                DisplayNameAttribute attr = (DisplayNameAttribute)Attribute.GetCustomAttribute(prop, typeof(DisplayNameAttribute));

                if (attr != null && attr.DisplayName != "IdenityConnection")
                {
                    string value = (string)prop.GetValue(model);

                    SecureSettings.SetValue(attr.DisplayName, value);

                }

            }
        }

       #region Properties to be secure
        private const string OpenIDclientIdKey = "ida:ClientId";
        private static string _OpenIDClientId;
        [DisplayName(OpenIDclientIdKey)]
        public static string OpenIDClientId
        {
            get
            {
                _OpenIDClientId = DecryptProperty(OpenIDclientIdKey);
                return _OpenIDClientId;

            }
            set
            {
                var result = Encrypt(value);
                AddOrUpdateAppSettings(OpenIDclientIdKey, result);
                _OpenIDClientId = value;

            }
        }

        private const string OpenIDAADInstanceKey = "ida:AADInstance";
        private static string _OpenIDAADInstance;
        [DisplayName(OpenIDAADInstanceKey)]
        public static string OpenIDAADInstance
        {
            get
            {
                _OpenIDAADInstance = DecryptProperty(OpenIDAADInstanceKey);
                return _OpenIDAADInstance;

            }
            set
            {
                var result = Encrypt(value);
                AddOrUpdateAppSettings(OpenIDAADInstanceKey, result);
                _OpenIDAADInstance = value;

            }
        }

        private const string OpenIDTenantKey = "ida:Tenant";
        private static string _OpenIDTenant;
        [DisplayName(OpenIDTenantKey)]
        public static string OpenIDTenant
        {
            get
            {
                _OpenIDTenant = DecryptProperty(OpenIDTenantKey);
                return _OpenIDTenant;

            }
            set
            {
                var result = Encrypt(value);
                AddOrUpdateAppSettings(OpenIDTenantKey, result);
                _OpenIDTenant = value;

            }
        }

        private const string OpenIDPostLogoutRedirectUrlKey = "ida:PostLogoutRedirectUri";
        private static string _OpenIDPostLogoutRedirectUrl;
        [DisplayName(OpenIDPostLogoutRedirectUrlKey)]
        public static string OpenIDPostLogoutRedirectUrl
        {
            get
            {
                _OpenIDPostLogoutRedirectUrl = DecryptProperty(OpenIDPostLogoutRedirectUrlKey);
                return _OpenIDPostLogoutRedirectUrl;

            }
            set
            {
                var result = Encrypt(value);
                AddOrUpdateAppSettings(OpenIDPostLogoutRedirectUrlKey, result);
                _OpenIDPostLogoutRedirectUrl = value;

            }
        }

        private const string SmsPhoneNumberKey = "sms:PhoneNumber";
        private static string _SmsPhoneNumberUrl;
        [DisplayName(SmsPhoneNumberKey)]
        public static  string SmsPhoneNumber
        {
            get
            {
                _SmsPhoneNumberUrl = DecryptProperty(SmsPhoneNumberKey);
                return _SmsPhoneNumberUrl;

            }
            set
            {
                var result = Encrypt(value);
                AddOrUpdateAppSettings(SmsPhoneNumberKey, result);
                _SmsPhoneNumberUrl = value;

            }
        }

        private const string SmsAccountSidKey = "sms:AccountSid";
        private static string _SmsAccountSid;
        [DisplayName(SmsAccountSidKey)]
        public static  string SmsAccountSid
        {
            get
            {
                _SmsAccountSid = DecryptProperty(SmsAccountSidKey);
                return _SmsAccountSid;

            }
            set
            {
                var result = Encrypt(value);
                AddOrUpdateAppSettings(SmsAccountSidKey, result);
                _SmsAccountSid = value;

            }
        }

        private const string SmsAuthTokenKey = "sms:AuthToken";
        private static string _SmsAuthToken;
        [DisplayName(SmsAuthTokenKey)]
        public static  string SmsAuthToken
        {
            get
            {
                _SmsAuthToken = DecryptProperty(SmsAuthTokenKey);
                return _SmsAuthToken;

            }
            set
            {
                var result = Encrypt(value);
                AddOrUpdateAppSettings(SmsAuthTokenKey, result);
                _SmsAuthToken = value;

            }
        }


        private const string SmtpHostKey = "smtp:Host";
        private static string _SmtpHost;
        [DisplayName(SmtpHostKey)]
        public static string SmtpHost
        {
            get
            {
                _SmtpHost = DecryptProperty(SmtpHostKey);
                return _SmtpHost;

            }
            set
            {
                var result = Encrypt(value);
                AddOrUpdateAppSettings(SmtpHostKey, result);
                _SmtpHost = value;

            }
        }

        private const string SmtpPortKey = "smtp:Port";
        private static string _SmtpPort;
        [DisplayName(SmtpPortKey)]
        public static string SmtpPort
        {
            get
            {
                _SmtpPort = DecryptProperty(SmtpPortKey);
                return _SmtpPort;

            }
            set
            {
                var result = Encrypt(value);
                AddOrUpdateAppSettings(SmtpPortKey, result);
                _SmtpPort = value;

            }
        }

        private const string SmtpUserNameKey = "smtp:UserName";
        private static string _SmtpUserName;
        [DisplayName(SmtpUserNameKey)]
        public static string SmtpUserName
        {
            get
            {
                _SmtpUserName = DecryptProperty(SmtpUserNameKey);
                return _SmtpUserName;

            }
            set
            {
                var result = Encrypt(value);
                AddOrUpdateAppSettings(SmtpUserNameKey, result);
                _SmtpUserName = value;

            }
        }

        private const string SmtpPasswordKey = "smtp:Password";
        private static string _SmtpPassword;
        [DisplayName(SmtpPasswordKey)]
        public static string SmtpPassword
        {
            get
            {
                _SmtpPassword = DecryptProperty(SmtpPasswordKey);
                return _SmtpUserName;

            }
            set
            {
                var result = Encrypt(value);
                AddOrUpdateAppSettings(SmtpPasswordKey, result);
                _SmtpPassword = value;

            }
        }
        #endregion

        /// <summary>
       /// Allows retrieval of the decrypted value
       /// </summary>
       /// <param name="key"></param>
       /// <returns></returns>
        public static string GetValue(string key)
        {
            var value = _config.AppSettings.Settings[key];

            if (value == null) return string.Empty;

            var encryptedValue = _config.AppSettings.Settings[key].Value;
            if (!string.IsNullOrEmpty(encryptedValue))
            {
                return DecryptProperty(key);
            }
            else
            {
                return string.Empty;
            }
        
        }
        
        /// <summary>
        /// Get Connection String Encrypted Value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConnectionValue(string key)
        {
            var value = _config.ConnectionStrings.ConnectionStrings[key];

            if (value == null) return string.Empty;

            var encryptedValue = _config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
            if (!string.IsNullOrEmpty(encryptedValue))
            {
                return Decrypt(encryptedValue);
             
            }
            else
            {
                return string.Empty;
            }

        }
        
        public static void SetConnectionValue(string key, string value)
        {
            if (string.IsNullOrEmpty(value)) return;

            var encryptedValue = Encrypt(value);
            AddOrUpdateConnectionString(key, encryptedValue);

        }
        
        public static void SetValue(string key, string value)
        {
            if (string.IsNullOrEmpty(value)) return;

            var encryptedValue = Encrypt(value);
            AddOrUpdateAppSettings(key, encryptedValue);
        }

        private static string DecryptProperty(string key)
        {
            var value = _config.AppSettings.Settings[key];
            
            if (value == null) return string.Empty;

            var encryptedValue = _config.AppSettings.Settings[key].Value;

            if (!string.IsNullOrEmpty(encryptedValue))
            {
                return Decrypt(_config.AppSettings.Settings[key].Value);
            }
            else{
                return string.Empty;
            }
           
        }

        private static void AddOrUpdateConnectionString(string key, string value)
        {
            if (string.IsNullOrEmpty(value)) return;
            try
            {
                if (_config.ConnectionStrings.ConnectionStrings[key] == null)
                {
                    ConnectionStringSettings settings = new ConnectionStringSettings() { ConnectionString = value, ProviderName = "System.Data.SqlClient" };
                    _config.ConnectionStrings.ConnectionStrings.Add(settings); 
                }
                else
                {
                    _config.ConnectionStrings.ConnectionStrings[key].ConnectionString = value;
                }
                _config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(_config.ConnectionStrings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

        private static void AddOrUpdateAppSettings(string key, string value)
        {
            if (string.IsNullOrEmpty(value)) return;
            try
            {

                var settings = _config.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                _config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(_config.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

        #region Encryption/Decryption
        private static string Encrypt(string clearText)
        {

            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        private static string Decrypt(string cipherText)
        {

            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        #endregion

    }
}
