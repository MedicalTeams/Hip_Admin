using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.Models
{
    public class SupplementalDiagnosisModel:BaseModel
    {
        public string SupplementalDiagnosisId { get; set; }
       [Display(Name="Description")]
        [Required]
        public string SupplementalDiagnosisDescription { get; set; }
       [Display(Name = "Diagnosis Id")]
       [Required]
        public string DiagnosisId { get; set; }
       [Display(Name = "Diagnosis Description")]
      
        public string Diagnosis { get; set; }
       [Display(Name = "Sort Order")]
               public string SortOrder { get; set; }
       [Display(Name = "Status")]
       [Required]
        public string Status { get; set; }
       [Display(Name = "Start Date")]
       [Required(ErrorMessage = "Effective Start Required")]
        public string SupplementalDiagnosisEffectiveStartDate { get; set; }
       [Display(Name = "End Date")]
       [Required(ErrorMessage = "Effective End Required")]
        public string SupplementalDiagnosisEffectiveEndDate { get; set; }

    }
}