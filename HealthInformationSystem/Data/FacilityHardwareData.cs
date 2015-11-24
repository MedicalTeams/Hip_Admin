using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HealthInformationProgram.Models;
using HealthInformationProgram.Data.Repositories;
namespace HealthInformationProgram.Data
{
    public class FacilityHardwareData
    {
        public List<FacilityHardwareInventoryModel> GetAllFacilityHardware()
        {
            var hardwareList = new List<FacilityHardwareInventoryModel>();
            var repo = new FacilityHardwareInventoryRespository();

            var dataList = repo.GetAll();
            foreach ( var item in dataList )
            {
                var hardware = new FacilityHardwareInventoryModel();

                hardware.FacilityHardwareInventoryId = item.faclty_hw_invtry_id.ToString();
                hardware.FacilityId =  item.faclty_id.ToString();
                hardware.ItemDescription = item.itm_descn.ToString();
                hardware.MacAddress = item.mac_addr.ToString();
                hardware.ApplicationVersion = item.aplctn_vrsn.ToString();
                hardware.HardwareStatus = item.hw_stat.ToString();
                hardware.CreateDate = item.rec_creat_dt.ToString();
                hardware.CreatedBy = item.rec_creat_user_id_cd.ToString();
                hardware.UpdateDate = item.rec_updt_dt.ToString();
                hardware.UpdatedBy = item.rec_updt_user_id_cd.ToString();

                hardwareList.Add(hardware);

            }


            return hardwareList;
        }
        public FacilityHardwareInventoryModel GetFacilityHardware(string id)
        {
            var hardware = new FacilityHardwareInventoryModel();
            var repo = new FacilityHardwareInventoryRespository();
            var dataItem = repo.GetFacilityHardware(Convert.ToDecimal(id));


            hardware.FacilityHardwareInventoryId = dataItem.faclty_hw_invtry_id.ToString();
            hardware.FacilityId = dataItem.faclty_id.ToString();
            hardware.ItemDescription = dataItem.itm_descn.ToString();
            hardware.MacAddress = dataItem.mac_addr.ToString();
            hardware.ApplicationVersion = dataItem.aplctn_vrsn.ToString();
            hardware.HardwareStatus = dataItem.hw_stat.ToString();
            hardware.CreateDate = dataItem.rec_creat_dt.ToString();
            hardware.CreatedBy = dataItem.rec_creat_user_id_cd.ToString();
            hardware.UpdateDate = dataItem.rec_updt_dt.ToString();
            hardware.UpdatedBy = dataItem.rec_updt_user_id_cd.ToString();

            return hardware;
        }
    }
}