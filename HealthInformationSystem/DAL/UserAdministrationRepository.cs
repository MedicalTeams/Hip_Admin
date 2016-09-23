using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HealthInformationProgram.Models;
using HealthInformationProgram.SessionData;
using System.Data.Entity.Validation;

namespace HealthInformationProgram.DAL
{
    public class UserAdministrationRepository
    {
    
        public user GetUserFromEmail(string eMailAddress, MTIUserRolesEntityDataModel mtiUserRolesEntityDataModel)
        {
            user userFromEmail = null;

            if ((!String.IsNullOrEmpty(eMailAddress)) && (!String.IsNullOrWhiteSpace(eMailAddress)))
            {
                userFromEmail = (from user in mtiUserRolesEntityDataModel.users
                                where ((user.email != null) && (user.email.Trim().ToUpper() == eMailAddress.Trim().ToUpper()))
                                select user).FirstOrDefault();
            }

            return userFromEmail;
        }

        public user SaveUser(user userToSave, MTIUserRolesEntityDataModel mtiUserRolesEntityDataModel)
        {
            user existingUser = null;

            try
            {
                if (userToSave.userId != Guid.Empty)
                {
                    existingUser = (from user in mtiUserRolesEntityDataModel.users
                                    where user.userId == userToSave.userId
                                    select user).SingleOrDefault();
                }

                if (existingUser == null)
                {
                    userToSave.createDate = DateTime.Now;
                    userToSave.createdBy = SessionData.SessionData.Current.loggedInUser.LoggedInUserId;
                    mtiUserRolesEntityDataModel.users.Add(userToSave);
                }
                else
                {
                    existingUser.email = userToSave.email;
                    existingUser.firstname = userToSave.firstname;
                    existingUser.lastname = userToSave.lastname;
                    existingUser.password = userToSave.password;
                    existingUser.createDate = DateTime.Now;
                    existingUser.createdBy = SessionData.SessionData.Current.loggedInUser.LoggedInUserId;
                }

                mtiUserRolesEntityDataModel.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

            return GetUserFromEmail(userToSave.email, mtiUserRolesEntityDataModel);
        }

        public void DeleteAllRolesForUser(Guid userId, MTIUserRolesEntityDataModel mtiUserRolesEntityDataModel)
        {
            if (userId != Guid.Empty)
            {
                var existingUserRolesForUser = (from userrolesforuser in mtiUserRolesEntityDataModel.userroles
                                                where userrolesforuser.userId == userId
                                                select userrolesforuser);

                foreach(userrole existingUserRole in existingUserRolesForUser)
                {
                    mtiUserRolesEntityDataModel.userroles.Remove(existingUserRole);
                }

                mtiUserRolesEntityDataModel.SaveChanges();
            }
        }

        public userrole AddUserRole(Guid userId, Guid roleId, MTIUserRolesEntityDataModel mtiUserRolesEntityDataModel)
        {
            userrole addedUserRole = null;

            if ((userId != Guid.Empty) && (roleId != Guid.Empty))
            {
                addedUserRole = new userrole();
                addedUserRole.userId = userId;
                addedUserRole.roleId = roleId;
                addedUserRole.createDate = DateTime.Now;
                addedUserRole.createdBy = SessionData.SessionData.Current.loggedInUser.LoggedInUserId;

                mtiUserRolesEntityDataModel.userroles.Add(addedUserRole);

                mtiUserRolesEntityDataModel.SaveChanges();
            }

            return addedUserRole;
        }
    }
}