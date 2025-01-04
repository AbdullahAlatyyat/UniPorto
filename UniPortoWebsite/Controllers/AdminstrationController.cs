// ***********************************************************************
// Assembly         : UniPortoWebsite
// Author           : RamiQ
// Created          : 01-07-2017
//
// Last Modified By : RamiQ
// Last Modified On : 01-07-2017
// ***********************************************************************
// <copyright file="AdminstrationController.cs" company="">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using GraduationProject.UniPortoWebsite.BL;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniPortoWebsite;
using UniPortoWebsite.Controllers;
using UniPortoWebsite.EF;
using UniPortoWebsite.EF.Enums;
using UniPortoWebsite.Manager;
using UniPortoWebsite.Models;
using UniPortoWebsite.Models.DashboredViewModel;

namespace Graduation.UniPortoWebsite.Controllers
{
    /// <summary>
    /// Class AdminstrationController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    [Authorize(Roles = "Admin")]

    public class AdminstrationController : Controller
    {
        /// <summary>
        /// The sign in manager
        /// </summary>
        private ApplicationSignInManager _signInManager;
        /// <summary>
        /// The user manager
        /// </summary>
        private ApplicationUserManager _userManager;
        // GET: Adminstration
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>System.Threading.Tasks.Task&lt;ActionResult&gt;.</returns>
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            try
            {
                AdminDashboredViewModel model = new AdminDashboredViewModel();
                var temp = ProfileManager.GetAllProfiles();
                //Gets Newest Users registered and saves them in the model
                model.NewestUsers = (from p in temp
                                     orderby p.CreatedOn descending
                                     select p).Take(10).ToList();
                //Counts the number of students & alumnis registered in the system and saves it in the model
                model.StudentsAndAlumniCount = temp.
                    Where(p => p.ProfileTypeID == (int)ProfileTypes.Student).Count() +
                    temp.Where(p => p.ProfileTypeID == (int)ProfileTypes.Alumni).Count();
                //Counts the number of companies registered in the system and saves it in the model
                model.CompaniesCount = temp.Where(p => p.ProfileTypeID == (int)ProfileTypes.Company).Count();
                //Counts the number of instructors registered in the system and saves it in the model
                model.instructorCount = temp.Where(p => p.ProfileTypeID == (int)ProfileTypes.Instructor).Count();
                //Counts the number of profiles that are pending for admin confirmation
                model.PendingCount = temp.Where(p => p.ProfileStatusID == (int)ProfileStatuses.Pending).Count();
                //Loop on all the pending profiles 
                model.RegisterPendingUsers = new List<Profile>();
                foreach (var item in temp.Where(p => p.ProfileStatusID == (int)ProfileStatuses.Pending).Take(10).ToList())
                {
                    //Checks if the profile is locked in order to exclude it from the list
                    var locked = await UserManager.GetLockoutEndDateAsync(item.SecurityID);
                    if (DateTime.Now >= locked)
                    {
                        model.RegisterPendingUsers.Add(item);
                    }
                }
                return View(model);
            }
            catch (Exception ex)
            {

                return View();
            }
          
        }

