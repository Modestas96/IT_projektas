using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UML_proj.Models;

namespace UML_proj.Controllers
{
    public class PriceComparisonController : Controller
    {
        // GET: PriceComparison
        public ActionResult Index()
        {
            return View();
        }

        // GET: PriceComparison/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PriceComparison/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PriceComparison/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        internal string ComparePrice(Product x)
        {
            // bad idea
            Shop dummy = new Shop();

            ITProjektasDB db = new ITProjektasDB();
            string resStr = "No deals for this item found.";
            // Find cheapest
            Product_in_shop inShopObj = db.Product_in_shop.Where(model => model.fk_Productid_Product == x.id_Product).OrderBy(model=>model.price).FirstOrDefault();
            Shop d = dummy.GetShop(1);
            if (d == null || inShopObj == null) return resStr;
            resStr = "Best price found in the " + d.name + " shop of $" + inShopObj.price + ".";
            return resStr;
        }

        // GET: PriceComparison/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PriceComparison/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PriceComparison/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PriceComparison/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
