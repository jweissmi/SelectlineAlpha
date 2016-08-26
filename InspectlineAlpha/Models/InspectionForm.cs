using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InspectlineAlpha.Models
{
    public class InspectionForm
    {
        public int CustomerID { get; set; }
        public int CustomerVehicleID { get; set; }
        public int ShopID { get; set; }

        public virtual Customer cust { get; set; }
        public virtual CustomerVehicle custveh { get; set; }
        public virtual Shop shop { get; set; }
    }
}