using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HealthInformationProgram.Models;

namespace HealthInformationProgram.Data
{
    public class HipSystemData:BaseHipData
    {
        public List<ExceptionModel> GetExceptionList()
        {
            var errorCodes = new List<ExceptionModel>();
            var repo = new HealthInformationProgram.Data.Repositories.LookupExceptionRepository();
            foreach ( var errorCode in repo.GetAll() )
            {

                var viewModel = new HealthInformationProgram.Models.ExceptionModel();

                viewModel.ErrorCode = errorCode.err_cd.ToString();
                viewModel.ExceptionDescription = errorCode.exception_descn;

                errorCodes.Add(viewModel);
            }

            return errorCodes;
        }

        public List<RawVisitModel> GetInvalidRawVisit()
        {
            var rawVisits = new List<RawVisitModel>();
            var repo = new HealthInformationProgram.Data.Repositories.RawVisitRepository();
            var exRepo = new HealthInformationProgram.Data.Repositories.LookupExceptionRepository();
            var excpList = exRepo.GetAll();

            foreach ( var raw in repo.GetAll().Where(v=>v.err_cd<0).OrderByDescending(v=>v.rec_creat_dt) )
            {

                var viewModel = new RawVisitModel();
                var exception =excpList.Where(e => e.err_cd == raw.err_cd).FirstOrDefault();
                
                viewModel.ErrorDescription = (exception != null) ? exception.exception_descn : "No error description in DB";
                viewModel.ErrorCode = GetDataValue(raw.err_cd);
                viewModel.VisitId = GetDataValue(raw.visit_uuid);
                viewModel.VisitJson = GetDataValue(raw.visit_json);
                viewModel.VisitStatus = GetDataValue(raw.visit_stat);
                viewModel.UpdatedBy = GetDataValue(raw.rec_updt_user_id_cd);
                viewModel.UpdateDate = GetDataValue(raw.rec_updt_dt);
                viewModel.CreatedBy = GetDataValue(raw.rec_creat_user_id_cd);
                viewModel.CreateDate = GetDataValue(raw.rec_creat_dt);

                rawVisits.Add(viewModel);
            }

            return rawVisits;

        }

        internal int UpdateRawvisit(RawVisitModel model)
        {
            var repo = new HealthInformationProgram.Data.Repositories.RawVisitRepository();
            var dataModel = new HealthInformationProgram.Data.Tables.raw_visit();
            try
            {
                dataModel.visit_uuid = model.VisitId.Trim();
                dataModel.visit_json = model.VisitJson;
                dataModel.visit_stat = model.VisitStatus;
                if ( String.IsNullOrEmpty(model.ErrorCode) == false )
                {
                    dataModel.err_cd = Convert.ToInt32(model.ErrorCode);
                }
                dataModel.rec_updt_dt = DateTime.Now;
                dataModel.rec_updt_user_id_cd = model.UpdatedBy;


                var returnCode = repo.Update(dataModel);

                return returnCode;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}