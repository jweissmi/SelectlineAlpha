using InspectlineAlpha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InspectlineAlpha.Models
{
    public partial class Employee
    {
        public static void CreateEmployee(Employee employee, InspectlineDataContext db)
        {
            db.Employees.InsertOnSubmit(employee);
            db.SubmitChanges();
        }

        public static void EditEmployee(Employee employee, InspectlineDataContext db)
        {
            var orgEmployee = (from e in db.Employees
                               where e.EmployeeID == employee.EmployeeID
                               select e).FirstOrDefault();

            orgEmployee.FirstName = employee.FirstName;
            orgEmployee.LastName = employee.LastName;
            orgEmployee.Title = employee.Title;
            orgEmployee.BirthDate = employee.BirthDate;
            orgEmployee.HireDate = employee.HireDate;
            orgEmployee.Address = employee.Address;
            orgEmployee.City = employee.City;
            orgEmployee.State = employee.State;
            orgEmployee.ZipCode = employee.ZipCode;
            orgEmployee.Country = employee.Country;
            orgEmployee.CellPhone = employee.CellPhone;
            orgEmployee.HomePhone = employee.HomePhone;
            orgEmployee.Email = employee.Email;
            db.SubmitChanges();
        }

        public static Employee GetEmpById(int? id, InspectlineDataContext db)
        {
            Employee employee = (from e in db.Employees
                                 where e.EmployeeID == id
                                 select e).FirstOrDefault();

            return employee;
        }

        public static void DeleteEmpById(int? id, InspectlineDataContext db)
        {
            Employee employee = (from e in db.Employees
                                 where e.EmployeeID == id
                                 select e).FirstOrDefault();

            db.Employees.DeleteOnSubmit(employee);
            db.SubmitChanges();
        }
    }
}