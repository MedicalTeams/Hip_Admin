using System.Configuration;

namespace HealthInformationProgram.Data
{
    public sealed class Connections
    {
        private string reportConnectionString = string.Empty;
        public Connections()
        {
            reportConnectionString = ConfigurationManager.ConnectionStrings["reportServer"].ConnectionString;
        }

        public  string GetReportConnection()
        {
            return reportConnectionString;
        }
    }
}
