﻿using InspectlineAlpha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InspectlineAlpha.Models
{
    public partial class CustomerVehicle
    {
        public static void CreateCustVeh(CustomerVehicle custveh, InspectlineDataContext db)
        {
            db.CustomerVehicles.InsertOnSubmit(custveh);
            db.SubmitChanges();
        }

      
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

        public static void DeleteCustVehById(int? id, InspectlineDataContext db)
        {
            CustomerVehicle custveh = (from cv in db.CustomerVehicles
                                       where cv.CustomerVehicleID == id
                                       select cv).FirstOrDefault();

            db.CustomerVehicles.DeleteOnSubmit(custveh);
            db.SubmitChanges();
        }

    }
}