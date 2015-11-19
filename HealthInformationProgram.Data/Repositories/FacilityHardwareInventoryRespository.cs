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
    }
}
