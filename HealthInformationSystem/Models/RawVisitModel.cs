using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.Models
{
    public class RawVisitModel:BaseModel
    {
        public string VisitId { get; set; }
        public string VisitJson { get; set; }
        public string VisitStatus { get; set; }
        public string ErrorCode { get; set; }

    }
}