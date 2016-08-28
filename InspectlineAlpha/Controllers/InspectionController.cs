using InspectlineAlpha.Models;
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
            return View();
        }

        public ActionResult StartInspection()
        {
            return View();
        }
    }
}