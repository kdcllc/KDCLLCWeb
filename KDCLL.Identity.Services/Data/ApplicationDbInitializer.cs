using System.Data.Entity;
using System.Web;
using KDCLLC.Identity.Services.Data.Migrations.Seed;
using KDCLLC.Identity.Services.Managers;
using KDCLLC.Identity.Services.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace KDCLLC.Identity.Services.Data
{
    // This is useful if you do not want to tear down the database each time you
    // run the application.
    // public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    //DropCreateDatabaseIfModelChanges, CreateDatabaseIfNotExists
    // This example shows you how to create a new database if the Model changes
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            //InitializeIdentityForEF(context);
            IdentityInitialize.SeedIdentityForEF(context);

            base.Seed(context);
        }

        //Create User=Admin@Admin.com with password=P@ssword in the Admin role
        public static void InitializeIdentityForEF(ApplicationDbContext db)
        {
            //original instantiation of the objects

            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();

            //var userManager = new UserManager<ApplicationUser,string>(new
            //UserStore<ApplicationUser, ApplicationRole, string,
            //                                        ApplicationUserLogin, ApplicationUserRole,
            //                                        ApplicationUserClaim>(db));
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            const string userName = "SuperUser";

            const string email = "admin@example.com";
            const string password = "P@ssword";
            const string roleName = "Admin";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new ApplicationRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            var user = userManager.FindByName(email);
            if (user == null)
            {
                user = new ApplicationUser { UserName = userName, Email = email };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }

            //added group manager 
            var groupManager = new ApplicationGroupManager();
            var newGroup = new ApplicationGroup("SuperAdmins", "Full Access to All");

            groupManager.CreateGroup(newGroup);
            groupManager.SetUserGroups(user.Id, new int[] { newGroup.Id });
            groupManager.SetGroupRoles(newGroup.Id, new string[] { role.Name });
        }
    }

}
