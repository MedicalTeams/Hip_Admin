using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HealthInformationProgram.Data.DataContext;
using HealthInformationProgram.Data.Tables;

namespace HealthInformationProgram.Data.Repositories
{
    public class FacilityHardwareInventoryRespository:BaseRepository
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

                    return ctx.faclty_hw_invtry.Where(f=>f.faclty_hw_invtry_id == id).FirstOrDefault();
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
    }
}
