using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HealthInformationProgram.Models;
using HealthInformationProgram.Data.Repositories;
namespace HealthInformationProgram.Data
{
    public class FacilityHardwareData : BaseHipData
    {
        public List<FacilityHardwareInventoryModel> GetAllFacilityHardware()
        {
            var hardwareList = new List<FacilityHardwareInventoryModel>();
            var repo = new FacilityHardwareInventoryRespository();
            var facData = new FacilityData();
            var dataList = repo.GetAll();
            foreach ( var item in dataList )
            {
                var hardware = new FacilityHardwareInventoryModel();

                hardware.FacilityHardwareInventoryId = GetDataValue(item.faclty_hw_invtry_id);
                hardware.FacilityId = GetDataValue(item.faclty_id);
                hardware.Facility = facData.GetFacility(item.faclty_id).HealthCareFacility;
                hardware.ItemDescription = GetDataValue(item.itm_descn);
                hardware.MacAddress = GetDataValue(item.mac_addr);
                hardware.ApplicationVersion = GetDataValue(item.aplctn_vrsn);
                hardware.HardwareStatus = GetDataValue(item.hw_stat);
                hardware.CreateDate = GetDataValue(item.rec_creat_dt);
                hardware.CreatedBy = GetDataValue(item.rec_creat_user_id_cd);
                hardware.UpdateDate = GetDataValue(item.rec_updt_dt);
                hardware.UpdatedBy = GetDataValue(item.rec_updt_user_id_cd);

                hardwareList.Add(hardware);

            }


            return hardwareList;
        }
        public FacilityHardwareInventoryModel GetFacilityHardware(string id)
        {
            var hardware = new FacilityHardwareInventoryModel();
            var repo = new FacilityHardwareInventoryRespository();
            var dataItem = repo.GetFacilityHardware(Convert.ToDecimal(id));
            var facData = new FacilityData();

            hardware.FacilityHardwareInventoryId = GetDataValue(dataItem.faclty_hw_invtry_id);
            hardware.FacilityId = GetDataValue(dataItem.faclty_id);
            hardware.Facility = facData.GetFacility(dataItem.faclty_id).HealthCareFacility; hardware.ItemDescription = GetDataValue(dataItem.itm_descn);
            hardware.MacAddress = GetDataValue(dataItem.mac_addr);
            hardware.ApplicationVersion = GetDataValue(dataItem.aplctn_vrsn);
            hardware.HardwareStatus = GetDataValue(dataItem.hw_stat);
            hardware.CreateDate = GetDataValue(dataItem.rec_creat_dt);
            hardware.CreatedBy = GetDataValue(dataItem.rec_creat_user_id_cd);
            hardware.UpdateDate = GetDataValue(dataItem.rec_updt_dt);
            hardware.UpdatedBy = GetDataValue(dataItem.rec_updt_user_id_cd);

            return hardware;
        }
        public FacilityHardwareInventoryModel GetFacilityHardware(decimal id)
        {
            var hardware = new FacilityHardwareInventoryModel();
            var repo = new FacilityHardwareInventoryRespository();
            var dataItem = repo.GetFacilityHardware(id);
            var facData = new FacilityData();

            hardware.FacilityHardwareInventoryId = GetDataValue(dataItem.faclty_hw_invtry_id);
            hardware.FacilityId = GetDataValue(dataItem.faclty_id);
            hardware.Facility = facData.GetFacility(dataItem.faclty_id).HealthCareFacility;
            hardware.ItemDescription = GetDataValue(dataItem.itm_descn);
            hardware.MacAddress = GetDataValue(dataItem.mac_addr);
            hardware.ApplicationVersion = GetDataValue(dataItem.aplctn_vrsn);
            hardware.HardwareStatus = GetDataValue(dataItem.hw_stat);
            hardware.CreateDate = GetDataValue(dataItem.rec_creat_dt);
            hardware.CreatedBy = GetDataValue(dataItem.rec_creat_user_id_cd);
            hardware.UpdateDate = GetDataValue(dataItem.rec_updt_dt);
            hardware.UpdatedBy = GetDataValue(dataItem.rec_updt_user_id_cd);

            return hardware;
        }

        public int CreateFacilityHardwareInventory(FacilityHardwareInventoryModel model)
        {
           var repo = new FacilityHardwareInventoryRespository();
            var dataModel = new HealthInformationProgram.Data.Tables.faclty_hw_invtry();

            try
            {
                
                dataModel.faclty_id = Convert.ToDecimal(model.FacilityId);
                dataModel.aplctn_vrsn = model.ApplicationVersion;
                dataModel.hw_stat = model.HardwareStatus;
                dataModel.itm_descn = model.ItemDescription;
                dataModel.mac_addr = model.MacAddress;
                dataModel.rec_creat_dt = DateTime.Now;
                dataModel.rec_creat_user_id_cd = model.CreatedBy;
                dataModel.rec_updt_dt = DateTime.Now;
                dataModel.rec_updt_user_id_cd = model.UpdatedBy;

              var result=  repo.CreateFacilityHardware(dataModel);

              return result;
            }
            catch ( Exception ex )
            {
                throw ex;
            }

        }

        public int UpdateFacilityHardwareInventory(FacilityHardwareInventoryModel model)
        {
            var repo = new FacilityHardwareInventoryRespository();
            var dataModel = new HealthInformationProgram.Data.Tables.faclty_hw_invtry();

            try
            {
                dataModel.faclty_hw_invtry_id = Convert.ToDecimal(model.FacilityHardwareInventoryId);
                dataModel.faclty_id = Convert.ToDecimal(model.FacilityId);
                dataModel.aplctn_vrsn = model.ApplicationVersion;
                dataModel.hw_stat = model.HardwareStatus;
                dataModel.itm_descn = model.ItemDescription;
                dataModel.mac_addr = model.MacAddress;
                dataModel.rec_updt_dt = DateTime.Now;
                dataModel.rec_updt_user_id_cd = model.UpdatedBy;


                var returnCode = repo.UpdateFacilityHardware(dataModel);
                return returnCode;
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }
    }
}