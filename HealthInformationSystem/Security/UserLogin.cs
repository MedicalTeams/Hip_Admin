using System;
using System.Linq;
using System.Text;
using HealthInformationProgram.Data;
using HealthInformationProgram.Models;
using HealthInformationProgram.SessionObject;

namespace HealthInformationProgram.Security
{
    public class UserLogin
    {
        private static int key = 129;

        public static bool LoginUser(string countryCode, string userName, string password)
        {
            var country = Countries.SupportedCountries.FirstOrDefault(c => string.Equals(c.Code, countryCode, System.StringComparison.CurrentCultureIgnoreCase));

            if (country == null)
                throw new ArgumentException($"A country with the code of {countryCode} is not currently supported. Please select a country from the supported list and try again.", nameof(countryCode));

            bool IsValidLogin = false;
            
            using (var mtiUserRolesEntityDataModel = MTIUserRolesEntityDataModel.Create(countryCode))
            {
                user loggedInUser = (from users in mtiUserRolesEntityDataModel.users
                                     where users.email != null && users.email.Trim().ToLower() == userName.Trim().ToLower()
                                     select users).FirstOrDefault();

                if(loggedInUser != null && !string.IsNullOrEmpty(loggedInUser.password) && 
                    !string.IsNullOrWhiteSpace(loggedInUser.password) &&
                    loggedInUser.password == EncryptDecryptPassword(password.ToString()))
                {
                    IsValidLogin = true;
                    SessionData.Current.LoggedInUser.LoggedInUserId = loggedInUser.userId;
                    SessionData.Current.LoggedInUser.UserName = loggedInUser.email;
                    SessionData.Current.LoggedInUser.Country = country;
                }
            }
            
            return IsValidLogin;
        }

        public static string EncryptDecryptPassword(string textToEncrypt)
        {
            StringBuilder inSb = new StringBuilder(textToEncrypt);
            StringBuilder outSb = new StringBuilder(textToEncrypt.Length);
            char c;
            for (int i = 0; i < textToEncrypt.Length; i++)
            {
                c = inSb[i];
                c = (char)(c ^ key);
                outSb.Append(c);
            }
            return outSb.ToString();
        }
    }
}