using DealerShipMastery.Data.ADO;
using DealerShipMastery.Models.TableModels;
using DealerShipMastery.UI.Models;
using DealerShipMastery.UI.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web.Mvc;

namespace DealerShipMastery.UI.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult SalesIndex()
        {
            var repo = new MobileSuitRepositoryADO();
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
        public ActionResult Details(int id)
        {
            var repo = new MobileSuitRepositoryADO();
            var modelfirst = repo.GetDetails(id);
            var model = new SalesViewModel();
            var statesrepo = new StateRepositoryADO();
            model.States = new SelectList(statesrepo.GetAll(), "StateId", "Name");
            var purchaseRepo = new PurchaseRepoADO();

            model.Purchase = new SelectList(purchaseRepo.GetAll(), "TypeId", "Type");
           

            model.MobileSuit = modelfirst;
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;

                ViewBag.displayMenu = "No";

                if (IsAdminUser())
                {
                    ViewBag.displayMenu = "Yes";
                }
                if (Request.IsAuthenticated)
                {
                    ViewBag.UserId = AuthorizeUtilities.GetUserId(this);
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
        public ActionResult Details(SalesViewModel temp)
        {

            var repo = new PurchaseRepoADO();


            var suit = temp.MobileSuit;
            var sale = temp.Sale;

            sale.InventoryNumber = suit.InventoryNumber;
            sale.SerialNumber = suit.SerialNumber;
            sale.Type = suit.Type;
            sale.Price = suit.SalePrice;
            var user = AuthorizeUtilities.GetUserId(this);
            repo.Insert(sale, user);
            //model.MobileSuit = modelfirst;
            //if (User.Identity.IsAuthenticated)
            //{
            //    var user = User.Identity;
            //    ViewBag.Name = user.Name;

            //    ViewBag.displayMenu = "No";

            //    if (IsAdminUser())
            //    {
            //        ViewBag.displayMenu = "Yes";
            //    }
            //    if (Request.IsAuthenticated)
            //    {
            //        ViewBag.UserId = AuthorizeUtilities.GetUserId(this);
            //    }
            //    return View(model);
            //}
            //else
            //{
            //    ViewBag.Name = "Not Logged IN";
            //    return View(model);
            //}
            return View(temp);




        }

        [Authorize]
        public ActionResult Models()
        {
            var repo = new ModelRepoADO();
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
                if (Request.IsAuthenticated)
                {
                    ViewBag.UserId = AuthorizeUtilities.GetUserId(this);
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
        public ActionResult Models(string model)
        {
            var repo = new ModelRepoADO();



            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;

                ViewBag.displayMenu = "No";

                if (IsAdminUser())
                {
                    ViewBag.displayMenu = "Yes";
                }
                if (Request.IsAuthenticated)
                {
                    ViewBag.UserId = AuthorizeUtilities.GetUserId(this);
                }
                var userId = AuthorizeUtilities.GetUserId(this);
                repo.Insert(model, userId);

                var models = repo.GetAll();
                return View(models);
            }
            else
            {
                ViewBag.Name = "Not Logged IN";

                var models = repo.GetAll();
                return View(models);
            }

        }







        [Authorize]
        public ActionResult Makes()
        {
            var repo = new MakeRepoADO();
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
                if (Request.IsAuthenticated)
                {
                    ViewBag.UserId = AuthorizeUtilities.GetUserId(this);
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
        public ActionResult Makes(string make)
        {
            var repo = new MakeRepoADO();
           


            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;

                ViewBag.displayMenu = "No";

                if (IsAdminUser())
                {
                    ViewBag.displayMenu = "Yes";
                }
                if (Request.IsAuthenticated)
                {
                    ViewBag.UserId = AuthorizeUtilities.GetUserId(this);
                }
                var userId = AuthorizeUtilities.GetUserId(this);
                repo.Insert(make, userId);

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