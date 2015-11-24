using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HealthInformationProgram.Data.DataContext;
using HealthInformationProgram.Data.Tables;


namespace HealthInformationProgram.Data.Repositories
{
    public class LookupGenderRepository: BaseRepository
    {
        public List<lkup_gndr> GetAll()
        {
         try
            {
                using ( var ctx = new ClinicDataContext(connString) )
                {

                    return ctx.lkup_gndr.ToList();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }

        public lkup_gndr GetGender(decimal id)
        {

            try
            {
                using ( var ctx = new ClinicDataContext(connString) )
                {

                    return ctx.lkup_gndr.Where(v=>v.gndr_id == id).FirstOrDefault();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }
        public int CreateGender(lkup_gndr entity)
        {
            try
            {

                using ( var ctx = new ClinicDataContext(connString) )
                {
                    ctx.lkup_gndr.Add(entity);
                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }

        public int Update(lkup_gndr entity)
        {
            try
            {
                using ( var ctx = new ClinicDataContext(connString) )
                {
                    var lookupRevisit = ctx.lkup_gndr.FirstOrDefault(x => x.gndr_id == entity.gndr_id);
                    if ( lookupRevisit == null )
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    lookupRevisit.gndr_id = entity.gndr_id;
                    lookupRevisit.gndr_descn = entity.gndr_descn;
                    lookupRevisit.rec_updt_dt = entity.rec_updt_dt;
                    lookupRevisit.rec_updt_user_id_cd = entity.rec_updt_user_id_cd;
                    

                    ctx.Entry(lookupRevisit).State = System.Data.Entity.EntityState.Modified;

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


