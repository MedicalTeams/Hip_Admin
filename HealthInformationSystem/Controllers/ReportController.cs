using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;

namespace HealthInformationProgram.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index(string id)
        {

            TempData["Version"] = string.Empty;
            if (id == null)
            {
                id = "3.0 Morbidity";
            }
            GetReport(id);
            ViewBag.ReportName = id;
            return View();
        }

        public void /*ActionResult*/ GetReport(string name)
        {
            var connection = new HealthInformationProgram.Data.Connections();

            ReportViewer reportViewer = new ReportViewer();
            try
            {
                connection.GetReportConnection();
                var reportUri = System.Configuration.ConfigurationManager.AppSettings["reportServerUri"];
                var reportUser = System.Configuration.ConfigurationManager.AppSettings["reportUserName"];
                var reportUserPass = System.Configuration.ConfigurationManager.AppSettings["reportUserPass"];
                var reportUserDomain = System.Configuration.ConfigurationManager.AppSettings["reportUserDomain"];
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = System.Web.UI.WebControls.Unit.Percentage(100);
                reportViewer.Height = System.Web.UI.WebControls.Unit.Percentage(100);
                reportViewer.ServerReport.ReportServerCredentials = new Security.ReportServerCredentials(reportUser, reportUserPass, reportUserDomain);
                reportViewer.CssClass = "reportViewer";
                reportViewer.ShowToolBar = true;
                reportViewer.ShowParameterPrompts = true;
                reportViewer.ShowExportControls = true;
                reportViewer.AsyncRendering = true;
                reportViewer.ServerReport.ReportPath = String.Format("/{0}", name);
                reportViewer.ServerReport.ReportServerUrl = new Uri(reportUri);
            }
            catch (ReportViewerException rvex)
            {
                throw new Exception(String.Format("reviewer error {0}", rvex.Message));
            }
            ViewBag.ReportViewer = reportViewer;
            //GetReportsList();
            //return View("Report");
        }

    }
}