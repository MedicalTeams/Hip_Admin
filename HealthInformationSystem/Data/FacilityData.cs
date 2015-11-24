using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HealthInformationProgram.Models;
using HealthInformationProgram.Data.Repositories;

namespace HealthInformationProgram.Data
{
    public class FacilityData
    {
        public List<FacilityModel> GetFacilityList()
        {
            var facilityList = new List<FacilityModel>();
            var repo = new FacilityRepository();

            var facilities = repo.GetAll();
            foreach ( var fac in facilities )
            {
                var facilityView = new FacilityModel();

                facilityView.FacilityId = fac.faclty_id.ToString();
                facilityView.FacilityStatus = fac.faclty_stat.ToString();
                facilityView.Country = fac.cntry.ToString();
                facilityView.HealthCareFacility = fac.hlth_care_faclty.ToString();
                facilityView.HealthCareFacilityLevel = fac.hlth_care_faclty_lvl.ToString();
                facilityView.HealthCoordinator = fac.hlth_coordtr.ToString();
                facilityView.Latitude = fac.lattd.ToString();
                facilityView.Longitude = fac.longtd.ToString();
                facilityView.OrganizationId = fac.orgzn_id.ToString();
                facilityView.Region = fac.rgn.ToString();
                facilityView.Settlement = fac.setlmt.ToString();
                facilityView.SortOrder = fac.user_intrfc_sort_ord.ToString();
                facilityView.FacilityStartEffectiveDate =fac.faclty_strt_eff_dt.ToString();
                facilityView.FacilityEndEffectiveDate = fac.faclty_end_eff_dt.ToString();
                
                facilityView.CreateDate = fac.rec_creat_dt.ToString();
                facilityView.CreatedBy = fac.rec_creat_user_id_cd.ToString();
                facilityView.UpdateDate = fac.rec_updt_dt.ToString();
                facilityView.UpdatedBy = fac.rec_updt_user_id_cd.ToString();

                facilityList.Add(facilityView);
            }
            return facilityList;
        }
        public FacilityModel GetFacility(string id)
        {
            
            var repo = new FacilityRepository();
            var facilityView = new FacilityModel();
            var facility = repo.GetFacility(Convert.ToDecimal(id));
           

                facilityView.FacilityId = facility.faclty_id.ToString();
                facilityView.FacilityStatus = facility.faclty_stat.ToString();
                facilityView.Country = facility.cntry.ToString();
                facilityView.HealthCareFacility = facility.hlth_care_faclty.ToString();
                facilityView.HealthCareFacilityLevel = facility.hlth_care_faclty_lvl.ToString();
                facilityView.HealthCoordinator = facility.hlth_coordtr.ToString();
                facilityView.Latitude = facility.lattd.ToString();
                facilityView.Longitude = facility.longtd.ToString();
                facilityView.OrganizationId = facility.orgzn_id.ToString();
                facilityView.Region = facility.rgn.ToString();
                facilityView.Settlement = facility.setlmt.ToString();
                facilityView.SortOrder = facility.user_intrfc_sort_ord.ToString();
                facilityView.FacilityStartEffectiveDate = facility.faclty_strt_eff_dt.ToString();
                facilityView.FacilityEndEffectiveDate = facility.faclty_end_eff_dt.ToString();

                facilityView.CreateDate = facility.rec_creat_dt.ToString();
                facilityView.CreatedBy = facility.rec_creat_user_id_cd.ToString();
                facilityView.UpdateDate = facility.rec_updt_dt.ToString();
                facilityView.UpdatedBy = facility.rec_updt_user_id_cd.ToString();

           
            return facilityView;
        }
    }
}