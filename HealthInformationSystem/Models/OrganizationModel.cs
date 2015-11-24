using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.Models
{
    public class OrganizationModel:BaseModel
    {
        public string OrganizationId { get; set; }
        public string Organization { get; set; }
        public string SortOrder { get; set; }
        public string OrganizationStatus { get; set; }
        public string StartEffectiveDate { get; set; }
        public string EndEffectiveDate { get; set; }
      

    }
}