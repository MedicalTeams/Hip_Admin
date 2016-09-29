using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.Models.ViewModels
{
    public enum HIPViewModelStates
    {
        Initial, EditUser, AddNewUser
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
    }
}