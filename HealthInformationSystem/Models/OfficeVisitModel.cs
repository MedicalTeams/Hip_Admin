using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.Models
{
    public class OfficeVisitModel : BaseModel
    {
        public OfficeVisitModel()
        {
            OfficeVisitDiagnosis = new List<OfficeVisitDiagnosisModel>();

        }
        public string FacililtyName { get; set; }
        public decimal FacilityId { get; set; }
        public string GenderName { get; set; }
        public decimal GenderId { get; set; }
        public string BeneficiaryName { get; set; }
        public decimal BeneficiaryId { get; set; }
        public decimal OpdId { get; set; }
        public decimal OfficeVisitId { get; set; }
        public decimal FacilityHardwareId { get; set; }
        public string StaffMemberName { get; set; }
        public DateTime VisitDate { get; set; }
        public decimal RevisitId { get; set; }
        public string RevisitName { get; set; }
        public decimal Age { get; set; }
        public List<OfficeVisitDiagnosisModel> OfficeVisitDiagnosis { get; set; }


    }
}