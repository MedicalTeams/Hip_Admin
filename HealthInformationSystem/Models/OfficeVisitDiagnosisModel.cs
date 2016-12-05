using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.Models
{
    public class OfficeVisitDiagnosisModel : BaseModel
    {
        public decimal OfficeVisitDiagnosisId { get; set; }
        public decimal OfficeVisitId { get; set; }
        public decimal DiagnosisId { get; set; }
        public string DiganosisName { get; set; }
        public decimal SupplementalDiagnosisId { get; set; }
        public string SupplementalDiagnosisName { get; set; }
        public decimal SupplementalDiagnosisCategoryId { get; set; }
        public string SupplementalDiagnosisCategoryName { get; set; }
        public string OtherDiagnosisDescription { get; set; }
        public string OtherSupplementalDiagnosisDescription { get; set; }
        public Nullable<decimal> ContactTreatmentCount { get; set; }


    }
}