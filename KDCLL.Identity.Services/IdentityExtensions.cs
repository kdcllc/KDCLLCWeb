using System.Threading.Tasks;
using KDCLLC.Identity.Services.Models;
using Microsoft.AspNet.Identity;

namespace KDCLLC.Identity.Services
{
    public static class IdentityExtensions
    {
        //http://anthonychu.ca/post/aspnet-identity-20---logging-in-with-email-or-username
        //public static async Task<ApplicationUser> FindByNameOrEmailAsync
        //    (this UserManager<ApplicationUser> userManager, string usernameOrEmail, string password)
        //{
        //    var username = usernameOrEmail;
        //    if (usernameOrEmail.Contains("@"))
        //    {
        //        var userForEmail = await userManager.FindByEmailAsync(usernameOrEmail);
        //        if (userForEmail != null)
        //        {
        //            username = userForEmail.UserName;
        //        }
        //    }
        //    return await userManager.FindAsync(username, password);
        //}
    }
}
