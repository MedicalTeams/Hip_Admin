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
    public class OrganizationRepository : BaseRepository
    {
        public List<lkup_orgzn> GetAll()
        {
         try
            {
                using ( var ctx = new ClinicDataContext(connString) )
                {

                    return ctx.lkup_orgzn.ToList();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }

        public lkup_orgzn GetOrganization(decimal id)
        {

            try
            {
                using ( var ctx = new ClinicDataContext(connString) )
                {

                    return ctx.lkup_orgzn.Where(v => v.orgzn_id == id).FirstOrDefault();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }
        public int CreateOragization(lkup_orgzn entity)
        {
            try
            {

                using ( var ctx = new ClinicDataContext(connString) )
                {
                    IdentityInsertOn<lkup_orgzn>(ctx, entity);
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

        public int Update(lkup_orgzn entity)
        {
            try
            {
                using ( var ctx = new ClinicDataContext(connString) )
                {
                    var lookupOrganization = ctx.lkup_orgzn.FirstOrDefault(x => x.orgzn_id == entity.orgzn_id);
                    if ( lookupOrganization == null )
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    lookupOrganization.orgzn_id = entity.orgzn_id;
                    lookupOrganization.orgzn_stat = entity. orgzn_stat;
                    lookupOrganization.user_intrfc_sort_ord = entity.user_intrfc_sort_ord;
                    lookupOrganization.rec_updt_user_id_cd = entity.rec_updt_user_id_cd;
                    lookupOrganization.rec_updt_dt = entity.rec_updt_dt;
                    lookupOrganization.orgzn_strt_eff_dt = entity.orgzn_strt_eff_dt;
                    lookupOrganization.orgzn_end_eff_dt = entity.orgzn_end_eff_dt;
                    

                    ctx.Entry(lookupOrganization).State = System.Data.Entity.EntityState.Modified;

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
