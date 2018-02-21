using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HealthInformationProgram.Data.DataContext;
using HealthInformationProgram.Data.Tables;


namespace HealthInformationProgram.Data.Repositories
{
    public class CurrentSystemInformationRepository : BaseRepository
    {
        public List<curr_sys_info> GetAll()
        {
            try
            {
                using ( var ctx = ClinicDataContext.CreateForLoggedInUser() )
                {

                    return ctx.curr_sys_info.ToList();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }

        public curr_sys_info GetCurrentSystemInfo(decimal id)
        {

            try
            {
                using ( var ctx = ClinicDataContext.CreateForLoggedInUser() )
                {

                    return ctx.curr_sys_info.Where(v => v.curr_sys_id == id).FirstOrDefault();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }
        public curr_sys_info GetCurrentSystemVersion()
        {
            try
            {
                using ( var ctx = ClinicDataContext.CreateForLoggedInUser() )
                {

                    return ctx.curr_sys_info.OrderByDescending(c=>c.dt_of_rlse).FirstOrDefault();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }
        public int CreateCurrentSystemInfo(curr_sys_info entity)
        {
            try
            {

                using ( var ctx = ClinicDataContext.CreateForLoggedInUser() )
                {
                    ctx.curr_sys_info.Add(entity);
                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }

        public int Update(curr_sys_info entity)
        {
            using (var ctx = ClinicDataContext.CreateForLoggedInUser())
            {
                var currentSystem = ctx.curr_sys_info.FirstOrDefault(x => x.curr_sys_id == entity.curr_sys_id);
                if (currentSystem == null)
                {
                    throw new Exception("Record doesn't exist and cannot be updated");
                }
                currentSystem.curr_sys_id = entity.curr_sys_id;
                currentSystem.itm_vrsn = entity.itm_vrsn;
                currentSystem.itm_descn = entity.itm_descn;
                currentSystem.dt_of_rlse = entity.dt_of_rlse;



                ctx.Entry(currentSystem).State = System.Data.Entity.EntityState.Modified;

                int result = ctx.SaveChanges();

                return result;
            }
        }
    }
}

