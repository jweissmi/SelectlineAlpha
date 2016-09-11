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
        private VehicleConfigDataContext vcdb = new VehicleConfigDataContext();

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
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FullName");

            return View();
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

            Customer customer = Customer.GetCustById(id, db);
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

        // GET: CustomerVehicle/GetYears/
        public JsonResult GetYears()
        {
            List<int> yearsList = new List<int>();

            yearsList = (from yr in vcdb.Years
             where yr.YearID >= 1990
             select yr.YearID).Distinct().OrderByDescending(yr => yr).ToList();

            return Json(yearsList);
        }

        // GET: CustomerVehicle/GetMakes/
        public JsonResult GetMakes(int year)
        {
            List<string> makesList = new List<string>();

            makesList = (from make in vcdb.Makes
                         join bv in vcdb.BaseVehicles on make.MakeID equals bv.MakeID
                         where bv.YearID == year
                         select make.MakeName.Trim()).Distinct().ToList();

            return Json(makesList);
        }

        // GET: CustomerVehicle/GetModels/
        public JsonResult GetModels(int year, string makeName)
        {
            List<string> modelsList = new List<string>();

            modelsList = (from make in vcdb.Makes
                          join bv in vcdb.BaseVehicles on make.MakeID equals bv.MakeID
                          join mod in vcdb.Models on bv.ModelID equals mod.ModelID
                          where bv.YearID == year && make.MakeName == makeName
                          select mod.ModelName.Trim()).Distinct().ToList();

            return Json(modelsList);
        }
    }
}
