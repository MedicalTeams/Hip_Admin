using HealthInformationProgram.Data.DataContext;
using HealthInformationProgram.Data.Tables.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInformationProgram.Data.Repositories.Reports
{
    public class CatalogRepository
    {
        private string connString;
        public CatalogRepository()
        {
            var connections = new Connections();
            connString = connections.GetReportConnection();
        }

        public List<Catalog> GetAllReports()
        {
            
            var reportList = new List<Catalog>();
            using (var ctx = ClinicDataContext.CreateForLoggedInUser())
            {
             reportList=   ctx.Catalog.ToList();
            }

                return reportList;
        } 
    }
}
