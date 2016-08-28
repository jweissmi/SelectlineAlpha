using InspectlineAlpha.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InspectlineAlpha.Models
{
    public partial class Inspection
    {
        public static void CreateInspection(Inspection inspection, InspectlineDataContext db)
        {
            db.Inspections.InsertOnSubmit(inspection);
            db.SubmitChanges();
        }

        public static void EditInspection(Inspection inspection, InspectlineDataContext db)
        {
            var orgInspection = (from i in db.Inspections
                                 where i.InspectionID == inspection.InspectionID
                                 select i).FirstOrDefault();

            orgInspection.InspectionDate = inspection.InspectionDate;
            orgInspection.InspectionMileage = inspection.InspectionMileage;


            db.SubmitChanges();
        }

        public static Inspection GetInspectionById(int? id, InspectlineDataContext db)
        {
            Inspection inspection = (from i in db.Inspections
                                     where i.InspectionID == id
                                     select i).FirstOrDefault();

            return inspection;
        }

        public static void DeleteInspectionById(int? id, InspectlineDataContext db)
        {
            Inspection inspection = (from i in db.Inspections
                                     where i.InspectionID == id
                                     select i).FirstOrDefault();

            db.Inspections.DeleteOnSubmit(inspection);
            db.SubmitChanges();
        }

    }
}