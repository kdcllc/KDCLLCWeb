using System;
using System.Data.Entity;
using KDCLLC.Identity.Services.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KDCLLC.Identity.Services.Data
{
    public class ApplicationUserStore : UserStore<ApplicationUser, ApplicationRole, int,
                                                    ApplicationUserLogin, ApplicationUserRole,
                                                    ApplicationUserClaim>, IUserStore<ApplicationUser, int>, IDisposable
    {
        public ApplicationUserStore()
            : this(new IdentityDbContext())
        {
            base.DisposeContext = true;
        }

        public ApplicationUserStore(DbContext context)
            : base(context)
        {
        }
    }
}
