using HealthInformationProgram.Data;
using HealthInformationProgram.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthInformationProgram.Controllers
{
    public class ClientManagementController : Controller
    {
        // GET: ClientManagement
        public ActionResult Index()
        {
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Message = "Client Management";
            //  var sysInfo = new FacilityHardwareData();
            //  var app = sysInfo.GetCurrentApplicationVersion();
            //ViewBag.Version
            // TempData["Version"] = String.Format("Current application version is {0} released on {1}", app.ItemVersion, app.ReleaseDate); ;
            return View();
        }

        [HttpPost]
        public ActionResult GetEntity(string entityName)
        {

            var jsonString = GetEntityDefinition(entityName);
            return Json(jsonString);
        }
        [HttpPost]
        public ActionResult Create(string modelName)
        {
            Type type = GetModelType(modelName);
            var model = Activator.CreateInstance(type);
            //var view = GetPartialViewPath(modelName, model);
            var viewResult = PartialView("~/Views/ClientManagement/CreateFacility/_CreateFacilityHardware.cshtml", model);
            return viewResult;
        }

        private static Type GetModelType(string entityName)
        {
            Type type = Type.GetType("HealthInformationProgram.Models." + entityName);
            return type;
        }
        private static string GetEntityDefinition(string entityName)
        {
            string jsonString = string.Empty;
            var diagnosisData = new Data.DiagnosisData();
            switch (entityName)
            {
              
                case "FacilityHardwareInventoryModel":


                    var facilityHardwareList = new List<FacilityHardwareInventoryModel>();
                    var facilityHardwareData = new FacilityHardwareData();

                    facilityHardwareList = facilityHardwareData.GetAllFacilityHardware();
                     jsonString = GetJsonString(facilityHardwareList);
                    break;

            }
            return jsonString;
        }
        private static string GetJsonString<T>(List<T> model)
        {
            System.Web.Script.Serialization.JavaScriptSerializer jSearializer =
                   new System.Web.Script.Serialization.JavaScriptSerializer();
            var jsonString = jSearializer.Serialize(model);
            return jsonString;
        }
        [HttpPost]
        public ActionResult SaveEntity(string keyValues, string entityName, bool isNew)
        {
            var jsonObject = JObject.Parse(keyValues);
            string jsonString = string.Empty;

            switch (entityName)
            {
                
                case "FacilityHardwareInventoryModel":
                    UpdateFacilityHardwareInventory(jsonObject);
                    break;
                
            }

            jsonString = GetEntityDefinition(entityName);
            return Json(jsonString);
        }
        #region Facility Hardware Inventory

        [HttpGet]
        public ActionResult GetFacilityList()
        {
            var selectList = new List<SelectListItem>();
            var data = new HealthInformationProgram.Data.FacilityData();

            foreach (var fac in data.GetFacilityList())
            {
                selectList.Add(new SelectListItem() { Value = fac.FacilityId, Text = fac.HealthCareFacility });
            }


            return Json(new { list = selectList }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveFacilityHardwareInventory(FacilityHardwareInventoryModel model)
        {
            int result = 0;

            if (ModelState.IsValid)
            {
                model.CreatedBy = SessionData.SessionData.Current.loggedInUser.UserName;//"admin ui";
                model.UpdatedBy = SessionData.SessionData.Current.loggedInUser.UserName;// "admin ui";

                var data = new HealthInformationProgram.Data.FacilityHardwareData();
                result = data.CreateFacilityHardwareInventory(model);
            }
            return Json(new { rowsEffected = result });
        }

        private void UpdateFacilityHardwareInventory(JObject jsonObject)
        {
            var model = new HealthInformationProgram.Models.FacilityHardwareInventoryModel();
            var repo = new HealthInformationProgram.Data.FacilityHardwareData();

            model.FacilityId = (string)jsonObject["FacilityId"];
            model.ItemDescription = (string)jsonObject["ItemDescription"];
            model.MacAddress = (string)jsonObject["MacAddress"];
            model.ApplicationVersion = (string)jsonObject["ApplicationVersion"];
            model.HardwareStatus = (string)jsonObject["HardwareStatus"];
            model.FacilityHardwareInventoryId = (string)jsonObject["FacilityHardwareInventoryId"];
            model.UpdateDate = DateTime.Now.ToString();
            model.UpdatedBy = SessionData.SessionData.Current.loggedInUser.UserName;// "admin ui";


            repo.UpdateFacilityHardwareInventory(model);
        }
        #endregion

    }
}