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
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
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
                ModelState.Clear();
            }
            if (operation == "FindVisit")
            {
                SessionData.Current.VisitManagementViewModel.SetupFindVisit(visitManagementViewModel.VisitIdSearchStringFilter);
                ModelState.Clear();
            }
            if (operation == "AddNewOfficeVisit")
            {
                SessionData.Current.VisitManagementViewModel.SetupAddNewOfficeVisit();
                ModelState.Clear();
            }
            if (operation == "EditOfficeVisit")
            {
                SessionData.Current.VisitManagementViewModel.SetupEditOfficeVisit();
                ModelState.Clear();
            }
            if (operation == "CancelSaveEditOfficeVisit")
            {
                SessionData.Current.VisitManagementViewModel.SetupCancelSaveEditOfficeVisit();
            }
            if (operation == "SaveEditOfficeVisit")
            {
                if (TryValidateModel(visitManagementViewModel.AddNewEditOfficeVisit))
                {
                    SessionData.Current.VisitManagementViewModel.SaveOfficeVisit(visitManagementViewModel.AddNewEditOfficeVisit);
                }
                else
                {
                    var errors = ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .Select(x => new { x.Key, x.Value.Errors })
                        .ToArray();
                }
            }
            if (operation == "AddNewOfficeVisitDiagnosis")
            {
                SessionData.Current.VisitManagementViewModel.SetupAddNewOfficeVisitDiagnosis();
                ModelState.Clear();
            }
            if (operation.Contains("EditOfficeVisitDiagnosis_"))
            {
                string selectedOfficeVisitDiagnosisId = string.Format(operation.Replace("EditOfficeVisitDiagnosis_", ""));
                SessionData.Current.VisitManagementViewModel.SetupEditOfficeVisitDiagnosis(selectedOfficeVisitDiagnosisId);
                ModelState.Clear();
            }
            if (operation == "CancelSaveEditOfficeVisitDiagnosis")
            {
                SessionData.Current.VisitManagementViewModel.SetupCancelSaveEditOfficeVisitDiagnosis();
                ModelState.Clear();
            }
            if (operation == "SaveEditOfficeVisitDiagnosis")
            {
                if (ModelState.IsValid)
                {
                    SessionData.Current.VisitManagementViewModel.SaveOfficeVisitDiagnosis(visitManagementViewModel.AddNewEditOfficeVisitDiagnosis);
                }
            }
            if(operation == "OnDiagnosisChange")
            {
                SessionData.Current.VisitManagementViewModel.AddNewEditOfficeVisitDiagnosis = visitManagementViewModel.AddNewEditOfficeVisitDiagnosis;
                ModelState.Clear();
            }

            return View(SessionData.Current.VisitManagementViewModel);
        }

        [HttpPost]
        [Route("VisitManagement/TestMethod/")]
        public ActionResult TestMethod(VisitManagementViewModel visitManagementViewModel, string operation)
        {
            return View(visitManagementViewModel);
        }
    }
}