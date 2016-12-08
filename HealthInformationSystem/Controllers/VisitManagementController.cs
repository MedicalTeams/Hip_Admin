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
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
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

            if (operation == "NewOfficeVisitSearch")
            {
                SessionData.Current.VisitManagementViewModel.SetupNewOfficeVisitSearch();
            }
            if (operation == "FindVisit")
            {
                SessionData.Current.VisitManagementViewModel.SetupFindVisit(visitManagementViewModel.VisitIdSearchStringFilter);
            }
            if (operation == "AddNewOfficeVisit")
            {
                SessionData.Current.VisitManagementViewModel.SetupAddNewOfficeVisit();
            }
            if (operation == "EditOfficeVisit")
            {
                SessionData.Current.VisitManagementViewModel.SetupEditOfficeVisit();
            }
            if(operation == "CancelSaveEditOfficeVisit")
            {
                SessionData.Current.VisitManagementViewModel.SetupCancelSaveEditOfficeVisit();
            }
            if (operation == "SaveEditOfficeVisit")
            {
                if (ModelState.IsValid)
                {
                    SessionData.Current.VisitManagementViewModel.SaveOfficeVisit(visitManagementViewModel.AddNewEditOfficeVisit);
                }
            }
            if (operation == "AddNewOfficeVisitDiagnosis")
            {
                SessionData.Current.VisitManagementViewModel.SetupAddNewOfficeVisitDiagnosis();
            }
            if (operation.Contains("EditOfficeVisitDiagnosis_"))
            {
                string selectedOfficeVisitDiagnosisId = string.Format(operation.Replace("EditOfficeVisitDiagnosis_", ""));
                SessionData.Current.VisitManagementViewModel.SetupEditOfficeVisitDiagnosis(selectedOfficeVisitDiagnosisId);
            }
            if (operation == "CancelSaveEditOfficeVisitDiagnosis")
            {
                SessionData.Current.VisitManagementViewModel.SetupCancelSaveEditOfficeVisitDiagnosis();
            }
            if (operation == "SaveEditOfficeVisitDiagnosis")
            {
                if (ModelState.IsValid)
                {
                    SessionData.Current.VisitManagementViewModel.SaveOfficeVisitDiagnosis(visitManagementViewModel.AddNewEditOfficeVisitDiagnosis);
                }
            }

            return View(SessionData.Current.VisitManagementViewModel);
        }
    }
}