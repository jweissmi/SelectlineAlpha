using InspectlineAlpha.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InspectlineAlpha.Models
{
    [MetadataType(typeof(EmployeeMetaData))]

    public partial class Employee
    {
        [DisplayName("Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

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
    public class EmployeeMetaData
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Birth Date")]
        public string BirthDate { get; set; }

        [DisplayName("Hire Date")]
        public string HireDate { get; set; }

        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }

        [DisplayName("Cell Phone")]
        public string CellPhone { get; set; }

        [DisplayName("Home Phone")]
        public string HomePhone { get; set; }
    }
}