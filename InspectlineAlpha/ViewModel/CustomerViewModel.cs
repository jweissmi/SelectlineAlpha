using InspectlineAlpha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InspectlineAlpha.ViewModel
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public CustomerVehicle CustVeh { get; set; }

        public SelectList Customers { get; set; }
        public SelectList CustomerVehicles { get; set; }

        public CustomerViewModel(Customer customer)
        {
            Customer = Customer;
            CustVeh = CustVeh;
            CustomerVehicles = CustomerVehicles;
        }

        public CustomerViewModel()
        {
            Customer = Customer;
            CustVeh = CustVeh;
            CustomerVehicles = CustomerVehicles;
        }
    }
}