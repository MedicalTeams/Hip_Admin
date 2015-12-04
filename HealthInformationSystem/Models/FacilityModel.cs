using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.Models
{
    public class FacilityModel : BaseModel
    {
        public string FacilityId { get; set; }
        [Display(Name = "Facility Name")]
        [Required]
        public string HealthCareFacility { get; set; }
        [Display(Name = "Facility Level")]
        [Required]
        public string HealthCareFacilityLevel { get; set; }
        [Display(Name = "Facility Coordinator")]
        [Required]
        public string HealthCoordinator { get; set; }
        [Display(Name = "Settlement")]
        [Required]
        public string Settlement { get; set; }
        [Display(Name = "Country")]
        [Required]
        public string Country { get; set; }
        [Display(Name = "Region")]
        [Required]
        public string Region { get; set; }
        [Display(Name = "Organization Id")]
        [Required]
        public string OrganizationId { get; set; }
        [Display(Name = "Organization Name")]
        public string OrganizationName { get; set; }
        [Display(Name = "Facility Status")]
        [Required]
        public string FacilityStatus { get; set; }
        [Display(Name = "Start Date")]
        [Required]
        public string FacilityStartEffectiveDate { get; set; }
        [Display(Name = "End Date")]
        [Required]
        public string FacilityEndEffectiveDate { get; set; }
        [Display(Name = "Sort Order")]
        public string SortOrder { get; set; }
        [Display(Name = "Longitude")]
        public string Longitude { get; set; }
        [Display(Name = "Latitude")]
        public string Latitude { get; set; }
    }
}