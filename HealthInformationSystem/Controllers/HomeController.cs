using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using HealthInformationProgram.Models;

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
            var model = new List<RevisitModel>();
            var data = new Data.RevisitData();
            model = data.GetAllRevisits();
            return View(model);
        }
        public ActionResult Report()
        {
            //ViewBag.Message = "Client Management";
            return View();
        }
        [HttpPost]
        public ActionResult GetEntity(string entityName)
        {
           
           //var tableHeaders =  GenerateValidationModel(entityName);
           var model = new List<RevisitModel>();
           var data = new Data.RevisitData();
           model = data.GetAllRevisits();
           System.Web.Script.Serialization.JavaScriptSerializer jSearializer =
                  new System.Web.Script.Serialization.JavaScriptSerializer();
           var jsonString = jSearializer.Serialize(model);
           return Json(jsonString);
        }

        [HttpPost]
        public ActionResult UpdateEntity(string keyValues, string entityName)
        {

            return View();
        }
       
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
            public Generic() {}
        }
    }
}
