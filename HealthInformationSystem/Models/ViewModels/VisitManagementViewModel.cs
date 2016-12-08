using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using HealthInformationProgram.Data;
using HealthInformationProgram.Models.ViewModels.Common;
using HealthInformationProgram.BAL;
using HealthInformationProgram.CustomExtensions;
using System.Web.Mvc;

namespace HealthInformationProgram.Models.ViewModels
{
    public class VisitManagementViewModel : HIPAdminCommonViewModel
    {
        private VisitManagementLogic _visitManagementLogic = new VisitManagementLogic();

        private string _visitIdSearchStringFilter = null;
        [DisplayName("Visit Id")]
        public string VisitIdSearchStringFilter
        {
            get
            {
                return _visitIdSearchStringFilter;
            }
            set
            {
                _visitIdSearchStringFilter = value;
            }
        }

        private OfficeVisitModel _visitSearchResult = null;
        public OfficeVisitModel VisitSearchResult
        {
            get
            {
                return _visitSearchResult;
            }
            set
            {
                _visitSearchResult = value;
            }
        }
        
        public OfficeVisitModel AddNewEditOfficeVisit
        {
            get
            {
                return _visitSearchResult;
            }
            set
            {
                _visitSearchResult = value;
            }
        }

        private OfficeVisitDiagnosisModel _addNewEditOfficeVisitDiagnosis = null;
        public OfficeVisitDiagnosisModel AddNewEditOfficeVisitDiagnosis
        {
            get
            {
                return _addNewEditOfficeVisitDiagnosis;
            }
            set
            {
                _addNewEditOfficeVisitDiagnosis = value;
            }
        }

        public void FindVisitByVisitId()
        {
            _visitSearchResult = _visitManagementLogic.FindVisitByVisitId(_visitIdSearchStringFilter);

            if (_visitSearchResult != null)
            {
                UserActionResponse = HIPUserActionResult.VisitFound;
            }
            else
            {
                UserActionResponse = HIPUserActionResult.VisitNotFound;
            }
        }

        public void SetupFindVisit(string visitIdSearchString)
        {
            _visitIdSearchStringFilter = visitIdSearchString;
            _modelState = HIPViewModelStates.FindVisit;
            FindVisitByVisitId();
        }

        public void SetupNewOfficeVisitSearch()
        {
            _modelState = HIPViewModelStates.Initial;
            _visitIdSearchStringFilter = string.Empty;
            _visitSearchResult = null;
        }

        public void SetupAddNewOfficeVisit()
        {
            _modelState = HIPViewModelStates.AddNewOfficeVisit;
            _userActionResponse = HIPUserActionResult.None;
            _visitSearchResult = new OfficeVisitModel();
        }

        public void SetupEditOfficeVisit()
        {
            _modelState = HIPViewModelStates.EditOfficeVisit;
        }

        public void SetupCancelSaveEditOfficeVisit()
        {
            if (_visitIdSearchStringFilter.IsNOTNullNorEmptyNorWhiteSpace())
            {
                SetupFindVisit(_visitIdSearchStringFilter);
            }
            else
            {
                ResetModelStates();
            }
        }

        public void SetupAddNewOfficeVisitDiagnosis()
        {
            _modelState = HIPViewModelStates.AddNewOfficeVisitDiagnosis;
            _userActionResponse = HIPUserActionResult.None;
            _addNewEditOfficeVisitDiagnosis = new OfficeVisitDiagnosisModel();
        }

        public void SetupEditOfficeVisitDiagnosis(string officeVisitDiagnosisId)
        {
            OfficeVisitDiagnosisModel officeVisitDiagnosisModelToEdit = null;

            decimal officeVisitDiagnosisIdAsDecimal = 0;
            if (decimal.TryParse(officeVisitDiagnosisId, out officeVisitDiagnosisIdAsDecimal))
            {
                _modelState = HIPViewModelStates.EditOfficeVisitDiagnosis;

                officeVisitDiagnosisModelToEdit = (from officevisitsearchresultdiagnosis in _visitSearchResult.OfficeVisitDiagnosis
                                                   where officevisitsearchresultdiagnosis.OfficeVisitDiagnosisId == officeVisitDiagnosisIdAsDecimal
                                                   select officevisitsearchresultdiagnosis).FirstOrDefault();

                if (officeVisitDiagnosisModelToEdit != null)
                {
                    _addNewEditOfficeVisitDiagnosis = officeVisitDiagnosisModelToEdit;
                    ModelState = HIPViewModelStates.EditOfficeVisitDiagnosis;
                }
            }
        }

        public void SetupCancelSaveEditOfficeVisitDiagnosis()
        {
            if (_visitIdSearchStringFilter.IsNOTNullNorEmptyNorWhiteSpace())
            {
                SetupFindVisit(_visitIdSearchStringFilter);
            }
            else
            {
                ResetModelStates();
            }
        }

        public List<SelectListItem> DiagnosisAsSelectListItems()
        {
            return _visitManagementLogic.DiagnosisAsSelectListItems();
        }

        public List<SelectListItem> SupplimentalDiagnosisAsSelectListItems(decimal? DiagnosisId)
        {
            if(DiagnosisId == null)
            {
                DiagnosisId = 0;
            }

            return _visitManagementLogic.SupplimentalDiagnosisAsSelectListItems((decimal)DiagnosisId);
        }

        public List<SelectListItem> GendersAsSelectListItems()
        {
            return _visitManagementLogic.GendersAsSelectListItems();
        }

        public List<SelectListItem> RefugeeStatusAsSelectListItems()
        {
            return _visitManagementLogic.RefugeeStatusAsSelectListItems();
        }

        public List<SelectListItem> NewOrRevisitStatusAsSelectListItems()
        {
            return _visitManagementLogic.NewOrRevisitStatusAsSelectListItems();
        }

        public List<SelectListItem> SettlementandHealthCentresAsSelectListItems()
        {
            return _visitManagementLogic.SettlementandHealthCentresAsSelectListItems();
        }

        public List<SelectListItem> SupplementalDiagnosisCategoryNamesAsSelectListItems()
        {
            return _visitManagementLogic.SupplementalDiagnosisCategoryNamesAsSelectListItems();
        }

        public void SaveOfficeVisit(OfficeVisitModel officeVisitModel)
        {
            _visitManagementLogic.SaveOfficeVisit(officeVisitModel);
        }

        public void SaveOfficeVisitDiagnosis(OfficeVisitDiagnosisModel officeVisitDiagnosisModel)
        {
            _visitManagementLogic.SaveOfficeVisitDiagnosis(officeVisitDiagnosisModel);
        }
    }
}