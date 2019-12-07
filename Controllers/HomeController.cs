using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SameDayServicezFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SameDayServicezFinal.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationDbContext db = new ApplicationDbContext();
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
        public async Task<ActionResult> Index()
        {

            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var userId = User.Identity.GetUserId();
            var UserList = db.Users.Select(p => p);
            var projects = db.Project.Select(p => p);

            PortalList portal = new PortalList();

            portal.ApplicationUser = user;
            if (user != null)
            {
                Session["FullName"] = user.FirstName + " " + user.LastName;

            }
            else
            {
                Session["FullName"] = null;
            }



            var contractors = db.Users.Where(p => p.IsInContractorMode == true).ToList();
            foreach (var contractor in contractors)
            {
                ContractorSearchList contractorList = new ContractorSearchList
                {
                    Contractor = contractor,                 
                };
                portal.ContractorList.Add(contractorList);
            }

            portal.Projects = db.Project.Where(p => p.IsActive == true).ToList();


            return View(portal);



        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Works()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}