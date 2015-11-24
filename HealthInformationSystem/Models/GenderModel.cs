using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.Models
{
    public class GenderModel:BaseModel
    {
        public string GenderId { get; set; }
        public string GenderDescription { get; set; }
        public string GenderCode { get; set; }
        public string SortOrder { get; set; }
    }
}