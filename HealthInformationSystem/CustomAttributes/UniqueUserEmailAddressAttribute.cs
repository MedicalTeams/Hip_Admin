using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HealthInformationProgram.Models;
using System.Text.RegularExpressions;
using HealthInformationProgram.BAL;

namespace HealthInformationProgram.CustomAttributes
{
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class UniqueUserEmailAddressAttribute : ValidationAttribute
    {
        public UniqueUserEmailAddressAttribute()
            : base("An existing user is already using this email address login")
        {
        }

        public override bool IsValid(object value)
        {
            bool isValid = true;

            user userToValidateEmailAddressOf = (user)value;

            if((userToValidateEmailAddressOf.userId == Guid.Empty) &&
                (!String.IsNullOrEmpty(userToValidateEmailAddressOf.email)) && 
                (!String.IsNullOrWhiteSpace(userToValidateEmailAddressOf.email)))
            {
                UserAdministrationLogic userAdministrationLogic = new UserAdministrationLogic();
                user userWithEmailExistsAlready = userAdministrationLogic.GetUserFromEmail(userToValidateEmailAddressOf.email);

                if(userWithEmailExistsAlready != null)
                {
                    isValid = false;
                }
            }

            return isValid;
        }
    }
}