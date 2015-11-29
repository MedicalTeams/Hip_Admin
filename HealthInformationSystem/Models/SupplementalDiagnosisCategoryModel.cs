using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.Models
{
    public class SupplementalDiagnosisCategoryModel:BaseModel
    {
        public string SupplementalDiagnosisCategoryId { get; set; }
        public string SupplementalDiagnosisCategoryType { get; set; }
        public string SortOrder { get; set; }
        public string Status { get; set; }
        public string SupplementalDiagnosisCategoryEffectiveStartDate { get; set; }
        public string SupplementalDiagnosisCategoryEffectiveEndDate { get; set; }


    }
}