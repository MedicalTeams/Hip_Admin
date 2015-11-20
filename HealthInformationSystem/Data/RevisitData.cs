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
        public RevisitModel GetRevisit(decimal id)
        {
            var revisitRepo = new RevisitRepository();
            var visitData = revisitRepo.GetRevisit(id);
            var visitView = new RevisitModel();

            visitView.Indicator = visitData.rvisit_ind;
            visitView.RevisitId = visitData.rvisit_id;
            visitView.SortOrder = visitData.user_intrfc_sort_ord.Value;
           
            visitView.Description = visitData.rvisit_descn;
            visitView.CreateDate = visitData.rec_creat_dt;
            visitView.CreatedBy = visitData.rec_creat_user_id_cd;
            visitView.UpdateDate = visitData.rec_updt_dt;
            visitView.UpdatedBy = visitData.rec_updt_user_id_cd;


            return visitView;

        }
        public int CreateRevisit(RevisitModel model)
        {
            var repo = new RevisitRepository();
            var dataModel = new HealthInformationProgram.Data.Tables.lkup_rvisit();

            dataModel.rvisit_ind = model.Indicator;
            dataModel.rvisit_id= model.RevisitId;
            dataModel.rvisit_descn = model.Description;
            dataModel.user_intrfc_sort_ord = model.SortOrder;
            dataModel.rec_creat_dt = DateTime.Now;
            dataModel.rec_creat_user_id_cd = "dbadmin"; //needs to get current user

            try
            {
             var returnCode=   repo.CreateRevisitConstant(dataModel);
             return returnCode;
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }
        public int UpdateRevisit(RevisitModel model)
        {
            var repo = new RevisitRepository();
            var dataModel = new HealthInformationProgram.Data.Tables.lkup_rvisit();
           
               
            dataModel.rvisit_ind = model.Indicator;
            dataModel.rvisit_id = model.RevisitId;
            dataModel.rvisit_descn = model.Description;
            dataModel.user_intrfc_sort_ord = model.SortOrder;
            dataModel.rec_creat_dt = DateTime.Now;
            dataModel.rec_creat_user_id_cd = "dbadmin"; //needs to get current user

            try
            {
               
                var returnCode = repo.Update(dataModel);
                return returnCode;
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }
    }
}