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
    public class FacilityHardwareInventoryRespository : BaseRepository
    {

        public List<faclty_hw_invtry> GetAll()
        {

            try
            {
                using ( var ctx = new ClinicDataContext(connString) )
                {

                    return ctx.faclty_hw_invtry.ToList();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }

        }
        public faclty_hw_invtry GetFacilityHardware(decimal id)
        {

            try
            {
                using ( var ctx = new ClinicDataContext(connString) )
                {

                    return ctx.faclty_hw_invtry.Where(f => f.faclty_hw_invtry_id == id).FirstOrDefault();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }

        }
        public faclty_hw_invtry GetFacilityHardwareByFacility(decimal facilityId)
        {

            try
            {
                using ( var ctx = new ClinicDataContext(connString) )
                {

                    return ctx.faclty_hw_invtry.Where(f => f.faclty_id == facilityId).FirstOrDefault();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }

        }
        public int CreateFacilityHardware(faclty_hw_invtry entity)
        {
            try
            {

                using ( var ctx = new ClinicDataContext(connString) )
                {
                    IdentityInsertOn<faclty_hw_invtry>(ctx, entity);
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
        public int UpdateFacilityHardware(faclty_hw_invtry entity)
        {
            try
            {

                using ( var ctx = new ClinicDataContext(connString) )
                {
                    var currentEntity = ctx.faclty_hw_invtry.FirstOrDefault(f => f.faclty_hw_invtry_id == entity.faclty_hw_invtry_id);
                    if ( currentEntity == null )
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }

                    
                    currentEntity.faclty_id = entity.faclty_id;
                    currentEntity.aplctn_vrsn = entity.aplctn_vrsn;
                    currentEntity.hw_stat = entity.hw_stat;
                    currentEntity.itm_descn = entity.itm_descn;
                    currentEntity.mac_addr = entity.mac_addr;
                    currentEntity.rec_updt_dt = entity.rec_updt_dt;
                    currentEntity.rec_updt_user_id_cd = entity.rec_updt_user_id_cd;
                    

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
