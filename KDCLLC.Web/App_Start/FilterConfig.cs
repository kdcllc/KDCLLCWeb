using System.Web.Mvc;
using KDCLLC.Web.Core.Filters;
using KDCLLC.Web.Core.Security.Attributes;

namespace KDCLLC.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new MvcHandleErrorAttribute());
            //filters.Add(new KDCMvcAuthorize());
        }
    }
}
