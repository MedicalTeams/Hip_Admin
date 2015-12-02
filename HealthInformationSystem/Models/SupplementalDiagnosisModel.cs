using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.Models
{
    public class SupplementalDiagnosisModel:BaseModel
    {
        public string SupplementalDiagnosisId { get; set; }
        public string SupplementalDiagnosisDescription { get; set; }
        public string DiagnosisId { get; set; }
        public string Diagnosis { get; set; }
        public string SortOrder { get; set; }
        public string Status { get; set; }
        public string SupplementalDiagnosisEffectiveStartDate { get; set; }
        public string SupplementalDiagnosisEffectiveEndDate { get; set; }

    }
}