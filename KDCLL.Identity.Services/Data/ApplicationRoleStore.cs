﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDCLLC.Identity.Services.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KDCLLC.Identity.Services.Data
{
    public class ApplicationRoleStore  : RoleStore<ApplicationRole, int, ApplicationUserRole>,
                                                    IQueryableRoleStore<ApplicationRole, int>,
                                                    IRoleStore<ApplicationRole, int>, IDisposable
    {
        public ApplicationRoleStore()
            : base(new IdentityDbContext())
        {
            base.DisposeContext = true;
        }

        public ApplicationRoleStore(DbContext context)
            : base(context)
        {
        }
    }
}
