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
        public decimal FacilityId { get; set; }

        [DisplayName("Gender")]
        public string GenderName { get; set; }
        public decimal GenderId { get; set; }

        [DisplayName("Refugee Status")]
        public string BeneficiaryName { get; set; }
        public decimal BeneficiaryId { get; set; }

        [DisplayName("OPD Id")]
        public decimal OpdId { get; set; }

        [DisplayName("Visit Id")]
        public decimal OfficeVisitId { get; set; }

        public decimal FacilityHardwareId { get; set; }

        [DisplayName("Staff Member")]
        public string StaffMemberName { get; set; }

        [DisplayName("Visit Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-mm-yyyy}")]
        public DateTime VisitDate { get; set; }

        public decimal RevisitId { get; set; }
        [DisplayName("New or Revisit")]
        public string RevisitName { get; set; }

        [DisplayName("Age")]
        public decimal Age { get; set; }

        public List<OfficeVisitDiagnosisModel> OfficeVisitDiagnosis { get; set; }
    }
}