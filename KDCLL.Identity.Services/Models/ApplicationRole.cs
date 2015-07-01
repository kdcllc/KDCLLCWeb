using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KDCLLC.Identity.Services.Models
{
    // Must be expressed in terms of our custom UserRole:
    public class ApplicationRole : IdentityRole<int, ApplicationUserRole>
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string name)
        {
            base.Name = name;
        }

        public string Description { get; set; }
        
    }

   
}
