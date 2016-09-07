using InspectlineAlpha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Data.Entity.Core.Objects;
using InspectlineAlpha.ViewModel;

namespace InspectlineAlpha.Controllers
{
    public class CustomerController : Controller
    {
        private InspectlineDataContext db = new InspectlineDataContext();

        // GET: Customer
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customer/CustomerDetails/
        public ActionResult CustomerDetails(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            Customer customer = Customer.GetCustById(id, db);

            return View(customer);
        }

        // GET: Customer/CreateCustomer/
        public ActionResult CreateCustomer()
        {
            return View();
        }

        // POST: Customer/CreateCustomer/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCustomer([Bind(Include = "FirstName, LastName, Title, Address, City, State, ZipCode, Country, CellPhone, HomePhone, Email")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                Customer.CreateCustomer(customer, db);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customer/EditCustomer/
        public ActionResult EditCustomer(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            Customer customer = Customer.GetCustById(id, db);

            return View(customer);
        }

        // POST: Customer/EditCustomer/
        [HttpPost]
        public ActionResult EditCustomer([Bind(Include = "CustomerID, FirstName, LastName, Title, Address, City, State, ZipCode, Country, CellPhone, HomePhone, Email")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                Customer.EditCustomer(customer, db);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customer/DeleteCustomer/
        public ActionResult DeleteCustomer(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            Customer cust = Customer.GetCustById(id, db);

            return View(cust);
        }

        // POST: Customer/DeleteCustomer/
        [HttpPost, ActionName("DeleteCustomer")]
        public ActionResult DeleteConfirmed(int? id)
        {
            try
            {
                Customer.DeleteCustById(id, db);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
