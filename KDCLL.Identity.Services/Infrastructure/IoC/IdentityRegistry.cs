﻿using System;
using System.Web;

using KDCLLC.Identity.Services;
using KDCLLC.Identity.Services.Data;
using KDCLLC.Identity.Services.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using StructureMap;
using KDCLLC.Identity.Services.Managers;
using KDCLLC.Identity.Services.Infrastructure.Configuration;
using StructureMap.Configuration.DSL;
using System.Data.Entity;

namespace KDCLLC.Identity.Services.Infrastructure.IoC
{
    /// <summary>
    /// good artcile for the strucruremap and asp.net identity http://stackoverflow.com/questions/20654011/structuremap-web-api-2-and-iuserstore-error
    /// </summary>
    public class IdentityRegistry : Registry
    {
        public IdentityRegistry()
        {

            For<IUserStore<ApplicationUser, int>>().Use<UserStore<ApplicationUser,
                                                                   ApplicationRole,
                                                                   int,
                                                                   ApplicationUserLogin,
                                                                   ApplicationUserRole,
                                                                   ApplicationUserClaim>>();

            For<ApplicationDbContext>().Use<ApplicationDbContext>();
            For<DbContext>().Use(() => new ApplicationDbContext());

            For<IUserStore<ApplicationUser,int>>().Use<ApplicationUserStore>();
            //For<UserStore<ApplicationUser, ApplicationRole, string,
            //                                        ApplicationUserLogin, ApplicationUserRole,
            //                                        ApplicationUserClaim>, IUserStore<ApplicationUser, string>>().Use<ApplicationUserStore>();


            //For<IRoleStore<IdentityRole, string>>().Use<RoleStore<IdentityRole, string, IdentityUserRole>>();

            For<IRoleStore<ApplicationRole, int>>().Use<ApplicationRoleStore>();

            For<IAuthenticationManager>().Use(() => HttpContext.Current.GetOwinContext().Authentication);

            //specific to the extended model
            For<ApplicationRoleStore>().Use(() => new ApplicationRoleStore());

            For<ApplicationUserManager>()
               .Use<ApplicationUserManager>()
               .Ctor<IIdentityMessageService>("smsService").Is<SmsService>()
               .Ctor<IIdentityMessageService>("emailService").Is<EmailService>()
               .Setter<IIdentityMessageService>(userManager => userManager.SmsService).Is<SmsService>()
               .Setter<IIdentityMessageService>(userManager => userManager.EmailService).Is<EmailService>();

            For<UserManager<ApplicationUser,int>>().Use(() => HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>());

        }
          
    }
}
