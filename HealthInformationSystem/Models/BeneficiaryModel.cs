using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.Models
{
    public class BeneficiaryModel:BaseModel
    {
        public string BeneficiaryId { get; set; }
        public string BeneficiaryType { get; set; }
        public string SortOrder { get; set; }

    }
}