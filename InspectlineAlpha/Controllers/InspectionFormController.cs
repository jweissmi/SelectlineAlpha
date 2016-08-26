using InspectlineAlpha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InspectlineAlpha.Controllers
{
    public class InspectionFormController : Controller
    {
        private InspectlineDataContext db = new InspectlineDataContext();

        // GET: InspectionForm
        public ActionResult Index()
        {
            return View();
        }

        // GET: Customer/CreateCustomer/
        public ActionResult CreateInspectionCustomer()
        {
            return View();
        }

        // POST: Customer/CreateCustomer/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateInspectionCustomer([Bind(Include = "FirstName, LastName, Title, Address, City, State, ZipCode, Country, CellPhone, HomePhone, Email")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                Customer.CreateCustomer(customer, db);
                return RedirectToAction("Index");
            }
            return View(customer);
        }
    }
}