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

        public static SelectList GetEmployees(InspectlineDataContext db)
        {
            var employees = (from i in db.Employees
                             select i)
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.EmployeeID.ToString(),
                                    Text = x.FirstName + " " + x.LastName
                                });

            return new SelectList(employees, "Value", "Text");
        }

        public static SelectList GetShops(InspectlineDataContext db)
        {
            var shops = (from i in db.Shops
                             select i)
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.ShopID.ToString(),
                                    Text = x.ShopName + " " + x.ShopPhone
                                });

            return new SelectList(shops, "Value", "Text");
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