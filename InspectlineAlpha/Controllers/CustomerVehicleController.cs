using InspectlineAlpha.Models;
using InspectlineAlpha.ViewModel;
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

            Customer customer = Customer.GetCustById(id, db);
            CustomerVehicle custveh = CustomerVehicle.GetCustVehById(id, db);

            return View(custveh);
        }

        // GET: CustomerVehicle/CreateCustVeh
        public ActionResult CreateCustVeh()
        {
            CustomerViewModel model = new CustomerViewModel();
            model.Customers = Customer.GetCustomers(db);
            
            return View(model);
        }

        // POST: CustomerVehicle/CreateCustVeh
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCustVeh([Bind(Include = "CustomerID, YearID, MakeName, ModelName, SubmodelName, Liter, BaseVehicleID, EngineBaseID")] CustomerVehicle customervehicle)
        {
            if (ModelState.IsValid)
            {
                CustomerVehicle.CreateCustVeh(customervehicle, db);
                return RedirectToAction("Index");
            }
            return View(customervehicle);
        }

        // GET: CustomerVehicle/EditCustVeh/
        public ActionResult EditCustVeh(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            CustomerVehicle customervehicle = CustomerVehicle.GetCustVehById(id, db);

            return View(customervehicle);
        }

        // POST: CustomerVehicle/EditCustVeh/
        [HttpPost]
        public ActionResult EditCustVeh([Bind(Include = "CustomerVehicleID, CustomerID, YearID, MakeName, ModelName, SubmodelName, Liter, BaseVehicleID, EngineBaseID")] CustomerVehicle customervehicle)
        {
            if (ModelState.IsValid)
            {
                CustomerVehicle.EditCustVeh(customervehicle, db);
                return RedirectToAction("Index");
            }
            return View(customervehicle);
        }

        // GET: CustomerVehicle/DeleteCustVeh/
        public ActionResult DeleteCustVeh(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            CustomerVehicle customervehicle = CustomerVehicle.GetCustVehById(id, db);

            return View(customervehicle);
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
