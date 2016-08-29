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
        public SelectList Vehicles { get; set; }

        public CustomerViewModel(Customer customer)
        {
            Customer = Customer;
            CustVeh = CustVeh;
            Vehicles = Vehicles;
        }

        public CustomerViewModel()
        {
            Customer = Customer;
            CustVeh = CustVeh;
            Vehicles = Vehicles;
        }
    }
}