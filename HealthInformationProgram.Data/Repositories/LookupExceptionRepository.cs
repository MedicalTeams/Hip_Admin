using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HealthInformationProgram.Data.DataContext;
using HealthInformationProgram.Data.Tables;

namespace HealthInformationProgram.Data.Repositories
{
    public class LookupExceptionRepository:BaseRepository
    {
        public List<lkup_exceptions> GetAll()
        {
            try
            {
                using ( var ctx = new ClinicDataContext(connString) )
                {

                    return ctx.lkup_exceptions.ToList();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }

        public lkup_exceptions GetException(decimal id)
        {

            try
            {
                using ( var ctx = new ClinicDataContext(connString) )
                {

                    return ctx.lkup_exceptions.Where(v => v.err_cd == id).FirstOrDefault();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }
    }
}
