using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.Models
{
    public class FacilityHardwareInventoryModel:BaseModel
    {
        public string FacilityHardwareInventoryId { get; set; }
        public string FacilityId { get; set; }
        public string Facility { get; set; }
        public string ItemDescription { get; set; }
        public string MacAddress { get; set; }
        public string ApplicationVersion { get; set; }
        public string HardwareStatus { get; set; }
    }
}