using InspectlineAlpha.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InspectlineAlpha.Models
{
    [MetadataType(typeof(ShopMetaData))]

    public partial class Shop
    {

        public static void CreateShop(Shop shop, InspectlineDataContext db)
        {
            db.Shops.InsertOnSubmit(shop);
            db.SubmitChanges();
        }

        public static void EditShop(Shop shop, InspectlineDataContext db)
        {
            var orgShop = (from s in db.Shops
                           where s.ShopID == shop.ShopID
                           select s).FirstOrDefault();

            orgShop.ShopName = shop.ShopName;


            orgShop.Address = shop.Address;
            orgShop.City = shop.City;
            orgShop.State = shop.State;
            orgShop.ZipCode = shop.ZipCode;
            orgShop.Country = shop.Country;
            orgShop.ShopPhone = shop.ShopPhone;
            orgShop.ShopEmail = shop.ShopEmail;
            orgShop.ShopWebsite = shop.ShopWebsite;
            db.SubmitChanges();
        }

        public static Shop GetShopById(int? id, InspectlineDataContext db)
        {
            Shop shop = (from s in db.Shops
                         where s.ShopID == id
                         select s).FirstOrDefault();

            return shop;
        }

        public static void DeleteShopById(int? id, InspectlineDataContext db)
        {
            Shop shop = (from s in db.Shops
                         where s.ShopID == id
                         select s).FirstOrDefault();

            db.Shops.DeleteOnSubmit(shop);
            db.SubmitChanges();
        }
    }
    public class ShopMetaData
    {
        [DisplayName("Shop Name")]
        public string ShopName { get; set; }

        [DisplayName("Added On Date")]
        public string AddedOnDate { get; set; }

        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }

        [DisplayName("Shop Phone")]
        public string ShopPhone { get; set; }

        [DisplayName("Shop Email")]
        public string ShopEmail { get; set; }

        [DisplayName("Website")]
        public string ShopWebsite { get; set; }
    }
}