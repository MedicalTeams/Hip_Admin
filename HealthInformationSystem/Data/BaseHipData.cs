using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.Data
{
    public class BaseHipData
    {

        public string GetDataValue(string value)
        {
            if ( string.IsNullOrEmpty(value) )
            {
                return string.Empty;
            }
            else
            {
                return value.ToString();
            }
        }
        public string GetDataValue(Nullable<decimal> value)
        {
            if ( value.HasValue.Equals(null))
            {
                return string.Empty;
            }
            else
            {
                return value.ToString();
            }
        }
        public string GetDataValue(DateTime value)
        {
            if (value.Equals(null) )
            {
                return string.Empty;
            }
            else
            {
                return value.ToString();
            }
        }
    }
}