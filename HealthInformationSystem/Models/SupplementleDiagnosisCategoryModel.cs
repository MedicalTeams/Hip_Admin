using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.Models
{
    public class SupplementleDiagnosisCategoryModel:BaseModel
    {
        public string SupplementleDiagnosisCategoryId { get; set; }
        public string SupplementleDiagnosisCategoryType { get; set; }
        public string SupplementleDiagnosisCategoryStartEffectiveDate { get; set; }
        public string SupplementleDiagnosisCategoryEndEffectiveDate { get; set; }


    }
}