using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.Models.ViewModels.Common
{
    public enum HIPViewModelStates
    {
        Initial, EditUser, AddNewUser, FindVisit, EditOfficeVisit, AddNewOfficeVisit, EditOfficeVisitDiagnosis, AddNewOfficeVisitDiagnosis
    };

    public enum HIPUserActionResult
    {
        None, VisitFound, VisitNotFound, OfficeVisitSaved, AddedNewOfficeVisit
    };

    public class HIPAdminCommonViewModel
    {
        protected HIPViewModelStates _modelState = HIPViewModelStates.Initial;
        public HIPViewModelStates ModelState
        {
            get
            {
                return _modelState;
            }
            set
            {
                _modelState = value;
            }
        }

        public void ResetModelState()
        {
            _modelState = HIPViewModelStates.Initial;
        }

        protected HIPUserActionResult _userActionResponse = HIPUserActionResult.None;
        public HIPUserActionResult UserActionResponse
        {
            get
            {
                return _userActionResponse;
            }
            set
            {
                _userActionResponse = value;
            }
        }
        public void ResetUserActionResponse()
        {
            _userActionResponse = HIPUserActionResult.None;
        }

        public void ResetModelStates()
        {
            ResetModelState();
            ResetUserActionResponse();            
        }
    }
}