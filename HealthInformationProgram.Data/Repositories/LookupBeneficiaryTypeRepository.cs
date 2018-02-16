using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HealthInformationProgram.Data.DataContext;
using HealthInformationProgram.Data.Tables;


namespace HealthInformationProgram.Data.Repositories
{
    public class LookupBeneficiaryTypeRepository: BaseRepository
    {
        public List<lkup_bnfcry> GetAll()
        {
         try
            {
                using ( var ctx = ClinicDataContext.CreateForLoggedInUser() )
                {

                    return ctx.lkup_bnfcry.ToList();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }

        public lkup_bnfcry GetBeneficiaryType(decimal id)
        {

            try
            {
                using ( var ctx = ClinicDataContext.CreateForLoggedInUser() )
                {

                    return ctx.lkup_bnfcry.Where(v=>v.bnfcry_id == id).FirstOrDefault();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }
        public int CreateBeneficiaryType(lkup_bnfcry entity)
        {
            try
            {

                using ( var ctx = ClinicDataContext.CreateForLoggedInUser() )
                {
                    ctx.lkup_bnfcry.Add(entity);
                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }

        public int Update(lkup_bnfcry entity)
        {
            try
            {
                using ( var ctx = ClinicDataContext.CreateForLoggedInUser() )
                {
                    var lookupBeneficiary = ctx.lkup_bnfcry.FirstOrDefault(x => x.bnfcry_id == entity.bnfcry_id);
                    if (lookupBeneficiary == null )
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    lookupBeneficiary.bnfcry_id = entity.bnfcry_id;
                    lookupBeneficiary.rec_updt_dt = entity.rec_updt_dt;
                    lookupBeneficiary.rec_updt_user_id_cd = entity.rec_updt_user_id_cd;
                    

                    ctx.Entry(lookupBeneficiary).State = System.Data.Entity.EntityState.Modified;

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



