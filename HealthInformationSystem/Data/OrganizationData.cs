using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HealthInformationProgram.Models;

namespace HealthInformationProgram.Data
{
    public class OrganizationData
    {
        public List<OrganizationModel> GetAll()
        {
            var viewModelList = new List<OrganizationModel>();
            var repo = new Data.Repositories.OrganizationRepository();
            var dataList = repo.GetAll();
            foreach ( var item in dataList )
            {
                var viewModel = new OrganizationModel();
                viewModel.Organization= item.orgzn.ToString();
                viewModel.OrganizationId = item.orgzn_id.ToString();
                viewModel.OrganizationStatus = item.orgzn_stat.ToString();
                viewModel.SortOrder = item.user_intrfc_sort_ord.ToString();
                viewModel.StartEffectiveDate = item.orgzn_strt_eff_dt.ToString();
                viewModel.EndEffectiveDate = item.orgzn_end_eff_dt.ToString();
                viewModel.CreateDate = item.rec_creat_dt.ToString();
                viewModel.CreatedBy = item.rec_creat_user_id_cd.ToString();
                viewModel.UpdateDate = item.rec_updt_dt.ToString();
                viewModel.UpdatedBy = item.rec_updt_user_id_cd.ToString();

                viewModelList.Add(viewModel);
            }

            return viewModelList;
        }
        public OrganizationModel GetOrganization(string id)
        {
          
            var repo = new Data.Repositories.OrganizationRepository();
            var dataModel = repo.GetOrganization(Convert.ToDecimal(id));
            var viewModel = new OrganizationModel();

            viewModel.OrganizationId = dataModel.orgzn_id.ToString();
            viewModel.Organization = dataModel.orgzn.ToString();
            viewModel.OrganizationStatus = dataModel.orgzn_stat.ToString();
            viewModel.SortOrder = dataModel.user_intrfc_sort_ord.ToString();
            viewModel.StartEffectiveDate = dataModel.orgzn_strt_eff_dt.ToString();
            viewModel.EndEffectiveDate = dataModel.orgzn_end_eff_dt.ToString();
            viewModel.CreateDate = dataModel.rec_creat_dt.ToString();
            viewModel.CreatedBy = dataModel.rec_creat_user_id_cd.ToString();
            viewModel.UpdateDate = dataModel.rec_updt_dt.ToString();
            viewModel.UpdatedBy = dataModel.rec_updt_user_id_cd.ToString();


            return viewModel;
        }
    }
}