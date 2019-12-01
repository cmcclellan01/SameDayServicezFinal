﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
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
        private ApplicationDbContext db = new ApplicationDbContext();


        public enum DatabaseTypeToRemove
        {
            Profile,
            ProjectDoument,
            ProfileID
        }


        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager )
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


        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(bool IsContractor = true)
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
            return RedirectToAction("Index", "Home");
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

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);

            if (result == SignInStatus.Success)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                user.Online = true;
                Session["FullName"] = user.FirstName + " " + user.LastName;
                Session["ID"] = user.Id;
                await UserManager.UpdateAsync(user);
                await LoginTime(model.Email);
            }

            switch (result)
            {
                case SignInStatus.Success:
                    if (returnUrl == "")
                    {
                        return RedirectToAction("Portal", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                    }
                    else
                    {
                        return RedirectToLocal(returnUrl);
                    }
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                    TempData["loginError"] = "Invalid login attempt. Please check your username or password";
                    ViewBag.ErrorResult = "Invalid login attempt. Please check your username or password";
                    return View(model);
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
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent:  model.RememberMe, rememberBrowser: model.RememberBrowser);
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
        [ValidateAntiForgeryToken]
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
                    PercentDone = 20  , 
                    DisplayName = model.FirstName + " " + model.LastName,
                    UserName = model.Email
                };

                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Profile", "Account", new { nr = true });
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
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
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

                if(model.ApplicationUser.OldPassword != null && model.ApplicationUser.NewPassword != null)
                {
                    IdentityResult passwordresult = await UserManager.ChangePasswordAsync(userId, model.ApplicationUser.OldPassword, model.ApplicationUser.NewPassword);
                }               

                IdentityResult result =  await UserManager.UpdateAsync(user);
  

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
            UpdatePortal(portal);

            return PartialView("_Projects", portal);
        }

        [HttpGet]
        [SessionTimeout]
        public async Task<ActionResult> Portal()
        {
            var states = Utils.Extensions.GetStatesList();
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            PortalList portal = new PortalList();


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
 
        public void UpdatePortal(PortalList portal)
        {
            var users = db.Users.Select(p => p).ToList();
            var userId = User.Identity.GetUserId();
            List<ProjectAssignment> ProjectAssignments = new List<ProjectAssignment>();

            switch (portal.ApplicationUser.IsInContractorMode)
            {

                case true:
                    portal.Projects = db.Project.Where(p => p.IsActive == true && p.AcceptingContractors == true).ToList();
                    break;

                case false:
                    portal.Projects = db.Project.Where(p => p.ProjectsUsersId == userId).ToList();
                    break;
            }         


            foreach (var project in portal.Projects)
            {             

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
                //var ProjectCompensationPackage = db.ProjectCompensationPackage.Where(p => p.ProjectId == project.ProjectsId).SingleOrDefault();
                //if (ProjectCompensationPackage != null)
                //{
                //    project.SelectedProjectCompensationPackage = ProjectCompensationPackage.ProjectCompensationType;
                //    project.ByTheHourRate = ProjectCompensationPackage.ByTheHourRate;
                //    project.ByTheProjectRate = ProjectCompensationPackage.ByTheProjectRate;
                //    project.EndingBidDate = ProjectCompensationPackage.EndingBidDate;
                //    project.EndingBidRate = ProjectCompensationPackage.EndingBidRate;
                //    project.FloatingBidRate = ProjectCompensationPackage.FloatingBidRate;
                //    project.StartingBidDate = ProjectCompensationPackage.StartingBidDate;
                //    project.StartingBidRate = ProjectCompensationPackage.StartingBidRate;
                //}

                // add the Project Job Categories to the object
               // project.ProjectCategories = db.ProjectCategories.Where(p => p.ProjectsId == project.ProjectsId).ToList();

                // add the Project Documents to the object
               // project.ProjectDocuments = db.ProjectDocuments.Where(p => p.ProjectId == project.ProjectsId).ToList();

                // fill the drops downs on the model
                //project.States = GetSelectListItems(states);
                //project.Professions = new List<SelectListItem>();
                //project.SubProfessions = new List<SelectListItem>();
                //project.CompensationTypeList = Utils.Extensions.GetCompensationType();

               // project.Conversations = new List<Conversations>();
                //project.Conversations = db.Conversations.Where(p => p.ProjectId == project.ProjectsId).ToList();


             

            }
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

            return PartialView("_FullProfile", portal);
        }


        [SessionTimeout]
        public ActionResult ContractorSearch(int rating=0,string HourlyRange="",string displayName="",string Profession="",string OnlineStatus="",bool All=false, int page=0)
        {
            PortalList portal = new PortalList();
            var userId = User.Identity.GetUserId();
            List<ApplicationUser> allcontractors = new List<ApplicationUser>();
            
            if(rating != 0)
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
                        foreach (var user in db.Users.Where(p => p.IsInContractorMode == true && p.ByTheHourRate > 100 ).ToList())
                        {
                            allcontractors.Add(user);
                        }
                        break;


                }
            }

            if (!string.IsNullOrEmpty(displayName))
            {
                foreach (var user in db.Users.Where(p => p.IsInContractorMode == true && p.DisplayName.Contains(displayName)).ToList())
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

            if(OnlineStatus != "")
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
            }

            portal.Projects = db.Project.Where(p => p.ProjectsUsersId == userId && p.IsActive == true).ToList();

         

            portal.ContractorList.OrderBy(p => p.Contractor.DisplayName);
            portal.Pager = pager;

        

            return PartialView("_ContractorSearch", portal);
        }
        [SessionTimeout]
        public ActionResult AssignContractor(string contractorId,long projectId)
        {
            var userId = User.Identity.GetUserId();
            ProjectAssignment projectAssignment = new ProjectAssignment
            {
                CreationDate = DateTime.Now,
                LastUpdated = DateTime.Now,
                ProjectId = projectId,
                UsersId = contractorId,
                ProjectOwner = userId
            };
           
            if (db.ProjectAssignment.Where(p => p.UsersId == contractorId && p.ProjectId == projectId).ToList().Count() == 0)
            {
                db.ProjectAssignment.Add(projectAssignment);
                db.SaveChanges();
            }
                       
            return Json("OK", JsonRequestBehavior.AllowGet);
        }
        [SessionTimeout]
        public ActionResult GetProject(long projectId)
        {
            Project project = new Project();
            var userId = User.Identity.GetUserId();
            var states = Extensions.GetStatesList();
            List<ProjectAssignment> ProjectAssignments = new List<ProjectAssignment>();

            var users = db.Users.Select(p => p).ToList();

            project = db.Project.Where(p => p.ProjectsId == projectId).SingleOrDefault();

            
                // add the project assignments to the object
                project.ProjectAssignments = new List<ProjectAssignment>();
                ProjectAssignments = db.ProjectAssignment.Where(p => p.ProjectId == project.ProjectsId && p.ProjectOwner == userId).ToList();


                foreach (var Assignment in ProjectAssignments)
                {
                    var profile = users.Where(i => i.Id == Assignment.UsersId).SingleOrDefault();
                    var projectOwnerName = users.Where(i => i.Id == Assignment.UsersId).SingleOrDefault();
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
                project.CompensationTypeList = Utils.Extensions.GetCompensationType();

                project.Conversations = new List<Conversations>();
                project.Conversations = db.Conversations.Where(p => p.ConversationOwnerId == userId).ToList();



            Session["IsInContractorMode"] = (users.Where(i => i.Id == userId).SingleOrDefault()).IsInContractorMode;


            return PartialView("_ViewProject", project);
        }
        [SessionTimeout]
        public async Task<ActionResult> UpdateProfile(string DisplayName,string Bio,string Email,string Address, string City, string State, string ZipCode, string FirstName, string MiddleName, string LastName, string PhoneNumber, decimal ByTheHourRate, string BirthDate,bool IsInContractorMode,string OldPassword,string NewPassword,bool InWorkMode)
        {

            var userId = User.Identity.GetUserId();

            ApplicationUser profile = db.Users.Where(p => p.Id == userId).SingleOrDefault();
                                  
            if(profile != null)
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

                if (OldPassword != null && NewPassword != null)
                {
                    IdentityResult passwordresult = await UserManager.ChangePasswordAsync(userId, OldPassword, NewPassword);
                }
            }

         
          
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
            

            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        [SessionTimeout]
        public ActionResult UpdateProject(string ProjectTitle, string Description, string Address, string City, string State, string ZipCode, long projectID,
            decimal ByTheHourRate, decimal ByTheProjectRate,decimal StartingBidRate,DateTime StartingBidDate, DateTime EndingBidDate, long SelectedProjectCompensationPackage,string Notes)
        {


            var project = db.Project.Where(p => p.ProjectsId == projectID).FirstOrDefault();

            if(project != null)
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
            }

            using (var db = new ApplicationDbContext())
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
            }

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

        [SessionTimeout]
        public JsonResult GetFullSubCategoryList()
        {

            // var wholeList = db.Subcategories.OrderBy(p => p.SubCatNames).Select(p => p.SubCatNames).Distinct().ToList();
            // var users = db.Users.Select(p => p);
            var subcats = db.ContractorCustomerCategories.Select(p => new { p.SubCatName }).ToList().OrderBy(p => p.SubCatName).Distinct();



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
        public async Task<ActionResult> SaveProjectCompensationPackage(int projectId, long ProjectCompensationType, decimal ByTheHourRate = 0, decimal ByTheProjectRate = 0, decimal StartingBidRate = 0, decimal EndingBidRate = 0, decimal FloatingBidRate = 0, DateTime StartingBidDate = default, DateTime EndingBidDate = default)
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
            string fName;
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            if (type == "profile")
            {
                fName = "profile_" + User.Identity.GetUserId() + Path.GetExtension(file.FileName);
            }
            else
            {
                fName = "id_" + User.Identity.GetUserId() + Path.GetExtension(file.FileName);
            }

            var ProfilePath = Path.Combine(Server.MapPath(MainProfilePath + User.Identity.GetUserId() + "/"));
            if (!System.IO.Directory.Exists(ProfilePath)) System.IO.Directory.CreateDirectory(ProfilePath);
            file.SaveAs(string.Format("{0}{1}", ProfilePath, fName));


            if (type == "profile")
            {
                user.ProfileImage = fName;
            }
            else
            {
                user.IdImage = fName;
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