using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HealthInformationProgram.Data.DataContext;
using HealthInformationProgram.Data.Tables;

namespace HealthInformationProgram.Data.Repositories
{
    public class RawVisitRepository : BaseRepository
    {
        public List<raw_visit> GetAll()
        {
            try
            {
                using ( var ctx = new ClinicDataContext(connString) )
                {

                    return ctx.raw_visit.ToList();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }

        public raw_visit GetRevisit(string id)
        {

            try
            {
                using ( var ctx = new ClinicDataContext(connString) )
                {

                    return ctx.raw_visit.Where(v => v.visit_uuid == id).FirstOrDefault();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }
        public int CreateRevisitConstant(raw_visit entity)
        {
            try
            {

                using ( var ctx = new ClinicDataContext(connString) )
                {
                    ctx.raw_visit.Add(entity);
                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }

        public int Update(raw_visit entity)
        {
            try
            {
                using ( var ctx = new ClinicDataContext(connString) )
                {
                    var rawVisit = ctx.raw_visit.FirstOrDefault(x => x.visit_uuid == entity.visit_uuid);
                    if ( rawVisit == null )
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    rawVisit.visit_uuid = entity.visit_uuid;
                    rawVisit.visit_stat = entity.visit_stat;
                    rawVisit.visit_json = entity.visit_json;
                    rawVisit.err_cd = entity.err_cd;
                    rawVisit.rec_updt_user_id_cd = entity.rec_updt_user_id_cd;


                    ctx.Entry(rawVisit).State = System.Data.Entity.EntityState.Modified;

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
