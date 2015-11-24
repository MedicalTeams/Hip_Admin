using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.Models
{
    public class FacilityModel:BaseModel
    {
        public string FacilityId { get; set; }
        public string HealthCareFacility { get; set; }
        public string HealthCareFacilityLevel { get; set; }
        public string HealthCoordinator { get; set; }
        public string Settlement { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string OrganizationId { get; set; }
        public string FacilityStatus { get; set; }
        public string FacilityStartEffectiveDate { get; set; }
        public string FacilityEndEffectiveDate { get; set; }
        public string SortOrder { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}