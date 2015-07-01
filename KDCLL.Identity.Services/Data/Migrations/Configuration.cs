namespace KDCLLC.Identity.Services.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using KDCLLC.Identity.Services.Data;
    using KDCLLC.Identity.Services.Data.Migrations.Seed;
    using KDCLLC.Identity.Services.Managers;
    using KDCLLC.Identity.Services.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<KDCLLC.Identity.Services.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "KDCLLC.Identity.Services.Data.ApplicationDbContext";
        }

        protected override void Seed(KDCLLC.Identity.Services.Data.ApplicationDbContext context)
        {


            IdentityInitialize.SeedIdentityForEF(context);

        }
    }
}
