using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HealthInformationProgram.Data;
using HealthInformationProgram.SessionObject;
using HealthInformationProgram.Models.ViewModels;
using HealthInformationProgram.Models.ViewModels.Common;

namespace HealthInformationProgram.Controllers
{
    public class VisitManagementController : Controller
    {
        // GET: VisitManagement
        public ActionResult Index()
        {
            return View(SessionData.Current.VisitManagementViewModel);
        }

        [HttpPost]
        public ActionResult Index(VisitManagementViewModel visitManagementViewModel, string operation)
        {
            if(operation == "FindVisit")
            {
                SessionData.Current.VisitManagementViewModel.ModelState = HIPViewModelStates.FindVisit;
                SessionData.Current.VisitManagementViewModel.VisitIdSearchStringFilter = visitManagementViewModel.VisitIdSearchStringFilter;

                if (ModelState.IsValid)
                {
                    SessionData.Current.VisitManagementViewModel.FindVisitByVisitId();
                }

            }
            if (operation == "AddNewVisit")
            {
                SessionData.Current.VisitManagementViewModel.SetupAddNewOfficeVisit();
            }

            return View(SessionData.Current.VisitManagementViewModel);
        }
    }
}