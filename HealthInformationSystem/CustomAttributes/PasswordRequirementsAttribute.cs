using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HealthInformationProgram.Models;
using System.Text.RegularExpressions;

namespace HealthInformationProgram.CustomAttributes
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class PasswordRequirementsAttribute : ValidationAttribute
    {
        public PasswordRequirementsAttribute()
            : base("Password must be at least 12 characters long and contain at least one digit, one lowercase character, one upper case character and one special character")
        {
        }

        public override bool IsValid(object value)
        {
            bool isValid = true;

            // get the string from the request
            string password = (string)value;
            
            if (!Regex.Match(password, @"^[a-zA-Z0-9'!@#$%^&*.][\S]{12,50}$", RegexOptions.ECMAScript).Success)
            {
                isValid = false;
            }

            // return the response
            return isValid;
        }
    }
}