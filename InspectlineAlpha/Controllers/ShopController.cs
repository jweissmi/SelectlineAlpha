using InspectlineAlpha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace InspectlineAlpha.Controllers
{
    public class ShopController : Controller
    {
        private InspectlineDataContext db = new InspectlineDataContext();

        // GET: Shop
        public ActionResult Index()
        {
            return View(db.Shops.ToList());
        }

        // GET: Shop/Details/
        public ActionResult ShopDetails(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            Shop shop = Shop.GetShopById(id, db);

            return View(shop);
        }

        // GET: Shop/Create
        public ActionResult CreateShop()
        {
            return View();
        }

        // POST: Shop/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateShop([Bind(Include = "ShopName, AddedOnDate, Address, City, State, ZipCode, Country, ShopPhone, ShopEmail, ShopWebsite")] Shop shop)
        {
            if (ModelState.IsValid)
            {
                Shop.CreateShop(shop, db);
                return RedirectToAction("Index");
            }
            return View(shop);
        }

        // GET: Shop/Edit/
        public ActionResult EditShop(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            Shop shop = Shop.GetShopById(id, db);

            return View(shop);
        }

        // POST: Shop/Edit/
        [HttpPost]
        public ActionResult EditShop([Bind(Include = "ShopID, ShopName, AddedOnDate, Address, City, State, ZipCode, Country, ShopPhone, ShopEmail, ShopWebsite")] Shop shop)
        {
            if (ModelState.IsValid)
            {
                Shop.EditShop(shop, db);
                return RedirectToAction("Index");
            }
            return View(shop);
        }

        // GET: Shop/Delete/
        public ActionResult DeleteShop(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            Shop shop = Shop.GetShopById(id, db);

            return View(shop);
        }

        // POST: Shop/Delete/
        [HttpPost, ActionName("DeleteShop")]
        public ActionResult DeleteConfirmed(int? id)
        {
            try
            {
                Shop.DeleteShopById(id, db);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
