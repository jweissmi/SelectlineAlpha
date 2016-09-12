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
    [MetadataType(typeof(InspectionMetaData))]

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

        public static SelectList GetCustomerVehicle(InspectlineDataContext db)
        {
            var customervehicles = (from i in db.CustomerVehicles
                                    select i)
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.CustomerVehicleID.ToString(),
                                    Text = x.YearID + " " + x.MakeName + " " + x.ModelName
                                });

            return new SelectList(customervehicles, "Value", "Text");
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

        public static void DeleteInspectionById(int? id, InspectlineDataContext db)
        {
            Inspection inspection = (from i in db.Inspections
                                     where i.InspectionID == id
                                     select i).FirstOrDefault();

            db.Inspections.DeleteOnSubmit(inspection);
            db.SubmitChanges();
        }
    }

    public class InspectionMetaData
    {

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Date")]
        public string InspectionDate { get; set; }

        [DisplayName("Mileage")]
        public string InspectionMileage { get; set; }

        [DisplayName("Inspection By")]
        public string EmployeeID { get; set; }

        [DisplayName("Left Front")]
        public int LeftFrontBrake { get; set; }

        [DisplayName("Right Front")]
        public int RightFrontBrake { get; set; }

        [DisplayName("Left Rear")]
        public int LeftRearBrake { get; set; }

        [DisplayName("Right Front")]
        public int RightRearBrake { get; set; }

        [DisplayName("Comments")]
        public string Comments { get; set; }
    }
}