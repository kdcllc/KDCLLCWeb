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


namespace KDCLLC.Identity.Services.Infrastructure.IoC
{
    /// <summary>
    /// Call this on Application_Start to register all of the types used by this project
    /// 
    /// IdentityRegistration.RegisterAll();
    /// 
    /// </summary>
    public class IdentityRegistration
    {
        public static void RegisterAll()
        {
            try
            {
                ObjectFactory.Configure(x =>
                {
                    x.AddRegistry<IdentityRegistry>();
                    x.For<IConfigurationAdapter>().Use<ConfigurationAdapter>();
                    x.For<LoggingService>().Use<LoggingService>();

                    
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    

    }

}
