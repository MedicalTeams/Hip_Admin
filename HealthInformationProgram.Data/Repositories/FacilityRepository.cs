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
                    IdentityInsertOn<lkup_faclty>(ctx, entity);
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

        public int Update(lkup_faclty entity)
        {
            try
            {
                using ( var ctx = new ClinicDataContext(connString) )
                {
                    var currentFacility = ctx.lkup_faclty.FirstOrDefault(x => x.faclty_id == entity.faclty_id);
                    if ( currentFacility == null )
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    currentFacility.faclty_id = entity.faclty_id;
                    currentFacility.faclty_stat = entity.faclty_stat;
                    currentFacility.hlth_care_faclty = entity.hlth_care_faclty;
                    currentFacility.cntry = entity.cntry;
                    currentFacility.faclty_strt_eff_dt = entity.faclty_strt_eff_dt;
                    currentFacility.faclty_end_eff_dt = entity.faclty_end_eff_dt;
                    currentFacility.hlth_care_faclty_lvl = entity.hlth_care_faclty_lvl;
                    currentFacility.hlth_coordtr = entity.hlth_coordtr;
                    currentFacility.lattd = entity.lattd;
                    currentFacility.longtd = entity.longtd;
                    currentFacility.orgzn_id = entity.orgzn_id;
                    currentFacility.rec_updt_dt = entity.rec_updt_dt;
                    currentFacility.rec_updt_user_id_cd = entity.rec_updt_user_id_cd;
                    currentFacility.rgn = entity.rgn;
                    currentFacility.setlmt = entity.setlmt;
                    currentFacility.user_intrfc_sort_ord = entity.user_intrfc_sort_ord;


                    ctx.Entry(currentFacility).State = System.Data.Entity.EntityState.Modified;

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

