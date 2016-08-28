using InspectlineAlpha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace InspectlineAlpha.Controllers
{
    public class CustomerVehicleController : Controller
    {
        private InspectlineDataContext db = new InspectlineDataContext();

        // GET: CustomerVehicle
        public ActionResult Index()
        {
            return View(db.CustomerVehicles.ToList());
        }

        // GET: CustomerVehicle/CustVehDetails/
        public ActionResult CustVehDetails(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            CustomerVehicle custveh = CustomerVehicle.GetCustVehById(id, db);

            return View(custveh);
        }

        // GET: CustomerVehicle/CreateCustVeh
        public ActionResult CreateCustVeh()
        {
            return View();
        }

        // POST: CustomerVehicle/CreateCustVeh
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCustVeh([Bind(Include = "YearID, MakeName, ModelName, SubmodelName, Liter, BaseVehicleID, EngineBaseID")] CustomerVehicle custveh)
        {
            if (ModelState.IsValid)
            {
                CustomerVehicle.CreateCustVeh(custveh, db);
                return RedirectToAction("Index");
            }
            return View(custveh);
        }

        // GET: CustomerVehicle/EditCustVeh/
        public ActionResult EditCustVeh(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            CustomerVehicle custveh = CustomerVehicle.GetCustVehById(id, db);

            return View(custveh);
        }

        // POST: CustomerVehicle/EditCustVeh/
        [HttpPost]
        public ActionResult EditCustVeh([Bind(Include = "CustomerVehicleID, YearID, MakeName, ModelName, SubmodelName, Liter, BaseVehicleID, EngineBaseID")] CustomerVehicle custveh)
        {
            if (ModelState.IsValid)
            {
                CustomerVehicle.EditCustVeh(custveh, db);
                return RedirectToAction("Index");
            }
            return View(custveh);
        }

        // GET: CustomerVehicle/DeleteCustVeh/
        public ActionResult DeleteCustVeh(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            CustomerVehicle custveh = CustomerVehicle.GetCustVehById(id, db);

            return View(custveh);
        }

        // POST: CustomerVehicle/DeleteCustVeh/
        [HttpPost, ActionName("DeleteCustVeh")]
        public ActionResult DeleteConfirmed(int? id)
        {
            try
            {
                CustomerVehicle.DeleteCustVehById(id, db);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
