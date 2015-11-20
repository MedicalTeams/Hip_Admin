using System;
using System.Collections.Generic;
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

                    return ctx.lkup_splmtl_diag.ToList();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }

        public lkup_splmtl_diag GetRevisit(decimal id)
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
        public int CreateRevisitConstant(lkup_splmtl_diag entity)
        {
            try
            {

                using ( var ctx = new ClinicDataContext(connString) )
                {
                    ctx.lkup_splmtl_diag.Add(entity);
                    int result = ctx.SaveChanges();

                    return result;
                }
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
                    var supplementalDiagnosisCategories = ctx.lkup_splmtl_diag.FirstOrDefault(x => x.splmtl_diag_id == entity.splmtl_diag_id);
                    if ( supplementalDiagnosisCategories == null )
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    supplementalDiagnosisCategories.diag_id = entity.diag_id;
                    supplementalDiagnosisCategories.splmtl_diag_id = entity.splmtl_diag_id;
                    supplementalDiagnosisCategories.splmtl_diag_descn = entity.splmtl_diag_descn;
                    supplementalDiagnosisCategories.rec_updt_user_id_cd = entity.rec_updt_user_id_cd;
                    supplementalDiagnosisCategories.rec_updt_dt = entity.rec_updt_dt;
                    supplementalDiagnosisCategories.user_intrfc_sort_ord = entity.user_intrfc_sort_ord;
                    supplementalDiagnosisCategories.splmtl_diag_stat = entity.splmtl_diag_stat;
                    supplementalDiagnosisCategories.splmtl_diag_strt_eff_dt = entity.splmtl_diag_strt_eff_dt;
                    supplementalDiagnosisCategories.splmtl_diag_end_eff_dt = entity.splmtl_diag_end_eff_dt;
                    
                    


                    ctx.Entry(supplementalDiagnosisCategories).State = System.Data.Entity.EntityState.Modified;

                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }

        }
    }
}
