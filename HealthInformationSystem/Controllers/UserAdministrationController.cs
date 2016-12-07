using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HealthInformationProgram.Models.ViewModels;

namespace HealthInformationProgram.Controllers
{
    public class UserAdministrationController : Controller
    {
        // GET: UserAdministration
        public ActionResult Index(UsersAdministrationUsersViewModel usersAdministrationUsersViewModel, string operation)
        {
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (usersAdministrationUsersViewModel == null)
            {
                usersAdministrationUsersViewModel = new UsersAdministrationUsersViewModel();
            }

            if ((operation != null) && (operation.Contains("UserAdministrationEditUser_")))
            {
                string selectedUserGuid = string.Format(operation.Replace("UserAdministrationEditUser_", ""));
                Guid userGuid = new Guid(selectedUserGuid);

                usersAdministrationUsersViewModel.SetSelectedUser(userGuid);
                usersAdministrationUsersViewModel.ModelState = HIPViewModelStates.EditUser;
                ModelState.Clear();
            }
            else if ((operation != null) && (operation == "AddNewUser"))
            {
                usersAdministrationUsersViewModel = new UsersAdministrationUsersViewModel();
                usersAdministrationUsersViewModel.ModelState = HIPViewModelStates.AddNewUser;
                ModelState.Clear();
            }
            else if ((operation != null) && (operation == "SaveAddNewUser"))
            {
                if (ViewData.ModelState.IsValid)
                {
                    usersAdministrationUsersViewModel.SaveAddNewUser();
                    return RedirectToAction("Users", "Home");
                }
            }
            else if ((operation != null) && (operation == "SaveEditUser"))
            {
                if (ViewData.ModelState.IsValid)
                {
                    usersAdministrationUsersViewModel.SaveEditUser();
                    return RedirectToAction("Users", "Home");
                }
            }

            return View(usersAdministrationUsersViewModel);
        }
    }
}