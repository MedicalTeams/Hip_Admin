using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.Models
{

    public class RevisitModel
    {
        [Display(Name = "Revisit Id")]
        public string RevisitId { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Sort Order")]
        public string SortOrder { get; set; }
        [Display(Name = "Indicator")]
        public string Indicator { get; set; }
        public string CreateDate { get; set; }
       
        public string CreatedBy { get; set; }
        [Display(Name = "Update Date")]
        public string UpdateDate { get; set; }
        [Display(Name = "Updated By")]
        public string UpdatedBy { get; set; }
    }
}