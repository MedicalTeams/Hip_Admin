using System.Linq;
using System.Text;
using HealthInformationProgram.Models;
using HealthInformationProgram.SessionData;

namespace HealthInformationProgram.Security
{
    public class UserLogin
    {
        public static bool LoginUser(string userName, string password)
        {
            bool IsValidLogin = false;
            
            using (MTIUserRolesEntityDataModel mtiUserRolesEntityDataModel = new MTIUserRolesEntityDataModel())
            {
                if (IsValidUserName(userName))
                {
                    user loggedInUser = (from users in mtiUserRolesEntityDataModel.users
                                         where (users.email != null) && (users.email.Trim().ToLower() == userName.Trim().ToLower())
                                         select users).FirstOrDefault();

                    if((loggedInUser != null) && (!string.IsNullOrEmpty(loggedInUser.password)) && 
                        (!string.IsNullOrWhiteSpace(loggedInUser.password)) &&
                        (loggedInUser.password == EncryptDecryptPassword(password.ToString())))
                    {
                        IsValidLogin = true;
                        SessionData.SessionData.Current.loggedInUser.LoggedInUserId = loggedInUser.userId;
                    }
                }
            }
            
            return IsValidLogin;
        }

        public static bool IsValidUserName(string userName)
        {
            bool isValidUserName = false;

            using (MTIUserRolesEntityDataModel mtiUserRolesEntityDataModel = new MTIUserRolesEntityDataModel())
            {
                var user = (from users in mtiUserRolesEntityDataModel.users
                                            where (users.email != null) && (users.email.Trim().ToLower() == userName.Trim().ToLower())
                                            select users).FirstOrDefault();

                if (user != null)
                {
                    isValidUserName = true;
                }
            }
            
            return isValidUserName;
        }

        private static int key = 129;
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