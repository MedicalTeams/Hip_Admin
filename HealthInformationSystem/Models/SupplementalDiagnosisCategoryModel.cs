using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.Models
{
    public class SupplementalDiagnosisCategoryModel:BaseModel
    {
        public string SupplementalDiagnosisCategoryId { get; set; }
        [Display(Name="Category")]
        [Required]
        public string SupplementalDiagnosisCategoryType { get; set; }
        [Display(Name = "Sort Order")]
        [Required]
        public string SortOrder { get; set; }
        [Display(Name = "Status")]
        [Required]
        public string Status { get; set; }
         [Display(Name = "Start Date")]
         [Required]
        public string SupplementalDiagnosisCategoryEffectiveStartDate { get; set; }
        [Display(Name = "End Date")]
        [Required]
        public string SupplementalDiagnosisCategoryEffectiveEndDate { get; set; }


    }
}