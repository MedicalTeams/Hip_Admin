using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.Models
{
    public class DiagnosisModel:BaseModel
    {
        public string DiagnosisId { get; set; }
        public string DiagnosisDescription { get; set; }
        public string DiagnosisAbbreviation { get; set; }
        public string DiagnosisStatus { get; set; }
        public string DiagnosisEffectiveStartDate { get; set; }
        public string DiagnosisEffectiveEndDate { get; set; }
        public string IcdCode { get; set; }
        public string SortOrder { get; set; }
        
    }
}