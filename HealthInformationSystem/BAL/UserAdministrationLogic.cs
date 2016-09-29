using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HealthInformationProgram.Models;
using HealthInformationProgram.DAL;

namespace HealthInformationProgram.BAL
{
    public class UserAdministrationLogic
    {
        private UserAdministrationRepository _userAdministrationRepository = new UserAdministrationRepository();

        public user SaveUser(user userToSave)
        {
            using (MTIUserRolesEntityDataModel mtiUserRolesEntityDataModel = new MTIUserRolesEntityDataModel())
            {
                userToSave = _userAdministrationRepository.SaveUser(userToSave, mtiUserRolesEntityDataModel);
            }

            return userToSave;
        }

        public void SaveUserRoles(Guid userId, List<BoundUserRole> boundUserRolesListForSelectedUser)
        {
            using (MTIUserRolesEntityDataModel mtiUserRolesEntityDataModel = new MTIUserRolesEntityDataModel())
            {
                _userAdministrationRepository.DeleteAllRolesForUser(userId, mtiUserRolesEntityDataModel);

                foreach(BoundUserRole boundUserRole in boundUserRolesListForSelectedUser)
                {
                    if (boundUserRole.UserIsInRole == true)
                    {
                        _userAdministrationRepository.AddUserRole(userId, boundUserRole.RoleId, mtiUserRolesEntityDataModel);
                    }
                }
            }
        }

        public user GetUserFromEmail(string eMailAddress)
        {
            user userWithEmail = null;

            using (MTIUserRolesEntityDataModel mtiUserRolesEntityDataModel = new MTIUserRolesEntityDataModel())
            {
                userWithEmail = _userAdministrationRepository.GetUserFromEmail(eMailAddress, mtiUserRolesEntityDataModel);
            }

            return userWithEmail;
        }
    }
}