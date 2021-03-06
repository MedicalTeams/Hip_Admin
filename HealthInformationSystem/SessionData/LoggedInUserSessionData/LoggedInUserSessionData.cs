﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HealthInformationProgram.Models;

namespace HealthInformationProgram.SessionObject
{
    public partial class SessionData
    {
        public enum Permissions
        {
            Nothing,
            Admin,
            ViewReports,
            ViewDataManagement,
            EditDataManagement,
            EditVisit
        }

        // Using this class to store logged in user data
        public class User
        {
            Guid _loggedInUserId = new Guid();

            public Guid LoggedInUserId
            {
                get
                {
                    return _loggedInUserId;
                }

                set
                {
                    _loggedInUserId = value;
                }
            }
            public string UserName
            {
                get;set;
            }

            public bool IsLoggedIn()
            {
                bool isLoggedIn = false;

                if(_loggedInUserId != Guid.Empty)
                {
                    isLoggedIn = true;
                }


                return isLoggedIn;
            }

            List<Permissions> _loggedInUsersPermissions = null;
            public List<Permissions> LoggedInUsersRoles
            {
                get
                {
                    _loggedInUsersPermissions = GetLoggedInUsersPermissions();
                    return _loggedInUsersPermissions;
                }
            }

            private List<Permissions> GetLoggedInUsersPermissions()
            {
                List<Permissions> userPermissions = new List<Permissions>();

                if (_loggedInUserId != Guid.Empty)
                {
                    using (MTIUserRolesEntityDataModel mtiUserRolesEntityDataModel = new MTIUserRolesEntityDataModel())
                    {
                        List<string> loggedInUsersRoles = (from rolesforuser in mtiUserRolesEntityDataModel.userroles
                                                           join rolesofuser in mtiUserRolesEntityDataModel.roles on rolesforuser.roleId equals rolesofuser.roleId
                                                           where rolesforuser.userId == _loggedInUserId
                                                           select rolesofuser.roleName).ToList();
                        
                        foreach(string userRole in loggedInUsersRoles)
                        {
                            if(userRole == "Admin")
                            {
                                userPermissions.Add(Permissions.Admin);
                            }
                            else if(userRole == "Report")
                            {
                                userPermissions.Add(Permissions.ViewReports);
                            }
                            else if (userRole == "DM View")
                            {
                                userPermissions.Add(Permissions.ViewDataManagement);
                            }
                            else if (userRole == "DM Edit")
                            {
                                userPermissions.Add(Permissions.EditDataManagement);
                            }
                            else if (userRole == "RawVisit Edit")
                            {
                                userPermissions.Add(Permissions.EditVisit);
                            }
                        }
                    }
                }

                return userPermissions;
            }

            public bool IsAuthroizedToViewDatabaseManagement()
            {
                bool isAuthorizedToEditThisReview = LoggedInUsersRoles.Contains(Permissions.Admin) ||
                    LoggedInUsersRoles.Contains(Permissions.ViewDataManagement) ||
                    LoggedInUsersRoles.Contains(Permissions.EditDataManagement);

                return isAuthorizedToEditThisReview;
            }

            public bool IsAuthroizedToEditDatabaseManagement()
            {
                bool isAuthorizedToEditThisReview = LoggedInUsersRoles.Contains(Permissions.Admin) ||
                    LoggedInUsersRoles.Contains(Permissions.EditDataManagement);

                return isAuthorizedToEditThisReview;
            }

            public bool IsAuthorizedToViewReports()
            {
                bool isAuthorizedToViewReports = LoggedInUsersRoles.Contains(Permissions.ViewReports) ||
                    LoggedInUsersRoles.Contains(Permissions.Admin);

                return isAuthorizedToViewReports;
            }

            public bool IsAuthorizedToEditVisits()
            {
                bool isAuthorizedToViewReports = LoggedInUsersRoles.Contains(Permissions.EditVisit) ||
                    LoggedInUsersRoles.Contains(Permissions.Admin);

                return isAuthorizedToViewReports;
            }

            public bool IsAuthorizedToEditClientManagement()
            {
                bool isAuthorizedToEditClientManagement = LoggedInUsersRoles.Contains(Permissions.Admin);

                return isAuthorizedToEditClientManagement;
            }

            public bool IsAuthorizedToAdminsterUsers()
            {
                bool isAuthorizedToEditUsers = LoggedInUsersRoles.Contains(Permissions.Admin);

                return isAuthorizedToEditUsers;
            }
        }
        private User _user = new User();
        public User LoggedInUser
        {
            get
            {
                return _user;
            }
        }
    }
}