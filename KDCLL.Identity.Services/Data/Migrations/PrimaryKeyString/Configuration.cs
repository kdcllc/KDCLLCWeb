namespace KDCLLC.Identity.Services.Data.Migrations.PrimaryKeyString
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using KDCLLC.Identity.Services.Data;
    using KDCLLC.Identity.Services.Managers;
    using KDCLLC.Identity.Services.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if ((!context.Roles.Any()) && (!context.Users.Any()))
            {
                var roleStore = new ApplicationRoleStore(context);
                var roleManager = new RoleManager<ApplicationRole,int>(roleStore);
                var role = new ApplicationRole
                {
                    Name = "Admin"
                };
                roleManager.Create(role);
           
                var userStore = new UserStore<ApplicationUser,
                                                ApplicationRole,
                                                int,
                                                ApplicationUserLogin,
                                                ApplicationUserRole,
                                                ApplicationUserClaim>(context);
                var userManager = new ApplicationUserManager(userStore);

                var user = new ApplicationUser
                {   
                    Email = "admin@example.com",
                    UserName = "SuperUser",
                    EmailConfirmed = true
                };
                userManager.Create(user, "P@ssword");
                var result = userManager.SetLockoutEnabled(user.Id, false);

                userManager.AddToRole(user.Id, "Admin");


                //added group manager
                var groupManager = new ApplicationGroupManager();
                var newGroup = new ApplicationGroup("SuperAdmins", "Full Access to All");

                groupManager.CreateGroup(newGroup);
                groupManager.SetUserGroups(user.Id, new int[] { newGroup.Id });
                groupManager.SetGroupRoles(newGroup.Id, new string[] { role.Name });
            }

           

        }
    }
}
