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
            var config = new Configuration();
            connString = config.GetConnection("reportServer");
        }

        public List<Catalog> GetAllReports()
        {
            
            var reportList = new List<Catalog>();
            using (var ctx = new ClinicDataContext(connString))
            {
             reportList=   ctx.Catalog.ToList();
            }

                return reportList;
        } 
    }
}
