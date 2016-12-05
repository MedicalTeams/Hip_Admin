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

            var dataList = _ovDiagRepo.GetDiagnosisByVisitId(officeVisitId);
            foreach (var item in dataList)
            {
                var visitDiag = new Models.OfficeVisitDiagnosisModel();
                visitDiag.ContactTreatmentCount = item.cntct_trmnt_cnt;
                visitDiag.DiagnosisId = item.diag_id;
                visitDiag.DiganosisName = item.lkup_diag.diag_descn;
                visitDiag.OfficeVisitDiagnosisId = item.ov_diag_id;
                visitDiag.OfficeVisitId = item.ov_id;
                visitDiag.OtherDiagnosisDescription = item.oth_diag_descn;
                visitDiag.OtherSupplementalDiagnosisDescription = item.oth_splmtl_diag_descn;
                if (item.lkup_splmtl_diag_cat.splmtl_diag_cat_id.HasValue)
                {
                    visitDiag.SupplementalDiagnosisCategoryId = item.lkup_splmtl_diag_cat.splmtl_diag_cat_id.Value;
                    visitDiag.SupplementalDiagnosisCategoryName = item.lkup_splmtl_diag_cat.splmtl_diag_cat;
                }
                visitDiag.UpdateDate = item.rec_updt_dt.ToShortDateString();
                visitDiag.UpdatedBy = item.rec_updt_user_id_cd;
                visitDiag.CreateDate = item.rec_creat_dt.ToShortDateString();
                visitDiag.CreatedBy = item.rec_creat_user_id_cd;
                


                list.Add(visitDiag);
                
            }

            return list;
        }
    }
}