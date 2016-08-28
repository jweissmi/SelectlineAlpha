using InspectlineAlpha.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace InspectlineAlpha.ViewModel
{
    public class InspectionViewModel
    {

        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public CustomerVehicle CustVeh { get; set; }
        public Shop Shop { get; set; }

        public InspectionViewModel(Inspection inspection)
        {
            Customer = Customer;
            Employee = Employee;
            CustVeh = CustVeh;
            Shop = Shop;
        }
    }
}