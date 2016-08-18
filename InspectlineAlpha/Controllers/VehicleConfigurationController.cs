using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InspectlineAlpha.Controllers
{
    public class VehicleConfigurationController : Controller
    {
        // GET: VehicleConfiguration
        public ActionResult Index()
        {
            return View();
        }

        // GET: VehicleConfiguration/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VehicleConfiguration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleConfiguration/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleConfiguration/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VehicleConfiguration/Edit/5
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

        // GET: VehicleConfiguration/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VehicleConfiguration/Delete/5
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
