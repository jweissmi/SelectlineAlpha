using InspectlineAlpha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        // GET: Customer/Details/5
        public ActionResult CustomerDetails(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult CreateCustomer()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult CreateCustomer(FormCollection collection)
        {
            try
            {
                foreach (string _formData in collection)
                {
                    ViewData[_formData] = collection[_formData];
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SubmitFormWithFormCollection(FormCollection formCollection)
        {
            foreach (string _formData in formCollection)
            {
                ViewData[_formData] = formCollection[_formData];
            }

            return View();
        }

        // GET: Customer/Edit/5
        public ActionResult EditCustomer(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult EditCustomer(int id, FormCollection collection)
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

        // GET: Customer/Delete/5
        public ActionResult DeleteCustomer(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult DeleteCustomer(int id, FormCollection collection)
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
