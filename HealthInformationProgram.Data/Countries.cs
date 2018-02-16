using System;
using System.Collections.Generic;

namespace HealthInformationProgram.Data
{
    public static class Countries
    {
        public static readonly IEnumerable<Country> SupportedCountries = new []
        {
            new Country("Bangladesh", "bd"),
            new Country("Uganda", "ug")
        };
    }
}
