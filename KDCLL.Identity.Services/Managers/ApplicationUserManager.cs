using System;
using System.Configuration;
using KDCLLC.Identity.Services.Data;
using KDCLLC.Identity.Services.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;

namespace KDCLLC.Identity.Services.Managers
{
    // Configure the application user manager used in this application.
    // UserManager is defined in ASP.NET Identity and is used by the
    // application.

    public class ApplicationUserManager : UserManager<ApplicationUser,int>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser,int> store)
            : base(store)
        {
            //added this to fix the issue with System.NotSupportedException: No IUserTokenProvider is registered. 
            //http://stackoverflow.com/questions/25740139/asp-net-identity-use-generatepasswordresettoken-on-azure-website
           
            this.UserTokenProvider = new EmailTokenProvider<ApplicationUser, int>();
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
            IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser,
                                                                   ApplicationRole, 
                                                                   int, 
                                                                   ApplicationUserLogin, 
                                                                   ApplicationUserRole, 
                                                                   ApplicationUserClaim>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser,int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            bool isLockedOut = true;
            string lockedout = ConfigurationManager.AppSettings["UserLockoutEnabledByDefault"];
            if (!string.IsNullOrEmpty(lockedout))
            {
                bool.TryParse(ConfigurationManager.AppSettings["UserLockoutEnabledByDefault"].ToString(), out isLockedOut);
            }
            manager.UserLockoutEnabledByDefault = isLockedOut;
            //------------------------------------------------

            double timespan = 5;
            string timespanString = ConfigurationManager.AppSettings["DefaultAccountLockoutTimeSpan"];
            if (!string.IsNullOrEmpty(timespanString))
            {
                double.TryParse(ConfigurationManager.AppSettings["DefaultAccountLockoutTimeSpan"].ToString(), out timespan);
            }
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(timespan); ;
            //-----------------------------------------------------------------------

            int attemps = 5;
            string attempsString = ConfigurationManager.AppSettings["MaxFailedAccessAttemptsBeforeLockout"];
            if (!string.IsNullOrEmpty(attempsString))
            {
                int.TryParse(ConfigurationManager.AppSettings["MaxFailedAccessAttemptsBeforeLockout"].ToString(), out attemps);
            }
            manager.MaxFailedAccessAttemptsBeforeLockout = attemps;
            //------------------------------------------------------


            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug in here.
            manager.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<ApplicationUser,int>
            {
                MessageFormat = "Your security code is: {0}"
            });
            manager.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<ApplicationUser,int>
            {
                Subject = "SecurityCode",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser,int>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
}