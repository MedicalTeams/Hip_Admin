using System;

namespace HealthInformationProgram.Data
{
    public static class ConnectionStringHelper
    {
        public static string GetConnectionStringName(string countryCode)
        {
            if (string.IsNullOrEmpty(countryCode))
                throw new ArgumentNullException(nameof(countryCode));

            return $"name=SqlAzure_Clinic_{countryCode}";
        }
    }
}
