using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HealthInformationProgram.Models.ViewModels;

namespace HealthInformationProgram.SessionObject
{
    public partial class SessionData
    {
        private VisitManagementViewModel _visitManagementViewModel = new VisitManagementViewModel();
        public VisitManagementViewModel VisitManagementViewModel
        {
            get
            {
                return _visitManagementViewModel;
            }

            set
            {
                _visitManagementViewModel = value;
            }
        }
    }
}