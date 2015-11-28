using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HealthInformationProgram.Models;
using HealthInformationProgram.Data.Repositories;

namespace HealthInformationProgram.Data
{
    public class DiagnosisData : BaseHipData
    {
        public List<DiagnosisModel> GetAllDiagnosis()
        {
            var diagnosisList = new List<DiagnosisModel>();
            var repo = new HealthInformationProgram.Data.Repositories.DiagnosisRepository();
            try
            {
                var dataList = repo.GetAll();
                foreach ( var item in dataList )
                {
                    var diagView = new DiagnosisModel();
                    diagView.DiagnosisId = GetDataValue(item.diag_id);
                    diagView.DiagnosisDescription = GetDataValue(item.diag_descn);
                    diagView.DiagnosisStatus = GetDataValue( item.diag_stat);
                    diagView.DiagnosisAbbreviation = GetDataValue(item.diag_abrvn);
                    diagView.IcdCode =GetDataValue( item.icd_cd);
                    diagView.SortOrder = GetDataValue(item.user_intrfc_sort_ord);
                    diagView.DiagnosisEffectiveStartDate = item.diag_strt_eff_dt.ToString();
                    diagView.DiagnosisEffectiveEndDate = item.diag_end_eff_dt.ToString();
                    diagView.CreateDate = item.rec_creat_dt.ToString();
                    diagView.CreatedBy = GetDataValue(item.rec_creat_user_id_cd);
                    diagView.UpdateDate = item.rec_updt_dt.ToString();
                    diagView.UpdatedBy = GetDataValue(item.rec_updt_user_id_cd);

                    diagnosisList.Add(diagView);

                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }

            return diagnosisList;
        }
        public DiagnosisModel GetDiagnosis(string id)
        {

            var repo = new DiagnosisRepository();
            var item = repo.GetDiagnosis(Convert.ToDecimal(id));

            var diagView = new DiagnosisModel();
            diagView.DiagnosisId = item.diag_id.ToString();
            diagView.DiagnosisStatus = item.diag_stat.ToString();
            diagView.DiagnosisAbbreviation = item.diag_abrvn.ToString();
            diagView.SortOrder = item.user_intrfc_sort_ord.ToString();
            diagView.IcdCode = item.icd_cd.ToString();
            diagView.DiagnosisEffectiveStartDate = item.diag_strt_eff_dt.ToString();
            diagView.DiagnosisEffectiveEndDate = item.diag_end_eff_dt.ToString();
            diagView.CreateDate = item.rec_creat_dt.ToString();
            diagView.CreatedBy = item.rec_creat_user_id_cd.ToString();
            diagView.UpdateDate = item.rec_updt_dt.ToString();
            diagView.UpdatedBy = item.rec_updt_user_id_cd.ToString();

            return diagView;

        }
        public int Create(DiagnosisModel model)
        {

            var repo = new DiagnosisRepository();
            var dataModel = new HealthInformationProgram.Data.Tables.lkup_diag();

            var diagView = new DiagnosisModel();
            dataModel.diag_id = Convert.ToDecimal(model.DiagnosisId);
            dataModel.diag_stat = model.DiagnosisStatus;
            dataModel.diag_abrvn = model.DiagnosisAbbreviation;
            dataModel.icd_cd = model.IcdCode;
            dataModel.user_intrfc_sort_ord = Convert.ToDecimal(model.SortOrder);
            dataModel.diag_strt_eff_dt = Convert.ToDateTime(model.DiagnosisEffectiveStartDate);
            dataModel.diag_end_eff_dt = Convert.ToDateTime(model.DiagnosisEffectiveEndDate);

            dataModel.rec_updt_dt = DateTime.Now;
            dataModel.rec_updt_user_id_cd = "dbadmin"; //TODO: change to use AD when wired up

            try
            {

                var returnCode = repo.Update(dataModel);
                return returnCode;
            }
            catch ( Exception ex )
            {
                throw ex;
            }

        }
        public int Update(DiagnosisModel model)
        {

            var repo = new DiagnosisRepository();
            var dataModel = new HealthInformationProgram.Data.Tables.lkup_diag();


            var diagView = new DiagnosisModel();
            dataModel.diag_id = Convert.ToDecimal(model.DiagnosisId);
            dataModel.diag_stat = model.DiagnosisStatus;
            dataModel.diag_descn = model.DiagnosisDescription;
            dataModel.diag_abrvn = model.DiagnosisAbbreviation;
            dataModel.icd_cd = model.IcdCode;
            dataModel.diag_strt_eff_dt = Convert.ToDateTime(model.DiagnosisEffectiveStartDate);
            dataModel.diag_end_eff_dt = Convert.ToDateTime(model.DiagnosisEffectiveEndDate);
            dataModel.user_intrfc_sort_ord = Convert.ToDecimal(model.SortOrder);
            dataModel.rec_updt_dt = DateTime.Now;
            dataModel.rec_updt_user_id_cd = "dbadmin"; //TODO: change to use AD when wired up

            try
            {

                var returnCode = repo.Update(dataModel);
                return returnCode;
            }
            catch ( Exception ex )
            {
                throw ex;
            }

        }

        
    }
}