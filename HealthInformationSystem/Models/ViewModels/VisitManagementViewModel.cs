using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using HealthInformationProgram.Data;
using HealthInformationProgram.Models.ViewModels.Common;
using HealthInformationProgram.BAL;

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

        private OfficeVisitModel _addNewEditOfficeVisit = null;
        public OfficeVisitModel AddNewEditOfficeVisit
        {
            get
            {
                return _addNewEditOfficeVisit;
            }
            set
            {
                _addNewEditOfficeVisit = value;
            }
        }

        public void FindVisitByVisitId()
        {
            _visitSearchResult = _visitManagementLogic.FindVisitByVisitId(_visitIdSearchStringFilter);

            if(_visitSearchResult != null)
            {
                UserActionResponse = HIPUserActionResult.VisitFound;
            }
            else
            {
                UserActionResponse = HIPUserActionResult.VisitNotFound;
            }
        }

        public void SetupAddNewOfficeVisit()
        {
            _modelState = HIPViewModelStates.AddNewOfficeVisit;
            _addNewEditOfficeVisit = _visitSearchResult;
        }
    }
}