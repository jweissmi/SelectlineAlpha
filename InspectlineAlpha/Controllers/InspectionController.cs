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
    public class InspectionController : Controller
    {
        private InspectlineDataContext db = new InspectlineDataContext();

        // GET: Inspection
        public ActionResult Index()
        {
            return View(db.Inspections.ToList());
        }

        // GET: Inspection/InspectionDetails/
        public ActionResult InspectionDetails(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            Inspection inspection = Inspection.GetInspectionById(id, db);
            CustomerVehicle custveh = CustomerVehicle.GetCustVehById(id, db);
            Employee employee = Employee.GetEmpById(id, db);
            Shop shop = Shop.GetShopById(id, db);

            return View(inspection);
        }

        // GET: Inspection/CreateInspection
        public ActionResult CreateInspection()
        {
            InspectionViewModel model = new InspectionViewModel();
            model.CustomerVehicles = Inspection.GetCustomerVehicle(db);
            model.Employees = Inspection.GetEmployees(db);
            model.Shops = Inspection.GetCustomerVehicle(db);

            return View(model);
        }

        // POST: Inspection/CreateInspection
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateInspection([Bind(Include = "CustomerVehicleID, ShopID, InspectionDate, InspectionMileage, InspectionResult, EmployeeID")] Inspection inspection)
        {
            if (ModelState.IsValid)
            {
                Inspection.CreateInspection(inspection, db);
                return RedirectToAction("Index");
            }
            return View(inspection);
        }

        // GET: Inspection/EditInspection/
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Inspection/EditInspection/
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inspection/DeleteInspection/
        public ActionResult DeleteInspection(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            Inspection inspection = Inspection.GetInspectionById(id, db);

            return View(inspection);
        }

        // POST: Inspection/DeleteInspection/
        [HttpPost, ActionName("DeleteInspection")]
        public ActionResult DeleteConfirmed(int? id)
        {
            try
            {
                Inspection.DeleteInspectionById(id, db);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
