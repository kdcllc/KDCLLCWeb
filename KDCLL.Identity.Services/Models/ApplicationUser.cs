using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using KDCLLC.Identity.Services.Managers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KDCLLC.Identity.Services.Models
{

    /// <summary>
    /// converted from generic public class ApplicationUser : IdentityUser to specific
    /// </summary>
    public class ApplicationUser : IdentityUser<int, ApplicationUserLogin,
                                   ApplicationUserRole, ApplicationUserClaim>
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string DisplayName
        {
            get { return FirstName + " " + LastName; }
        }

        public string ProfilePicUrl { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        // Use a sensible display name for views:
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        // Concatenate the address info for display in tables and such:
        public string DisplayAddress
        {
            get
            {
                string dspAddress = string.IsNullOrWhiteSpace(this.Address) ? "" : this.Address;
                string dspCity = string.IsNullOrWhiteSpace(this.City) ? "" : this.City;
                string dspState = string.IsNullOrWhiteSpace(this.State) ? "" : this.State;
                string dspPostalCode = string.IsNullOrWhiteSpace(this.PostalCode) ? "" : this.PostalCode;
                return string.Format("{0} {1} {2} {3}", dspAddress, dspCity, dspState, dspPostalCode);
            }
        }

        public ApplicationUser()
        {
            //this.Id = Guid.NewGuid().ToString();

            // Add any custom User properties/code here
           
        }
        
        public async Task<ClaimsIdentity>
            GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            var userIdentity = await manager
                .CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
