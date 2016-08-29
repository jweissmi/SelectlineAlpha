using InspectlineAlpha.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace InspectlineAlpha.ViewModel
{
    public class InspectionViewModel
    {

        public Inspection Inspection { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public CustomerVehicle CustVeh { get; set; }
        public Shop Shop { get; set; }
        public SelectList Employees { get; set; }
        public SelectList Customers { get; set; }
        public SelectList Shops { get; set; }

        public InspectionViewModel(Inspection inspection)
        {
            Inspection = Inspection;
            Customer = Customer;
            Employee = Employee;
            CustVeh = CustVeh;
            Shop = Shop;
        }

        public InspectionViewModel()
        {
            Inspection = Inspection;
            Customer = Customer;
            Employee = Employee;
            CustVeh = CustVeh;
            Shop = Shop;
        }
    }
}