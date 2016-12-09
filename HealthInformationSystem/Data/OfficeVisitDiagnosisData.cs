using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.Data
{
    public class OfficeVisitDiagnosisData
    {
        private Data.Repositories.OfficeVisitDiagnosisRepository _ovDiagRepo = null;
        public OfficeVisitDiagnosisData()
        {
            _ovDiagRepo = new Repositories.OfficeVisitDiagnosisRepository();
        }
        public List<Models.OfficeVisitDiagnosisModel> GetByVisit(decimal officeVisitId)
        {
            var list = new List<Models.OfficeVisitDiagnosisModel>();
            var diagnosisData = new DiagnosisData();
            var supplimentalDaignosisData = new MulticastNotSupportedException();

            var dataList = _ovDiagRepo.GetDiagnosisByVisitId(officeVisitId);
            foreach (var item in dataList)
            {
                var visitDiag = new Models.OfficeVisitDiagnosisModel();
                visitDiag.ContactTreatmentCount = item.cntct_trmnt_cnt;
                visitDiag.DiagnosisId = item.diag_id;
                visitDiag.DiganosisName = diagnosisData.GetDiagnosis(item.diag_id).DiagnosisDescription;
                visitDiag.SupplementalDiagnosisId = item.splmtl_diag_id;
                visitDiag.OfficeVisitDiagnosisId = item.ov_diag_id;
                visitDiag.OfficeVisitId = item.ov_id;
                visitDiag.OtherDiagnosisDescription = item.oth_diag_descn;
                visitDiag.OtherSupplementalDiagnosisDescription = item.oth_splmtl_diag_descn;
                if (item.splmtl_diag_id.HasValue)
                {
                    visitDiag.SupplementalDiagnosisCategoryId = Convert.ToDecimal(diagnosisData.GetSupplementalDiagnosis(item.splmtl_diag_id.Value).DiagnosisId);
                    visitDiag.SupplementalDiagnosisCategoryName = diagnosisData.GetSupplementalDiagnosis(item.splmtl_diag_id.Value).SupplementalDiagnosisDescription;
                }
                visitDiag.UpdateDate = item.rec_updt_dt.ToShortDateString();
                visitDiag.UpdatedBy = item.rec_updt_user_id_cd;
                visitDiag.CreateDate = item.rec_creat_dt.ToShortDateString();
                visitDiag.CreatedBy = item.rec_creat_user_id_cd;

                list.Add(visitDiag);
            }

            return list;
        }

        public decimal CreateOfficeVisitDiagnosis(Models.OfficeVisitDiagnosisModel officeVisitDiag)
        {
            var officeVisitDiagRepo = new Data.Repositories.OfficeVisitDiagnosisRepository();
            var dataModel = new Data.Tables.ov_diag();

            dataModel.ov_id = officeVisitDiag.OfficeVisitId;
            dataModel.diag_id = (decimal)officeVisitDiag.DiagnosisId;
            dataModel.splmtl_diag_id = officeVisitDiag.SupplementalDiagnosisId;
            dataModel.cntct_trmnt_cnt = officeVisitDiag.ContactTreatmentCount;
            dataModel.splmtl_diag_cat_id = officeVisitDiag.SupplementalDiagnosisCategoryId;
            dataModel.oth_diag_descn = officeVisitDiag.OtherDiagnosisDescription;
            dataModel.oth_splmtl_diag_descn = officeVisitDiag.OtherSupplementalDiagnosisDescription;
           
            dataModel.rec_creat_dt = DateTime.Now;
            dataModel.rec_creat_user_id_cd = SessionObject.SessionData.Current.LoggedInUser.UserName;

            dataModel.rec_updt_dt = DateTime.Now;
            dataModel.rec_updt_user_id_cd = SessionObject.SessionData.Current.LoggedInUser.UserName;


          return  officeVisitDiagRepo.CreateOfficeDiagnosis(dataModel);
        }

        public int UpdateOfficeVisitDiagnosis(Models.OfficeVisitDiagnosisModel officeVisitDiag)
        {
            var officeVisitDiagRepo = new Data.Repositories.OfficeVisitDiagnosisRepository();
            var dataModel = new Data.Tables.ov_diag();
            dataModel.ov_diag_id = officeVisitDiag.OfficeVisitDiagnosisId;
            dataModel.ov_id = officeVisitDiag.OfficeVisitId;
            dataModel.diag_id = (decimal)officeVisitDiag.DiagnosisId;
            dataModel.splmtl_diag_id = officeVisitDiag.SupplementalDiagnosisId;
            dataModel.cntct_trmnt_cnt = officeVisitDiag.ContactTreatmentCount;
            dataModel.splmtl_diag_cat_id = officeVisitDiag.SupplementalDiagnosisCategoryId;
            dataModel.oth_diag_descn = officeVisitDiag.OtherDiagnosisDescription;
            dataModel.oth_splmtl_diag_descn = officeVisitDiag.OtherSupplementalDiagnosisDescription;

            dataModel.rec_updt_dt = DateTime.Now;
            dataModel.rec_updt_user_id_cd = SessionObject.SessionData.Current.LoggedInUser.UserName;


            return officeVisitDiagRepo.Update(dataModel);
        }
    }
}