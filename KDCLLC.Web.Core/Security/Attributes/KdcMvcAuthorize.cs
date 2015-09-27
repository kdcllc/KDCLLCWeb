using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcSiteMapProvider.Collections.Specialized;


namespace KDCLLC.Web.Core.Security.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    public class KDCMvcAuthorize : AuthorizeAttribute
    {
        private bool _authenticated = false;
        private bool _authorized = false;

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);

            if ((_authenticated && !_authorized) || (filterContext.Result is HttpUnauthorizedResult))
            {
                filterContext.Result = new RedirectResult("~/Error/UnAuthorized"); //new HttpUnauthorizedResult(); ;
            }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            if (!httpContext.User.Identity.IsAuthenticated) return false;

            var roles = GetAuthorizedRoles();

            var provider = new WindowsTokenRoleProvider();

            if (roles.Any(role => provider.IsUserInRole(httpContext.User.Identity.Name, role)))
            {
                return true;
            }

            return base.AuthorizeCore(httpContext);

        }

        //TODO: and error and other logging
        private IEnumerable<string> GetAuthorizedRoles()
        {
            var groups = this.Roles.Split(',');

            List<string> roles = new List<string>();

            var allRoles = (NameValueCollection)ConfigurationManager.GetSection("roles");

            if (allRoles != null)
            {
                foreach (var groupKey in groups)
                {
                    var result = allRoles[groupKey];

                    if (result != null)
                    {
                        var rolesAd = allRoles[groupKey].Split(',');
                        foreach (var item in rolesAd)
                        {
                            roles.Add(item.Trim());
                        }

                    }

                }

                return roles;

            }

            else
            {
                Trace.TraceError("Missing AD groups in Web.config for Roles {0}", Roles);
                return new[] { "" };
            }


        }
    }
}
