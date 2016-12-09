using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HealthInformationProgram.Models
{
    public class OfficeVisitModel : BaseModel
    {
        public OfficeVisitModel()
        {
            OfficeVisitDiagnosis = new List<OfficeVisitDiagnosisModel>();

        }

        [DisplayName("Settlement and Health Centre")]
        public string FacililtyName { get; set; }
        [Required]
        public decimal? FacilityId { get; set; }

        [DisplayName("Gender")]
        public string GenderName { get; set; }
        [Required]
        public decimal? GenderId { get; set; }

        [DisplayName("Refugee Status")]
        public string BeneficiaryName { get; set; }
        [Required]
        public decimal? BeneficiaryId { get; set; }

        [DisplayName("OPD Id")]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        public decimal? OpdId { get; set; }

        [DisplayName("Visit Id")]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        public decimal OfficeVisitId { get; set; }

        public decimal FacilityHardwareId { get; set; }

        public string _staffMemberName = string.Empty;
        [DisplayName("Staff Member")]
        [Required]
        public string StaffMemberName
        {
            get
            {
                return _staffMemberName;
            }

            set
            {
                _staffMemberName = value;
            }
        }

        private DateTime _visitDate = DateTime.Now;
        [DisplayName("Visit Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required]
        public DateTime VisitDate
        {
            get
            {
                return _visitDate;
            }

            set
            {
                _visitDate = value;
            }
        }

        [Required]
        public decimal? RevisitId { get; set; }
        [DisplayName("New or Revisit")]
        public string RevisitName { get; set; }

        [DisplayName("Age")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0}")]
        [Range(1, 200)]
        [Required]
        public decimal? Age { get; set; }

        public List<OfficeVisitDiagnosisModel> OfficeVisitDiagnosis { get; set; }
    }
}