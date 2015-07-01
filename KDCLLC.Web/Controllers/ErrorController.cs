using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KDCLLC.Web.Interfaces.Services;

namespace KDCLLC.Web.Controllers
{
    public partial class ErrorController : Controller
    {
        private readonly ILogService _logService;

        public ErrorController(ILogService logService)
        {
            this._logService = logService;
        }
        public virtual ActionResult NotFound()
        {
            _logService.Info("Page not Found: {0} ",HttpContext.AllErrors);
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return View();
        }

        public virtual ActionResult InternalServerError()
        {
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return View();
        }

        public virtual ActionResult UnAuthorized()
        {
            _logService.Error("The Following User Doesn't have access: {0}", User.Identity.Name);
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
    }
}