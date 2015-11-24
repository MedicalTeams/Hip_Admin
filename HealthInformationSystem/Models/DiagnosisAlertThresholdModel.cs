using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.Models
{
    public class DiagnosisAlertThresholdModel:BaseModel
    {
        public string DiagnosisAlertThresholdId { get; set; }
        public string DiagnosisId { get; set; }
        public string CaseCount { get; set; }
        public string BaselineMultipler { get; set; }

    }
}