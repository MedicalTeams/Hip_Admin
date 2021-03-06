﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using HealthInformationProgram.Data.DataContext;
using HealthInformationProgram.Data.Tables;

namespace HealthInformationProgram.Data.Repositories
{
    public class DiagnosisRepository : BaseRepository
    {
        public List<lkup_diag> GetAll()
        {
            try
            {
                using (var ctx = new ClinicDataContext(connString))
                {

                    return ctx.lkup_diag.OrderBy(x => x.user_intrfc_sort_ord).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public lkup_diag GetDiagnosis(decimal id)
        {

            try
            {
                using (var ctx = new ClinicDataContext(connString))
                {

                    return ctx.lkup_diag.Where(v => v.diag_id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int CreateDiagnosis(lkup_diag entity)
        {
            try
            {

                using (var ctx = new ClinicDataContext(connString))
                {

                    IdentityInsertOn<lkup_diag>(ctx, entity);
                    ctx.Entry(entity).State = System.Data.Entity.EntityState.Added;
                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch (DbEntityValidationException ex)
            {
                string returnerror = string.Empty;
                foreach (var error in ex.EntityValidationErrors)
                {
                    foreach (var ve in error.ValidationErrors)
                    {
                        returnerror += string.Format("Error on property {0}, message {1}", ve.PropertyName, ve.ErrorMessage);
                    }
                }
               
                throw new DbEntityValidationException(returnerror);
            }
            catch (EntityException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(lkup_diag entity)
        {
            try
            {
                using (var ctx = new ClinicDataContext(connString))
                {
                    var lookupDiagnosis = ctx.lkup_diag.FirstOrDefault(x => x.diag_id == entity.diag_id);
                    if (lookupDiagnosis == null)
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    lookupDiagnosis.diag_id = entity.diag_id;
                    lookupDiagnosis.diag_descn = entity.diag_descn;
                    lookupDiagnosis.diag_abrvn = entity.diag_abrvn;
                    lookupDiagnosis.rec_updt_user_id_cd = entity.rec_updt_user_id_cd;
                    lookupDiagnosis.rec_updt_dt = entity.rec_updt_dt;
                    lookupDiagnosis.user_intrfc_sort_ord = entity.user_intrfc_sort_ord;
                    lookupDiagnosis.diag_stat = entity.diag_stat;
                    lookupDiagnosis.diag_strt_eff_dt = entity.diag_strt_eff_dt;
                    lookupDiagnosis.diag_end_eff_dt = entity.diag_end_eff_dt;

                    ctx.Entry(lookupDiagnosis).State = System.Data.Entity.EntityState.Modified;

                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
