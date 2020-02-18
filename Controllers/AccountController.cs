using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Google.Authenticator;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SameDayServicezFinal.Models;
using SameDayServicezFinal.Utils;

namespace SameDayServicezFinal.Controllers
{
    [Authorize]

    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private string MainProfilePath = "/Uploads/ProfileImages/";
        private string MainProjectPath = "/Uploads/Projects/";
        private string MainResumePath = "/Uploads/ProfileResume/";
        private ApplicationDbContext db = new ApplicationDbContext();
        private const string GAuthPrivKey = "c8abd10610c54eebabbf2ed08e33eadc";

        public enum DatabaseTypeToRemove
        {
            Profile,
            ProjectDoument,
            ProfileID
        }


        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

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

        public async Task LoginTime(string email)
        {
            var user = await UserManager.FindByNameAsync(email);
            //  var user = db.LoginHistory.Where(x=> x.UserId == userName).FirstOrDefault();

            var model = new LoginHistory
            {
                UserId = user.UserName,
                LoginTime = DateTime.Now,
                LogoutTime = null,
            };
            db.LoginHistory.Add(model);
            db.SaveChanges();

        }
        public void LogOutTime(string email)
        {
            var model = db.LoginHistory.Where(u => u.UserId == email).OrderByDescending(u => u.Id).FirstOrDefault();
            if (model != null)
            {
                model.LogoutTime = DateTime.Now;
                db.SaveChanges();
            }


        }

        public async Task<ActionResult> CreateNewProject(string projectTitle,int type)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            if (user != null)
            {
                Project prj = new Project
                {
                    ProjectTitle = projectTitle,
                    ProjectsUsersId = userId,
                    CreationDate = DateTime.Now,
                    LastUpdated = DateTime.Now,
                    IsActive = false,
                    latitude = 0,
                    longitude = 0,
                    SelectedProjectCompensationPackage = type,
                    AcceptingContractors = false,
                    NumberOfContractorsNeeded = 0,
                    Duration = 0,
                    ProjectStatus = ProjectStatuses.Draft,
                    NumberOfDaysHelpIsNeeded = 0
                };

                db.Project.Add(prj);
                db.SaveChanges();

                await SaveProjectCompensationPackage(prj.ProjectsId, type);

                return Json(prj.ProjectsId, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return RedirectToAction("Login", "Account");
            }


        }


        public ActionResult Applicants()
        {
            return View();
        }


        public ActionResult EditCategories()
        {
            List<Subcategories> Model = new List<Subcategories>();
            Model = db.Subcategories.Select(p => p).ToList();

            return View(Model);
        }


        //
        // GET: /Account/Login
        [AllowAnonymous]
        public async Task<ActionResult> Login(bool IsContractor = true)
        {
             

            LoginViewModel model = new LoginViewModel();

            if (IsContractor)
            {

                model.Type = "Contractor";
                Utils.Extensions.IsInContractorMode = true;
                Utils.Extensions.IsInCustomerMode = false;
            }
            else
            {
                model.Type = "Customer";
                Utils.Extensions.IsInCustomerMode = true;
                Utils.Extensions.IsInContractorMode = false;
            }

            return View(model);
        }

        //
        //POST: //Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> LogOff()
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            user.Online = false;
            await UserManager.UpdateAsync(user);

            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            LogOutTime(User.Identity.Name);

            Session["UserName"] = null;
            FormsAuthentication.SignOut();           

            HttpCookie TwoFCookie = Request.Cookies["TwoFCookie"];
            if(TwoFCookie != null)
            {
                TwoFCookie.Expires = DateTime.Now.AddDays(-100);
                Response.Cookies.Add(TwoFCookie);
            }
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            FormsAuthentication.RedirectToLoginPage();

