using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.Models
{
    public class SupplementalDiagnosisModel:BaseModel
    {
        public string SupplementleDiagnosisId { get; set; }
        public string SupplementleDiagnosisDescription { get; set; }
        public string DiagnosisId { get; set; }
        public string SortOrder { get; set; }
        public string SupplementleDiagnosisStartEffectiveDate { get; set; }
        public string SupplementleDiagnosisEndEffecgtiveDate { get; set; }

    }
}