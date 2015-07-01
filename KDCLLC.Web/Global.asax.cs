using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using KDCLLC.Web.Controllers;
using KDCLLC.Web.DependencyResolution;
using KDCLLC.Web.Interfaces.Services;
using ChameleonForms;
using ChameleonForms.ModelBinders;
using StructureMap;

namespace KDCLLC.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly ILogService log = StructuremapMvc.StructureMapDependencyScope.Container.GetInstance<ILogService>() as ILogService;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ScriptBundleConfig.RegisterBundles(BundleTable.Bundles);

            StyleBundleConfig.RegisterBundles(BundleTable.Bundles);

            //allows for labels to be readable without the need to provide display mode
            HumanizedLabels.Register();

            //register Chameleon Date time binder
            //System.Web.Mvc.ModelBinders.Binders.Add(typeof(DateTime?), new DateTimeModelBinder());
        
        }

        
        /// <summary>
        /// Global Error Handling in case there is un-handle exception
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            if (exception == null) return;
           
            Server.ClearError();
           
            var routeData = new RouteData();
            routeData.Values.Add("controller", "Error");


            //--log the errors
            log.Fatal("Global Exception: {0}", exception);

            if (null != Context && null != Context.AllErrors)
                System.Diagnostics.Debug.WriteLine(Context.AllErrors.Length);

           
            routeData.Values.Add("action", "InternalServerError");
            routeData.Values.Add("statusCode", 500);

            if (exception.GetType() == typeof(HttpException))
            {
                Response.StatusCode = ((HttpException)exception).GetHttpCode();
                switch (Response.StatusCode)
                {
                    case 404:
                        routeData.Values["action"] = "NotFound";
                        routeData.Values["statusCode"] = Response.StatusCode;
                        break;
                }
            }
            //while in debug mode the entire error dump is visible to the user once it is switched to release it is no longer displayed
#if !DEBUG
            Response.ClearContent();
#endif
            IController controller = new ErrorController(this.log);
            controller.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
            Response.End();
        }
    }
}
