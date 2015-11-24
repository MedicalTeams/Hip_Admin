using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HealthInformationProgram.Data.DataContext;
using HealthInformationProgram.Data.Tables;


namespace HealthInformationProgram.Data.Repositories
{
    public class FacilityRepository : BaseRepository
    {
        public List<lkup_faclty> GetAll()
        {
            try
            {
                using ( var ctx = new ClinicDataContext(connString) )
                {

                    return ctx.lkup_faclty.ToList();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }

        public lkup_faclty GetFacility(decimal id)
        {

            try
            {
                using ( var ctx = new ClinicDataContext(connString) )
                {

                    return ctx.lkup_faclty.Where(v => v.faclty_id == id).FirstOrDefault();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }
        public lkup_faclty GetFacilityByOrganization(decimal id)
        {

            try
            {
                using ( var ctx = new ClinicDataContext(connString) )
                {

                    return ctx.lkup_faclty.Where(v => v.orgzn_id == id).FirstOrDefault();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }
        public int CreateFacility(lkup_faclty entity)
        {
            try
            {

                using ( var ctx = new ClinicDataContext(connString) )
                {
                    ctx.lkup_faclty.Add(entity);
                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }

        public int Update(lkup_faclty entity)
        {
            try
            {
                using ( var ctx = new ClinicDataContext(connString) )
                {
                    var currentSystem = ctx.lkup_faclty.FirstOrDefault(x => x.faclty_id == entity.faclty_id);
                    if ( currentSystem == null )
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    currentSystem.faclty_id = entity.faclty_id;
                    currentSystem.faclty_stat = entity.faclty_stat;
                    currentSystem.hlth_care_faclty = entity.hlth_care_faclty;
                    currentSystem.cntry = entity.cntry;
                    currentSystem.faclty_strt_eff_dt = entity.faclty_strt_eff_dt;
                    currentSystem.faclty_end_eff_dt = entity.faclty_end_eff_dt;
                    currentSystem.hlth_care_faclty_lvl = entity.hlth_care_faclty_lvl;
                    currentSystem.hlth_coordtr = entity.hlth_coordtr;
                    currentSystem.lattd = entity.lattd;
                    currentSystem.longtd = entity.longtd;
                    currentSystem.orgzn_id = entity.orgzn_id;
                    currentSystem.rec_updt_dt = entity.rec_updt_dt;
                    currentSystem.rec_updt_user_id_cd = entity.rec_updt_user_id_cd;
                    currentSystem.rgn = entity.rgn;
                    currentSystem.setlmt = entity.setlmt;
                    currentSystem.user_intrfc_sort_ord = entity.user_intrfc_sort_ord;


                    ctx.Entry(currentSystem).State = System.Data.Entity.EntityState.Modified;

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

