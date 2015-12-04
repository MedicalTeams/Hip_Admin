using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using HealthInformationProgram.Data;
using HealthInformationProgram.Models;
using Newtonsoft.Json.Linq;

namespace HealthInformationProgram.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Instruction:.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ClientManagement()
        {
            ViewBag.Message = "Client Management";
            return View();
        }
        public ActionResult DatabaseManagement()
        {
            //TODO: Set a default entity for initial load
            return View();
        }
        public ActionResult Report()
        {
            //ViewBag.Message = "Client Management";
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
            var view = GetPartialViewPath(modelName, model);
            return view;
        }

        private PartialViewResult GetPartialViewPath(string modelName, object model)
        {
            PartialViewResult viewResult = null;

            switch ( modelName )
            {
                case "DiagnosisModel":
                    viewResult = PartialView("~/Views/Home/CreateDiagnosis/_CreateDiagnosis.cshtml", model);
                    break;
                case "SupplementalDiagnosisModel":
                    viewResult = PartialView("~/Views/Home/CreateDiagnosis/_CreateSupplementalDiagnosis.cshtml", model);
                    break;
                case "SupplementalDiagnosisCategoryModel":
                    viewResult = PartialView("~/Views/Home/CreateDiagnosis/_CreateSupplementalCategoryDiagnosis.cshtml", model);
                    break;
                case "FacilityModel":
                    viewResult = PartialView("~/Views/Home/CreateFacility/_CreateFacility.cshtml", model);
                    break;
                case "FacilityHarwareInventoryModel":
                    viewResult = PartialView("~/Views/Home/CreateFacility/_CreateFacilityHardware.cshtml", model);
                    break;

            }
            return viewResult;
        }

        private static string GetEntityDefinition(string entityName)
        {
            string jsonString = string.Empty;
            var diagnosisData = new Data.DiagnosisData();
            switch ( entityName )
            {
                case "RevisitModel":
                    var model = new List<RevisitModel>();
                    var data = new Data.RevisitData();
                    model = data.GetAllRevisits();
                    jsonString = GetJsonString(model);
                    break;
                case "DiagnosisModel":
                    var diagnosisModel = new List<DiagnosisModel>();

                    diagnosisModel = diagnosisData.GetAllDiagnosis();
                    jsonString = GetJsonString(diagnosisModel);
                    break;
                case "SupplementalDiagnosisCategoryModel":
                    var categoryModel = new List<SupplementalDiagnosisCategoryModel>();
                    categoryModel = diagnosisData.GetAllSupplementalCategories();
                    jsonString = GetJsonString(categoryModel);

                    break;
                case "SupplementalDiagnosisModel":
                    var supplementalDiagnosis = new List<SupplementalDiagnosisModel>();

                    supplementalDiagnosis = diagnosisData.GetAllSupplementalDiagnosis();
                    jsonString = GetJsonString(supplementalDiagnosis);
                    break;

                case "OrganizationModel":
                    var orgList = new List<OrganizationModel>();
                    var orgData = new OrganizationData();

                    orgList = orgData.GetAll();
                    jsonString = GetJsonString(orgList);

                    break;
                case "FacilityModel":
                    var facilityList = new List<FacilityModel>();
                    var facilityData = new FacilityData();

                    facilityList = facilityData.GetFacilityList();
                    jsonString = GetJsonString(facilityList);
                    break;
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

            switch ( entityName )
            {
                case "RevisitModel":
                    UpdateRevisit(jsonObject);
                    break;
                case "DiagnosisModel":
                    SaveDiagnosis(jsonObject, isNew);
                    break;
                case "SupplementalDiagnosisModel":
                    UpdateSupplementalDiagnosis(jsonObject);
                    break;
                case "SupplementalDiagnosisCategoryModel":
                    UpdateSupplementalDiagnosisCategory(jsonObject);
                    break;
                case "FacilityModel":
                    UpdateFacility(jsonObject);
                    break;
                case "FacilityHardwareInventoryModel":
                    UpdateFacilityHardwareInventory(jsonObject);
                    break;

            }

            jsonString = GetEntityDefinition(entityName);
            return Json(jsonString);
        }



        private void UpdateRevisit(JObject jsonObject)
        {
            var model = new HealthInformationProgram.Models.RevisitModel();
            var repo = new HealthInformationProgram.Data.RevisitData();

            model.Description = (string) jsonObject["Description"];
            model.RevisitId = (string) jsonObject["RevisitId"];
            model.Indicator = (string) jsonObject["Indicator"];
            model.SortOrder = (string) jsonObject["SortOrder"];
            model.UpdateDate = DateTime.Now.ToString();
            model.UpdatedBy = "current user";


            repo.UpdateRevisit(model);

        }




        #region Diagnosis Methods

        [HttpGet]
        public ActionResult GetDiagnosisList()
        {
            // var diagDict = new Dictionary<string, string>();
            var selectList = new List<SelectListItem>();
            var repo = new HealthInformationProgram.Data.DiagnosisData();
            foreach ( var diag in repo.GetAllDiagnosis() )
            {
                selectList.Add(new SelectListItem() { Value = diag.DiagnosisId, Text = diag.DiagnosisDescription });

                //    diagDict.Add(diag.DiagnosisId, diag.DiagnosisDescription);
            }

            return Json(new { list = selectList }, JsonRequestBehavior.AllowGet);
            //  return Json(new { list = diagDict }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveDiagnosis(DiagnosisModel model)
        {

            var errorList = new Dictionary<string, string>();
            int result = 0;
            if ( ModelState.IsValid )
            {
                model.CreatedBy = "current user";
                model.UpdatedBy = "current user";
                var repo = new HealthInformationProgram.Data.DiagnosisData();
                result = repo.CreateDiagnosis(model);

            }
            //else
            //{
            //    foreach ( var error in ModelState )
            //    {
            //       var mess= ModelState[error.Key].Errors[0].ErrorMessage;

            //        errorList.Add(error.Key, mess);
            //    }
            //}
            return Json(new { rowsEffected = result });
            //return Json(new { rowsEffected = result, errors = errorList });
        }

        private void SaveDiagnosis(JObject jsonObject, bool isNew)
        {
            var model = new HealthInformationProgram.Models.DiagnosisModel();
            var repo = new HealthInformationProgram.Data.DiagnosisData();

            model.DiagnosisId = (string) jsonObject["DiagnosisId"];
            model.DiagnosisDescription = (string) jsonObject["DiagnosisDescription"];
            model.DiagnosisAbbreviation = (string) jsonObject["DiagnosisAbbreviation"];
            model.DiagnosisStatus = (string) jsonObject["DiagnosisStatus"];
            model.IcdCode = (string) jsonObject["IcdCode"];
            model.SortOrder = (string) jsonObject["SortOrder"];
            model.DiagnosisEffectiveStartDate = (string) jsonObject["DiagnosisEffectiveStartDate"];
            model.DiagnosisEffectiveEndDate = (string) jsonObject["DiagnosisEffectiveEndDate"];
            model.UpdateDate = DateTime.Now.ToString();
            model.UpdatedBy = "current user";

            if ( isNew )
            {
                repo.CreateDiagnosis(model);
            }
            else
            {
                repo.UpdateDiagnosis(model);
            }
        }

        #endregion

        #region Supplemental Diagnosis Methods

        [HttpPost]
        public ActionResult SaveSupplementalDiagnosis(SupplementalDiagnosisModel model)
        {
            int result = 0;

            if ( ModelState.IsValid )
            {
                model.CreatedBy = "current user";
                model.UpdatedBy = "current user";

                var data = new HealthInformationProgram.Data.DiagnosisData();
                result = data.CreateSupplementalDiagnosis(model);
            }
            return Json(new { rowsEffected = result });
        }
        private void UpdateSupplementalDiagnosis(JObject jsonObject)
        {
            var model = new HealthInformationProgram.Models.SupplementalDiagnosisModel();
            var repo = new HealthInformationProgram.Data.DiagnosisData();

            model.SupplementalDiagnosisId = (string) jsonObject["SupplementalDiagnosisId"];
            model.SupplementalDiagnosisDescription = (string) jsonObject["SupplementalDiagnosisDescription"];
            model.Status = (string) jsonObject["Status"];
            model.DiagnosisId = (string) jsonObject["DiagnosisId"];
            model.SupplementalDiagnosisEffectiveStartDate = (string) jsonObject["SupplementalDiagnosisEffectiveStartDate"];
            model.SupplementalDiagnosisEffectiveEndDate = (string) jsonObject["SupplementalDiagnosisEffectiveEndDate"];
            model.SortOrder = (string) jsonObject["SortOrder"];
            model.UpdateDate = DateTime.Now.ToString();
            model.UpdatedBy = "current user";


            repo.UpdateSupplementalDiagnosis(model);

        }
        #endregion

        #region Supplemental Diagnosis Category Methods
        [HttpPost]
        public ActionResult SaveSupplementalCategory(SupplementalDiagnosisCategoryModel model)
        {
            int result = 0;

            if ( ModelState.IsValid )
            {
                model.CreatedBy = "current user";
                model.UpdatedBy = "current user";

                var data = new HealthInformationProgram.Data.DiagnosisData();
                result = data.CreateDiagnosisCategory(model);
            }
            return Json(new { rowsEffected = result });
        }

        private void UpdateSupplementalDiagnosisCategory(JObject jsonObject)
        {
            var model = new HealthInformationProgram.Models.SupplementalDiagnosisCategoryModel();
            var repo = new HealthInformationProgram.Data.DiagnosisData();

            model.SupplementalDiagnosisCategoryId = (string) jsonObject["SupplementalDiagnosisCategoryId"];
            model.SupplementalDiagnosisCategoryType = (string) jsonObject["SupplementalDiagnosisCategoryType"];
            model.Status = (string) jsonObject["Status"];
            model.SortOrder = (string) jsonObject["SortOrder"];
            model.SupplementalDiagnosisCategoryEffectiveStartDate = (string) jsonObject["SupplementalDiagnosisCategoryEffectiveStartDate"];
            model.SupplementalDiagnosisCategoryEffectiveEndDate = (string) jsonObject["SupplementalDiagnosisCategoryEffectiveEndDate"];
            model.UpdateDate = DateTime.Now.ToString();
            model.UpdatedBy = "current user";


            repo.UpdateSupplementalDiagnosisCategory(model);

        }
        #endregion

        #region Facility Methods
        [HttpGet]
        public ActionResult GetOrganizationList()
        {
            var selectList = new List<SelectListItem>();
            var repo = new HealthInformationProgram.Data.OrganizationData();
            foreach ( var org in repo.GetAll() )
            {
                selectList.Add(new SelectListItem() { Value = org.OrganizationId, Text = org.Organization });

            }

            return Json(new { list = selectList }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult SaveFacility(FacilityModel model)
        {
            int result = 0;

            if ( ModelState.IsValid )
            {
                model.CreatedBy = "current user";
                model.UpdatedBy = "current user";

                var data = new HealthInformationProgram.Data.FacilityData();
                result = data.CreateFacility(model);
            }
            return Json(new { rowsEffected = result });
        }

        private void UpdateFacility(JObject jsonObject)
        {
            var model = new HealthInformationProgram.Models.FacilityModel();
            var repo = new HealthInformationProgram.Data.FacilityData();
            model.FacilityId = (string) jsonObject["FacilityId"];
            model.HealthCareFacility = (string) jsonObject["HealthCareFacility"];
            model.HealthCareFacilityLevel = (string) jsonObject["HealthCareFacilityLevel"];
            model.HealthCoordinator = (string) jsonObject["HealthCoordinator"];
            model.OrganizationId = (string) jsonObject["OrganizationId"];
            model.Settlement = (string) jsonObject["Settlement"];
            model.Country = (string) jsonObject["Country"];
            model.Region = (string) jsonObject["Region"];
            model.Latitude = (string) jsonObject["Latitude"];
            model.Longitude = (string) jsonObject["Longitude"];
            model.FacilityStatus = (string) jsonObject["FacilityStatus"];
            model.SortOrder = (string) jsonObject["SortOrder"];
            model.FacilityStartEffectiveDate = (string) jsonObject["FacilityStartEffectiveDate"];
            model.FacilityEndEffectiveDate = (string) jsonObject["FacilityEndEffectiveDate"];
            model.UpdateDate = DateTime.Now.ToString();
            model.UpdatedBy = "current user";


            repo.UpdateFacility(model);

        }
        #endregion

        #region Facility Hardware Inventory

        [HttpPost]
        public ActionResult SaveFacilityHardwareInventory(FacilityHardwareInventoryModel model)
        {
            int result = 0;

            if ( ModelState.IsValid )
            {
                model.CreatedBy = "current user";
                model.UpdatedBy = "current user";

                var data = new HealthInformationProgram.Data.FacilityData();
                result = data.CreateFacilityHardwareInventory(model);
            }
            return Json(new { rowsEffected = result });
        }

        private void UpdateFacilityHardwareInventory(JObject jsonObject)
        {
            var model = new HealthInformationProgram.Models.FacilityModel();
            var repo = new HealthInformationProgram.Data.FacilityData();

            model.HealthCareFacility = (string) jsonObject["HealthCareFacility"];
            model.HealthCareFacilityLevel = (string) jsonObject["HealthCareFacilityLevel"];
            model.HealthCoordinator = (string) jsonObject["HealthCoordinator"];
            model.OrganizationId = (string) jsonObject["OrganizationId"];
            model.Settlement = (string) jsonObject["Settlement"];
            model.Country = (string) jsonObject["Country"];
            model.Region = (string) jsonObject["Region"];
            model.Latitude = (string) jsonObject["Latitude"];
            model.Longitude = (string) jsonObject["Longitude"];
            model.FacilityStatus = (string) jsonObject["FacilityStatus"];
            model.SortOrder = (string) jsonObject["SortOrder"];
            model.FacilityStartEffectiveDate = (string) jsonObject["FacilityStartEffectiveDate"];
            model.FacilityEndEffectiveDate = (string) jsonObject["FacilityEndEffectiveDate"];
            model.UpdateDate = DateTime.Now.ToString();
            model.UpdatedBy = "current user";


            repo.UpdateFacilityHardwareInventory(model);
        }
        #endregion

        //not currently being used 11-28-15
        private string GenerateValidationModel(string entityName)
        {
            Type type = GetModelType(entityName);



            //var name = type.Name.Replace("Model", "ViewModel");
            //name = Char.ToLowerInvariant(name[0]) + name.Substring(1);

            //var validationModel = "var " + name + " = {\n";

            var validationModel = string.Empty;

            foreach ( var prop in type.GetProperties() )
            {
                object[] attrs = prop.GetCustomAttributes(true);
                if ( attrs == null || attrs.Length == 0 )
                    continue;

                string conds = "";

                foreach ( Attribute attr in attrs )
                {
                    if ( attr is DisplayAttribute )
                    {
                        conds += (attr as DisplayAttribute).Name + ",";
                    }
                    //if ( attr is MinLengthAttribute )
                    //{
                    //    conds += ", minLength: " + (attr as MinLengthAttribute).Length;
                    //}
                    else if ( attr is RequiredAttribute )
                    {
                        conds += ", required: true";
                    }
                    // ...
                }

                validationModel += conds;
                //if ( conds.Length > 0 )
                //    validationModel += String.Format("\t{0}: ko.observable().extend({{ {1} }}),\n", prop.Name, conds.Trim(',', ' '));
            }

            return validationModel;// +"};";
        }

        private static Type GetModelType(string entityName)
        {
            Type type = Type.GetType("HealthInformationProgram.Models." + entityName);
            return type;
        }

        public class Generic<T>
        {
            public Generic() { }
        }
    }
    public class MyGenericClass<T>
    { }
}
