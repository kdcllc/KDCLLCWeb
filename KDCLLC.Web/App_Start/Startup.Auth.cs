using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;

using Owin;
using System;
using Microsoft.Owin.Security.DataProtection;
using System.Web.Mvc;
using KDCLLC.Identity.Services.Infrastructure.Configuration;
using System.Globalization;
using KDCLLC.Identity.Services.Managers;
using KDCLLC.Identity.Services.Models;
using KDCLLC.Identity.Services.Data;
using Microsoft.Owin.Security.OpenIdConnect;


namespace KDCLLC.Web
{
	public partial class Startup
	{
        private static string openClientId = SecureSettings.GetValue("ida:ClientId");
        private static string openAadInstance = SecureSettings.GetValue("ida:AADInstance");
        private static string openTenant = SecureSettings.GetValue("ida:Tenant");
        private static string openPostLogoutRedirectUri = SecureSettings.GetValue("ida:PostLogoutRedirectUri");

        private static string msClientId = SecureSettings.GetValue("ms:clientId");
        private static string msSecret = SecureSettings.GetValue("ms:clientSecret");

        private static string googleClientId = SecureSettings.GetValue("google:clientId");
        private static string googleSecret = SecureSettings.GetValue("google:clientSecret");

        string authority = String.Format(CultureInfo.InvariantCulture, openAadInstance, openTenant);

        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and role manager to use a
            // single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                 

                    OnValidateIdentity = SecurityStampValidator
                                   .OnValidateIdentity<ApplicationUserManager, ApplicationUser, int>(
                                       validateInterval: TimeSpan.FromMinutes(30),
                                       regenerateIdentityCallback: (manager, user) =>
                                           user.GenerateUserIdentityAsync(manager),
                                       getUserIdCallback: (id) => (id.GetUserId<int>()))
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Uncomment the following lines to enable logging in with third party login providers

            #region Active Logins
            //http://www.oauthforaspnet.com/providers/microsoft/
            //host file %systemroot%\system32\drivers\etc\
            //127.0.0.1 localdev.kdc.com:44302
            //%USERPROFILE%\My Documents\IISExpress\config\applicationhost.config

            //netsh http add urlacl url=https://localdev.kdc.com user=everyone

            //https://localdev.kdc.com:44302/signin-microsoft
            if (!string.IsNullOrEmpty(msClientId))
            {
                app.UseMicrosoftAccountAuthentication(clientId: msClientId,
                                                      clientSecret: msSecret);
            }

            if (!string.IsNullOrEmpty(googleClientId))
            {
                app.UseGoogleAuthentication(clientId: googleClientId,
                                            clientSecret: googleSecret);
            }

            if (!string.IsNullOrEmpty(openClientId))
            {
                app.UseOpenIdConnectAuthentication(
                            new OpenIdConnectAuthenticationOptions
                            {
                                ClientId = openClientId,
                                Authority = authority,
                                PostLogoutRedirectUri = openPostLogoutRedirectUri
                            });
            }
            #endregion

            #region InActive Logins

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");
            #endregion
        }

	}
}