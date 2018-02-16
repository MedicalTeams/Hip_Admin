using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HealthInformationProgram.Data.DataContext;
using HealthInformationProgram.Data.Tables;

namespace HealthInformationProgram.Data.Repositories
{
    public class DiagnosisAlertThresholdRepository : BaseRepository
    {
        public List<diag_alert_thrshld> GetAll()
        {
            try
            {
                using ( var ctx = ClinicDataContext.CreateForLoggedInUser() )
                {

                    return ctx.diag_alert_thrshld.ToList();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }

        public diag_alert_thrshld GetDiagnosisAlertThreshold(decimal id)
        {

            try
            {
                using ( var ctx = ClinicDataContext.CreateForLoggedInUser() )
                {

                    return ctx.diag_alert_thrshld.Where(v => v.diag_alert_thrshld_id == id).FirstOrDefault();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }
        public int CreateDiagnosisAlertThreshold(diag_alert_thrshld entity)
        {
            try
            {

                using ( var ctx = ClinicDataContext.CreateForLoggedInUser() )
                {
                    ctx.diag_alert_thrshld.Add(entity);
                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }

        public int Update(diag_alert_thrshld entity)
        {
            try
            {
                using ( var ctx = ClinicDataContext.CreateForLoggedInUser() )
                {
                    var diagnosisAlertThreshold = ctx.diag_alert_thrshld.FirstOrDefault(x => x.diag_alert_thrshld_id == entity.diag_alert_thrshld_id);
                    if ( diagnosisAlertThreshold == null )
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    diagnosisAlertThreshold.diag_alert_thrshld_id = entity.diag_alert_thrshld_id;
                    diagnosisAlertThreshold.diag_id = entity.diag_id;
                    diagnosisAlertThreshold.case_cnt = entity.case_cnt;
                    diagnosisAlertThreshold.baseln_multr = entity.baseln_multr;
                    diagnosisAlertThreshold.rec_updt_dt = entity.rec_updt_dt;
                    diagnosisAlertThreshold.rec_updt_user_id_cd = entity.rec_updt_user_id_cd;


                    ctx.Entry(diagnosisAlertThreshold).State = System.Data.Entity.EntityState.Modified;

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
