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

        private InspectlineDataContext db = new InspectlineDataContext();

        // GET: Employee
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        // GET: Employee/Details/
        public ActionResult EmployeeDetails(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            Employee employee = Employee.GetEmpById(id, db);

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
                Employee.CreateEmployee(employee, db);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Customer/EditEmployee/
        public ActionResult EditEmployee(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            Employee employee = Employee.GetEmpById(id, db);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", "LastName", employee.EmployeeID);

            return View(employee);
        }

        // POST: Customer/EditEmployee/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployee([Bind(Include = "EmployeeID, LastName, FirstName, Title, BirthDate, HireDate, Address, City, State, ZipCode, Country, CellPhone, HomePhone, Email")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee.EditEmployee(employee, db);
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", "LastName", employee.EmployeeID);
            return View(employee);

        }

        // GET: Employee/Delete/
        public ActionResult DeleteEmployee(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            Employee emp = Employee.GetEmpById(id, db);

            return View(emp);
        }

        // POST: Employee/Delete/
        [HttpPost, ActionName("DeleteEmployee")]
        public ActionResult DeleteConfirmed(int? id)
        {
            try
            {
                Employee.DeleteEmpById(id, db);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
