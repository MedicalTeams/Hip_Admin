using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using HealthInformationProgram.Security;
using HealthInformationProgram.BAL;
using HealthInformationProgram.CustomAttributes;
using HealthInformationProgram.Models.ViewModels.Common;

namespace HealthInformationProgram.Models.ViewModels
{
    public class UsersAdministrationUsersViewModel : HIPAdminCommonViewModel
    {
        private List<user> _systemUsers = null;
        public List<user> SystemUsers
        {
            get
            {
                if (_systemUsers == null)
                {
                    using (MTIUserRolesEntityDataModel mtiUserRolesEntityDataModel = new MTIUserRolesEntityDataModel())
                    {
                        _systemUsers = (from users in mtiUserRolesEntityDataModel.users
                                        select users).ToList();
                    }
                }

                return _systemUsers;
            }
        }

        private user _selectedUser = null;
        public user SelectedUser
        {
            get
            {
                if (_selectedUser == null)
                {
                    _selectedUser = new user();
                    BindUserRolesForSelectedUser();
                }

                return _selectedUser;
            }
        }

        public void SetSelectedUser(Guid userGuid)
        {
            using (MTIUserRolesEntityDataModel mtiUserRolesEntityDataModel = new MTIUserRolesEntityDataModel())
            {
                if (userGuid != Guid.Empty)
                {
                    _selectedUser = (from users in mtiUserRolesEntityDataModel.users
                                     where (users.userId == userGuid)
                                     select users).FirstOrDefault();

                    if (_selectedUser != null)
                    {
                        BindUserRolesForSelectedUser();
                        UnEncryptedPassword = Security.UserLogin.EncryptDecryptPassword(_selectedUser.password);
                    }
                }
            }
        }

        private string _unEncryptedPassword = string.Empty;

        [Required]
        [PasswordRequirementsAttribute]
        [DisplayName("Password")]
        public string UnEncryptedPassword
        {
            get
            {
                return _unEncryptedPassword;
            }
            set
            {
                _unEncryptedPassword = value;
            }
        }

        List<BoundUserRole> _boundUserRolesListForSelectedUser = new List<BoundUserRole>();
        public List<BoundUserRole> BoundUserRolesListForSelectedUser
        {
            get
            {
                return _boundUserRolesListForSelectedUser;
            }
        }

        public void BindUserRolesForSelectedUser()
        {
            _boundUserRolesListForSelectedUser.Clear();

            using (MTIUserRolesEntityDataModel mtiUserRolesEntityDataModel = new MTIUserRolesEntityDataModel())
            {
                List<role> allRoles = (from allroles in mtiUserRolesEntityDataModel.roles
                                       select allroles).ToList();

                foreach (role userRole in allRoles)
                {
                    BoundUserRole boundUserRole = new BoundUserRole();
                    boundUserRole.RoleId = userRole.roleId;
                    boundUserRole.RoleName = userRole.roleName;

                    if ((SelectedUser != null) && (SelectedUser.userId != Guid.Empty))
                    {
                        userrole isUserInRole = (from alluserroles in mtiUserRolesEntityDataModel.userroles
                                                 where alluserroles.userId == SelectedUser.userId
                                                 where alluserroles.roleId == userRole.roleId
                                                 select alluserroles).FirstOrDefault();

                        if (isUserInRole != null)
                        {
                            boundUserRole.UserIsInRole = true;
                        }
                    }

                    _boundUserRolesListForSelectedUser.Add(boundUserRole);
                }
            }
        }

        public void SaveAddNewUser()
        {
            SaveSelectedUser();
        }

        public void SaveEditUser()
        {
            SaveSelectedUser();
        }

        public void SaveSelectedUser()
        {
            SelectedUser.password = UserLogin.EncryptDecryptPassword(UnEncryptedPassword);

            UserAdministrationLogic userAdministrationLogic = new UserAdministrationLogic();
            userAdministrationLogic.SaveUser(SelectedUser);
            userAdministrationLogic.SaveUserRoles(SelectedUser.userId, _boundUserRolesListForSelectedUser);
        }
    }
}