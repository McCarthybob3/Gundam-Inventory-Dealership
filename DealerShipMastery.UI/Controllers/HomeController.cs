using DealerShipMastery.Data.ADO;
using DealerShipMastery.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealerShipMastery.UI.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            var repo = new MobileSuitRepositoryADO();
            var model = repo.GetRecent();
            return View(model);
        }

      

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us.";
            var repo = new MobileSuitAPIController();
                //var model = repo.AddContact
         //   ViewBag.User = "test";
            return View();
        }


        public ActionResult Special()
        {
            var repo = new SpecialsRepositoryADO();
            var model = repo.GetAll();

            if (User.Identity.IsAuthenticated)
            {

                var user = User.Identity;
                ViewBag.Name = user.Name;

                ViewBag.displayMenu = "No";

                if (IsAdminUser())
                {
                    ViewBag.displayMenu = "Yes";
                }

                return View(model);
            }
            else
            {
                ViewBag.Name = "Not Logged IN";
                return View(model);
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult Special(string Title, string Content)
        {
            var repo = new SpecialsRepositoryADO();
           

            if (User.Identity.IsAuthenticated)
            {

                var user = User.Identity;
                ViewBag.Name = user.Name;

                ViewBag.displayMenu = "No";

                if (IsAdminUser())
                {
                    ViewBag.displayMenu = "Yes";
                }
                repo.Insert(Title, Content);
                var model = repo.GetAll();
                return View(model);
            }
            else
            {
                ViewBag.Name = "Not Logged IN";
                var model = repo.GetAll();
                return View(model);
            }
        }


        public Boolean IsAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}