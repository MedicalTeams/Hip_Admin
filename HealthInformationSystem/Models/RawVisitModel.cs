using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HealthInformationProgram.Models
{
    public class RawVisitModel:BaseModel
    {
        [Display(Name="Visit Id")]
        [Required]
        public string VisitId { get; set; }
        [Display(Name="Visit Json")]
        [Required]
        public string VisitJson { get; set; }
        [Display(Name = "Visit Status")]
        [Required]
        public string VisitStatus { get; set; }
        [Display(Name = "Error Code")]
        public string ErrorCode { get; set; }
        [Display(Name = "Error Description")]
        public string ErrorDescription { get; set; }
    }
}