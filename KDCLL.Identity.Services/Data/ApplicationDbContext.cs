using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDCLLC.Identity.Services.Infrastructure.Configuration;
using KDCLLC.Identity.Services.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KDCLLC.Identity.Services.Data
{
    public class ApplicationDbContext :  IdentityDbContext<ApplicationUser, ApplicationRole,
                                                          int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationDbContext()
            //: base("IdenityConnection")
            : base(CheckConnectionSting())
        {
            
        }

        private static string CheckConnectionSting()
        {
            if (string.IsNullOrEmpty(SecureSettings.GetConnectionValue("IdenityConnectionSecure")))
            {
                return "IdenityConnection";
            }
            else
            {
                return SecureSettings.GetConnectionValue("IdenityConnectionSecure");
            }
           
        }
        //public ApplicationDbContext(string nameOrConnectionString) :base(nameOrConnectionString)
        //{
        //}
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationGroup>()
                .HasMany<ApplicationUserGroup>((ApplicationGroup g) => g.ApplicationUsers)
                .WithRequired().HasForeignKey<int>((ApplicationUserGroup ag) => ag.ApplicationGroupId);
            modelBuilder.Entity<ApplicationUserGroup>()
                .HasKey((ApplicationUserGroup r) =>
                    new
                    {
                        ApplicationUserId = r.ApplicationUserId,
                        ApplicationGroupId = r.ApplicationGroupId
                    }).ToTable("ApplicationUserGroups");

            modelBuilder.Entity<ApplicationGroup>()
                .HasMany<ApplicationGroupRole>((ApplicationGroup g) => g.ApplicationRoles)
                .WithRequired().HasForeignKey<int>((ApplicationGroupRole ap) => ap.ApplicationGroupId);
            modelBuilder.Entity<ApplicationGroupRole>().HasKey((ApplicationGroupRole gr) =>
                new
                {
                    ApplicationRoleId = gr.ApplicationRoleId,
                    ApplicationGroupId = gr.ApplicationGroupId
                }).ToTable("ApplicationGroupRoles");

        }

        // Add the ApplicationGroups property:
        public virtual IDbSet<ApplicationGroup> ApplicationGroups { get; set; }

        static ApplicationDbContext()
        {
            // Set the database initializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, KDCLLC.Identity.Services.Data.Migrations.Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
