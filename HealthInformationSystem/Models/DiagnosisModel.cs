﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.Models
{
    public class DiagnosisModel : BaseModel
    {
        [Display(Name = "Diagnosis Id")]
        [ScaffoldColumn(false)]
        public string DiagnosisId { get; set; }
        
        [Display(Name = "Diagnosis")]
        [Required(ErrorMessage = "Diagnosis Description Required")]
        public string DiagnosisDescription { get; set; }
        
        [Display(Name = "Diagnosis Abbreviation")]
        public string DiagnosisAbbreviation { get; set; }
        
        [Display(Name = "Status")]
        [Required(ErrorMessage="Status is Required")]
        public string DiagnosisStatus { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage="Effective Start Required")]
        public string DiagnosisEffectiveStartDate { get; set; }
        
        [Display(Name = "End Date")]
        [Required(ErrorMessage = "Effective End Required")]
        public string DiagnosisEffectiveEndDate { get; set; }
        
        [Display(Name = "Icd")]
        public string IcdCode { get; set; }
        
        [Display(Name = "Display order")]
        public string SortOrder { get; set; }

    }
}