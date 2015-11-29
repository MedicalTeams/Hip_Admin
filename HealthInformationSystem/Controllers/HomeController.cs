using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
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
                    jsonString= GetJsonString( model);
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
            }
            return jsonString;
        }

        private static string GetJsonString<T>( List<T> model)
        {
            System.Web.Script.Serialization.JavaScriptSerializer jSearializer =
                   new System.Web.Script.Serialization.JavaScriptSerializer();
            var jsonString = jSearializer.Serialize(model);
            return jsonString;
        }

        [HttpPost]
        public ActionResult UpdateEntity(string keyValues, string entityName)
        {
            var jsonObject = JObject.Parse(keyValues);
            string jsonString = string.Empty;

            switch ( entityName )
            {
                case "RevisitModel":
                    UpdateRevisit(jsonObject);
                    break;
                case "DiagnosisModel":
                    UpdateDiagnosis(jsonObject);
                    break;
                case "SupplementalDiagnosisModel":
                    UpdateSupplementalDiagnosis(jsonObject);
                    break;
                case "SupplementalDiagnosisCategoryModel":
                    UpdateSupplementalDiagnosisCategory(jsonObject);
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
        private void UpdateDiagnosis(JObject jsonObject)
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


            repo.UpdateDiagnosis(model);

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
    
        
        
        
        
        
        
        //not currently being used 11-28-15
        private string GenerateValidationModel(string entityName)
        {
            Type type = Type.GetType("HealthInformationProgram.Models." + entityName);



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

        public class Generic<T>
        {
            public Generic() { }
        }
    }
}