        // GET : Create User
        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        public ActionResult CreateUser()
        {
            RegisterViewModel model = new RegisterViewModel();
            model.profile = new Profile();
            model.profile.ProfileTypes = new SelectList(getProfileTypes(), "Value", "Text");
            return View(model);
        }
        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>System.Threading.Tasks.Task&lt;ActionResult&gt;.</returns>
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> CreateUser(RegisterViewModel model)
        {
            AccountController account = new AccountController(UserManager, SignInManager);
            var res = await account.RegisterByAdmin(model);
            if (res == true)
            {
                return RedirectToAction("ManageUsers", "Adminstration");
            }
            return View(account);
        }
        /// <summary>
        /// Gets the profile types.
        /// </summary>
        /// <returns>List&lt;SelectListItem&gt;.</returns>
        private List<SelectListItem> getProfileTypes()
        {
            var ProfileTypesList = new List<SelectListItem>();
            ProfileTypesList.Add(new SelectListItem
            {
                Value = ((int)ProfileTypes.Student).ToString(),
                Text = "Student"

            });
            ProfileTypesList.Add(new SelectListItem
            {
                Value = ((int)ProfileTypes.Alumni).ToString(),
                Text = "Alumni"

            });
            ProfileTypesList.Add(new SelectListItem
            {
                Value = ((int)ProfileTypes.Instructor).ToString(),
                Text = "Instructor"

            });
            ProfileTypesList.Add(new SelectListItem
            {
                Value = ((int)ProfileTypes.Company).ToString(),
                Text = "Company"

            });
            return ProfileTypesList;
        }
        private List<SelectListItem> getProfileStatus()
        {
            var ProfileTypesList = new List<SelectListItem>();
            ProfileTypesList.Add(new SelectListItem
            {
                Value = ((int)ProfileStatuses.Active).ToString(),
                Text = "Active"

            });
            ProfileTypesList.Add(new SelectListItem
            {
                Value = ((int)ProfileStatuses.Pending).ToString(),
                Text = "Pending"

            });
         
            return ProfileTypesList;
        }
        /// <summary>
        /// Manages the users.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        public ActionResult ManageUsers()
        {
            var r = ProfileManager.GetAllProfiles();
            return View(r);
        }
        /// <summary>
        /// Manages the users.
        /// </summary>
        /// <param name="profile">The profile.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult ManageUsers(Profile profile)
        {
            return View(profile);
        }
        /// <summary>
        /// Actives the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>JsonResult.</returns>
        [HttpPost]
        public JsonResult ActiveUser(int id)
        {
            var res = ProfileManager.ActiveRequest(id);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>System.Threading.Tasks.Task&lt;JsonResult&gt;.</returns>
        [HttpPost]
        public async System.Threading.Tasks.Task<JsonResult> DeleteUser(int id)
        {
            var res = ProfileManager.GetProfileById(id);
            var set = await UserManager.SetLockoutEndDateAsync(res.SecurityID, DateTime.Now.AddYears(5));
            if (set.Succeeded)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);

            }

        }
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var res = ProfileManager.GetProfileById(id);
            res.ProfileTypes = new SelectList(getProfileTypes(), "Value", "Text");
            res.ProfileStatus = new SelectList(getProfileStatus(), "Value", "Text");
            return View(res);
        }
        /// <summary>
        /// Edits the specified profile.
        /// </summary>
        /// <param name="profile">The profile.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult Edit(Profile profile)
        {
            var res = ProfileManager.UpdateProfileByAdmin(profile);
            if (res == true)
            {
                return RedirectToAction("ManageUsers", "Adminstration");
            }
            profile.ProfileTypes = new SelectList(getProfileTypes(), "Value", "Text");
            profile.ProfileStatus = new SelectList(getProfileStatus(), "Value", "Text");
            return View(res);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var res = ProfileManager.GetProfileById(id);
            return View(res);
        }
        /// <summary>
        /// Deletes the specified profile.
        /// </summary>
        /// <param name="profile">The profile.</param>
        /// <returns>ActionResult.</returns>
      //  [HttpPost]
        //public ActionResult Delete(Profile profile)
        //{
        //    var res = ProfileManager.DeleteProfileAndASPSecurity(profile.Id);
        //    if (res == true)
        //    {
        //        return RedirectToAction("ManageUsers", "Adminstration");
        //    }
        //    return View(res);
        //}
        /// <summary>
        /// Gets the sign in manager.
        /// </summary>
        /// <value>The sign in manager.</value>
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        /// <summary>
        /// Gets the user manager.
        /// </summary>
        /// <value>The user manager.</value>
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        /// <summary>
        /// Rejects the status request.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>JsonResult.</returns>
        public JsonResult RejectStatusRequest(int id)
        {
            var res = ProfileManager.DeleteRequest(id);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Accepts the status request.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>JsonResult.</returns>
        public JsonResult AcceptStatusRequest(int id)
        {

            var res = ProfileManager.AcceptStatusRequest(id);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Creates the company ad.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        public ActionResult CreateCompanyAd()
        {
            return View();
        }
        /// <summary>
        /// Creates the company ad.
        /// </summary>
        /// <param name="companyAd">The company ad.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult CreateCompanyAd(CompanyAd companyAd)
        {
            companyAd.CreatedOn = DateTime.Now;
            companyAd.CreatedBy = "ADMIN";
            var res = CompanyManager.AddCompanyAds(companyAd);
            if (res > 0)
            {
                return RedirectToAction("Index", "Adminstration");
            }
            else
            {
                return View();
            }
        }
        /// <summary>
        /// Sends the email by admin.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [ChildActionOnly]
        [HttpGet]
        public ActionResult SendEmailByAdmin()
        {
            EmailByAdminViewModel model = new EmailByAdminViewModel();
            return PartialView("SendEmailByAdmin", model);
        }
        /// <summary>
        /// Sends the email by admin.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>System.Threading.Tasks.Task&lt;ActionResult&gt;.</returns>
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> SendEmailByAdmin(EmailByAdminViewModel model)
        {
            ///TODO: NEED TO HANDEL THE VALIDATION 
            if (ModelState.IsValid)
            {
                EmailService service = new EmailService();
               await service.SendAsync(new Microsoft.AspNet.Identity.IdentityMessage
                {
                    Body = model.Message,
                    Destination=model.EmailTo,
                    Subject=model.Subject
                });
                return RedirectToAction("Index");
            }
            return PartialView("SendEmailByAdmin", model);
        }
    }
}