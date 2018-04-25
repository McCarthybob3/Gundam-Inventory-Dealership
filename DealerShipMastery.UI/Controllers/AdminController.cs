using DealerShipMastery.Data.ADO;
using DealerShipMastery.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealerShipMastery.UI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }


        [Authorize]
        public ActionResult Add()
        {


            var model = new AddMobileSuitViewModel();

            var TypeRepo = new TypeRepositoryADO();
            var BodyRepo = new BodyStylesRepoADO();
            var CenturyRepo = new CenturyRepoADO();
            var ColorRepo = new ColorRepoADO();
            var ModelRepo = new ModelRepoADO();
            var MakeRepo = new MakeRepoADO();
            var WeaponRepo = new WeaponRepoADO();

            model.Types = new SelectList(TypeRepo.GetAll(), "TypeId", "Name");

            model.BodyStyles = new SelectList(BodyRepo.GetAll(), "BodyStyleId", "Name");
              
            model.Centuries = new SelectList(CenturyRepo.GetAll(), "CenturyId", "CenturyName");
          
            model.Colors = new SelectList(ColorRepo.GetAll(), "ColorId", "Name");
            model.Models = new SelectList(ModelRepo.GetAll(), "ModelId", "Name");
            model.Makes = new SelectList(MakeRepo.GetAll(), "MakeId", "Name");
            model.Weapons = new SelectList(WeaponRepo.GetAll(), "WeaponId", "WeaponName");
              
            //  model.Categories = new SelectList(categoriesRepo.GetAll(), "CategoryName", "CategoryName");

            return View(model);
        }

        [Authorize]
  [HttpPost]
        public ActionResult Add(AddMobileSuitViewModel model)
        {
           var user= User.Identity;
            model.MobileSuit.UserID = user.GetUserId();

            var MakeModelCheck = new MakeModelrepo();
            var test = MakeModelCheck.GetByBoth(model.MobileSuit.MakeID, model.MobileSuit.ModelID);

            if (test.MakeModelID == 0)
            {
                var temp = MakeModelCheck.Insert(model.MobileSuit.MakeID, model.MobileSuit.ModelID);
                model.MobileSuit.MakeModelID = temp;
            }
            else {
                model.MobileSuit.MakeModelID = test.MakeModelID;
            }



            if (ModelState.IsValid)
            {
                var repo = new MobileSuitRepositoryADO();

                try
                {
                    var savepath = Server.MapPath("~/Images");

                    string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                    string extension = Path.GetExtension(model.ImageUpload.FileName);

                    var filePath = Path.Combine(savepath, fileName + extension);

                    int counter = 1;
                    while (System.IO.File.Exists(filePath))
                    {
                        filePath = Path.Combine(savepath, fileName + counter.ToString() + extension);
                        counter++;
                    }

                    model.ImageUpload.SaveAs(filePath);

                    model.MobileSuit.Image = Path.GetFileName(filePath);

                    repo.Insert(model.MobileSuit);

                    return RedirectToAction("MobileSuits", "Admin");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                var model2 = new AddMobileSuitViewModel();
                var TypeRepo = new TypeRepositoryADO();
                var BodyRepo = new BodyStylesRepoADO();
                var CenturyRepo = new CenturyRepoADO();
                var ColorRepo = new ColorRepoADO();
                var ModelRepo = new ModelRepoADO();
                var MakeRepo = new MakeRepoADO();
                var WeaponRepo = new WeaponRepoADO();

                model2.Types = new SelectList(TypeRepo.GetAll(), "TypeId", "Name");

                model2.BodyStyles = new SelectList(BodyRepo.GetAll(), "BodyStyleId", "Name");
         
                model2.Centuries = new SelectList(CenturyRepo.GetAll(), "CenturyId", "CenturyName");
      
                model2.Colors = new SelectList(ColorRepo.GetAll(), "ColorId", "Name");
                model2.Models = new SelectList(ModelRepo.GetAll(), "ModelId", "Name");
                model2.Makes = new SelectList(MakeRepo.GetAll(), "MakeId", "Name");
                model2.Weapons = new SelectList(WeaponRepo.GetAll(), "WeaponId", "WeaponName");


                return View(model2);
            }
        }

        [Authorize]
        public ActionResult MobileSuits()
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