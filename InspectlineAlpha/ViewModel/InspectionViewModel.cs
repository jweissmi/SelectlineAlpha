using InspectlineAlpha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InspectlineAlpha.ViewModel
{
    public class InspectionViewModel
    {

        public Customer Customer { get; set; }
        public CustomerVehicle CustVeh { get; set; }
        public Shop Shop { get; set; }
        
        public InspectionViewModel(Inspection inspection)            
        {
            Customer = Customer;
            CustVeh = CustVeh;
            Shop = Shop;
        }
}
}