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
    public class RevisitRepository: BaseRepository
    {
        public List<lkup_rvisit> GetAll()
        {
         try
            {
                using ( var ctx = ClinicDataContext.CreateForLoggedInUser() )
                {

                    return ctx.lkup_rvisit.ToList();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }

        public lkup_rvisit GetRevisit(decimal id)
        {

            try
            {
                using ( var ctx = ClinicDataContext.CreateForLoggedInUser() )
                {

                    return ctx.lkup_rvisit.Where(v=>v.rvisit_id == id).FirstOrDefault();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }
        public int CreateRevisitConstant(lkup_rvisit entity)
        {
            try
            {

                using ( var ctx = ClinicDataContext.CreateForLoggedInUser() )
                {
                    ctx.lkup_rvisit.Add(entity);
                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }

        public int Update(lkup_rvisit entity)
        {
            try
            {
                using ( var ctx = ClinicDataContext.CreateForLoggedInUser() )
                {
                    var lookupRevisit = new lkup_rvisit();
                    lookupRevisit = ctx.lkup_rvisit.FirstOrDefault(x => x.rvisit_id == entity.rvisit_id);
                    if ( lookupRevisit == null )
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    // lookupRevisit.rvisit_id = entity.rvisit_id;
                    lookupRevisit.rvisit_descn = entity.rvisit_descn;
                    lookupRevisit.rec_updt_dt = entity.rec_updt_dt;
                    lookupRevisit.rec_updt_user_id_cd = entity.rec_updt_user_id_cd;
                    lookupRevisit.rvisit_ind = entity.rvisit_ind;


                    ctx.Entry(lookupRevisit).State = System.Data.Entity.EntityState.Modified;

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
