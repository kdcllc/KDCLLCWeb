using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KDCLLC.Web.Core.Filters;
using KDCLLC.Web.Core.Security.Attributes;
using KDCLLC.Web.Interfaces.Services;

namespace KDCLLC.Web.Controllers
{
    public partial class HomeController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly ILogService _logService;

        /// <summary>
        /// Injection of the service
        /// </summary>
        /// <param name="messageService"></param>
        public HomeController(IMessageService messageService, ILogService logService)
        {
            this._messageService = messageService;
            this._logService = logService;

        }

        public virtual ActionResult Index()
        {
            _logService.Info("Home/Index view triggered");

            return View();
            
        }

        //[MvcHandleError]
        public virtual ActionResult About()
        {
            _logService.Info("Home/About view triggered");

            ViewBag.Message = _messageService.GetMessage(); //"Your application description page.";

          

            return View();

           
        }

        //[KDCMvcAuthorize(Roles = Roles.ViewContact)]
        public virtual ActionResult Contact()
        {
            _logService.Info("Home/Contact view triggered");

            ViewBag.Message = "Your contact page.";

            return View();
        }


        public virtual ActionResult RaiseException()
        {
            throw new ApplicationException("Not working here....");
        }

        public virtual ActionResult SignUpExample()
        {
            return View();
        }

        public virtual ActionResult LearnMore()
        {
            return View();
        }
    }
}