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

namespace InspectlineAlpha.Controllers
{
    public class EmployeeController : Controller
    {

        private InspectlineDataContext edb = new InspectlineDataContext();

        // GET: Employee
        public ActionResult Index()
        {
            return View(edb.Employees.ToList());
        }

        // GET: Employee/Details/
        public ActionResult EmployeeDetails(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            Employee employee = Employee.GetEmpById(id, edb);

            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult CreateEmployee()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEmployee([Bind(Include = "FirstName, LastName, Title, BirthDate, HireDate, Address, City, State, ZipCode, Country, CellPhone, HomePhone, Email")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee.CreateEmployee(employee, edb);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employee/Edit/
        public ActionResult EditEmployee(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            Employee employee = Employee.GetEmpById(id, edb);

            return View(employee);
        }

        // POST: Employee/Edit/
        [HttpPost]
        public ActionResult EditEmployee([Bind(Include = "FirstName, LastName, Title, BirthDate, HireDate, Address, City, State, ZipCode, Country, CellPhone, HomePhone, Email")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee.EditEmployee(employee, edb);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employee/Delete/
        public ActionResult DeleteEmployee(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            Employee emp = Employee.GetEmpById(id, edb);

            return View(emp);
        }

        // POST: Employee/Delete/
        [HttpPost, ActionName("DeleteEmployee")]
        public ActionResult DeleteConfirmed(int? id)
        {
            try
            {
                Employee.DeleteEmpById(id, edb);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
