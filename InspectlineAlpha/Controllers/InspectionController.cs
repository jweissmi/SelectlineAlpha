using InspectlineAlpha.Models;
using InspectlineAlpha.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Data.Entity.Core.Objects;

namespace InspectlineAlpha.Controllers
{
    public class InspectionController : Controller
    {
        private InspectlineDataContext db = new InspectlineDataContext();

        // GET: Inspection
        public ActionResult IndexSAVE()
        {
            return View(db.Inspections.ToList());
        }

        // GET: Inspection
        public ActionResult Index()
        {
            InspectionViewModel model = new InspectionViewModel();
            
            model.Customers = Inspection.GetCustomers(db);
            //model.CustomerVehicle = Inspection.GetCustomerVehicle(db);
            model.Employees = Inspection.GetEmployees(db);
            model.Shops = Inspection.GetCustomerVehicle(db);

            return View(model);
        }

        public ActionResult StartInspection()
        {
            InspectionViewModel model = new InspectionViewModel();
            model.Customers = Inspection.GetCustomers(db);
            //model.CustomerVehicle = Inspection.GetCustomerVehicle(db);
            model.Employees = Inspection.GetEmployees(db);
            model.Shops = Inspection.GetCustomerVehicle(db);

            return View(model);
        }

        // GET: Inspection/InspectionDetails/
        public ActionResult InspectionDetails(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            Inspection inspection = Inspection.GetInspectionById(id, db);

            return View(inspection);
        }

        // GET: Inspection/CreateInspection
        public ActionResult CreateInspection()
        {
            InspectionViewModel model = new InspectionViewModel();
            model.Customers = Inspection.GetCustomers(db);
            //model.CustomerVehicle = Inspection.GetCustomerVehicle(db);
            model.Employees = Inspection.GetEmployees(db);
            model.Shops = Inspection.GetCustomerVehicle(db);

            return View(model);
        }

        // POST: Inspection/CreateInspection
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateInspection([Bind(Include = "CustomerID, CustomerVehicleID, ShopID, InspectionDate, InspectionMileage, InspectionResult, EmployeeID")] Inspection inspection)
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inspection/DeleteInspection/
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
