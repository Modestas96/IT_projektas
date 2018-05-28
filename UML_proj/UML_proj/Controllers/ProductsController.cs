using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UML_proj.Models;

namespace UML_proj.Controllers
    {
        public class ProductsController : Controller
        {
            private ITProjektasDB db = new ITProjektasDB();
            private Product product = new Product();


            Product productModel = new Product();

            public List<Tuple<Product, String>> GetItems(String textQuery)
            {
                ITProjektasDB db = new ITProjektasDB();

                var res = new List<Product>();
                var intermed = db.Products.Where(
                    x => x.name.Contains(textQuery) == true
                   ).ToList();
                List<Tuple<Product, String>> ret = new List<Tuple<Product, string>>();
                PriceComparisonController PCC = new PriceComparisonController();

                foreach (var x in intermed)
                {
                    String bestPrice = PCC.ComparePrice(x);
                    Tuple<Product, String> t = new Tuple<Product, string>(x, bestPrice);
                    ret.Add(t);
                }
                return ret;
            }

            // GET: Products
            public ActionResult Index()
            {
                int id = Int32.Parse(Session["UserID"].ToString());
                var products = product.select_personal_products(id);
                //var products = db.Products.Include(p => p.Shop);
                return View(products.ToList());
            }

            // GET: Products/Details/5
            public ActionResult Details(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Product product = db.Products.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product);
            }

            // GET: Products/Create
            public ActionResult Create()
            {
                ViewBag.fk_Shopid_Shop = new SelectList(db.Shops, "id_Shop", "name");
                return View();
            }

            // POST: Products/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "id_Product,name,price,description,state,barcode,picture,fk_Shopid_Shop")] Product product)
            {
                if (ModelState.IsValid)
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.fk_Shopid_Shop = new SelectList(db.Shops, "id_Shop", "name", product.fk_Shopid_Shop);
                return View(product);
            }
            
            // GET: Products/Edit/5
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Product product = db.Products.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                ViewBag.fk_Shopid_Shop = new SelectList(db.Shops, "id_Shop", "name", product.fk_Shopid_Shop);
                return View(product);
            }

            // POST: Products/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "id_Product,name,price,description,state,barcode,picture,fk_Shopid_Shop")] Product product)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.fk_Shopid_Shop = new SelectList(db.Shops, "id_Shop", "name", product.fk_Shopid_Shop);
                return View(product);
            }

            // GET: Products/Delete/5
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Product product = db.Products.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product);
            }

            // POST: Products/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                Product product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }
        }
    }

