using DealerShipMastery.Data.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DealerShipMastery.UI.Utilities;

namespace DealerShipMastery.UI.Controllers
{
    public class InventoryController : Controller
    {

        public ActionResult Details(int id)
        {
            if (Request.IsAuthenticated)
            {
                ViewBag.UserId = AuthorizeUtilities.GetUserId(this);
            }
            var repo = new MobileSuitRepositoryADO();
            var model = repo.GetDetails(id);


            return View(model);
        }

        public ActionResult MassProducedInventory()
        {
            var repo = new MobileSuitRepositoryADO();
            var model = repo.GetMassProduced();
            return View(model);
        }

        public ActionResult CustomInventory()
        {
            var repo = new MobileSuitRepositoryADO();
            var model = repo.GetCustom();
            return View(model);
        }
        public ActionResult BrokenInventory()
        {
            var repo = new MobileSuitRepositoryADO();
            var model = repo.GetBroken();
            return View(model);
        }
    }
}