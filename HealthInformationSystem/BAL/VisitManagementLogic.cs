using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HealthInformationProgram.CustomExtensions;
using HealthInformationProgram.Models;
using HealthInformationProgram.Data;

namespace HealthInformationProgram.BAL
{
    public class VisitManagementLogic
    {
        public OfficeVisitModel FindVisitByVisitId(string visitId)
        {
            OfficeVisitModel officeVisitModel = null;

            visitId = visitId.MakeDBFriendly();
            decimal decimalVisitId = 0;
            if (decimal.TryParse(visitId, out decimalVisitId))
            {
                OfficeVisitData officeVisitData = new OfficeVisitData();
                officeVisitModel = officeVisitData.GetVisit(decimalVisitId);
            }

            return officeVisitModel;
        }
    }
}