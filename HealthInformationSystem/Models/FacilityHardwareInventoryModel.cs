using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.Models
{
    public class FacilityHardwareInventoryModel : BaseModel
    {
        [Display(Name = "Hardware Id")]
        public string FacilityHardwareInventoryId { get; set; }
        [Display(Name = "Facility Id")]
        [Required]
        public string FacilityId { get; set; }
        [Display(Name = "Facility")]
        public string Facility { get; set; }
        [Display(Name = "Description")]
        [Required]
        public string ItemDescription { get; set; }
        [Display(Name = "Mac Address")]
        public string MacAddress { get; set; }
        [Display(Name = "Application Version")]
        public string ApplicationVersion { get; set; }
        [Display(Name = "Status")]
        public string HardwareStatus { get; set; }
    }
}