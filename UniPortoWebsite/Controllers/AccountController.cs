﻿using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using UniPortoWebsite.Models;
using UniPortoWebsite.Manager;
using UniPortoWebsite.EF.Enums;
using NotyNotification;
using NotyNotification.Extension;
using System.Collections.Generic;

namespace UniPortoWebsite.Controllers
{
    /// <summary>
    /// Class AccountController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class AccountController : Controller
    {
        /// <summary>
        /// The sign in manager
        /// </summary>
        private ApplicationSignInManager _signInManager;
        /// <summary>
        /// The user manager
        /// </summary>
        private ApplicationUserManager _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        public AccountController()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="signInManager">The sign in manager.</param>
        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

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

        //
        // GET: /Account/Login
        /// <summary>
        /// Logins the specified return URL.
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns>ActionResult.</returns>
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        /// <summary>
        /// Logins the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns>Task&lt;ActionResult&gt;.</returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        //
        // GET: /Account/VerifyCode
        /// <summary>
        /// Verifies the code.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <param name="rememberMe">if set to <c>true</c> [remember me].</param>
        /// <returns>Task&lt;ActionResult&gt;.</returns>
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        /// <summary>
        /// Verifies the code.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;ActionResult&gt;.</returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        /// <summary>
        /// Registers this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [AllowAnonymous]
        public ActionResult Register()
        {
            var model = new RegisterViewModel();

            model.profile = new EF.Profile();
            model.profile.ProfileTypes = new SelectList(getProfileTypes(), "Value", "Text");

            return View(model);
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
        //
        // POST: /Account/Register
        /// <summary>
        /// Registers the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;ActionResult&gt;.</returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                if (model.profile.ProfileTypeID == (int)ProfileTypes.Student)
                {
                    var username = model.Email.Trim();
                    int index = username.IndexOf("@");
                    if (index > 0)
                        username = username.Substring(0, index);
                    user = new ApplicationUser { UserName = username, Email = model.Email, EmailConfirmed = false };

                }
                else
                {
                    user = new ApplicationUser { UserName = model.Email, Email = model.Email, EmailConfirmed = false };
                }
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var profile = new EF.Profile
                    {
                        FullName = model.profile.FullName,
                        SecurityID = user.Id,
                        Email = user.Email,
                        CreatedBy = "SYSTEM REGISTER",
                        CreatedOn = DateTime.Now,
                        ProfileTypeID = model.profile.ProfileTypeID,
                    };
                    profile.ProfileStatusID = model.profile.ProfileTypeID == (int)ProfileTypes.Student ? (int)ProfileStatuses.Active : (int)ProfileStatuses.Pending;
                    ProfileManager.AddProfile(profile);
                    if (profile.ProfileTypeID == (int)ProfileTypes.Student || profile.ProfileTypeID == (int)ProfileTypes.Alumni)
                    {
                        UserManager.AddToRole(user.Id, "Student/Alumni");
                    }
                    else if (profile.ProfileTypeID == (int)ProfileTypes.Instructor)
                    {
                        UserManager.AddToRole(user.Id, "Instructor");
                    }
                    else
                    {
                        UserManager.AddToRole(user.Id, "Companies");
                    }

                    string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("StudentEmailMessage", "Account");


                }
                AddErrors(result);
            }
            model.profile.ProfileTypes = new SelectList(getProfileTypes(), "Value", "Text");
            // If we got this far, something failed, redisplay form
            return View(model);
        }
        /// <summary>
        /// Registers the by admin.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> RegisterByAdmin(RegisterViewModel model)
        {
            var added = false;
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                if (model.profile.ProfileTypeID == (int)ProfileTypes.Student)
                {
                    var username = model.Email.Trim();
                    int index = username.IndexOf("@");
                    if (index > 0)
                        username = username.Substring(0, index);
                    user = new ApplicationUser { UserName = username, Email = model.Email, EmailConfirmed = false };

                }
                else
                {
                    user = new ApplicationUser { UserName = model.Email, Email = model.Email, EmailConfirmed = false };
                }
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var profile = new EF.Profile
                    {
                        FullName = model.profile.FullName,
                        SecurityID = user.Id,
                        Email = user.Email,
                        CreatedBy = "ADMIN REGISTER",
                        CreatedOn = DateTime.Now,
                        ProfileTypeID = model.profile.ProfileTypeID,
                        ProfileStatusID = (int)ProfileStatuses.Active
                    };

                    ProfileManager.AddProfile(profile);
                    if (profile.ProfileTypeID == (int)ProfileTypes.Student || profile.ProfileTypeID == (int)ProfileTypes.Alumni)
                    {
                        UserManager.AddToRole(user.Id, "Student/Alumni");
                    }
                    else if (profile.ProfileTypeID == (int)ProfileTypes.Instructor)
                    {
                        UserManager.AddToRole(user.Id, "Instructor");
                    }
                    else
                    {
                        UserManager.AddToRole(user.Id, "Companies");
                    }
                    added = true;



                }
            }


            return added;
        }
        //
        // GET: /Account/ConfirmEmail
        /// <summary>
        /// Students the email message.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        public ActionResult StudentEmailMessage()
        {
            return View();
        }
        /// <summary>
        /// Confirms the email.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="code">The code.</param>
        /// <returns>Task&lt;ActionResult&gt;.</returns>
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        /// <summary>
        /// Forgots the password.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        /// <summary>
        /// Forgots the password.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;ActionResult&gt;.</returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByEmailAsync(model.Email);
                if (user == null)
                { 
                    ModelState.AddModelError("", "This email does not exist");
                }
                else
                {
                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                    return RedirectToAction("ForgotPasswordConfirmation", "Account");
                }


            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        /// <summary>
        /// Forgots the password confirmation.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>ActionResult.</returns>
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;ActionResult&gt;.</returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "This email does not exist");
                // Don't reveal that the user does not exist
                // return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        /// <summary>
        /// Resets the password confirmation.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        /// <summary>
        /// Externals the login.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        /// <summary>
        /// Sends the code.
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <param name="rememberMe">if set to <c>true</c> [remember me].</param>
        /// <returns>Task&lt;ActionResult&gt;.</returns>
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        /// <summary>
        /// Sends the code.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;ActionResult&gt;.</returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        /// <summary>
        /// Externals the login callback.
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns>Task&lt;ActionResult&gt;.</returns>
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        /// <summary>
        /// Externals the login confirmation.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns>Task&lt;ActionResult&gt;.</returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        /// <summary>
        /// Logs the off.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Account");
        }

        //
        // GET: /Account/ExternalLoginFailure
        /// <summary>
        /// Externals the login failure.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }









        /// <summary>
        /// Checks the student username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        public ActionResult CheckStudentUsername(string username)
        {
            var res = UniversityStudentsManager.CheckTheStudet(username);
            if (res != null)
            {
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            return View();
        }
        /// <summary>
        /// Releases unmanaged resources and optionally releases managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        /// <summary>
        /// The XSRF key
        /// </summary>
        private const string XsrfKey = "XsrfId";

        /// <summary>
        /// Gets the authentication manager.
        /// </summary>
        /// <value>The authentication manager.</value>
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        /// <summary>
        /// Adds the errors.
        /// </summary>
        /// <param name="result">The result.</param>
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        /// <summary>
        /// Redirects to local.
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns>ActionResult.</returns>
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "PrivateProfile");
        }

        /// <summary>
        /// Class ChallengeResult.
        /// </summary>
        /// <seealso cref="System.Web.Mvc.HttpUnauthorizedResult" />
        internal class ChallengeResult : HttpUnauthorizedResult
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ChallengeResult"/> class.
            /// </summary>
            /// <param name="provider">The provider.</param>
            /// <param name="redirectUri">The redirect URI.</param>
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="ChallengeResult"/> class.
            /// </summary>
            /// <param name="provider">The provider.</param>
            /// <param name="redirectUri">The redirect URI.</param>
            /// <param name="userId">The user identifier.</param>
            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            /// <summary>
            /// Gets or sets the login provider.
            /// </summary>
            /// <value>The login provider.</value>
            public string LoginProvider { get; set; }
            /// <summary>
            /// Gets or sets the redirect URI.
            /// </summary>
            /// <value>The redirect URI.</value>
            public string RedirectUri { get; set; }
            /// <summary>
            /// Gets or sets the user identifier.
            /// </summary>
            /// <value>The user identifier.</value>
            public string UserId { get; set; }

            /// <summary>
            /// Enables processing of the result of an action method by a custom type that inherits from the <see cref="T:System.Web.Mvc.ActionResult" /> class.
            /// </summary>
            /// <param name="context">The context in which the result is executed. The context information includes the controller, HTTP content, request context, and route data.</param>
            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion

    }
}