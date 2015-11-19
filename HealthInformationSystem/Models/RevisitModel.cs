using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.Models
{
    public class RevisitModel
    {
        public decimal RevisitId { get; set; }
        public string Description { get; set; }
        public decimal SortOrder { get; set; }
        public string Indicator { get; set; }
        public DateTime CreateDate { get;  set; }
        public DateTime UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}