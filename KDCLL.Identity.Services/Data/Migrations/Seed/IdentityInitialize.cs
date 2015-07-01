using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDCLLC.Identity.Services.Managers;
using KDCLLC.Identity.Services.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KDCLLC.Identity.Services.Data.Migrations.Seed
{
    public static class IdentityInitialize
    {

        public static void SeedIdentityForEF(ApplicationDbContext context)
        {
            if ((!context.Roles.Any()) && (!context.Users.Any()))
            {
                var roleStore = new ApplicationRoleStore(context);
                //var roleManager = new RoleManager<ApplicationRole, int>(roleStore);

                var roleManager = new ApplicationRoleManager(roleStore);

                var role = new ApplicationRole
                {
                    Name = "Admin",
                    Description = "Super Admin User group"
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

                user.FirstName = "Jack";
                user.LastName = "Smith";

                userManager.Create(user, "P@ssword");
                var result = userManager.SetLockoutEnabled(user.Id, false);

                userManager.AddToRole(user.Id, "Admin");


                //added group manager
                var groupManager = new ApplicationGroupManager(roleManager,userManager);
                var newGroup = new ApplicationGroup("SuperAdmins", "Full Access to All");

                groupManager.CreateGroup(newGroup);
                groupManager.SetUserGroups(user.Id, new int[] { newGroup.Id });
                groupManager.SetGroupRoles(newGroup.Id, new string[] { role.Name });
            }
        }
    }
}
