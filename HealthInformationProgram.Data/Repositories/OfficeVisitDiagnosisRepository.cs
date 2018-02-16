using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HealthInformationProgram.Data.DataContext;
using HealthInformationProgram.Data.Tables;

namespace HealthInformationProgram.Data.Repositories
{
    public class OfficeVisitDiagnosisRepository: BaseRepository
    {
        public List<ov_diag> GetAll()
        {
         try
            {
                using ( var ctx = ClinicDataContext.CreateForLoggedInUser() )
                {

                    return ctx.ov_diag.ToList();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }

        public ov_diag GetOfficeDiagnosis(decimal id)
        {

            try
            {
                using ( var ctx = ClinicDataContext.CreateForLoggedInUser() )
                {

                    return ctx.ov_diag.Where(v=>v.ov_diag_id == id).FirstOrDefault();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }
        public List<ov_diag> GetDiagnosisByVisitId(decimal officeVisitId)
        {
            try
            {
                using (var ctx = ClinicDataContext.CreateForLoggedInUser())
                {

                    return ctx.ov_diag.Where(v => v.ov_id == officeVisitId).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal CreateOfficeDiagnosis(ov_diag entity)
        {
            try
            {

                using ( var ctx = ClinicDataContext.CreateForLoggedInUser() )
                {
                    ctx.ov_diag.Add(entity);
                    int result = ctx.SaveChanges();

                    return entity.ov_id;
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }

        public int Update(ov_diag entity)
        {
            try
            {
                using ( var ctx = ClinicDataContext.CreateForLoggedInUser() )
                {
                    var officeVisitDiagnonsis = ctx.ov_diag.FirstOrDefault(x => x.ov_diag_id == entity.ov_diag_id);
                    if (officeVisitDiagnonsis == null )
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    officeVisitDiagnonsis.ov_diag_id = entity.ov_diag_id;
                    officeVisitDiagnonsis.ov_id = entity.ov_id;
                    officeVisitDiagnonsis.splmtl_diag_id = entity.splmtl_diag_id;
                    officeVisitDiagnonsis.diag_id = entity.diag_id;
                    officeVisitDiagnonsis.cntct_trmnt_cnt = entity.cntct_trmnt_cnt;
                    officeVisitDiagnonsis.splmtl_diag_cat_id = entity.splmtl_diag_cat_id;
                    officeVisitDiagnonsis.oth_diag_descn = entity.oth_diag_descn;
                    officeVisitDiagnonsis.oth_splmtl_diag_descn = entity.oth_splmtl_diag_descn;


                    officeVisitDiagnonsis.rec_updt_dt = entity.rec_updt_dt;
                    officeVisitDiagnonsis.rec_updt_user_id_cd = entity.rec_updt_user_id_cd;
                    

                    ctx.Entry(officeVisitDiagnonsis).State = System.Data.Entity.EntityState.Modified;

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
