using InspectlineAlpha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InspectlineAlpha.Models
{
    public partial class Customer
    {

        public static void CreateCustomer(Customer customer, InspectlineDataContext db)
        {
            db.Customers.InsertOnSubmit(customer);
            db.SubmitChanges();
        }

        public static void EditCustomer(Customer customer, InspectlineDataContext db)
        {
            var orgCustomer = (from c in db.Customers
                               where c.CustomerID == customer.CustomerID
                               select c).FirstOrDefault();

            orgCustomer.FirstName = customer.FirstName;
            orgCustomer.LastName = customer.LastName;
            orgCustomer.Title = customer.Title;
            orgCustomer.Address = customer.Address;
            orgCustomer.City = customer.City;
            orgCustomer.State = customer.State;
            orgCustomer.ZipCode = customer.ZipCode;
            orgCustomer.Country = customer.Country;
            orgCustomer.CellPhone = customer.CellPhone;
            orgCustomer.HomePhone = customer.HomePhone;
            orgCustomer.Email = customer.Email;
            db.SubmitChanges();
        }

        public static Customer GetCustById(int? id, InspectlineDataContext db)
        {
            Customer customer = (from c in db.Customers
                                 where c.CustomerID == id
                                 select c).FirstOrDefault();

            return customer;
        }

        public static void DeleteById(int? id, InspectlineDataContext db)
        {
            Customer customer = (from c in db.Customers
                                 where c.CustomerID == id
                                 select c).FirstOrDefault();

            db.Customers.DeleteOnSubmit(customer);
            db.SubmitChanges();
        }

    }
}