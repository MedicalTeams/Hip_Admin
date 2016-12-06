using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace HealthInformationProgram.CustomExtensions
{
    //Extension methods must be defined in a static class
    public static class StringExtensions
    {
        public static bool IsNullOrEmptyOrWhiteSpace(this string str)
        {
            return (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str)) ? true : false;
        }

        public static bool IsNOTNullNorEmptyNorWhiteSpace(this string str)
        {
            return ((!string.IsNullOrEmpty(str)) && (!string.IsNullOrWhiteSpace(str))) ? true : false;
        }

        public static string MakeDBFriendly(this string str)
        {
            string cleanedUpString = string.Empty;

            if (str != null)
            {
                cleanedUpString = Regex.Replace(str, @"[^ '\w\.@-]", "", RegexOptions.None);
                cleanedUpString = str.Replace("'", "''").Trim('\0');
                cleanedUpString = cleanedUpString.Trim();
            }

            return cleanedUpString;
        }

        public static string TrimedUpperCase(this string str)
        {
            if (str != null)
            {
                str = str.Trim().ToUpper();
            }

            return str;
        }

        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}