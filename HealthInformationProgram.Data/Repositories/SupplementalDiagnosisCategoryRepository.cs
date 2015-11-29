using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using HealthInformationProgram.Data.DataContext;
using HealthInformationProgram.Data.Tables;

namespace HealthInformationProgram.Data.Repositories
{
    public class SupplementalDiagnosisCategoryRepository : BaseRepository
    {
        public List<lkup_splmtl_diag_cat> GetAll()
        {
            try
            {
                using ( var ctx = new ClinicDataContext(connString) )
                {

                    return ctx.lkup_splmtl_diag_cat.ToList();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }

        public lkup_splmtl_diag_cat GetSupplementalDiagnosisCat(decimal id)
        {

            try
            {
                using ( var ctx = new ClinicDataContext(connString) )
                {

                    return ctx.lkup_splmtl_diag_cat.Where(v => v.splmtl_diag_cat_id == id).FirstOrDefault();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }
        public lkup_splmtl_diag_cat GetSupplementalDiagnosisCat(string  category)
        {

            try
            {
                using ( var ctx = new ClinicDataContext(connString) )
                {

                    return ctx.lkup_splmtl_diag_cat.Where(v => v.splmtl_diag_cat == category).FirstOrDefault();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }
        public int CreateSupplementalDiagnosisCat(lkup_splmtl_diag_cat entity)
        {
            try
            {

                using ( var ctx = new ClinicDataContext(connString) )
                {
                    ctx.lkup_splmtl_diag_cat.Add(entity);
                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }

        public int Update(lkup_splmtl_diag_cat entity)
        {
            try
            {
                using ( var ctx = new ClinicDataContext(connString) )
                {
                    var supplementalDiagnosisCategories = ctx.lkup_splmtl_diag_cat.FirstOrDefault(x => x.splmtl_diag_cat_id == entity.splmtl_diag_cat_id);
                    if ( supplementalDiagnosisCategories == null )
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    supplementalDiagnosisCategories.splmtl_diag_cat_id = entity.splmtl_diag_cat_id;
                    supplementalDiagnosisCategories.splmtl_diag_cat = entity.splmtl_diag_cat;
                    supplementalDiagnosisCategories.user_intrfc_sort_ord = entity.user_intrfc_sort_ord;
                    supplementalDiagnosisCategories.splmtl_diag_cat_stat = entity.splmtl_diag_cat_stat;


                    supplementalDiagnosisCategories.rec_updt_user_id_cd = entity.rec_updt_user_id_cd;
                    supplementalDiagnosisCategories.rec_updt_dt = entity.rec_updt_dt;

                    ctx.Entry(supplementalDiagnosisCategories).State = System.Data.Entity.EntityState.Modified;

                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch ( DbEntityValidationException ex )
            {
                throw ex;
            }
            catch ( EntityException ex )
            {
                throw ex;
            }
            catch ( Exception ex )
            {
                throw ex;
            }

        }
    }
}
