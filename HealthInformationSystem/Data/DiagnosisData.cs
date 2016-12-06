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
        #region Diagnosis

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
                    diagView.DiagnosisStatus = GetDataValue(item.diag_stat);
                    diagView.DiagnosisAbbreviation = GetDataValue(item.diag_abrvn);
                    diagView.IcdCode = GetDataValue(item.icd_cd);
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
        public DiagnosisModel GetDiagnosis(decimal id)
        {

            var repo = new DiagnosisRepository();
            var item = repo.GetDiagnosis(id);

            var diagView = new DiagnosisModel();
            diagView.DiagnosisId = GetDataValue(item.diag_id);
            diagView.DiagnosisStatus = GetDataValue(item.diag_stat);
            diagView.DiagnosisAbbreviation = GetDataValue(item.diag_abrvn);
            diagView.DiagnosisDescription = GetDataValue(item.diag_descn);
            diagView.SortOrder = GetDataValue(item.user_intrfc_sort_ord);
            diagView.IcdCode = GetDataValue(item.icd_cd);
            diagView.DiagnosisEffectiveStartDate = GetDataValue(item.diag_strt_eff_dt);
            diagView.DiagnosisEffectiveEndDate = GetDataValue(item.diag_end_eff_dt);
            diagView.CreateDate = GetDataValue(item.rec_creat_dt);
            diagView.CreatedBy = GetDataValue(item.rec_creat_user_id_cd);
            diagView.UpdateDate = GetDataValue(item.rec_updt_dt);
            diagView.UpdatedBy = GetDataValue(item.rec_updt_user_id_cd);

            return diagView;

        }
        public int CreateDiagnosis(DiagnosisModel model)
        {

            var repo = new DiagnosisRepository();
            var dataModel = new HealthInformationProgram.Data.Tables.lkup_diag();

           
            dataModel.diag_id = Convert.ToDecimal(model.DiagnosisId);
            dataModel.diag_descn = model.DiagnosisDescription;
            dataModel.diag_stat = model.DiagnosisStatus;
            dataModel.diag_abrvn = model.DiagnosisAbbreviation;
            dataModel.icd_cd = model.IcdCode;
            dataModel.user_intrfc_sort_ord = Convert.ToDecimal(model.SortOrder);
            dataModel.diag_strt_eff_dt = Convert.ToDateTime(model.DiagnosisEffectiveStartDate);
            dataModel.diag_end_eff_dt = Convert.ToDateTime(model.DiagnosisEffectiveEndDate);
            dataModel.rec_creat_dt = DateTime.Now;
            dataModel.rec_creat_user_id_cd = model.CreatedBy;
            dataModel.rec_updt_dt = DateTime.Now;
            dataModel.rec_updt_user_id_cd = model.UpdatedBy; 

            try
            {

                var returnCode = repo.CreateDiagnosis(dataModel);
                return returnCode;
            }
            catch ( Exception ex )
            {
                throw ex;
            }

        }
        public int UpdateDiagnosis(DiagnosisModel model)
        {

            var repo = new DiagnosisRepository();
            var dataModel = new HealthInformationProgram.Data.Tables.lkup_diag();


           
            dataModel.diag_id = Convert.ToDecimal(model.DiagnosisId);
            dataModel.diag_stat = model.DiagnosisStatus;
            dataModel.diag_descn = model.DiagnosisDescription;
            dataModel.diag_abrvn = model.DiagnosisAbbreviation;
            dataModel.icd_cd = model.IcdCode;
            dataModel.diag_strt_eff_dt = Convert.ToDateTime(model.DiagnosisEffectiveStartDate);
            dataModel.diag_end_eff_dt = Convert.ToDateTime(model.DiagnosisEffectiveEndDate);
            dataModel.user_intrfc_sort_ord = Convert.ToDecimal(model.SortOrder);
            dataModel.rec_updt_dt = DateTime.Now;
            dataModel.rec_updt_user_id_cd = model.UpdatedBy;

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

        #endregion

        #region Diagnosis Supplemental Category

        public List<SupplementalDiagnosisCategoryModel> GetAllSupplementalCategories()
        {
            var categories = new List<SupplementalDiagnosisCategoryModel>();
            var repo = new HealthInformationProgram.Data.Repositories.SupplementalDiagnosisCategoryRepository();

            var dataList = repo.GetAll();
            foreach ( var item in dataList )
            {
                var cat = new SupplementalDiagnosisCategoryModel();

                cat.SupplementalDiagnosisCategoryId = GetDataValue(item.splmtl_diag_cat_id);
                cat.SupplementalDiagnosisCategoryType = GetDataValue(item.splmtl_diag_cat);
                cat.SortOrder = GetDataValue(item.user_intrfc_sort_ord);
                cat.Status = GetDataValue(item.splmtl_diag_cat_stat);
                cat.SupplementalDiagnosisCategoryEffectiveStartDate = GetDataValue(item.splmtl_diag_cat_strt_eff_dt);
                cat.SupplementalDiagnosisCategoryEffectiveEndDate = GetDataValue(item.splmtl_diag_cat_end_eff_dt);
                cat.UpdatedBy = GetDataValue(item.rec_updt_user_id_cd);
                cat.UpdateDate = GetDataValue(item.rec_updt_dt);
                cat.CreatedBy = GetDataValue(item.rec_creat_user_id_cd);
                cat.CreateDate = GetDataValue(item.rec_creat_dt);



                categories.Add(cat);
            }
            return categories;
        }
        public SupplementalDiagnosisCategoryModel GetSupplementalCategory(string id)
        {

            var repo = new HealthInformationProgram.Data.Repositories.SupplementalDiagnosisCategoryRepository();
            var cat = new SupplementalDiagnosisCategoryModel();
            var dataItem = repo.GetSupplementalDiagnosisCat(Convert.ToDecimal(id));



            cat.SupplementalDiagnosisCategoryId = GetDataValue(dataItem.splmtl_diag_cat_id);
            cat.SupplementalDiagnosisCategoryType = GetDataValue(dataItem.splmtl_diag_cat);
            cat.SortOrder = GetDataValue(dataItem.user_intrfc_sort_ord);
            cat.Status = GetDataValue(dataItem.splmtl_diag_cat_stat);
            cat.SupplementalDiagnosisCategoryEffectiveStartDate = GetDataValue(dataItem.splmtl_diag_cat_strt_eff_dt);
            cat.SupplementalDiagnosisCategoryEffectiveEndDate = GetDataValue(dataItem.splmtl_diag_cat_end_eff_dt);
            cat.UpdatedBy = GetDataValue(dataItem.rec_updt_user_id_cd);
            cat.UpdateDate = GetDataValue(dataItem.rec_updt_dt);
            cat.CreatedBy = GetDataValue(dataItem.rec_creat_user_id_cd);
            cat.CreateDate = GetDataValue(dataItem.rec_creat_dt);



            return cat;
        }
        public SupplementalDiagnosisCategoryModel GetSupplementalCategoryByCategory(string category)
        {

            var repo = new HealthInformationProgram.Data.Repositories.SupplementalDiagnosisCategoryRepository();
            var cat = new SupplementalDiagnosisCategoryModel();
            var dataItem = repo.GetSupplementalDiagnosisCat(category);



            cat.SupplementalDiagnosisCategoryId = GetDataValue(dataItem.splmtl_diag_cat_id);
            cat.SupplementalDiagnosisCategoryType = GetDataValue(dataItem.splmtl_diag_cat);
            cat.SortOrder = GetDataValue(dataItem.user_intrfc_sort_ord);
            cat.Status = GetDataValue(dataItem.splmtl_diag_cat_stat);
            cat.SupplementalDiagnosisCategoryEffectiveStartDate = GetDataValue(dataItem.splmtl_diag_cat_strt_eff_dt);
            cat.SupplementalDiagnosisCategoryEffectiveEndDate = GetDataValue(dataItem.splmtl_diag_cat_end_eff_dt);
            cat.UpdatedBy = GetDataValue(dataItem.rec_updt_user_id_cd);
            cat.UpdateDate = GetDataValue(dataItem.rec_updt_dt);
            cat.CreatedBy = GetDataValue(dataItem.rec_creat_user_id_cd);
            cat.CreateDate = GetDataValue(dataItem.rec_creat_dt);



            return cat;
        }
        public int CreateDiagnosisCategory(SupplementalDiagnosisCategoryModel model)
        {

            var repo = new SupplementalDiagnosisCategoryRepository();
            var dataModel = new HealthInformationProgram.Data.Tables.lkup_splmtl_diag_cat();

          // dataModel.splmtl_diag_cat_id = Convert.ToDecimal(model.SupplementalDiagnosisCategoryId);
            dataModel.splmtl_diag_cat_stat = model.Status;
            dataModel.splmtl_diag_cat = model.SupplementalDiagnosisCategoryType;
            dataModel.user_intrfc_sort_ord = Convert.ToDecimal(model.SortOrder);
            dataModel.splmtl_diag_cat_strt_eff_dt = Convert.ToDateTime(model.SupplementalDiagnosisCategoryEffectiveStartDate);
            dataModel.splmtl_diag_cat_end_eff_dt = Convert.ToDateTime(model.SupplementalDiagnosisCategoryEffectiveEndDate);
            dataModel.rec_creat_dt = DateTime.Now;
            dataModel.rec_creat_user_id_cd = model.CreatedBy;
            dataModel.rec_updt_dt = DateTime.Now;
            dataModel.rec_updt_user_id_cd = model.UpdatedBy;

            try
            {

                var returnCode = repo.CreateSupplementalDiagnosisCat(dataModel);
                return returnCode;
            }
            catch ( Exception ex )
            {
                throw ex;
            }

        }
        public int UpdateSupplementalDiagnosisCategory(SupplementalDiagnosisCategoryModel model)
        {

            var repo = new SupplementalDiagnosisCategoryRepository();
            var dataModel = new HealthInformationProgram.Data.Tables.lkup_splmtl_diag_cat();



            dataModel.splmtl_diag_cat_id = Convert.ToDecimal(model.SupplementalDiagnosisCategoryId);
            dataModel.splmtl_diag_cat_stat = model.Status;
            dataModel.splmtl_diag_cat = model.SupplementalDiagnosisCategoryType;
            dataModel.user_intrfc_sort_ord = Convert.ToDecimal(model.SortOrder);
            dataModel.splmtl_diag_cat_strt_eff_dt = Convert.ToDateTime(model.SupplementalDiagnosisCategoryEffectiveStartDate);
            dataModel.splmtl_diag_cat_end_eff_dt = Convert.ToDateTime(model.SupplementalDiagnosisCategoryEffectiveEndDate);

            dataModel.rec_updt_dt = DateTime.Now;
            dataModel.rec_updt_user_id_cd = model.UpdatedBy;

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
        #endregion


        #region  Supplemental Diagnosis

        public List<SupplementalDiagnosisModel> GetAllSupplementalDiagnosis()
        {
            var categories = new List<SupplementalDiagnosisModel>();
            var repo = new HealthInformationProgram.Data.Repositories.SupplementalDiagnosisRepository();

            var dataList = repo.GetAll();
            foreach ( var item in dataList )
            {
                var cat = new SupplementalDiagnosisModel();

                cat.SupplementalDiagnosisId = GetDataValue(item.splmtl_diag_id);
                cat.SupplementalDiagnosisDescription = GetDataValue(item.splmtl_diag_descn);
                cat.DiagnosisId = GetDataValue(item.diag_id);
                cat.Diagnosis = GetDiagnosis(item.diag_id).DiagnosisDescription;
                cat.SortOrder = GetDataValue(item.user_intrfc_sort_ord);
                cat.Status = GetDataValue(item.splmtl_diag_stat);
                cat.SupplementalDiagnosisEffectiveStartDate = GetDataValue(item.splmtl_diag_strt_eff_dt);
                cat.SupplementalDiagnosisEffectiveEndDate = GetDataValue(item.splmtl_diag_end_eff_dt);
                cat.UpdatedBy = GetDataValue(item.rec_updt_user_id_cd);
                cat.UpdateDate = GetDataValue(item.rec_updt_dt);
                cat.CreatedBy = GetDataValue(item.rec_creat_user_id_cd);
                cat.CreateDate = GetDataValue(item.rec_creat_dt);



                categories.Add(cat);
            }
            return categories;
        }
        public SupplementalDiagnosisModel GetSupplementalDiagnosis(string id)
        {

            var repo = new HealthInformationProgram.Data.Repositories.SupplementalDiagnosisRepository();
       
            var dataItem = repo.GetSupplementalDiagnosis(Convert.ToDecimal(id));



            var cat = new SupplementalDiagnosisModel();

            cat.SupplementalDiagnosisId = GetDataValue(dataItem.splmtl_diag_id);
            cat.SupplementalDiagnosisDescription = GetDataValue(dataItem.splmtl_diag_descn);
            cat.DiagnosisId = GetDataValue(dataItem.diag_id);
            cat.Diagnosis = GetDiagnosis(dataItem.diag_id).DiagnosisDescription;
            cat.SortOrder = GetDataValue(dataItem.user_intrfc_sort_ord);
            cat.Status = GetDataValue(dataItem.splmtl_diag_stat);
            cat.SupplementalDiagnosisEffectiveStartDate = GetDataValue(dataItem.splmtl_diag_strt_eff_dt);
            cat.SupplementalDiagnosisEffectiveEndDate = GetDataValue(dataItem.splmtl_diag_end_eff_dt);
            cat.UpdatedBy = GetDataValue(dataItem.rec_updt_user_id_cd);
            cat.UpdateDate = GetDataValue(dataItem.rec_updt_dt);
            cat.CreatedBy = GetDataValue(dataItem.rec_creat_user_id_cd);
            cat.CreateDate = GetDataValue(dataItem.rec_creat_dt);


            return cat;
        }
        public SupplementalDiagnosisModel GetSupplementalDiagnosis(decimal id)
        {

            var repo = new HealthInformationProgram.Data.Repositories.SupplementalDiagnosisRepository();

            var dataItem = repo.GetSupplementalDiagnosis(id);



            var cat = new SupplementalDiagnosisModel();

            cat.SupplementalDiagnosisId = GetDataValue(dataItem.splmtl_diag_id);
            cat.SupplementalDiagnosisDescription = GetDataValue(dataItem.splmtl_diag_descn);
            cat.DiagnosisId = GetDataValue(dataItem.diag_id);
            cat.Diagnosis = GetDiagnosis(dataItem.diag_id).DiagnosisDescription;
            cat.SortOrder = GetDataValue(dataItem.user_intrfc_sort_ord);
            cat.Status = GetDataValue(dataItem.splmtl_diag_stat);
            cat.SupplementalDiagnosisEffectiveStartDate = GetDataValue(dataItem.splmtl_diag_strt_eff_dt);
            cat.SupplementalDiagnosisEffectiveEndDate = GetDataValue(dataItem.splmtl_diag_end_eff_dt);
            cat.UpdatedBy = GetDataValue(dataItem.rec_updt_user_id_cd);
            cat.UpdateDate = GetDataValue(dataItem.rec_updt_dt);
            cat.CreatedBy = GetDataValue(dataItem.rec_creat_user_id_cd);
            cat.CreateDate = GetDataValue(dataItem.rec_creat_dt);


            return cat;
        }
        public SupplementalDiagnosisModel GetSupplementalDiagnosisByDescription(string description)
        {

            var repo = new HealthInformationProgram.Data.Repositories.SupplementalDiagnosisRepository();
            var dataItem = repo.GetSupplementalDiagnosis(description);



            var cat = new SupplementalDiagnosisModel();

            cat.SupplementalDiagnosisId = GetDataValue(dataItem.splmtl_diag_id);
            cat.SupplementalDiagnosisDescription = GetDataValue(dataItem.splmtl_diag_descn);
            cat.SortOrder = GetDataValue(dataItem.user_intrfc_sort_ord);
            cat.Status = GetDataValue(dataItem.splmtl_diag_stat);
            cat.SupplementalDiagnosisEffectiveStartDate = GetDataValue(dataItem.splmtl_diag_strt_eff_dt);
            cat.SupplementalDiagnosisEffectiveEndDate = GetDataValue(dataItem.splmtl_diag_end_eff_dt);
            cat.UpdatedBy = GetDataValue(dataItem.rec_updt_user_id_cd);
            cat.UpdateDate = GetDataValue(dataItem.rec_updt_dt);
            cat.CreatedBy = GetDataValue(dataItem.rec_creat_user_id_cd);
            cat.CreateDate = GetDataValue(dataItem.rec_creat_dt);



            return cat;
        }
        public int CreateSupplementalDiagnosis(SupplementalDiagnosisModel model)
        {

            var repo = new SupplementalDiagnosisRepository();
            var dataModel = new HealthInformationProgram.Data.Tables.lkup_splmtl_diag();
            //dataModel.splmtl_diag_id = null;// Convert.ToDecimal(model.SupplementalDiagnosisId);
            dataModel.diag_id = Convert.ToDecimal(model.DiagnosisId);
            dataModel.splmtl_diag_stat = model.Status;
            dataModel.splmtl_diag_descn = model.SupplementalDiagnosisDescription;
            dataModel.user_intrfc_sort_ord = Convert.ToDecimal(model.SortOrder);
            dataModel.splmtl_diag_strt_eff_dt = Convert.ToDateTime(model.SupplementalDiagnosisEffectiveStartDate);
            dataModel.splmtl_diag_end_eff_dt = Convert.ToDateTime(model.SupplementalDiagnosisEffectiveEndDate);
            dataModel.rec_creat_dt = DateTime.Now;
            dataModel.rec_creat_user_id_cd = model.CreatedBy;
            dataModel.rec_updt_dt = DateTime.Now;
            dataModel.rec_updt_user_id_cd = model.UpdatedBy;

            try
            {

                var returnCode = repo.CreateSupplementalDiagnosis(dataModel);
                return returnCode;
            }
            catch ( Exception ex )
            {
                throw ex;
            }

        }
        public int UpdateSupplementalDiagnosis(SupplementalDiagnosisModel model)
        {

            var repo = new SupplementalDiagnosisRepository();
            var dataModel = new HealthInformationProgram.Data.Tables.lkup_splmtl_diag();


            dataModel.diag_id = Convert.ToDecimal(model.DiagnosisId);
            dataModel.splmtl_diag_id = Convert.ToDecimal(model.SupplementalDiagnosisId);
            dataModel.splmtl_diag_stat = model.Status;
            dataModel.splmtl_diag_descn = model.SupplementalDiagnosisDescription;
            dataModel.user_intrfc_sort_ord = Convert.ToDecimal(model.SortOrder);
            dataModel.splmtl_diag_strt_eff_dt = Convert.ToDateTime(model.SupplementalDiagnosisEffectiveStartDate);
            dataModel.splmtl_diag_end_eff_dt = Convert.ToDateTime(model.SupplementalDiagnosisEffectiveEndDate);
            dataModel.rec_updt_dt = DateTime.Now;
            dataModel.rec_updt_user_id_cd = model.UpdatedBy;

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
        #endregion
    }
}