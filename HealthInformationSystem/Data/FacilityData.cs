using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HealthInformationProgram.Models;
using HealthInformationProgram.Data.Repositories;

namespace HealthInformationProgram.Data
{
    public class FacilityData:BaseHipData 
    {
        public List<FacilityModel> GetFacilityList()
        {
            var facilityList = new List<FacilityModel>();
            var repo = new FacilityRepository();
            var orgData = new OrganizationData();
            var facilities = repo.GetAll();
            foreach ( var fac in facilities )
            {
                var facilityView = new FacilityModel();
                

                facilityView.FacilityId = GetDataValue(fac.faclty_id);
                facilityView.FacilityStatus = GetDataValue(fac.faclty_stat);
                facilityView.Country = GetDataValue(fac.cntry);
                facilityView.HealthCareFacility = GetDataValue(fac.hlth_care_faclty);
                facilityView.HealthCareFacilityLevel = GetDataValue(fac.hlth_care_faclty_lvl);
                facilityView.HealthCoordinator = GetDataValue(fac.hlth_coordtr);
                facilityView.Latitude = GetDataValue(fac.lattd);
                facilityView.Longitude = GetDataValue(fac.longtd);
                facilityView.OrganizationId = GetDataValue(fac.orgzn_id);
                facilityView.OrganizationName = orgData.GetOrganization(fac.orgzn_id).Organization;    
                facilityView.Region = GetDataValue(fac.rgn);
                facilityView.Settlement = GetDataValue(fac.setlmt);
                facilityView.SortOrder = GetDataValue(fac.user_intrfc_sort_ord);
                facilityView.FacilityStartEffectiveDate =GetDataValue(fac.faclty_strt_eff_dt);
                facilityView.FacilityEndEffectiveDate = GetDataValue(fac.faclty_end_eff_dt);
                
                facilityView.CreateDate = GetDataValue(fac.rec_creat_dt);
                facilityView.CreatedBy = GetDataValue(fac.rec_creat_user_id_cd);
                facilityView.UpdateDate = GetDataValue(fac.rec_updt_dt);
                facilityView.UpdatedBy = GetDataValue(fac.rec_updt_user_id_cd);

                facilityList.Add(facilityView);
            }
            return facilityList;
        }
        public FacilityModel GetFacility(string id)
        {
            
            var repo = new FacilityRepository();
            var facilityView = new FacilityModel();
            var facility = repo.GetFacility(Convert.ToDecimal(id));
            var orgData = new OrganizationData();

                facilityView.FacilityId = GetDataValue(facility.faclty_id);
                facilityView.FacilityStatus = GetDataValue(facility.faclty_stat);
                facilityView.Country = GetDataValue(facility.cntry);
                facilityView.HealthCareFacility = GetDataValue(facility.hlth_care_faclty);
                facilityView.HealthCareFacilityLevel = GetDataValue(facility.hlth_care_faclty_lvl);
                facilityView.HealthCoordinator = GetDataValue(facility.hlth_coordtr);
                facilityView.Latitude = GetDataValue(facility.lattd);
                facilityView.Longitude = GetDataValue(facility.longtd);
                facilityView.OrganizationId = GetDataValue(facility.orgzn_id);
                facilityView.OrganizationName = orgData.GetOrganization(facility.orgzn_id).Organization;    
            facilityView.Region = GetDataValue(facility.rgn);
                facilityView.Settlement = GetDataValue(facility.setlmt);
                facilityView.SortOrder = GetDataValue(facility.user_intrfc_sort_ord);
                facilityView.FacilityStartEffectiveDate = GetDataValue(facility.faclty_strt_eff_dt);
                facilityView.FacilityEndEffectiveDate = GetDataValue(facility.faclty_end_eff_dt);

                facilityView.CreateDate = GetDataValue(facility.rec_creat_dt);
                facilityView.CreatedBy = GetDataValue(facility.rec_creat_user_id_cd);
                facilityView.UpdateDate = GetDataValue(facility.rec_updt_dt);
                facilityView.UpdatedBy = GetDataValue(facility.rec_updt_user_id_cd);

           
            return facilityView;
        }
        public FacilityModel GetFacility(decimal id)
        {

            var repo = new FacilityRepository();
            var facilityView = new FacilityModel();
            var facility = repo.GetFacility(id);
            var orgData = new OrganizationData();

            facilityView.FacilityId = GetDataValue(facility.faclty_id);
            facilityView.FacilityStatus = GetDataValue(facility.faclty_stat);
            facilityView.Country = GetDataValue(facility.cntry);
            facilityView.HealthCareFacility = GetDataValue(facility.hlth_care_faclty);
            facilityView.HealthCareFacilityLevel = GetDataValue(facility.hlth_care_faclty_lvl);
            facilityView.HealthCoordinator = GetDataValue(facility.hlth_coordtr);
            facilityView.Latitude = GetDataValue(facility.lattd);
            facilityView.Longitude = GetDataValue(facility.longtd);
            facilityView.OrganizationId = GetDataValue(facility.orgzn_id);
            facilityView.OrganizationName = orgData.GetOrganization(facility.orgzn_id).Organization;
            facilityView.Region = GetDataValue(facility.rgn);
            facilityView.Settlement = GetDataValue(facility.setlmt);
            facilityView.SortOrder = GetDataValue(facility.user_intrfc_sort_ord);
            facilityView.FacilityStartEffectiveDate = GetDataValue(facility.faclty_strt_eff_dt);
            facilityView.FacilityEndEffectiveDate = GetDataValue(facility.faclty_end_eff_dt);

            facilityView.CreateDate = GetDataValue(facility.rec_creat_dt);
            facilityView.CreatedBy = GetDataValue(facility.rec_creat_user_id_cd);
            facilityView.UpdateDate = GetDataValue(facility.rec_updt_dt);
            facilityView.UpdatedBy = GetDataValue(facility.rec_updt_user_id_cd);


            return facilityView;
        }

        public int CreateFacility(FacilityModel model)
        {
            
            var repo = new FacilityRepository();
            var dataModel = new HealthInformationProgram.Data.Tables.lkup_faclty();

            try
            {
                dataModel.hlth_care_faclty = model.HealthCareFacility;
                dataModel.hlth_care_faclty_lvl = model.HealthCareFacilityLevel;
                dataModel.hlth_coordtr = model.HealthCoordinator;
                dataModel.setlmt = model.Settlement;
                dataModel.cntry = model.Country;
                dataModel.rgn = model.Region;                
                dataModel.orgzn_id = Convert.ToDecimal(model.OrganizationId);
                dataModel.faclty_stat = model.FacilityStatus;
                dataModel.faclty_strt_eff_dt = Convert.ToDateTime(model.FacilityStartEffectiveDate);
                dataModel.faclty_end_eff_dt = Convert.ToDateTime(model.FacilityEndEffectiveDate);
                dataModel.user_intrfc_sort_ord = Convert.ToDecimal(model.SortOrder);
                dataModel.lattd = Convert.ToDecimal(model.Latitude);
                dataModel.longtd = Convert.ToDecimal(model.Longitude);

                dataModel.rec_creat_dt = DateTime.Now;
                dataModel.rec_creat_user_id_cd = model.CreatedBy;
                dataModel.rec_updt_dt = DateTime.Now;
                dataModel.rec_updt_user_id_cd = model.UpdatedBy;

                var returnCode = repo.CreateFacility(dataModel);
                return returnCode;
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }
    }
}