            return RedirectToAction("Index", "Home");
        }


       

        [HttpPost]
        [AllowAnonymous]

        public ActionResult TwoFactorAuthenticate()
        {
            var token = Request["CodeDigit"];
            TwoFactorAuthenticator TwoFacAuth = new TwoFactorAuthenticator();
            string UserUniqueKey = Session["UserUniqueKey"].ToString();


            bool isValid = TwoFacAuth.ValidateTwoFactorPIN(UserUniqueKey, token);
            LoginViewModel model = (LoginViewModel)Session["model"];
            string returnUrl = Session["returnUrl"].ToString();

           

            if (isValid)
            {
                HttpCookie TwoFCookie = new HttpCookie("TwoFCookie");
                string UserCode = Convert.ToBase64String(MachineKey.Protect(Encoding.UTF8.GetBytes(UserUniqueKey)));

                TwoFCookie.Values.Add("UserCode", UserCode);
                TwoFCookie.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(TwoFCookie);
                Session["IsValidTwoFactorAuthentication"] = true;

                if (returnUrl == "")
                {
                    return RedirectToAction("Portal", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                }
                else
                {
                    return RedirectToLocal(returnUrl);
                }


                //return RedirectToAction("UserProfile", "Login");
            }


           


            ViewBag.errorMessage = "Invalid login attempt.";
            return View("Error");
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {

          

            if (!ModelState.IsValid)
            {
                return View(model);
            }



            // Require the user to have a confirmed email before they can log on.
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user != null)
            {
                if (!await UserManager.IsEmailConfirmedAsync(user.Id))
                {
                    ViewBag.errorMessage = "You must have a confirmed email to log on.";
                    return View("Error");
                }
            }



            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
 
            if (result == SignInStatus.Success)
            {
                Session["model"] = model;
                Session["returnUrl"] = returnUrl;
                string message = "";
                bool status = false;
                //
                //check UserName and password form our database here
                
                string UserUniqueKey = (user.UserName + GAuthPrivKey);

                status = true;
                user.Online = true;
                Session["FullName"] = user.FirstName + " " + user.LastName;
                Session["UserName"] = user.UserName;
                Session["ID"] = user.Id;
                await UserManager.UpdateAsync(user);
                await LoginTime(model.Email);


                if (user.GAuthEnable)
                {
                    HttpCookie TwoFCookie = Request.Cookies["TwoFCookie"];
                    int k = 0;
                    if (TwoFCookie == null)
                    {
                        k = 1;
                    }
                    else
                    {

                        if (!string.IsNullOrEmpty(TwoFCookie.Values["UserCode"]))
                        {
                            string UserCodeE = TwoFCookie.Values["UserCode"].ToString();
                            string UserCodeD = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(UserCodeE)));


                            if (UserUniqueKey == UserCodeD)
                            {
                                FormsAuthentication.SetAuthCookie(Session["Username"].ToString(), false);
                                // ViewBag.Message = "Welcome to Mr. " + Session["Username"].ToString();
                                //return View("UserProfile");
                                // return RedirectToAction("UserProfile");
                                if (returnUrl == "")
                                {
                                    return RedirectToAction("Portal", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                                }
                                else
                                {
                                    return RedirectToLocal(returnUrl);
                                }

                            }
                            else
                            {
                                k = 1;
                            }


                        }
                    }

                    if (k == 1)
                    {

                        message = "Two Factor Authentication Verification using Google Authenticator";

                        //Two Factor Authentication Setup
                        TwoFactorAuthenticator TwoFacAuth = new TwoFactorAuthenticator();
                       
                        Session["UserUniqueKey"] = UserUniqueKey;

                        var setupInfo = TwoFacAuth.GenerateSetupCode("samedayservicez.com", user.UserName, UserUniqueKey, false, 300);
                       
                        ViewBag.BarcodeImageUrl = setupInfo.QrCodeSetupImageUrl;
                        ViewBag.SetupCode = setupInfo.ManualEntryKey;
                        ViewBag.Message = message;
                        ViewBag.Status = status;

                    }
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(Session["Username"].ToString(), true);
                    //ViewBag.Message = "Welcome to Mr. " + Session["Username"].ToString();
                    ////       return View("UserProfile");
                    //return RedirectToAction("UserProfile");

                    if (returnUrl == "")
                    {
                        return RedirectToAction("Portal", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                    }
                    else
                    {
                        return RedirectToLocal(returnUrl);
                    }
                }









            }

            switch (result)
            {

                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                   ViewBag.errorMessage = "Invalid login attempt. Please check your username or password";
                    return View("Error");
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
         
        }

        //
        // GET: /Account/VerifyCode
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
        [AllowAnonymous]
        public ActionResult Register()
        {
            //var states = Utils.Extensions.GetStatesList();

            //var model = new RegisterViewModel
            //{
            //    States = GetSelectListItems(states)
            //};
            RegisterViewModel model = new RegisterViewModel();

            return View(model);
        }

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<SelectListItem> elements)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            //     <option value="State Name">State Name</option>
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.Value,
                    Text = element.Text
                });
            }

            return selectList;
        }


        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]      
        public async Task<ActionResult> Register(RegisterViewModel model)
        {

            //var states = Utils.Extensions.GetStatesList();

            //model.States = GetSelectListItems(states);

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    IsInContractorMode = model.IsInContractorMode,
                    IsInCustomerMode = model.IsInCustomerMode,
                    PercentDone = 10,
                    DisplayName = model.FirstName + " " + model.LastName,
                    UserName = model.Email,
                    CreationDate = DateTime.Now,
                    ContactWithEmail = true,
                    ContactWithPhone = true
                };

                user.PercentDone = 6.666666666666667 * 4;

                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                   // await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");


                    ViewBag.Message = "Check your email and confirm your account, you must be confirmed "
                         + "before you can log in.";

                    return View("Info");



                    //return RedirectToAction("Portal", "Account", new { nr = true });
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ConfirmEmail
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
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);

                var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
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
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
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
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [HttpPost]
        [SessionTimeout]
        public async Task<ActionResult> Portal(PortalList model)
        {
            var states = Utils.Extensions.GetStatesList();
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());


            if (user != null && ModelState.IsValid)
            {

                user.FirstName = model.ApplicationUser.FirstName;
                user.MiddleName = model.ApplicationUser.MiddleName;
                user.LastName = model.ApplicationUser.LastName;
                user.Address = model.ApplicationUser.Address;
                user.City = model.ApplicationUser.City;
                user.State = model.ApplicationUser.State;
                user.ZipCode = model.ApplicationUser.ZipCode;
                user.BirthDate = model.ApplicationUser.BirthDate;
                user.Bio = model.ApplicationUser.Bio;
                user.IsInContractorMode = model.ApplicationUser.IsInContractorMode;
                user.IsInCustomerMode = model.ApplicationUser.IsInCustomerMode;
                user.PhoneNumber = model.ApplicationUser.PhoneNumber;
                user.State = model.ApplicationUser.State;
                user.States = GetSelectListItems(states);
                user.Professions = new List<SelectListItem>();
                user.SubProfessions = new List<SelectListItem>();
                user.InfoTabOpen = model.ApplicationUser.InfoTabOpen;
                user.longitude = model.ApplicationUser.longitude;
                user.latitude = model.ApplicationUser.latitude;
                user.DisplayName = model.ApplicationUser.DisplayName;
                user.Email = model.ApplicationUser.Email;
                user.ByTheHourRate = model.ApplicationUser.ByTheHourRate;



                if (model.ApplicationUser.JsonProfession != null)
                {
                    foreach (var item in model.ApplicationUser.JsonProfession.Trim(',').Split(','))
                    {

                        var m = long.Parse(item.Split('_')[0]);
                        var s = long.Parse(item.Split('_')[1]);

                        var MainCatName = db.Categories.Where(p => p.Id == m).Select(p => p.MainCatName).FirstOrDefault();
                        var SubCatName = db.Subcategories.Where(p => p.Id == s).Select(p => p.SubCatNames).FirstOrDefault();
                        var UserCategories = db.ContractorCustomerCategories.Where(p => p.ContractorCustomerId == userId && p.MainCatId == m && p.SubCatId == s).ToList();

                        if (UserCategories.Count() == 0)
                        {
                            ContractorCustomerCategories SelectedProfession = new ContractorCustomerCategories
                            {
                                ContractorCustomerId = userId,
                                MainCatId = long.Parse(item.Split('_')[0]),
                                SubCatId = long.Parse(item.Split('_')[1]),
                                MainCatName = MainCatName,
                                SubCatName = SubCatName
                            };

                            db.ContractorCustomerCategories.Add(SelectedProfession);
                            db.SaveChanges();
                        }

                    }
                }

                if (model.ApplicationUser.OldPassword != null && model.ApplicationUser.NewPassword != null)
                {
                    IdentityResult passwordresult = await UserManager.ChangePasswordAsync(userId, model.ApplicationUser.OldPassword, model.ApplicationUser.NewPassword);
                }

                IdentityResult result = await UserManager.UpdateAsync(user);


                user.UserProfessions = db.ContractorCustomerCategories.Where(p => p.ContractorCustomerId == userId).ToList();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

            PortalList portal = new PortalList
            {
                ApplicationUser = user
            };

            UpdatePortal(portal);

            return View(portal);

        }


        public async Task<ActionResult> UpdateProjectPortal()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            PortalList portal = new PortalList();
            portal.ApplicationUser = user;
            var pager = new Pager(db.Project.Where(p => p.IsActive == true && p.AcceptingContractors == true).Count(), 0);

            portal.Pager = pager;
            UpdatePortal(portal);

            return PartialView("_Projects", portal);
        }



        public async Task<ActionResult> GetContractorAppliedForJobsList(bool Hide)
        {
            PortalList portal = new PortalList();
            var users = db.Users.Select(p => p).ToList();
            var userId = User.Identity.GetUserId();          
            var currentuser = await UserManager.FindByIdAsync(User.Identity.GetUserId());
           
            currentuser.HideClosedAppliedFor = Hide;
            IdentityResult result = await UserManager.UpdateAsync(currentuser);

            portal.ApplicationUser = currentuser;

            var pp = from c in db.ProjectApplicants
                     join p in db.Project on c.ProjectsId equals p.ProjectsId
                     where c.ApplicantId == userId
                     orderby c.AppliedDate descending
                     select new
                     {
                         p.ProjectsId,
                         p.ProjectTitle,
                         c.AppliedDate,
                         c.AssinedToProject,
                         p.ProjectStatus

                     };

            foreach (var item in pp)
            {
                ProjectPosting post = new ProjectPosting
                {
                    CreationDate = item.AppliedDate,
                    ProjectId = item.ProjectsId,
                    ProjectTitle = item.ProjectTitle,
                    AssinedToProject = item.AssinedToProject,
                    ProjectStatus = item.ProjectStatus
                };

                if (currentuser.HideClosedAppliedFor)
                {
                    if (post.ProjectStatus != ProjectStatuses.Completed)
                    {
                        portal.ProjectApplies.Add(post);
                    }
                }
                else
                {
                    portal.ProjectApplies.Add(post);
                }

                

            }

            portal.ProjectApplies = portal.ProjectApplies.OrderByDescending(p => p.CreationDate).ThenBy(p => p.AssinedToProject).ThenBy(p => p.ProjectStatus).ToList();

            var pager = new Pager(portal.ProjectApplies.Count(),0);

            portal.Pager = pager;

            return PartialView("_ContractorAppliedJobsList", portal);
        }

        [HttpGet]
        public async Task<ActionResult> ReloadChat()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            PortalList portal = new PortalList();

            if (user != null)
            {
                Session["FullName"] = user.FirstName + " " + user.LastName;
                portal.ApplicationUser = user;
                portal.Conversations = GetChatHeads();
            }

            return PartialView("_ProfileChat", portal);
        }

        [HttpGet]
        [SessionTimeout]
        public async Task<ActionResult> Portal()
        {
            var states = Extensions.GetStatesList();
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            PortalList portal = new PortalList();
            var pager = new Pager(db.Project.Where(p => p.IsActive == true && p.AcceptingContractors == true && p.IsProjectPublished == true).Count(), 0);

            portal.Pager = pager;

            if (user != null)
            {
                Session["FullName"] = user.FirstName + " " + user.LastName;
                user.States = GetSelectListItems(states);
                user.Professions = new List<SelectListItem>();
                user.SubProfessions = new List<SelectListItem>();
                user.InfoTabOpen = "0";
                user.UserProfessions = db.ContractorCustomerCategories.Where(p => p.ContractorCustomerId == userId).ToList();
                user.Conversations = db.Conversations.Where(p => p.ConversationOwnerId == userId).ToList();





                portal.ApplicationUser = user;

                UpdatePortal(portal);



                //var contractors = db.Users.Where(p => p.IsInContractorMode == true).ToList();
                //foreach (var contractor in contractors)
                //{
                //    var pastprojects = db.Project.Where(p => p.ProjectsUsersId == contractor.Id).ToList();
                //    contractor.UserProfessions = db.ContractorCustomerCategories.Where(p => p.ContractorCustomerId == userId).ToList();


                //    ContractorSearchList contractorList = new ContractorSearchList
                //    {
                //        Contractor = contractor,
                //        PastProjects = pastprojects
                //    };
                //    portal.ContractorList.Add(contractorList);
                //}

            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

            return View(portal);
        }

        public async Task<ActionResult> GetJobAcceptedList(long ProjectId)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            ProjectAcceptance job = new ProjectAcceptance();

            if (user != null)
            {
                job.Project = db.Project.Where(p => p.ProjectsId == ProjectId).SingleOrDefault();
             
            }

            return PartialView("_JobMessage", job);
        }



       

        public void UpdatePortal(PortalList portal)
        {          

            var users = db.Users.Select(p => p).ToList();
            var userId = User.Identity.GetUserId();
            List<ProjectAssignment> ProjectAssignments = new List<ProjectAssignment>();
            var currentuser = db.Users.Where(p => p.Id == userId).SingleOrDefault();

            portal.Conversations = GetChatHeads();

           

            switch (portal.ApplicationUser.IsInContractorMode)
            {

                case true:
                    portal.Projects = db.Project.Where(p => p.IsActive == true && p.AcceptingContractors == true && p.IsProjectPublished == true && p.ProjectStatus != ProjectStatuses.Completed && p.ProjectsUsersId != userId).OrderByDescending(p => p.CreationDate).Take(10).ToList();
                    List<Project> prjGroup = new List<Project>();
                    var ProjectApplicants = db.ProjectApplicants.Where(p => p.ApplicantId == userId).ToList();
                    var isInArray = false;
                    foreach (var prj in portal.Projects)
                    {
                        isInArray = false;

                        foreach (var appl in ProjectApplicants)
                        {
                            if (appl.ProjectsId == prj.ProjectsId)
                            {
                                isInArray = true;
                                break;
                            }
                        }

                        if (isInArray == false)
                        {
                            prjGroup.Add(prj);
                        }

                       
                    }
                   
                    portal.ProjectAcceptance = db.ProjectAcceptance.Where(p => p.ContractorId == userId && p.Read == false).ToList();
                    foreach (var item in portal.ProjectAcceptance)
                    {
                        item.Project = db.Project.Where(p => p.ProjectsId == item.ProjectId).SingleOrDefault();
                    }
                  

                    portal.Projects = prjGroup;
                    break;

                case false:
                    var Inprogress = db.Project.Where(p => p.ProjectsUsersId == userId && p.ProjectStatus == ProjectStatuses.InProgress).OrderByDescending(p => p.LastUpdated).ToList();
                    var Published = db.Project.Where(p => p.ProjectsUsersId == userId && p.ProjectStatus == ProjectStatuses.Published).OrderByDescending(p => p.LastUpdated).ToList();
                    var Draft = db.Project.Where(p => p.ProjectsUsersId == userId && p.ProjectStatus == ProjectStatuses.Draft).OrderByDescending(p => p.LastUpdated).ToList();
                    var Completed = db.Project.Where(p => p.ProjectsUsersId == userId && p.ProjectStatus == ProjectStatuses.Completed).OrderByDescending(p => p.LastUpdated).ToList();

                    portal.Projects.AddRange(Inprogress);
                    portal.Projects.AddRange(Published);
                    portal.Projects.AddRange(Draft);
                    portal.Projects.AddRange(Completed);
                 
                    

                    foreach (var item in portal.Projects)
                    {
                        var applicants = db.ProjectApplicants.Where(p => p.ProjectsId == item.ProjectsId && p.AssinedToProject == false && p.Rejected == false).ToList();

                        if (applicants.Count > 0)
                        {
                            item.HasApplicants = true;
                            item.ApplicantCount = applicants.Count;
                        }
                    }



                    break;
            }

            var pp = from c in db.ProjectApplicants
                     join p in db.Project on c.ProjectsId equals p.ProjectsId
                     where c.ApplicantId == userId
                     orderby c.AppliedDate descending
                     select new
                     {
                         p.ProjectsId,
                         p.ProjectTitle,
                         c.AppliedDate,
                         c.AssinedToProject,
                         p.ProjectStatus

                     };

            foreach (var item in pp)
            {
                ProjectPosting post = new ProjectPosting
                {
                    CreationDate = item.AppliedDate,
                    ProjectId = item.ProjectsId,
                    ProjectTitle = item.ProjectTitle,
                    AssinedToProject = item.AssinedToProject,
                    ProjectStatus = item.ProjectStatus
                };

                if (currentuser.HideClosedAppliedFor)
                {
                    if (post.ProjectStatus != ProjectStatuses.Completed)
                    {
                        portal.ProjectApplies.Add(post);
                    }
                }
                else
                {
                    portal.ProjectApplies.Add(post);
                }

              

            }

            portal.ProjectApplies = portal.ProjectApplies.OrderByDescending(p => p.CreationDate).ThenBy(p => p.AssinedToProject).ThenBy(p => p.ProjectStatus).ToList();


            foreach (var project in portal.Projects)
            {
                project.DurationList = Extensions.GetDurationList();

                // add the project assignments to the object
                project.ProjectAssignments = new List<ProjectAssignment>();
                ProjectAssignments = db.ProjectAssignment.Where(p => p.ProjectId == project.ProjectsId && p.ProjectOwner == userId).ToList();


                foreach (var Assignment in ProjectAssignments)
                {
                    var profile = users.Where(i => i.Id == Assignment.UsersId).SingleOrDefault();
                    // var projectOwnerName = users.Where(i => i.Id == Assignment.UsersId).SingleOrDefault();
                    //  var pp = db.ContractorCustomerCategories.Where(p => p.ContractorCustomerId == Assignment.UsersId);
                    //Assignment.ProfileProfessions = db.ContractorCustomerCategories.Where(p => p.ContractorCustomerId == userId).ToList();


                    // List<Project> ProfilePastProjects = new List<Project>();
                    // ProfilePastProjects = db.Project.Where(p => p.ProjectsUsersId == Assignment.UsersId).ToList(); //.Select(x => new Project { ProjectTitle = x.ProjectTitle, CreationDate = x.CreationDate }).ToList(); 

                    Assignment.ProfileImage = profile.ProfileImage;
                    Assignment.ProfileDisplayName = profile.DisplayName;
                    //Assignment.ProfileBios = profile.Bio;
                    //Assignment.ProfileRating = profile.Rating;
                    //Assignment.ByTheHourRate = profile.ByTheHourRate;
                    //Assignment.ProfilePastProjects = ProfilePastProjects;
                    //Assignment.ProjectOwnerName = projectOwnerName.DisplayName;
                    project.ProjectAssignments.Add(Assignment);
                }


                // add the Project Compensation Package to the object
                var ProjectCompensationPackage = db.ProjectCompensationPackage.Where(p => p.ProjectId == project.ProjectsId).SingleOrDefault();
                if (ProjectCompensationPackage != null)
                {
                    project.SelectedProjectCompensationPackage = ProjectCompensationPackage.ProjectCompensationType;
                    project.ByTheHourRate = ProjectCompensationPackage.ByTheHourRate;
                    project.ByTheProjectRate = ProjectCompensationPackage.ByTheProjectRate;
                    project.EndingBidDate = ProjectCompensationPackage.EndingBidDate;
                    project.EndingBidRate = ProjectCompensationPackage.EndingBidRate;
                    project.FloatingBidRate = ProjectCompensationPackage.FloatingBidRate;
                    project.StartingBidDate = ProjectCompensationPackage.StartingBidDate;
                    project.StartingBidRate = ProjectCompensationPackage.StartingBidRate;
                }

                //add the Project Job Categories to the object
                project.ProjectCategories = db.ProjectCategories.Where(p => p.ProjectsId == project.ProjectsId).ToList();

                // add the Project Documents to the object
                // project.ProjectDocuments = db.ProjectDocuments.Where(p => p.ProjectId == project.ProjectsId).ToList();

                // fill the drops downs on the model
                //project.States = GetSelectListItems(states);
                //project.Professions = new List<SelectListItem>();
                //project.SubProfessions = new List<SelectListItem>();
                //project.CompensationTypeList = Utils.Extensions.GetCompensationType();

                // project.Conversations = new List<Conversations>();


            }


            if (currentuser.PercentDone != 100)
            {
                currentuser.PercentDone = 0;

                if (!string.IsNullOrWhiteSpace(currentuser.DisplayName))
                {
                    currentuser.PercentDone += 6.666666666666667;
                }

                if (!string.IsNullOrWhiteSpace(currentuser.Bio))
                {
                    currentuser.PercentDone += 6.666666666666667;
                }

                if (!string.IsNullOrWhiteSpace(currentuser.Email))
                {
                    currentuser.PercentDone += 6.666666666666667;
                }

                if (!string.IsNullOrWhiteSpace(currentuser.Address))
                {
                    currentuser.PercentDone += 6.666666666666667;
                }

                if (!string.IsNullOrWhiteSpace(currentuser.City))
                {
                    currentuser.PercentDone += 6.666666666666667;
                }

                if (!string.IsNullOrWhiteSpace(currentuser.State))
                {
                    currentuser.PercentDone += 6.666666666666667;
                }


                if (!string.IsNullOrWhiteSpace(currentuser.ZipCode))
                {
                    currentuser.PercentDone += 6.666666666666667;
                }

                if (!string.IsNullOrWhiteSpace(currentuser.FirstName))
                {
                    currentuser.PercentDone += 6.666666666666667;
                }

                if (!string.IsNullOrWhiteSpace(currentuser.MiddleName))
                {
                    currentuser.PercentDone += 6.666666666666667;
                }

                if (!string.IsNullOrWhiteSpace(currentuser.PhoneNumber))
                {
                    currentuser.PercentDone += 6.666666666666667;
                }

                if (currentuser.ByTheHourRate != 0)
                {
                    currentuser.PercentDone += 6.666666666666667;
                }

                if (!string.IsNullOrWhiteSpace(currentuser.BirthDate))
                {
                    currentuser.PercentDone += 6.666666666666667;
                }

                var job = db.ContractorCustomerCategories.Where(p => p.ContractorCustomerId == userId).ToList();

                if (job.Count() != 0)
                {
                    currentuser.PercentDone += 6.666666666666667;
                }

                if (!string.IsNullOrWhiteSpace(currentuser.ProfileImage))
                {
                    currentuser.PercentDone += 6.666666666666667;
                }

                if (!string.IsNullOrWhiteSpace(currentuser.ProfileResume))
                {
                    currentuser.PercentDone += 6.666666666666667;
                }
            }



            //currentuser.PercentDone = Math.Round(currentuser.PercentDone);

        }

        public List<Conversations> GetChatHeads()
        {
            PortalList portal = new PortalList();

            var userId = User.Identity.GetUserId();

            portal.Conversations = db.Conversations.Where(p => p.ConversationOwnerId == userId || p.ConversationSubOwnerId == userId).ToList();

            foreach (var conv in portal.Conversations)
            {
                // var msg = db.Messages.Where(p => p.ConversationsId == conv.Id).ToList();
                conv.ConversationOwner = db.Users.Where(p => p.Id == conv.ConversationOwnerId).SingleOrDefault();
                conv.ConversationSubOwner = db.Users.Where(p => p.Id == conv.ConversationSubOwnerId).SingleOrDefault();
            }

            return portal.Conversations;
        }

        public ActionResult GetUnreadMessages()
        {
            var userId = User.Identity.GetUserId();
            List<Conversations> conversation = db.Conversations.Where(p => p.Message.Any(i => i.Read == false && i.ReceiverId == userId)).ToList();

            foreach (var item in conversation)
            {
                var messages = db.Messages.Where(p => p.ConversationsId == item.Id && p.Read == false && p.SenderId != userId).ToList();
                item.SenderUnreadMessageCount = messages.Count();

                if (item.SenderUnreadMessageCount > 0)
                {
                    var Id = "";

                    if (messages[0].ReceiverId != userId)
                    {
                        Id = messages[0].ReceiverId;
                        var sender = db.Users.Where(p => p.Id == Id).SingleOrDefault();
                        item.SenderProfileDisplayImage = sender.ProfileImage;
                        item.SenderProfileDisplayName = sender.DisplayName;
                    }
                    else
                    {
                        Id = messages[0].SenderId;
                        var sender = db.Users.Where(p => p.Id == Id).SingleOrDefault();
                        item.SenderProfileDisplayImage = sender.ProfileImage;
                        item.SenderProfileDisplayName = sender.DisplayName;
                    }





                }
            }
            
            return Json(conversation, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetChatMessages(int ConversationId)
        {

            var userId = User.Identity.GetUserId();
            Conversations conversation = db.Conversations.Where(p => p.Id == ConversationId).SingleOrDefault();

            var msg = db.Messages.Where(p => p.ConversationsId == conversation.Id).OrderBy(p => p.CreationDate).ToList();

            foreach (var item in msg)
            {
                if (item.Read == false && item.ReceiverId == userId)
                {
                    item.DeliveredDate = DateTime.Now;
                    item.ReadDate = DateTime.Now;
                    item.Read = true;
                    item.Delivered = true;

                    using (var db = new ApplicationDbContext())
                    {
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }

                item.JosnDateTime = item.CreationDate.ToShortTimeString();


            }



            return Json(conversation, JsonRequestBehavior.AllowGet);

        }

        public ActionResult CreateMessageWithConversationId(string message, string ReceiverId, string SenderId, int ConversationId)
        {
            Messages msg = new Messages
            {
                CreationDate = DateTime.Now,
                Message = message,
                ReceiverId = ReceiverId,
                SenderId = SenderId,
                ConversationsId = ConversationId
            };

            db.Messages.Add(msg);
            db.SaveChanges();

            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        public ActionResult CreateMessage(string message, string ReceiverId, string SenderId)
        {

            var SenderCheck = db.Conversations.Where(p => p.ConversationOwnerId == SenderId && p.ConversationSubOwnerId == ReceiverId).SingleOrDefault();
            var ReceiverCheck = db.Conversations.Where(p => p.ConversationOwnerId == ReceiverId && p.ConversationSubOwnerId == SenderId).SingleOrDefault();

            string senderOrReceiver = "N";
            Conversations conv = new Conversations
            {
                CreationDate = DateTime.Now,

            };

            Messages msg = new Messages
            {
                CreationDate = DateTime.Now,
                Message = message,
                ReceiverId = ReceiverId,
                SenderId = SenderId,
            };

            if (SenderCheck != null)
            {
                senderOrReceiver = "S";
            }

            if (ReceiverCheck != null)
            {
                senderOrReceiver = "R";
            }

            if (senderOrReceiver == "S")
            {
                msg.ConversationsId = SenderCheck.Id;
                db.Messages.Add(msg);
                db.SaveChanges();
            }


            if (senderOrReceiver == "R")
            {
                msg.ConversationsId = ReceiverCheck.Id;
                db.Messages.Add(msg);
                db.SaveChanges();
            }

            if (senderOrReceiver == "N")
            {
                conv.ConversationOwnerId = SenderId;
                conv.ConversationSubOwnerId = ReceiverId;
                msg.ConversationsId = conv.Id;
                conv.Message.Add(msg);

                db.Conversations.Add(conv);
                db.SaveChanges();


                //db.Messages.Add(msg);
                //db.SaveChanges();
            }









            return Json("OK", JsonRequestBehavior.AllowGet);
        }


        [SessionTimeout]
        public ActionResult ReloadProfile()
        {
            PortalList portal = new PortalList();
            var userId = User.Identity.GetUserId();
            var states = Utils.Extensions.GetStatesList();

            portal.ApplicationUser = db.Users.Where(p => p.Id == userId).SingleOrDefault();

            portal.ApplicationUser.States = GetSelectListItems(states);
            portal.ApplicationUser.Professions = new List<SelectListItem>();
            portal.ApplicationUser.SubProfessions = new List<SelectListItem>();
            portal.ApplicationUser.UserProfessions = db.ContractorCustomerCategories.Where(p => p.ContractorCustomerId == userId).ToList();
            portal.ApplicationUser.Conversations = db.Conversations.Where(p => p.ConversationOwnerId == userId).ToList();
            return PartialView("_Profile", portal.ApplicationUser);
        }
        [SessionTimeout]
        public ActionResult FullProfile(string Id)
        {
            PortalList portal = new PortalList();
            var userId = User.Identity.GetUserId();
            List<ApplicationUser> allcontractors = new List<ApplicationUser>();

            var contractor = db.Users.Where(p => p.Id == Id).SingleOrDefault();
            var pastprojects = db.Project.Where(p => p.ProjectsUsersId == contractor.Id).ToList();
            contractor.UserProfessions = db.ContractorCustomerCategories.Where(p => p.ContractorCustomerId == contractor.Id).ToList();

            contractor.Professions = new List<SelectListItem>();
            contractor.SubProfessions = new List<SelectListItem>();

            ContractorSearchList contractorList = new ContractorSearchList
            {
                Contractor = contractor,
                PastProjects = pastprojects
            };
            portal.ContractorList.Add(contractorList);


            portal.Projects = db.Project.Where(p => p.ProjectsUsersId == userId && p.IsActive == true).ToList();

            portal.ContractorList.OrderBy(p => p.Contractor.DisplayName);

            portal.ProjectRating = db.ProjectRating.Where(p => p.ContractorId == contractor.Id).ToList();
            foreach (var item in portal.ProjectRating)
            {
                item.Project = db.Project.Where(p => p.ProjectsId == item.ProjectsId).SingleOrDefault();
                item.ProjectOwner = db.Users.Where(p=> p.Id == item.ProjectOwnerId).SingleOrDefault();
            }
           

            return PartialView("_FullProfile", portal);
        }

        //public ActionResult ShowPdfInBrowser()
        //{
        //    byte[] pdfContent = CodeThatRetrievesMyFilesContent();
        //    if (pdfContent == null)
        //    {
        //        return null;
        //    }
        //    var contentDispositionHeader = new System.Net.Mime.ContentDisposition
        //    {
        //        Inline = true,
        //        FileName = "someFilename.pdf"
        //    };
        //    Response.Headers.Add("Content-Disposition", contentDispositionHeader.ToString());
        //    return File(pdfContent, System.Net.Mime.MediaTypeNames.Application.Pdf);
        //}



        public async Task<ActionResult> GetOpenProjects(int page = 0, string HourlyRange = "", string descripton = "", string Profession = "", bool reset = false)
        {

            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            PortalList portal = new PortalList();
            var ProjectCompensationPackages = new List<ProjectCompensationPackage>();
            var projects = new List<Project>();




            if (!string.IsNullOrEmpty(HourlyRange))
            {
                switch (HourlyRange)
                {
                    case "10":
                        ProjectCompensationPackages = db.ProjectCompensationPackage.Where(p => p.ByTheHourRate < 10).ToList();
                        break;

                    case "10_40":
                        ProjectCompensationPackages = db.ProjectCompensationPackage.Where(p => p.ByTheHourRate >= 10 && p.ByTheHourRate <= 40).ToList();
                        break;

                    case "40_100":
                        ProjectCompensationPackages = db.ProjectCompensationPackage.Where(p => p.ByTheHourRate >= 40 && p.ByTheHourRate <= 100).ToList();
                        break;

                    case "100_plus":
                        ProjectCompensationPackages = db.ProjectCompensationPackage.Where(p => p.ByTheHourRate >= 100).ToList();
                        break;
                }

                foreach (var item in ProjectCompensationPackages)
                {
                    portal.Projects.AddRange(db.Project.Where(p => p.ProjectsId == item.ProjectId && p.IsProjectPublished == true).ToList());
                }
            }

            if (!string.IsNullOrEmpty(descripton))
            {
                projects = db.Project.Where(p => p.IsActive == true && p.IsProjectPublished == true && (p.Description.Contains(descripton) || p.ProjectTitle.Contains(descripton))).ToList();

                foreach (var prj in projects)
                {
                    portal.Projects.Add(prj);
                }
            }

            if (!string.IsNullOrEmpty(Profession))
            {
                foreach (var sub in db.ProjectCategories.Where(p => p.ProjectsSubCatName == Profession).Select(p => p.ProjectsId).ToList())
                {
                    foreach (var project in db.Project.Where(p => p.IsActive == true && p.ProjectsId == sub && p.IsProjectPublished == true).ToList())
                    {
                        portal.Projects.Add(project);
                    }
                }
            }

            if (reset)
            {
                portal.Projects = db.Project.Where(p => (p.IsActive == true) && (p.AcceptingContractors == true) && (p.IsProjectPublished == true)).ToList();
            }

            List<Project> prjGroup = new List<Project>();
            var ProjectApplicants = db.ProjectApplicants.Where(p => p.ApplicantId == userId).ToList();
            var isInArray = false;
            foreach (var prj in portal.Projects)
            {
                isInArray = false;

                foreach (var appl in ProjectApplicants)
                {
                    if (appl.ProjectsId == prj.ProjectsId)
                    {
                        isInArray = true;
                        break;
                    }
                }

                if (isInArray == false)
                {
                    prjGroup.Add(prj);
                }
            }

            portal.Projects = prjGroup;

            var pager = new Pager(portal.Projects.Distinct().Where(p => p.IsActive == true && p.AcceptingContractors == true && p.IsProjectPublished == true && p.ProjectStatus != ProjectStatuses.Completed && p.ProjectsUsersId != userId).Count(), page);

            portal.Projects = portal.Projects.Distinct().Where(p => p.IsActive == true && p.AcceptingContractors == true && p.IsProjectPublished == true && p.ProjectStatus != ProjectStatuses.Completed && p.ProjectsUsersId != userId).OrderByDescending(p => p.CreationDate).Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();
          

            foreach (var project in portal.Projects)
            {
                // add the Project Compensation Package to the object
                var ProjectCompensationPackage = db.ProjectCompensationPackage.Where(p => p.ProjectId == project.ProjectsId).SingleOrDefault();
                if (ProjectCompensationPackage != null)
                {
                    project.SelectedProjectCompensationPackage = ProjectCompensationPackage.ProjectCompensationType;
                    project.ByTheHourRate = ProjectCompensationPackage.ByTheHourRate;
                    project.ByTheProjectRate = ProjectCompensationPackage.ByTheProjectRate;
                    project.EndingBidDate = ProjectCompensationPackage.EndingBidDate;
                    project.EndingBidRate = ProjectCompensationPackage.EndingBidRate;
                    project.FloatingBidRate = ProjectCompensationPackage.FloatingBidRate;
                    project.StartingBidDate = ProjectCompensationPackage.StartingBidDate;
                    project.StartingBidRate = ProjectCompensationPackage.StartingBidRate;
                }

                //add the Project Job Categories to the object
                project.ProjectCategories = db.ProjectCategories.Where(p => p.ProjectsId == project.ProjectsId).ToList();
            }





            portal.Pager = pager;



            return PartialView("_ViewOpenProjectsC", portal);
        }


        [SessionTimeout]
        public ActionResult ContractorSearch(int rating = 0, string HourlyRange = "", string displayName = "", string Profession = "", string OnlineStatus = "", bool All = false, int page = 0)
        {
            PortalList portal = new PortalList();
            var userId = User.Identity.GetUserId();
            List<ApplicationUser> allcontractors = new List<ApplicationUser>();

            if (rating != 0)
            {
                foreach (var user in db.Users.Where(p => p.IsInContractorMode == true && p.Rating == rating).ToList())
                {
                    allcontractors.Add(user);
                }
            }

            if (!string.IsNullOrEmpty(HourlyRange))
            {
                switch (HourlyRange)
                {
                    case "10":
                        foreach (var user in db.Users.Where(p => p.IsInContractorMode == true && p.ByTheHourRate < 10).ToList())
                        {
                            allcontractors.Add(user);
                        }
                        break;

                    case "10_40":
                        foreach (var user in db.Users.Where(p => p.IsInContractorMode == true && p.ByTheHourRate >= 10 && p.ByTheHourRate <= 40).ToList())
                        {
                            allcontractors.Add(user);
                        }
                        break;

                    case "40_100":
                        foreach (var user in db.Users.Where(p => p.IsInContractorMode == true && p.ByTheHourRate >= 40 && p.ByTheHourRate <= 100).ToList())
                        {
                            allcontractors.Add(user);
                        }
                        break;

                    case "100_plus":
                        foreach (var user in db.Users.Where(p => p.IsInContractorMode == true && p.ByTheHourRate > 100).ToList())
                        {
                            allcontractors.Add(user);
                        }
                        break;


                }
            }

            if (!string.IsNullOrEmpty(displayName))
            {
                foreach (var user in db.Users.Where(p => p.IsInContractorMode == true && p.DisplayName.ToLower().Contains(displayName.ToLower())).ToList())
                {
                    allcontractors.Add(user);
                }
            }

            if (!string.IsNullOrEmpty(Profession))
            {
                foreach (var sub in db.ContractorCustomerCategories.Where(p => p.SubCatName == Profession).Select(p => p.ContractorCustomerId).ToList())
                {
                    foreach (var user in db.Users.Where(p => p.IsInContractorMode == true && p.Id == sub).ToList())
                    {
                        allcontractors.Add(user);
                    }
                }
            }

            if (OnlineStatus != "")
            {
                try
                {
                    var onlinestatus = bool.Parse(OnlineStatus);

                    foreach (var user in db.Users.Where(p => p.IsInContractorMode == true && p.Online == onlinestatus).ToList())
                    {
                        allcontractors.Add(user);
                    }
                }
                catch (Exception)
                {


                }

            }



            if (All)
            {
                allcontractors.Clear();
                allcontractors = db.Users.Where(p => p.IsInContractorMode == true).ToList();
            }

            var pager = new Pager(allcontractors.Distinct().Count(), page);

            foreach (var contractor in allcontractors.Distinct().Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize))
            {
                var pastprojects = db.Project.Where(p => p.ProjectsUsersId == contractor.Id).ToList();
                               
                contractor.UserProfessions = db.ContractorCustomerCategories.Where(p => p.ContractorCustomerId == contractor.Id).ToList();

                contractor.Professions = new List<SelectListItem>();
                contractor.SubProfessions = new List<SelectListItem>();

                ContractorSearchList contractorList = new ContractorSearchList
                {
                    Contractor = contractor,
                    PastProjects = pastprojects
                };
                portal.ContractorList.Add(contractorList);

                portal.ProjectRating = db.ProjectRating.Where(p => p.ContractorId == contractor.Id).ToList();
                foreach (var item in portal.ProjectRating)
                {
                    item.Project = db.Project.Where(p => p.ProjectsId == item.ProjectsId).SingleOrDefault();
                    item.ProjectOwner = db.Users.Where(p => p.Id == item.ProjectOwnerId).SingleOrDefault();
                }
            }


           

            //ProjectRating pr = new ProjectRating
            //{
            //    Project = item,
            //    ProjectsId = item.ProjectsId,
            //    ContractorId = contractor.Id,
            //    ProjectOwnerId = item.ProjectsUsersId
            //};









            portal.Projects = db.Project.Where(p => p.ProjectsUsersId == userId && p.IsActive == true).ToList();



            portal.ContractorList.OrderBy(p => p.Contractor.DisplayName);
            portal.Pager = pager;



            return PartialView("_ContractorSearch", portal);
        }
        [SessionTimeout]
        public ActionResult AssignContractor(string ApplicantId, long projectId)
        {
            var userId = User.Identity.GetUserId();
            ProjectAssignment projectAssignment = new ProjectAssignment
            {
                CreationDate = DateTime.Now,
                LastUpdated = DateTime.Now,
                ProjectId = projectId,
                UsersId = ApplicantId,
                ProjectOwner = userId
            };

            if (db.ProjectAssignment.Where(p => p.UsersId == ApplicantId && p.ProjectId == projectId).ToList().Count() == 0)
            {
                db.ProjectAssignment.Add(projectAssignment);
                db.SaveChanges();

                var applicant = db.ProjectApplicants.Where(p => p.ApplicantId == ApplicantId && p.ProjectsId == projectId).SingleOrDefault();
                applicant.AssinedToProject = true;
                db.Entry(applicant).State = EntityState.Modified;
                db.SaveChanges();

                var project = db.Project.Where(p => p.ProjectsId == projectId).SingleOrDefault();
                project.ProjectStatus = ProjectStatuses.InProgress;
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();


                ProjectAcceptance prt = new ProjectAcceptance
                {
                    Project = project,
                    Read = false,
                    Delivered = false,
                    ContractorId = ApplicantId,
                    AccecptedProject = false,
                    CreationDate = DateTime.Now,
                    CustomerId = project.ProjectsUsersId,
                     CanStartWorkNow  = false,
                      ProjectId = project.ProjectsId

                };

                db.ProjectAcceptance.Add(prt);
                db.SaveChanges();

                var user = db.Users.Where(p => p.Id == ApplicantId).SingleOrDefault();
                             

               SendEmail(project, user, ReplaceAcceptedEmailData(project, user), "Your application has been accepted.");
            }

            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        public void SendEmail(Project prj, ApplicationUser user, string Body, string Subject)
        {
            if (user.ContactWithEmail)
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("relay-hosting.secureserver.net");
                mail.From = new MailAddress("samedayservicez-noreply@devsamedayservicez.com");
                // mail.To.Add(user.Email);
                mail.To.Add("christopher.mcclellan@gmail.com");
                mail.To.Add("jm.millerzconstruction@gmail.com");
                mail.Subject = Subject;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpServer.Port = 25;
                SmtpServer.Send(mail);
            }        
        }

        private bool SendEmailToApplicants(Project prj)
        {
            var ProjectCategories = db.ProjectCategories.Where(p => p.ProjectsId == prj.ProjectsId).ToList();
            var ProjectCategoriesA = "";
            var UserList = new List<ApplicationUser>();
            var ContractorCustomerCategories = new List<ContractorCustomerCategories>();

            foreach (var item in ProjectCategories)
            {
                var c = db.ContractorCustomerCategories.Where(p => p.SubCatId == item.ProjectsSubCatId).ToList();

                foreach (var i in c)
                {
                    var user = db.Users.Where(p => p.Id == i.ContractorCustomerId).FirstOrDefault();
                    if (user != null)
                    {
                        UserList.Add(user);
                    }
                }

                ProjectCategoriesA += item.ProjectsSubCatName + ",";
            }          
       

            ProjectCategoriesA.Trim(',');

            foreach (var user in UserList)
            {
                SendEmail(prj, user, ReplaceNewProjectAvailEmailData(prj, ProjectCategoriesA), "A new project that fits your skills has been posted.");
            }


            return true;

        }

        public string ReplaceNewProjectAvailEmailData(Project prj, string ProjectCategoriesA)
        {
            string body = System.IO.File.ReadAllText(Server.MapPath("/Views/Shared/NewProject.html"));

            string Duration = "";
            switch (prj.Duration)
            {
                case 1:
                    Duration = "Short Term / Day(s) Needed: " + prj.NumberOfDaysHelpIsNeeded;
                    break;

                case 2:
                    Duration = "Long Term  / Day(s) Needed: " + prj.NumberOfDaysHelpIsNeeded;
                    break;

                case 3:

                    Duration = "Proposal / Day(s) Needed: " + prj.NumberOfDaysHelpIsNeeded;
                    break;
            }

       

            body = body.Replace("~ProjectTitle", prj.ProjectTitle).Replace("~Skills", ProjectCategoriesA).Replace("~ProjectTimeline", Duration).Replace("~Compensation", "$" + prj.ByTheHourRate.ToString() + " / hourly").Replace("~JobDescription", prj.Description);

            return body;
        }


        public string ReplaceNewApplicantEmailData(Project prj, ApplicationUser applicant)
        {
            string body = System.IO.File.ReadAllText(Server.MapPath("/Views/Shared/NewApplicant.html"));

            string Duration = "";
            switch (prj.Duration)
            {
                case 1:
                    Duration = "Short Term / Day(s) Needed: " + prj.NumberOfDaysHelpIsNeeded;
                    break;

                case 2:
                    Duration = "Long Term  / Day(s) Needed: " + prj.NumberOfDaysHelpIsNeeded;
                    break;

                case 3:

                    Duration = "Proposal / Day(s) Needed: " + prj.NumberOfDaysHelpIsNeeded;
                    break;
            }

            var ProfilePath = "/Uploads/ProfileImages/" + applicant.Id + "/";

            string pathString = "https://www.devsamedayservicez.com" + ProfilePath.ToString() + "profile_" + applicant.Id + Path.GetExtension(applicant.ProfileImage);

            body = body.Replace("~ProfileImageUrl", pathString).Replace("~FullName", applicant.DisplayName).Replace("~ProjectTitle", prj.ProjectTitle).Replace("~ProjectTimeline", Duration).Replace("~Compensation", "$" + prj.ByTheHourRate.ToString() + " / hourly").Replace("~JobDescription", prj.Description);

            return body;
        }


        public string ReplaceAcceptedEmailData(Project prj,ApplicationUser applicant)
        {
            string body = System.IO.File.ReadAllText(Server.MapPath("/Views/Shared/acceptedEmail.html"));

            string Duration="";
            switch (prj.Duration)
                {
                    case 1:
                    Duration = "Short Term / Day(s) Needed: " + prj.NumberOfDaysHelpIsNeeded;
                    break;

                    case 2:
                    Duration = "Long Term  / Day(s) Needed: " + prj.NumberOfDaysHelpIsNeeded;
                    break;

                    case 3:

                    Duration = "Proposal / Day(s) Needed: " + prj.NumberOfDaysHelpIsNeeded;
                    break;
            }

            var ProfilePath = "/Uploads/ProfileImages/" + applicant.Id + "/";
   
            string pathString = "https://www.devsamedayservicez.com" + ProfilePath.ToString() + "profile_" + applicant.Id + Path.GetExtension(applicant.ProfileImage);

            body = body.Replace("~ProfileImageUrl", pathString).Replace("~FullName", applicant.DisplayName).Replace("~ProjectTitle", prj.ProjectTitle).Replace("~ProjectTimeline", Duration).Replace("~Compensation", "$" + prj.ByTheHourRate.ToString() + " / hourly").Replace("~JobDescription", prj.Description);

            return body;
        }

        [HttpPost]
        public ActionResult ApplyForJob(long projectId, string contractorMessage = "")
        {
            var userId = User.Identity.GetUserId();
            var contrator = db.Users.Where(p => p.Id == userId).SingleOrDefault();
            var project = db.Project.Where(p => p.ProjectsId == projectId).SingleOrDefault();
            var projectOwner = db.Users.Where(p => p.Id == project.ProjectsUsersId).SingleOrDefault();


            ProjectApplicants applicant = new ProjectApplicants
            {
                ApplicantId = userId,
                AppliedDate = DateTime.Now,
                AssinedToProject = false,
                ProjectsId = projectId,
                ApplicantMessage = contractorMessage
            };

            int HasAppliedBefore = db.ProjectApplicants.Where(p => p.ProjectsId == projectId && p.ApplicantId == userId).Count();

            if (HasAppliedBefore == 0)
            {
                db.ProjectApplicants.Add(applicant);
                db.SaveChanges();                                         
                
                SendEmail(project, projectOwner, ReplaceNewApplicantEmailData(project, contrator), "A new applicant has applied for your project.");

                return Json("OK", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Applied", JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult ViewPastAppliedForProjects(long projectId)
        {
            PortalList portal = new PortalList();
            Project project = new Project();

            project = db.Project.Where(p => p.ProjectsId == projectId).SingleOrDefault();

            // add the Project Job Categories to the object
            project.ProjectCategories = db.ProjectCategories.Where(p => p.ProjectsId == project.ProjectsId).ToList();

            // add the Project Compensation Package to the object
            var ProjectCompensationPackage = db.ProjectCompensationPackage.Where(p => p.ProjectId == project.ProjectsId).SingleOrDefault();
            if (ProjectCompensationPackage != null)
            {
                project.SelectedProjectCompensationPackage = ProjectCompensationPackage.ProjectCompensationType;
                project.ByTheHourRate = ProjectCompensationPackage.ByTheHourRate;
                project.ByTheProjectRate = ProjectCompensationPackage.ByTheProjectRate;
                project.EndingBidDate = ProjectCompensationPackage.EndingBidDate;
                project.EndingBidRate = ProjectCompensationPackage.EndingBidRate;
                project.FloatingBidRate = ProjectCompensationPackage.FloatingBidRate;
                project.StartingBidDate = ProjectCompensationPackage.StartingBidDate;
                project.StartingBidRate = ProjectCompensationPackage.StartingBidRate;
            }


            portal.Projects.Add(project);







            return PartialView("_ViewPastJobs", portal);



        }
        public ActionResult ViewFullProject(long projectId)
        {
            PortalList portal = new PortalList();
            Project project = new Project();

            project = db.Project.Where(p => p.ProjectsId == projectId).SingleOrDefault();

            // add the Project Job Categories to the object
            project.ProjectCategories = db.ProjectCategories.Where(p => p.ProjectsId == project.ProjectsId).ToList();

            // add the Project Compensation Package to the object
            var ProjectCompensationPackage = db.ProjectCompensationPackage.Where(p => p.ProjectId == project.ProjectsId).SingleOrDefault();
            if (ProjectCompensationPackage != null)
            {
                project.SelectedProjectCompensationPackage = ProjectCompensationPackage.ProjectCompensationType;
                project.ByTheHourRate = ProjectCompensationPackage.ByTheHourRate;
                project.ByTheProjectRate = ProjectCompensationPackage.ByTheProjectRate;
                project.EndingBidDate = ProjectCompensationPackage.EndingBidDate;
                project.EndingBidRate = ProjectCompensationPackage.EndingBidRate;
                project.FloatingBidRate = ProjectCompensationPackage.FloatingBidRate;
                project.StartingBidDate = ProjectCompensationPackage.StartingBidDate;
                project.StartingBidRate = ProjectCompensationPackage.StartingBidRate;
            }


            portal.Projects.Add(project);







            return PartialView("_ViewJob", portal);
        }


        public ActionResult RejectOrUnrejectApplicant(long projectId, string ApplicantId, bool Reject)
        {
            var applicant = db.ProjectApplicants.Where(p => p.ProjectsId == projectId && p.ApplicantId == ApplicantId).FirstOrDefault();

            if (applicant != null && Reject == true)
            {
                applicant.Rejected = true;
                db.Entry(applicant).State = EntityState.Modified;
                db.SaveChanges();
            }

            if (applicant != null && Reject == false)
            {
                applicant.Rejected = false;
                db.Entry(applicant).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateApplicantRating(long projectId, string ApplicantId, int rating)
        {
            var applicant = db.ProjectApplicants.Where(p => p.ProjectsId == projectId && p.ApplicantId == ApplicantId).FirstOrDefault();


            if (applicant != null)
            {
                applicant.ApplicantRating = rating;
                db.Entry(applicant).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                applicant.ApplicantRating = rating;
                db.ProjectApplicants.Add(applicant);
                db.SaveChanges();
            }


            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProjectAssignmentSingle(long ProjectsId, string ApplicantId)
        {
            var userId = User.Identity.GetUserId();
            var ProjectAssignments = db.ProjectAssignment.Where(p => p.ProjectId == ProjectsId && p.ProjectOwner == userId && p.UsersId == ApplicantId).SingleOrDefault();



            var profile = db.Users.Where(i => i.Id == ProjectAssignments.UsersId).SingleOrDefault();
            ProjectAssignments.ProfileProfessions = db.ContractorCustomerCategories.Where(p => p.ContractorCustomerId == userId).ToList();

            List<Project> ProfilePastProjects = new List<Project>();
            ProfilePastProjects = db.Project.Where(p => p.ProjectsUsersId == ProjectAssignments.UsersId).ToList();

            ProjectAssignments.ProfileImage = profile.ProfileImage;
            ProjectAssignments.ProfileDisplayName = profile.DisplayName;
            ProjectAssignments.ProfileBios = profile.Bio;
            ProjectAssignments.ProfileRating = profile.Rating;
            ProjectAssignments.ByTheHourRate = profile.ByTheHourRate;
            ProjectAssignments.ProfilePastProjects = ProfilePastProjects;
            ProjectAssignments.ProjectOwnerName = profile.DisplayName;


            return PartialView("_ProjectAssignmentSingle", ProjectAssignments);
        }

        public ActionResult GetProjectP(long projectId)
        {
            Project project = new Project();
            var userId = User.Identity.GetUserId();
            var states = Extensions.GetStatesList();
            List<ProjectAssignment> ProjectAssignments = new List<ProjectAssignment>();

            project = db.Project.Where(p => p.ProjectsId == projectId).SingleOrDefault();


            // add the project assignments to the object
            project.ProjectAssignments = new List<ProjectAssignment>();
            ProjectAssignments = db.ProjectAssignment.Where(p => p.ProjectId == project.ProjectsId && p.ProjectOwner == userId).ToList();


            foreach (var Assignment in ProjectAssignments)
            {
                var profile = db.Users.Where(i => i.Id == Assignment.UsersId).SingleOrDefault();
                var projectOwnerName = db.Users.Where(i => i.Id == Assignment.UsersId).SingleOrDefault();
                var pp = db.ContractorCustomerCategories.Where(p => p.ContractorCustomerId == Assignment.UsersId);
                Assignment.ProfileProfessions = db.ContractorCustomerCategories.Where(p => p.ContractorCustomerId == Assignment.UsersId).ToList();


                List<Project> ProfilePastProjects = new List<Project>();
                ProfilePastProjects = db.Project.Where(p => p.ProjectsUsersId == Assignment.UsersId).ToList(); //.Select(x => new Project { ProjectTitle = x.ProjectTitle, CreationDate = x.CreationDate }).ToList(); 

                Assignment.ProfileImage = profile.ProfileImage;
                Assignment.ProfileDisplayName = profile.DisplayName;
                Assignment.ProfileBios = profile.Bio;
                Assignment.ProfileRating = profile.Rating;
                Assignment.ByTheHourRate = profile.ByTheHourRate;
                Assignment.ProfilePastProjects = ProfilePastProjects;
                Assignment.ProjectOwnerName = projectOwnerName.DisplayName;
                Assignment.UsersId = profile.Id;
                project.ProjectAssignments.Add(Assignment);

                project.ProjectRating = db.ProjectRating.Where(p => p.ContractorId == Assignment.UsersId).ToList();
                foreach (var item in project.ProjectRating)
                {
                    item.Project = db.Project.Where(p => p.ProjectsId == item.ProjectsId).SingleOrDefault();
                    item.ProjectOwner = db.Users.Where(p => p.Id == item.ProjectOwnerId).SingleOrDefault();
                }
            }


            // add the Project Compensation Package to the object
            var ProjectCompensationPackage = db.ProjectCompensationPackage.Where(p => p.ProjectId == project.ProjectsId).SingleOrDefault();
            if (ProjectCompensationPackage != null)
            {
                project.SelectedProjectCompensationPackage = ProjectCompensationPackage.ProjectCompensationType;
                project.ByTheHourRate = ProjectCompensationPackage.ByTheHourRate;
                project.ByTheProjectRate = ProjectCompensationPackage.ByTheProjectRate;
                project.EndingBidDate = ProjectCompensationPackage.EndingBidDate;
                project.EndingBidRate = ProjectCompensationPackage.EndingBidRate;
                project.FloatingBidRate = ProjectCompensationPackage.FloatingBidRate;
                project.StartingBidDate = ProjectCompensationPackage.StartingBidDate;
                project.StartingBidRate = ProjectCompensationPackage.StartingBidRate;
            }

            // add the Project Job Categories to the object
            project.ProjectCategories = db.ProjectCategories.Where(p => p.ProjectsId == project.ProjectsId).ToList();

            // add the Project Documents to the object
            project.ProjectDocuments = db.ProjectDocuments.Where(p => p.ProjectId == project.ProjectsId).ToList();

            // fill the drops downs on the model
            project.States = GetSelectListItems(states);
            project.Professions = new List<SelectListItem>();
            project.SubProfessions = new List<SelectListItem>();
            project.CompensationTypeList = Extensions.GetCompensationType(true);
            project.DurationList = Extensions.GetDurationList();



            project.Conversations = new List<Conversations>();
            project.ProjectApplicants = db.ProjectApplicants.Where(p => p.ProjectsId == projectId).ToList();

            foreach (var applicant in project.ProjectApplicants)
            {
                if (ProjectAssignments.Where(p => p.ProjectId == applicant.ProjectsId && p.ProjectOwner == userId && p.UsersId == applicant.ApplicantId).ToList().Count() > 0)
                {
                    applicant.AssinedToProject = true;
                }
                else
                {
                    applicant.AssinedToProject = false;
                    applicant.Applicant = db.Users.Where(p => p.Id == applicant.ApplicantId).SingleOrDefault();
                    applicant.Applicant.UserProfessions = db.ContractorCustomerCategories.Where(p => p.ContractorCustomerId == applicant.ApplicantId).ToList();
                    applicant.PastProjects = db.Project.Where(p => p.ProjectsUsersId == applicant.ApplicantId).ToList();
                }
            }

            project.ProjectApplicants = project.ProjectApplicants.OrderByDescending(p => p.ApplicantRating).ThenByDescending(p => p.Rejected).ToList();

            Session["IsInContractorMode"] = (db.Users.Where(i => i.Id == userId).SingleOrDefault()).IsInContractorMode;






            return PartialView("_ViewProjectP", project);
        }

        [SessionTimeout]
        public ActionResult GetProject(long projectId)
        {
            Project project = new Project();
            var userId = User.Identity.GetUserId();
            var states = Extensions.GetStatesList();
            List<ProjectAssignment> ProjectAssignments = new List<ProjectAssignment>();

            project = db.Project.Where(p => p.ProjectsId == projectId).SingleOrDefault();


            // add the project assignments to the object
            project.ProjectAssignments = new List<ProjectAssignment>();
            ProjectAssignments = db.ProjectAssignment.Where(p => p.ProjectId == project.ProjectsId && p.ProjectOwner == userId).ToList();


            foreach (var Assignment in ProjectAssignments)
            {
                var profile = db.Users.Where(i => i.Id == Assignment.UsersId).SingleOrDefault();
                var projectOwnerName = db.Users.Where(i => i.Id == Assignment.UsersId).SingleOrDefault();
                var pp = db.ContractorCustomerCategories.Where(p => p.ContractorCustomerId == Assignment.UsersId);
                Assignment.ProfileProfessions = db.ContractorCustomerCategories.Where(p => p.ContractorCustomerId == Assignment.UsersId).ToList();


                List<Project> ProfilePastProjects = new List<Project>();
                ProfilePastProjects = db.Project.Where(p => p.ProjectsUsersId == Assignment.UsersId).ToList(); //.Select(x => new Project { ProjectTitle = x.ProjectTitle, CreationDate = x.CreationDate }).ToList(); 

                Assignment.ProfileImage = profile.ProfileImage;
                Assignment.ProfileDisplayName = profile.DisplayName;
                Assignment.ProfileBios = profile.Bio;
                Assignment.ProfileRating = profile.Rating;
                Assignment.ByTheHourRate = profile.ByTheHourRate;
                Assignment.ProfilePastProjects = ProfilePastProjects;
                Assignment.ProjectOwnerName = projectOwnerName.DisplayName;
                Assignment.UsersId = profile.Id;
                project.ProjectAssignments.Add(Assignment);

                project.ProjectRating = db.ProjectRating.Where(p => p.ContractorId == Assignment.UsersId).ToList();
                foreach (var item in project.ProjectRating)
                {
                    item.Project = db.Project.Where(p => p.ProjectsId == item.ProjectsId).SingleOrDefault();
                    item.ProjectOwner = db.Users.Where(p => p.Id == item.ProjectOwnerId).SingleOrDefault();
                }
            }


            // add the Project Compensation Package to the object
            var ProjectCompensationPackage = db.ProjectCompensationPackage.Where(p => p.ProjectId == project.ProjectsId).SingleOrDefault();
            if (ProjectCompensationPackage != null)
            {
                project.SelectedProjectCompensationPackage = ProjectCompensationPackage.ProjectCompensationType;
                project.ByTheHourRate = ProjectCompensationPackage.ByTheHourRate;
                project.ByTheProjectRate = ProjectCompensationPackage.ByTheProjectRate;
                project.EndingBidDate = ProjectCompensationPackage.EndingBidDate;
                project.EndingBidRate = ProjectCompensationPackage.EndingBidRate;
                project.FloatingBidRate = ProjectCompensationPackage.FloatingBidRate;
                project.StartingBidDate = ProjectCompensationPackage.StartingBidDate;
                project.StartingBidRate = ProjectCompensationPackage.StartingBidRate;
            }

            // add the Project Job Categories to the object
            project.ProjectCategories = db.ProjectCategories.Where(p => p.ProjectsId == project.ProjectsId).ToList();

            // add the Project Documents to the object
            project.ProjectDocuments = db.ProjectDocuments.Where(p => p.ProjectId == project.ProjectsId).ToList();

            // fill the drops downs on the model
            project.States = GetSelectListItems(states);
            project.Professions = new List<SelectListItem>();
            project.SubProfessions = new List<SelectListItem>();
            project.CompensationTypeList = Extensions.GetCompensationType(false);
            project.DurationList = Extensions.GetDurationList();



            project.Conversations = new List<Conversations>();
            project.ProjectApplicants = db.ProjectApplicants.Where(p => p.ProjectsId == projectId).ToList();

            foreach (var applicant in project.ProjectApplicants)
            {
                if (ProjectAssignments.Where(p => p.ProjectId == applicant.ProjectsId && p.ProjectOwner == userId && p.UsersId == applicant.ApplicantId).ToList().Count() > 0)
                {
                    applicant.AssinedToProject = true;
                }
                else
                {
                    applicant.AssinedToProject = false;
                    applicant.Applicant = db.Users.Where(p => p.Id == applicant.ApplicantId).SingleOrDefault();
                    applicant.Applicant.UserProfessions = db.ContractorCustomerCategories.Where(p => p.ContractorCustomerId == applicant.ApplicantId).ToList();
                    applicant.PastProjects = db.Project.Where(p => p.ProjectsUsersId == applicant.ApplicantId).ToList();
                }
            }

            project.ProjectApplicants = project.ProjectApplicants.OrderByDescending(p => p.ApplicantRating).ThenByDescending(p => p.Rejected).ToList();

            Session["IsInContractorMode"] = (db.Users.Where(i => i.Id == userId).SingleOrDefault()).IsInContractorMode;



         


            return PartialView("_ViewProject", project);
        }
        [SessionTimeout]
        public async Task<ActionResult> UpdateProfile(string DisplayName, string Bio, string Email, string Address, string City, string State, string ZipCode, string FirstName, string MiddleName, string LastName, string PhoneNumber, decimal ByTheHourRate, string BirthDate, bool IsInContractorMode, string OldPassword, string NewPassword, bool InWorkMode,bool ContactByEmail,bool ContactByPhone)
        {

            var userId = User.Identity.GetUserId();

            ApplicationUser profile = db.Users.Where(p => p.Id == userId).SingleOrDefault();

            if (profile != null)
            {
                profile.DisplayName = DisplayName;
                profile.Bio = System.Net.WebUtility.UrlDecode(Bio);
                profile.Email = Email;
                profile.Address = Address;
                profile.City = City;
                profile.State = State;
                profile.ZipCode = ZipCode;
                profile.FirstName = FirstName;
                profile.MiddleName = MiddleName;
                profile.LastName = LastName;
                profile.PhoneNumber = PhoneNumber;
                profile.ByTheHourRate = ByTheHourRate;
                profile.BirthDate = BirthDate;
                profile.IsInContractorMode = IsInContractorMode;
                profile.IsInCustomerMode = !IsInContractorMode;
                profile.InWorkMode = InWorkMode;
                profile.ContactWithEmail = ContactByEmail;
                profile.ContactWithPhone = ContactByPhone;

                if (OldPassword != null && NewPassword != null)
                {
                    IdentityResult passwordresult = await UserManager.ChangePasswordAsync(userId, OldPassword, NewPassword);
                }

                
                    profile.PercentDone = 0;

                    if (!string.IsNullOrWhiteSpace(profile.DisplayName))
                    {                      
                        profile.PercentDone += 6.666666666666667;
                    }

                    if (!string.IsNullOrWhiteSpace(profile.Bio))
                    {
                        profile.PercentDone += 6.666666666666667;
                    }

                    if (!string.IsNullOrWhiteSpace(profile.Email))
                    {
                        profile.PercentDone += 6.666666666666667;
                    }

                    if (!string.IsNullOrWhiteSpace(profile.Address))
                    {
                        profile.PercentDone += 6.666666666666667;
                    }

                    if (!string.IsNullOrWhiteSpace(profile.City))
                    {
                        profile.PercentDone += 6.666666666666667;
                    }

                    if (!string.IsNullOrWhiteSpace(profile.State))
                    {
                        profile.PercentDone += 6.666666666666667;
                    }


                    if (!string.IsNullOrWhiteSpace(profile.ZipCode))
                    {
                        profile.PercentDone += 6.666666666666667;
                    }

                    if (!string.IsNullOrWhiteSpace(profile.FirstName))
                    {
                        profile.PercentDone += 6.666666666666667;
                    }

                    if (!string.IsNullOrWhiteSpace(profile.MiddleName))
                    {
                        profile.PercentDone += 6.666666666666667;
                    }

                    if (!string.IsNullOrWhiteSpace(profile.PhoneNumber))
                    {
                        profile.PercentDone += 6.666666666666667;
                    }

                    if (profile.ByTheHourRate != 0)
                    {
                        profile.PercentDone += 6.666666666666667;
                    }

                    if (!string.IsNullOrWhiteSpace(profile.BirthDate))
                    {
                        profile.PercentDone += 6.666666666666667;
                    }

                    var job = db.ContractorCustomerCategories.Where(p => p.ContractorCustomerId == userId).ToList();

                    if (job.Count() != 0)
                    {
                        profile.PercentDone += 6.666666666666667;
                    }

                    if (!string.IsNullOrWhiteSpace(profile.ProfileImage))
                    {
                        profile.PercentDone += 6.666666666666667;
                    }

                    if (!string.IsNullOrWhiteSpace(profile.ProfileResume))
                    {
                        profile.PercentDone += 6.666666666666667;
                    }
               

               

                //profile.PercentDone = Math.Round(profile.PercentDone);

            }



            db.Entry(profile).State = EntityState.Modified;
            db.SaveChanges();


            return Json("OK", JsonRequestBehavior.AllowGet);
        }



        public ActionResult SaveUserRating(string ContractorId,long ProjectsId,int Rating,string ProjectOwnerComment)
        {
            var userId = User.Identity.GetUserId();

            ApplicationUser profile = db.Users.Where(p => p.Id == userId).SingleOrDefault();

            if (profile != null)
            {
                var projectOwenerId = db.Project.Where(p => p.ProjectsId == ProjectsId).SingleOrDefault();

                ProjectRating pr = new ProjectRating
                {
                    ContractorId = ContractorId,
                    ProjectsId = ProjectsId,
                    CreationDate = DateTime.Now,
                    Rating = Rating,
                    ProjectOwnerComment = ProjectOwnerComment,
                    ProjectOwnerId  = projectOwenerId.ProjectsUsersId

                };

                db.ProjectRating.Add(pr);
                db.SaveChanges();
            }

            return Json("OK", JsonRequestBehavior.AllowGet);
        }


        [ValidateInput(false)]
        [SessionTimeout]
        public async Task<ActionResult> UpdateProject(string ProjectTitle, string Description, string Address, string City, string State, string ZipCode, long projectID,
            decimal ByTheHourRate, decimal ByTheProjectRate, decimal StartingBidRate, DateTime StartingBidDate, DateTime EndingBidDate,
            long SelectedProjectCompensationPackage, string Notes, long Duration, int NumberOfContractorsNeeded, int NumberOfDaysHelpIsNeeded, int ProjectStatus)
        {
            var userId = User.Identity.GetUserId();

            var project = db.Project.Where(p => p.ProjectsId == projectID).FirstOrDefault();

            if (project != null)
            {
                project.ProjectTitle = ProjectTitle;
                project.Description = Description;
                project.Address = Address;
                project.City = City;
                project.State = State;
                project.ZipCode = ZipCode;
                project.ByTheHourRate = ByTheHourRate;
                project.ByTheProjectRate = ByTheProjectRate;
                project.StartingBidRate = StartingBidRate;
                project.StartingBidDate = StartingBidDate;
                project.EndingBidDate = EndingBidDate;
                project.SelectedProjectCompensationPackage = SelectedProjectCompensationPackage;
                project.Notes = Notes;
                project.Duration = Duration;


                switch (ProjectStatus)
                {
                    case 0:
                        project.ProjectStatus = ProjectStatuses.Completed;
                        break;
                    case 1:
                        project.ProjectStatus = ProjectStatuses.Published;
                        break;
                    case 2:
                        project.ProjectStatus = ProjectStatuses.Draft;
                        break;
                    case 3:
                        project.ProjectStatus = ProjectStatuses.InProgress;
                        break;
                }

                project.NumberOfContractorsNeeded = NumberOfContractorsNeeded;
                project.NumberOfDaysHelpIsNeeded = NumberOfDaysHelpIsNeeded;



                await SaveProjectCompensationPackage(project.ProjectsId, SelectedProjectCompensationPackage, ByTheHourRate, ByTheProjectRate, StartingBidRate, 0, 0, StartingBidDate, EndingBidDate);


            }

            using (var db = new ApplicationDbContext())
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(projectID, JsonRequestBehavior.AllowGet);
        }


        public ActionResult PublishProject(long projectID)
        {
            var project = db.Project.Where(p => p.ProjectsId == projectID).SingleOrDefault();
            project.IsProjectPublished = true;
            project.IsActive = true;
            project.ProjectStatus = ProjectStatuses.Published;
            project.AcceptingContractors = true;

            using (var db = new ApplicationDbContext())
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
            }

            SendEmailToApplicants(project);





            return Json(projectID, JsonRequestBehavior.AllowGet);
        }

       


        [SessionTimeout]
        public JsonResult GetSubCategoryList(int Id)
        {

            var userId = User.Identity.GetUserId();

            var UserProfessions = db.ContractorCustomerCategories.Where(p => p.ContractorCustomerId == userId).ToList();

            var wholeList = db.Subcategories.Where(x => x.MainCatId == Id).ToList();
            List<Subcategories> catList = new List<Subcategories>();

            wholeList.RemoveAll(x => UserProfessions.Any(y => y.SubCatId == x.Id));

            return Json(wholeList, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetFullProjectASubCategoryList(int Id)
        {
            var wholeList = db.Subcategories.Where(x => x.MainCatId == Id).ToList();        

            return Json(wholeList, JsonRequestBehavior.AllowGet);

        }

        [SessionTimeout]
        public JsonResult GetFullSubCategoryList()
        {

            // var wholeList = db.Subcategories.OrderBy(p => p.SubCatNames).Select(p => p.SubCatNames).Distinct().ToList();
            // var users = db.Users.Select(p => p);
            var subcats = db.ContractorCustomerCategories.Select(p => new { p.SubCatName }).ToList().OrderBy(p => p.SubCatName).Distinct();



            return Json(subcats, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetFullProjectSubCategoryList()
        {

            // var wholeList = db.Subcategories.OrderBy(p => p.SubCatNames).Select(p => p.SubCatNames).Distinct().ToList();
            // var users = db.Users.Select(p => p);
            var subcats = db.ProjectCategories.Select(p => new { p.ProjectsSubCatName }).ToList().OrderBy(p => p.ProjectsSubCatName).Distinct();



            return Json(subcats, JsonRequestBehavior.AllowGet);

        }
        [SessionTimeout]
        public ActionResult AddUserContractorCustomerCategories(string json)
        {
            var userId = User.Identity.GetUserId();

            if (json != string.Empty)
            {
                foreach (var item in json.Trim(',').Split(','))
                {

                    var m = long.Parse(item.Split('_')[0]);
                    var s = long.Parse(item.Split('_')[1]);

                    var MainCatName = db.Categories.Where(p => p.Id == m).Select(p => p.MainCatName).FirstOrDefault();
                    var SubCatName = db.Subcategories.Where(p => p.Id == s).Select(p => p.SubCatNames).FirstOrDefault();
                    var UserCategories = db.ContractorCustomerCategories.Where(p => p.ContractorCustomerId == userId && p.MainCatId == m && p.SubCatId == s).ToList();

                    if (UserCategories.Count() == 0)
                    {
                        ContractorCustomerCategories SelectedProfession = new ContractorCustomerCategories
                        {
                            ContractorCustomerId = userId,
                            MainCatId = long.Parse(item.Split('_')[0]),
                            SubCatId = long.Parse(item.Split('_')[1]),
                            MainCatName = MainCatName,
                            SubCatName = SubCatName
                        };

                        db.ContractorCustomerCategories.Add(SelectedProfession);
                        db.SaveChanges();
                    }

                }
            }

            return Json("", JsonRequestBehavior.AllowGet);
        }
        [SessionTimeout]
        public ActionResult RemoveUserContractorCustomerCategories(int mainId, int subId)
        {
            var userId = User.Identity.GetUserId();

            var UserProfessions = db.ContractorCustomerCategories.Where(p => p.ContractorCustomerId == userId && p.SubCatId == subId && p.MainCatId == mainId).ToList();

            foreach (var item in UserProfessions)
            {
                db.ContractorCustomerCategories.Remove(item);
                db.SaveChanges();
            }

            return Json("", JsonRequestBehavior.AllowGet);
        }
        [SessionTimeout]
        public JsonResult GetProjectSubCategoryList(int Id)
        {

            var userId = User.Identity.GetUserId();

            var UserProfessions = db.ProjectCategories.Where(p => p.ProjectsUsersId == userId).ToList();

            var wholeList = db.Subcategories.Where(x => x.MainCatId == Id).ToList();
            List<Subcategories> catList = new List<Subcategories>();

            wholeList.RemoveAll(x => UserProfessions.Any(y => y.ProjectsSubCatId == x.Id));

            return Json(wholeList, JsonRequestBehavior.AllowGet);

        }
        [SessionTimeout]
        public ActionResult AddProjectContractorCustomerCategories(int mainId, int subId, int projectId)
        {
            try
            {
                var userId = User.Identity.GetUserId();

                if (userId != null)
                {
                    ProjectCategories projectCatagory = new ProjectCategories
                    {
                        ProjectsId = projectId,
                        ProjectsMainCatId = mainId,
                        ProjectsSubCatId = subId,
                        ProjectsMainCatName = db.Categories.Where(p => p.Id == mainId).Select(p => p.MainCatName).FirstOrDefault(),
                        ProjectsSubCatName = db.Subcategories.Where(p => p.Id == subId).Select(p => p.SubCatNames).FirstOrDefault(),
                        ProjectsUsersId = userId
                    };

                    db.ProjectCategories.Add(projectCatagory);
                    db.SaveChanges();
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }

                return Json("", JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {
                return Json("ERROR", JsonRequestBehavior.AllowGet);
            }
        }
        [SessionTimeout]
        public ActionResult RemoveProjectContractorCustomerCategories(int mainId, int subId, int projectId)
        {

            try
            {
                var userId = User.Identity.GetUserId();

                if (userId != null)
                {
                    var UserProfessions = db.ProjectCategories.Where(p => p.ProjectsUsersId == userId && p.ProjectsSubCatId == subId && p.ProjectsMainCatId == mainId && p.ProjectsId == projectId).ToList();

                    foreach (var item in UserProfessions)
                    {
                        db.ProjectCategories.Remove(item);
                        db.SaveChanges();
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception)
            {

                return Json("ERROR", JsonRequestBehavior.AllowGet);
            }

            return Json("", JsonRequestBehavior.AllowGet);
        }
        [SessionTimeout]
        public ActionResult AutoComplete(string term)
        {
            if (!String.IsNullOrEmpty(term))
            {
                var list = db.Categories.Where(c => c.MainCatName.ToUpper().StartsWith(term.ToUpper())).Select(c => new { Name = c.MainCatName, ID = c.Id })
                    .ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var list = db.Categories.Select(c => new { Name = c.MainCatName, ID = c.Id })
                    .ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }
        [SessionTimeout]
        public ActionResult AutoCompleteCity(string term)
        {
            if (!String.IsNullOrEmpty(term))
            {
                var list = db.StateInfo.OrderBy(p => p.City).Where(c => c.City.ToUpper().StartsWith(term.ToUpper())).Select(c => new { Name = c.City, ID = c.Id })
                    .ToList().DistinctBy(p => p.Name);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var list = db.StateInfo.OrderBy(p => p.City).Select(c => new { Name = c.City, ID = c.Id })
                    .ToList().DistinctBy(p => p.Name);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }
        [SessionTimeout]
        public ActionResult AutoCompleteZipCode(string city, string term)
        {
            if (!String.IsNullOrEmpty(term))
            {
                var list = db.StateInfo.OrderBy(p => p.ZipCode).Where(c => c.City.ToUpper() == city.ToUpper() && c.ZipCode.StartsWith(term)).Select(c => new { Name = c.ZipCode, ID = c.Id })
                    .ToList().DistinctBy(p => p.Name);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var list = db.StateInfo.OrderBy(p => p.ZipCode).Select(c => new { Name = c.ZipCode, ID = c.Id })
                    .ToList().DistinctBy(p => p.Name);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        private bool RemoveFromDatabase(DatabaseTypeToRemove type, string imagename = "")
        {

            try
            {
                if (type == DatabaseTypeToRemove.ProjectDoument)
                {
                    var document = db.ProjectDocuments.Where(p => p.ImageName == imagename).FirstOrDefault();
                    db.ProjectDocuments.Remove(document);
                    db.SaveChanges();
                }

                if (type == DatabaseTypeToRemove.Profile)
                {

                }



                if (type == DatabaseTypeToRemove.ProfileID)
                {

                }
            }
            catch (Exception ex)
            {

                return false;
            }






            return true;
        }

        [HttpPost]
        [SessionTimeout]
        public async Task<ActionResult> RemoveUpload(string type, int projectId = 0, string imagename = "")
        {
            bool isSavedSuccessfully = true;
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var ProfilePath = "/Uploads/ProfileImages/" + User.Identity.GetUserId() + "/";
            var ResumePath = "/Uploads/ProfileResume/" + User.Identity.GetUserId() + "/";
            try
            {

                if (type == "project")
                {

                    var path = Path.Combine(Server.MapPath("/Uploads/Projects/" + projectId + "/" + User.Identity.GetUserId() + "/"));
                    string pathString = System.IO.Path.Combine(path.ToString() + Path.GetFileName(imagename));

                    if (System.IO.File.Exists(pathString))
                    {
                        System.IO.File.Delete(pathString);

                        RemoveFromDatabase(DatabaseTypeToRemove.ProjectDoument, Path.GetFileName(imagename));
                    }

                }


                if (type == "profile")
                {
                    if (user.ProfileImage != null)
                    {
                        var path = Path.Combine(Server.MapPath(ProfilePath));
                        string pathString = System.IO.Path.Combine(path.ToString() + "profile_" + userId + Path.GetExtension(user.ProfileImage));

                        if (System.IO.File.Exists(pathString))
                        {
                            System.IO.File.Delete(pathString);
                        }

                        user.ProfileImage = null;
                        await UserManager.UpdateAsync(user);
                    }
                }

                if (type == "id")
                {
                    if (user.IdImage != null)
                    {
                        var path = Path.Combine(Server.MapPath(ProfilePath));
                        string pathString = System.IO.Path.Combine(path.ToString() + "id_" + userId + Path.GetExtension(user.IdImage));

                        if (System.IO.File.Exists(pathString))
                        {
                            System.IO.File.Delete(pathString);
                        }
                        user.IdImage = null;
                        await UserManager.UpdateAsync(user);
                    }
                }

                if (type == "resume")
                {
                    if (user.ProfileResume != null)
                    {
                        var path = Path.Combine(Server.MapPath(ResumePath));
                        string pathString = System.IO.Path.Combine(path.ToString() + "resume_" + userId + Path.GetExtension(user.IdImage));

                        if (System.IO.File.Exists(pathString))
                        {
                            System.IO.File.Delete(pathString);
                        }
                        user.IdImage = null;
                        await UserManager.UpdateAsync(user);
                    }
                }

            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
            }
            if (isSavedSuccessfully)
            {
                return Json(new
                {
                    Message = true
                });
            }
            else
            {
                return Json(new
                {
                    Message = false
                });
            }
        }

        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };
        [SessionTimeout]
        private static int GetImageCountFromFolder(string path)
        {

            int i = 0;

            foreach (var item in Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly))
            {
                if (ImageExtensions.Contains(Path.GetExtension(item).ToUpperInvariant()))
                {
                    i++;
                }
            }


            return i++;
        }

        [HttpPost]
        [SessionTimeout]
        public async Task<ActionResult> Upload(string type, int projectId = 0)
        {

            string fName = "";
            bool isSavedSuccessfully = true;

            List<JsonProjectDocumentList> returnList = new List<JsonProjectDocumentList>();
            try
            {

                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];


                    if (file != null && file.ContentLength > 0)
                    {
                        if (type == "project")
                        {
                            fName = SaveProjectFile(projectId, file);
                            JsonProjectDocumentList returnImage = new JsonProjectDocumentList
                            {
                                ImageName = fName.Split(':')[0]
                            };

                            returnList.Add(returnImage);
                        }


                        if (type == "profile")
                        {

                            fName = await SaveProfileFile(file, "profile");

                        }

                        if (type == "id")
                        {
                            fName = await SaveProfileFile(file, "id");

                        }


                        if (type == "resume")
                        {
                            fName = await SaveProfileFile(file, "resume");

                        }

                    }


                }
            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
            }
            if (isSavedSuccessfully)
            {
                if (type == "profile")
                {

                    return Json(new
                    {
                        Message = fName
                    }); ;
                }

                if (type == "id")
                {
                    return Json(new
                    {
                        Message = fName
                    }); ;
                }

                if (type == "project")
                {
                    return Json(new
                    {
                        Message = returnList
                    });
                }

                return Json(new
                {
                    Message = "default"
                });
            }
            else
            {
                return Json(new
                {
                    Message = "Error in saving file"
                });
            }
        }

        [HttpPost]
        [SessionTimeout]
        public ActionResult SaveProjectImageComment(string ImageName, string comment)
        {

            try
            {
                var document = db.ProjectDocuments.Where(p => p.ImageName == ImageName).FirstOrDefault();
                document.ImageComment = comment;
                db.SaveChanges();


            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Message = "Error in saving file"
                });

            }


            return Json(new
            {
                Message = "OK"
            });

        }

        [SessionTimeout]
        private string SaveProjectFile(int projectId, HttpPostedFileBase file)
        {
            string fName;
            var ProjectPath = Path.Combine(Server.MapPath(MainProjectPath + projectId + "/" + User.Identity.GetUserId() + "/"));
            if (!System.IO.Directory.Exists(ProjectPath)) System.IO.Directory.CreateDirectory(ProjectPath);
            int fCount = GetImageCountFromFolder(ProjectPath) + 1;
            //fName = "PID_" + projectId + "_Num_" + fCount + Path.GetExtension(file.FileName);
            fName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
            file.SaveAs(string.Format("{0}{1}", ProjectPath, fName));


            ProjectDocuments pd = new ProjectDocuments
            {
                CreationDate = DateTime.Now,
                ImageName = fName,
                ProjectId = projectId,
                UsersId = User.Identity.GetUserId()
            };
            db.ProjectDocuments.Add(pd);
            db.SaveChanges();


            return fName + ":" + pd.Id.ToString();
        }

        [HttpPost]
        [SessionTimeout]
        public async Task<ActionResult> SaveProjectCompensationPackage(long projectId, long ProjectCompensationType, decimal ByTheHourRate = 0, decimal ByTheProjectRate = 0, decimal StartingBidRate = 0, decimal EndingBidRate = 0, decimal FloatingBidRate = 0, DateTime StartingBidDate = default, DateTime EndingBidDate = default)
        {

            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            bool isSavedSuccessfully = true;
            try
            {
                if (user != null)
                {

                    //change the date to be acceptable but still have it to where we know its blank
                    if (StartingBidDate == Convert.ToDateTime("01/01/0001 12:00 AM")) { StartingBidDate = Convert.ToDateTime("01/01/2000 12:00 AM"); }
                    if (EndingBidDate == Convert.ToDateTime("01/01/0001 12:00 AM")) { EndingBidDate = Convert.ToDateTime("01/01/2000 12:00 AM"); }

                    var pcomp = db.ProjectCompensationPackage.Where(p => p.ProjectId == projectId).FirstOrDefault();


                    if (pcomp != null)
                    {
                        pcomp.ProjectId = projectId;
                        pcomp.ProjectCompensationType = ProjectCompensationType;
                        pcomp.ByTheHourRate = ByTheHourRate;
                        pcomp.ByTheProjectRate = ByTheProjectRate;
                        pcomp.StartingBidRate = StartingBidRate;
                        pcomp.EndingBidRate = EndingBidRate;
                        pcomp.FloatingBidRate = FloatingBidRate;
                        pcomp.StartingBidDate = StartingBidDate;
                        pcomp.EndingBidDate = EndingBidDate;
                        pcomp.UsersId = User.Identity.GetUserId();



                        switch (ProjectCompensationType)
                        {
                            case 1:
                                pcomp.ByTheProjectRate = 0;
                                pcomp.StartingBidRate = 0;
                                pcomp.EndingBidRate = 0;
                                pcomp.FloatingBidRate = 0;
                                break;


                            case 2:
                                pcomp.ByTheHourRate = 0;

                                pcomp.StartingBidRate = 0;
                                pcomp.EndingBidRate = 0;
                                pcomp.FloatingBidRate = 0;
                                break;

                            case 3:
                                pcomp.ByTheHourRate = 0;
                                pcomp.ByTheProjectRate = 0;

                                break;

                            default:
                                break;
                        }

                    }



                    if (pcomp == null)
                    {
                        ProjectCompensationPackage package = new ProjectCompensationPackage
                        {
                            ProjectId = projectId,
                            ProjectCompensationType = ProjectCompensationType,
                            ByTheHourRate = ByTheHourRate,
                            ByTheProjectRate = ByTheProjectRate,
                            StartingBidRate = StartingBidRate,
                            EndingBidRate = EndingBidRate,
                            FloatingBidRate = FloatingBidRate,
                            StartingBidDate = StartingBidDate,
                            EndingBidDate = EndingBidDate,
                            UsersId = User.Identity.GetUserId(),
                            CreationDate = DateTime.Now,
                        };

                        using (var db = new ApplicationDbContext())
                        {
                            db.ProjectCompensationPackage.Add(package);
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        using (var db = new ApplicationDbContext())
                        {
                            db.Entry(pcomp).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
            }
            if (isSavedSuccessfully)
            {
                return Json(new
                {
                    Message = "OK"
                });
            }
            else
            {
                return Json(new
                {
                    Message = "Error"
                });
            }






        }
        [SessionTimeout]
        private async Task<string> SaveProfileFile(HttpPostedFileBase file, string type)
        {
            string fName = "";
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var path = "";

            if (type == "profile")
            {
                fName = "profile_" + User.Identity.GetUserId() + Path.GetExtension(file.FileName);
                path = Path.Combine(Server.MapPath(MainProfilePath + User.Identity.GetUserId() + "/"));
            }

            if (type == "id")
            {
                fName = "id_" + User.Identity.GetUserId() + Path.GetExtension(file.FileName);
                path = Path.Combine(Server.MapPath(MainProfilePath + User.Identity.GetUserId() + "/"));
            }

            if (type == "resume")
            {
                fName = "resume_" + User.Identity.GetUserId() + Path.GetExtension(file.FileName);
                path = Path.Combine(Server.MapPath(MainResumePath + User.Identity.GetUserId() + "/"));

            }

            if (!System.IO.Directory.Exists(path)) System.IO.Directory.CreateDirectory(path);
            file.SaveAs(string.Format("{0}{1}", path, fName));


            if (type == "profile")
            {
                user.ProfileImage = fName;
            }

            if (type == "id")
            {
                user.IdImage = fName;
            }

            if (type == "resume")
            {
                user.ProfileResume = fName;
            }


            await UserManager.UpdateAsync(user);

            return fName;
        }
        [SessionTimeout]
        public ActionResult GetPublicPortalList()
        {
            var userId = User.Identity.GetUserId();
            var projects = db.Project.Select(p => p);
            var ProjectCompensationPackage = db.ProjectCompensationPackage.Select(p => p).ToList();


            PortalList portal = new PortalList();
            if (projects != null && ProjectCompensationPackage != null)
            {
                foreach (var item in projects)
                {
                    foreach (var pack in ProjectCompensationPackage)
                    {
                        if (pack.ProjectId == item.ProjectsId)
                        {
                            item.ByTheHourRate = pack.ByTheHourRate;
                            item.ByTheProjectRate = pack.ByTheProjectRate;

                            portal.Projects.Add(item);
                        }
                    }
                }
            }

            return Json(portal, JsonRequestBehavior.AllowGet);

        }
        [SessionTimeout]
        public ActionResult GetPortalList()
        {
            var userId = User.Identity.GetUserId();
            var projects = db.Project.Where(p => p.ProjectsUsersId == userId);
            var assignedProjects = db.ProjectAssignment.Where(p => p.UsersId == userId);

            PortalList portal = new PortalList();
            if (projects != null && assignedProjects != null)
            {
                foreach (var item in projects)
                {
                    foreach (var project in assignedProjects)
                    {
                        if (project.ProjectId == item.ProjectsId)
                        {
                            portal.Projects.Add(item);
                        }
                    }
                }
            }

            return Json(portal, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult KeepSessionAlive()
        {

            return new JsonResult
            {
                Data = "Beat Generated"
            };
        }

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
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

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