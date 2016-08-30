using InspectlineAlpha.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InspectlineAlpha.Models
{
    [MetadataType(typeof(CustomerMetaData))]

    public partial class Customer
    {

        public static void CreateCustomer(Customer customer, InspectlineDataContext db)
        {
            db.Customers.InsertOnSubmit(customer);
            db.SubmitChanges();
        }

        public static void IndexSample(Customer customer, InspectlineDataContext db)
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
            orgCustomer.CustomerVehicleID = customer.CustomerID;
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

        public static SelectList GetCustomers(InspectlineDataContext db)
        {
            var customers = (from i in db.Customers
                             select i)
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.CustomerID.ToString(),
                                    Text = x.FirstName + " " + x.LastName
                                });

            return new SelectList(customers, "Value", "Text");
        }

        public static SelectList GetCustomerVehicle(InspectlineDataContext db)
        {
            var customervehicles = (from i in db.CustomerVehicles
                                    select i)
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.CustomerVehicleID.ToString(),
                                    Text = x.YearID + " " + x.MakeName + " " + x.ModelName
                                });

            return new SelectList(customervehicles, "Value", "Text");
        }

        public static void DeleteCustById(int? id, InspectlineDataContext db)
        {
            Customer customer = (from c in db.Customers
                                 where c.CustomerID == id
                                 select c).FirstOrDefault();

            db.Customers.DeleteOnSubmit(customer);
            db.SubmitChanges();
        }

        public static SelectList GetVehicles(InspectlineDataContext db)
        {
            var vehicles = (from i in db.CustomerVehicles
                             select i)
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.CustomerVehicleID.ToString(),
                                    Text = x.YearID + " " + x.MakeName + " " + x.ModelName
                                });

            return new SelectList(vehicles, "Value", "Text");
        }

    }
    public class CustomerMetaData
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }

        [DisplayName("Cell Phone")]
        public string CellPhone { get; set; }

        [DisplayName("Home Phone")]
        public string HomePhone { get; set; }
    }
}