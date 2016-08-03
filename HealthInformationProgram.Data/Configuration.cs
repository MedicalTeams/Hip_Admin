using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace HealthInformationProgram.Data
{
    public class Configuration
    {
        public  string GetConnection(string connectionStringName)
        {
            string conn = string.Empty;

            conn = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            return conn;
        }
    }
}
