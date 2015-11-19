using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HealthInformationProgram.Models;
using HealthInformationProgram.Data.Repositories;
namespace HealthInformationProgram.Data
{
    public class RevisitData
    {
        public List<RevisitModel> GetAllRevisits() 
        {
            var revisitRepo = new RevisitRepository();
            var revisitList = new List<RevisitModel>();
            foreach ( var visit in revisitRepo.GetAll() )
            {
                var visitView = new RevisitModel();

                visitView.RevisitId = visit.rvisit_id;
                visitView.SortOrder = visit.user_intrfc_sort_ord.Value;
                visitView.Indicator = visit.rvisit_ind;
                visitView.Description = visit.rvisit_descn;
                visitView.CreateDate = visit.rec_creat_dt;
                visitView.CreatedBy = visit.rec_creat_user_id_cd;
                visitView.UpdateDate = visit.rec_updt_dt;
                visitView.UpdatedBy = visit.rec_updt_user_id_cd;

                revisitList.Add(visitView);
            }
            return revisitList;
        }
    }
}