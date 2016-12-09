using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HealthInformationProgram.Data.DataContext;
using HealthInformationProgram.Data.Tables;
using System.Data.Entity.Validation;

namespace HealthInformationProgram.Data.Repositories
{
    public class OfficeVisitRepository : BaseRepository
    {
        public List<ov> GetAll()
        {
            try
            {
                using ( var ctx = new ClinicDataContext(connString) )
                {

                    return ctx.ovs.ToList();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }

        public ov GetOfficeVisit(decimal id)
        {

            try
            {
                using ( var ctx = new ClinicDataContext(connString) )
                {
                    return ctx.ovs.Where(v => v.ov_id == id).FirstOrDefault();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }
        public decimal? CreateOfficeVisit(ov entity)
        {
            try
            {
                

                using (var ctx = new ClinicDataContext(connString))
                {
                    ctx.ovs.Add(entity);
                    int result = ctx.SaveChanges();

                    return entity.ov_id;
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(ov entity)
        {
            try
            {
                using ( var ctx = new ClinicDataContext(connString) )
                {
                    var officeVisit = ctx.ovs.FirstOrDefault(x => x.rvisit_id == entity.rvisit_id);
                    if ( officeVisit == null )
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    officeVisit.faclty_id = entity.faclty_id;
                    officeVisit.gndr_id = entity.gndr_id;
                    officeVisit.bnfcry_id = entity.bnfcry_id;
                    officeVisit.opd_id = entity.opd_id;
                  
                    officeVisit.faclty_hw_invtry_id = entity.faclty_hw_invtry_id;

                    officeVisit.dt_of_visit = entity.dt_of_visit;
                    officeVisit.staff_mbr_name = entity.staff_mbr_name;
                    officeVisit.refl_in_ind = entity.refl_in_ind;
                    officeVisit.refl_out_ind = entity.refl_out_ind;
                    officeVisit.refl_out_ind = entity.refl_out_ind;
                    officeVisit.rvisit_id = entity.rvisit_id;
                    officeVisit.rec_creat_dt = entity.rec_creat_dt;
                    officeVisit.refl_out_ind = entity.refl_out_ind;
                    officeVisit.rec_updt_dt = entity.rec_updt_dt;
                    officeVisit.rec_updt_user_id_cd = entity.rec_updt_user_id_cd;

                    ctx.Entry(officeVisit).State = System.Data.Entity.EntityState.Modified;

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
