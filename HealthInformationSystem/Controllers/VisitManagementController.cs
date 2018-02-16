using System.Web.Mvc;
using HealthInformationProgram.Models.ViewModels;

namespace HealthInformationProgram.Controllers
{

    public class VisitManagementController : Controller
    {
        private VisitManagementViewModel VisitManagementViewModel
        {
            get {
                var viewModel = Session["VisitManagementViewModel"] as VisitManagementViewModel;

                if (viewModel == null)
                {
                    viewModel = new VisitManagementViewModel();
                    Session["VisitManagementViewModel"] = viewModel;
                }

                return viewModel;
            }
        }

        // GET: VisitManagement
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Index()
        {
            return View(VisitManagementViewModel);
        }

        [HttpPost]
        public ActionResult Index(VisitManagementViewModel visitManagementViewModel, string operation)
        {
            if (operation == "NewOfficeVisitSearch")
            {
                VisitManagementViewModel.SetupNewOfficeVisitSearch();
                ModelState.Clear();
            }
            if (operation == "FindVisit")
            {
                VisitManagementViewModel.SetupFindVisit(visitManagementViewModel.VisitIdSearchStringFilter);
                ModelState.Clear();
            }
            if (operation == "AddNewOfficeVisit")
            {
                VisitManagementViewModel.SetupAddNewOfficeVisit();
                ModelState.Clear();
            }
            if (operation == "EditOfficeVisit")
            {
                VisitManagementViewModel.SetupEditOfficeVisit();
                ModelState.Clear();
            }
            if (operation == "CancelSaveEditOfficeVisit")
            {
                VisitManagementViewModel.SetupCancelSaveEditOfficeVisit();
            }
            if (operation == "SaveEditOfficeVisit")
            {
                if (ModelState.IsValid)
                {
                    VisitManagementViewModel.SaveOfficeVisit(visitManagementViewModel.AddNewEditOfficeVisit);
                }
                else
                {
                    VisitManagementViewModel.AddNewEditOfficeVisit = visitManagementViewModel.AddNewEditOfficeVisit;

                    if (VisitManagementViewModel.IsValidModelDespiteWhatItIsSaying(ViewData.ModelState.Values))
                    {
                        VisitManagementViewModel.SaveOfficeVisit(visitManagementViewModel.AddNewEditOfficeVisit);
                    }
                }
            }
            if (operation == "AddNewOfficeVisitDiagnosis")
            {
                VisitManagementViewModel.SetupAddNewOfficeVisitDiagnosis();
                ModelState.Clear();
            }
            if (operation.Contains("EditOfficeVisitDiagnosis_"))
            {
                string selectedOfficeVisitDiagnosisId = string.Format(operation.Replace("EditOfficeVisitDiagnosis_", ""));
                VisitManagementViewModel.SetupEditOfficeVisitDiagnosis(selectedOfficeVisitDiagnosisId);
                ModelState.Clear();
            }
            if (operation == "CancelSaveEditOfficeVisitDiagnosis")
            {
                VisitManagementViewModel.SetupCancelSaveEditOfficeVisitDiagnosis();
                ModelState.Clear();
            }
            if (operation == "SaveEditOfficeVisitDiagnosis")
            {
                if (ModelState.IsValid)
                {
                    VisitManagementViewModel.SaveOfficeVisitDiagnosis(visitManagementViewModel.AddNewEditOfficeVisitDiagnosis);
                }
                else
                {
                    VisitManagementViewModel.AddNewEditOfficeVisitDiagnosis = visitManagementViewModel.AddNewEditOfficeVisitDiagnosis;

                    if (VisitManagementViewModel.IsValidModelDespiteWhatItIsSaying(ViewData.ModelState.Values))
                    {
                        VisitManagementViewModel.SaveOfficeVisitDiagnosis(visitManagementViewModel.AddNewEditOfficeVisitDiagnosis);
                    }
                }
            }
            if(operation == "OnDiagnosisChange")
            {
                VisitManagementViewModel.AddNewEditOfficeVisitDiagnosis = visitManagementViewModel.AddNewEditOfficeVisitDiagnosis;
                ModelState.Clear();
            }

            return View(VisitManagementViewModel);
        }
    }
}