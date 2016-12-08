using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HealthInformationProgram.Data;
using HealthInformationProgram.SessionObject;
using HealthInformationProgram.Models.ViewModels;
using HealthInformationProgram.Models.ViewModels.Common;
using HealthInformationProgram.CustomExtensions;

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
                if (ModelState.IsValid)
                {
                    SessionData.Current.VisitManagementViewModel.SaveOfficeVisit(visitManagementViewModel.AddNewEditOfficeVisit);
                }
                else
                {
                    SessionData.Current.VisitManagementViewModel.AddNewEditOfficeVisit = visitManagementViewModel.AddNewEditOfficeVisit;

                    if (SessionData.Current.VisitManagementViewModel.IsValidModelDespiteWhatItIsSaying(ViewData.ModelState.Values))
                    {
                        SessionData.Current.VisitManagementViewModel.SaveOfficeVisit(visitManagementViewModel.AddNewEditOfficeVisit);
                    }
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
                else
                {
                    SessionData.Current.VisitManagementViewModel.AddNewEditOfficeVisitDiagnosis = visitManagementViewModel.AddNewEditOfficeVisitDiagnosis;

                    if (SessionData.Current.VisitManagementViewModel.IsValidModelDespiteWhatItIsSaying(ViewData.ModelState.Values))
                    {
                        SessionData.Current.VisitManagementViewModel.SaveOfficeVisitDiagnosis(visitManagementViewModel.AddNewEditOfficeVisitDiagnosis);
                    }
                }
            }
            if(operation == "OnDiagnosisChange")
            {
                SessionData.Current.VisitManagementViewModel.AddNewEditOfficeVisitDiagnosis = visitManagementViewModel.AddNewEditOfficeVisitDiagnosis;
                ModelState.Clear();
            }

            return View(SessionData.Current.VisitManagementViewModel);
        }
    }
}