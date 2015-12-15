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
    public class SupplementalDiagnosisRepository : BaseRepository
    {
        public List<lkup_splmtl_diag> GetAll()
        {
            try
            {
                using ( var ctx = new ClinicDataContext(connString) )
                {

                    return ctx.lkup_splmtl_diag.OrderBy(x => x.user_intrfc_sort_ord).ToList();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }

        public lkup_splmtl_diag GetSupplementalDiagnosis(decimal id)
        {

            try
            {
                using ( var ctx = new ClinicDataContext(connString) )
                {

                    return ctx.lkup_splmtl_diag.Where(v => v.splmtl_diag_id == id).FirstOrDefault();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }
        public lkup_splmtl_diag GetSupplementalDiagnosis(string description)
        {

            try
            {
                using ( var ctx = new ClinicDataContext(connString) )
                {

                    return ctx.lkup_splmtl_diag.Where(v => v.splmtl_diag_descn == description).FirstOrDefault();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }

        public int CreateSupplementalDiagnosis(lkup_splmtl_diag entity)
        {
            try
            {

                using ( var ctx = new ClinicDataContext(connString) )
                {
                    IdentityInsertOn<lkup_splmtl_diag>(ctx, entity);
                    ctx.Entry(entity).State = System.Data.Entity.EntityState.Added;
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

        public int Update(lkup_splmtl_diag entity)
        {
            try
            {
                using ( var ctx = new ClinicDataContext(connString) )
                {
                    var supplementalDiagnosis = ctx.lkup_splmtl_diag.FirstOrDefault(x => x.splmtl_diag_id == entity.splmtl_diag_id);
                    if ( supplementalDiagnosis == null )
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    supplementalDiagnosis.diag_id = entity.diag_id;
                    supplementalDiagnosis.splmtl_diag_id = entity.splmtl_diag_id;
                    supplementalDiagnosis.splmtl_diag_descn = entity.splmtl_diag_descn;
                    supplementalDiagnosis.rec_updt_user_id_cd = entity.rec_updt_user_id_cd;
                    supplementalDiagnosis.rec_updt_dt = entity.rec_updt_dt;
                    supplementalDiagnosis.user_intrfc_sort_ord = entity.user_intrfc_sort_ord;
                    supplementalDiagnosis.splmtl_diag_stat = entity.splmtl_diag_stat;
                    supplementalDiagnosis.splmtl_diag_strt_eff_dt = entity.splmtl_diag_strt_eff_dt;
                    supplementalDiagnosis.splmtl_diag_end_eff_dt = entity.splmtl_diag_end_eff_dt;
                    
                    


                    ctx.Entry(supplementalDiagnosis).State = System.Data.Entity.EntityState.Modified;

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
