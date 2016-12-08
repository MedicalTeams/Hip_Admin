using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HealthInformationProgram.Models
{
    public class OfficeVisitDiagnosisModel : BaseModel
    {
        public decimal OfficeVisitDiagnosisId { get; set; }
        public decimal OfficeVisitId { get; set; }

        [Required]
        public decimal? DiagnosisId { get; set; }        
        [DisplayName("Diagnosis")]
        public string DiganosisName { get; set; }

        public decimal? SupplementalDiagnosisId { get; set; }
        [DisplayName("Supplemental Diagnosis")]
        public string SupplementalDiagnosisName { get; set; }

        public decimal? SupplementalDiagnosisCategoryId { get; set; }

        [DisplayName("Injury Location")]
        public string SupplementalDiagnosisCategoryName { get; set; }

        [DisplayName("Other Diagnosis Description")]
        public string OtherDiagnosisDescription { get; set; }

        [DisplayName("Other Supplemental Diagnosis Description")]
        public string OtherSupplementalDiagnosisDescription { get; set; }

        [DisplayName("Contacts Treated")]
        public Nullable<decimal> ContactTreatmentCount { get; set; }
    }
}