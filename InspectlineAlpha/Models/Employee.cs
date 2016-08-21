using InspectlineAlpha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InspectlineAlpha.Models
{
    public partial class Employee
    {
        public static void CreateEmployee(Employee employee, InspectlineDataContext edb)
        {
            edb.Employees.InsertOnSubmit(employee);
            edb.SubmitChanges();
        }

        public static void EditEmployee(Employee employee, InspectlineDataContext edb)
        {
            var orgEmployee = (from e in edb.Employees
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
            edb.SubmitChanges();
        }

        public static Employee GetEmpById(int? id, InspectlineDataContext edb)
        {
            Employee employee = (from e in edb.Employees
                                 where e.EmployeeID == id
                                 select e).FirstOrDefault();

            return employee;
        }

        public static void DeleteEmpById(int? id, InspectlineDataContext edb)
        {
            Employee employee = (from e in edb.Employees
                                 where e.EmployeeID == id
                                 select e).FirstOrDefault();

            edb.Employees.DeleteOnSubmit(employee);
            edb.SubmitChanges();
        }
    }
}