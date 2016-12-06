﻿using HealthInformationProgram.SessionObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.Data
{
    public class OfficeVisitData
    {
        Data.Repositories.OfficeVisitRepository _officeVisitRepo = null;
        public OfficeVisitData()
        {
            _officeVisitRepo = new Repositories.OfficeVisitRepository();

        }
        public List<Models.OfficeVisitModel> GetOfficeVisits()
        {
            var officeVisits = new List<Models.OfficeVisitModel>();
            var visitDiag = new OfficeVisitDiagnosisData();
            var beneficiaryData = new BeneficiaryData();
            var dataList = _officeVisitRepo.GetAll();
            var genderData = new GenderData();
            var facilityHardwareData = new FacilityHardwareData();

            foreach (var item in dataList)
            {
                var visit = new Models.OfficeVisitModel();
                visit.OfficeVisitId = item.ov_id;
                visit.OpdId = item.opd_id;
                visit.BeneficiaryId = item.bnfcry_id;
                visit.BeneficiaryName = beneficiaryData.Get(item.bnfcry_id).BeneficiaryType;
                visit.FacililtyName = facilityHardwareData.GetFacilityHardware(item.faclty_hw_invtry_id).FacilityId;
                visit.FacilityId = item.faclty_id;
                visit.GenderId = item.gndr_id;
                visit.GenderName = genderData.Get(item.gndr_id).GenderDescription;
                visit.OfficeVisitDiagnosis = visitDiag.GetByVisit(item.ov_id);
                visit.Age = item.infnt_age_mos;
                visit.FacilityHardwareId = item.faclty_hw_invtry_id;
                visit.RevisitId = item.rvisit_id;
                visit.StaffMemberName = item.staff_mbr_name;
                visit.VisitDate = item.dt_of_visit;
                visit.CreateDate = item.rec_creat_dt.ToShortDateString();
                visit.CreatedBy = item.rec_creat_user_id_cd;
                visit.UpdateDate = item.rec_updt_dt.ToShortDateString();
                visit.UpdatedBy = item.rec_updt_user_id_cd;

                officeVisits.Add(visit);
            }

            return officeVisits;

        }
        public Models.OfficeVisitModel GetVisit(decimal id)
        {

            var visitDiag = new OfficeVisitDiagnosisData();
            var item = _officeVisitRepo.GetOfficeVisit(id);
            var visit = new Models.OfficeVisitModel();
            visit.OfficeVisitId = item.ov_id;
            visit.OpdId = item.opd_id;
            visit.BeneficiaryId = item.bnfcry_id;
            visit.BeneficiaryName = item.lkup_bnfcry.bnfcry;
            visit.FacililtyName = item.lkup_faclty.hlth_care_faclty;
            visit.FacilityId = item.faclty_id;
            visit.GenderId = item.gndr_id;
            visit.GenderName = item.lkup_gndr.gndr_descn;
            visit.OfficeVisitDiagnosis = visitDiag.GetByVisit(item.ov_id);
            visit.Age = item.infnt_age_mos;


            visit.CreateDate = item.rec_creat_dt.ToShortDateString();
            visit.CreatedBy = item.rec_creat_user_id_cd;
            visit.UpdateDate = item.rec_updt_dt.ToShortDateString();
            visit.UpdatedBy = item.rec_updt_user_id_cd;

            return visit;
        }

        public int UpdateVisit(Models.OfficeVisitModel officeVisit)
        {
            var dataOfficeVisit = new Data.Tables.ov();
            dataOfficeVisit.bnfcry_id = officeVisit.BeneficiaryId;
            dataOfficeVisit.dt_of_visit = officeVisit.VisitDate;
            dataOfficeVisit.faclty_hw_invtry_id = officeVisit.FacilityHardwareId;
            dataOfficeVisit.faclty_id = officeVisit.FacilityId;
            dataOfficeVisit.gndr_id = officeVisit.GenderId;
            dataOfficeVisit.infnt_age_mos = officeVisit.Age;
            dataOfficeVisit.opd_id = officeVisit.OpdId;
            dataOfficeVisit.ov_id = officeVisit.OfficeVisitId;
            dataOfficeVisit.rec_updt_dt = DateTime.UtcNow;
            dataOfficeVisit.rec_updt_user_id_cd = SessionData.Current.LoggedInUser.UserName;

            return  _officeVisitRepo.Update(dataOfficeVisit);

        }
        public int CreateVisit(Models.OfficeVisitModel officeVisit)
        {
            var dataOfficeVisit = new Data.Tables.ov();
            dataOfficeVisit.bnfcry_id = officeVisit.BeneficiaryId;
            dataOfficeVisit.dt_of_visit = officeVisit.VisitDate;
            dataOfficeVisit.faclty_hw_invtry_id = officeVisit.FacilityHardwareId;
            dataOfficeVisit.faclty_id = officeVisit.FacilityId;
            dataOfficeVisit.gndr_id = officeVisit.GenderId;
            dataOfficeVisit.infnt_age_mos = officeVisit.Age;
            dataOfficeVisit.opd_id = officeVisit.OpdId;
            dataOfficeVisit.ov_id = officeVisit.OfficeVisitId;
            dataOfficeVisit.rec_updt_dt = DateTime.UtcNow;
            dataOfficeVisit.rec_updt_user_id_cd = SessionData.Current.LoggedInUser.UserName;
            dataOfficeVisit.rec_creat_dt = DateTime.UtcNow;
            dataOfficeVisit.rec_creat_user_id_cd = SessionData.Current.LoggedInUser.UserName;
            return _officeVisitRepo.CreateOfficeVisit(dataOfficeVisit);

        }
    }
}