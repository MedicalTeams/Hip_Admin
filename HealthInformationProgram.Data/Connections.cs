using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInformationProgram.Data
{
   public  class Connections
    {
        private string reportConnectionString = string.Empty;
        public Connections()
        {
            var config = new Configuration();
            reportConnectionString = config.GetConnection("reportServer");
        }

        public  string GetReportConnection()
        {
            return reportConnectionString;
        }
    }
}
