using InspectlineAlpha.Models;
using InspectlineAlpha.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InspectlineAlpha.Controllers
{
    public class InspectionController : Controller
    {
        private InspectlineDataContext db = new InspectlineDataContext();

        // GET: Inspection
        public ActionResult Index()
        {
            InspectionViewModel model = new InspectionViewModel();
            model.Employees = Inspection.GetEmployees(db);
            model.Shop = Inspection.GetShop(db);

            return View(model);
        }

        public ActionResult StartInspection()
        {
            InspectionViewModel model = new InspectionViewModel();
            model.Employees = Inspection.GetEmployees(db);

            return View(model);
        }
    }
}