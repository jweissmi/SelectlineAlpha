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
    [MetadataType(typeof(CustomerVehicleMetaData))]

    public partial class CustomerVehicle
    {
        public static void CreateCustVeh(CustomerVehicle customervehicle, InspectlineDataContext db)
        {
            db.CustomerVehicles.InsertOnSubmit(customervehicle);
            db.SubmitChanges();
        }

        //This version uses Year, Make, Model.  Submodel, Liter, EngineBaseID reserved for next iteration.
        public static void EditCustVeh(CustomerVehicle custveh, InspectlineDataContext db)
        {
            var orgCustVeh = (from cv in db.CustomerVehicles
                              where cv.CustomerVehicleID == custveh.CustomerVehicleID
                              select cv).FirstOrDefault();

            orgCustVeh.CustomerID = custveh.CustomerID;
            orgCustVeh.YearID = custveh.YearID;
            orgCustVeh.MakeName = custveh.MakeName;
            orgCustVeh.ModelName = custveh.ModelName;
            orgCustVeh.SubmodelName = custveh.SubmodelName;
            orgCustVeh.Liter = custveh.Liter;
            orgCustVeh.BaseVehicleID = custveh.BaseVehicleID;
            orgCustVeh.EngineBaseID = custveh.EngineBaseID;
            db.SubmitChanges();
        }

        public static CustomerVehicle GetCustVehById(int? id, InspectlineDataContext db)
        {
            CustomerVehicle custveh = (from cv in db.CustomerVehicles
                                       where cv.CustomerVehicleID == id
                                       select cv).FirstOrDefault();

            return custveh;
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

        public static void DeleteCustVehById(int? id, InspectlineDataContext db)
        {
            CustomerVehicle custveh = (from cv in db.CustomerVehicles
                                       where cv.CustomerVehicleID == id
                                       select cv).FirstOrDefault();

            db.CustomerVehicles.DeleteOnSubmit(custveh);
            db.SubmitChanges();
        }
    }
    public class CustomerVehicleMetaData
    {
        [DisplayName("Year")]
        public string YearID { get; set; }

        [DisplayName("Make")]
        public string MakeName { get; set; }

        [DisplayName("Model")]
        public string ModelName { get; set; }
    }
}