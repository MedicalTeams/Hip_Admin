using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthInformationProgram.Controllers
{
    public class ClientManagementController : Controller
    {
        // GET: ClientManagement
        public ActionResult Index()
        {
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Message = "Client Management";
            //  var sysInfo = new FacilityHardwareData();
            //  var app = sysInfo.GetCurrentApplicationVersion();
            //ViewBag.Version
            // TempData["Version"] = String.Format("Current application version is {0} released on {1}", app.ItemVersion, app.ReleaseDate); ;
            return View();
        }
    }
}