using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UML_proj.Models;

namespace UML_proj.Controllers
{
    public class TextSearchController : Controller
    {
        ITProjektasDB db = new ITProjektasDB();
        // GET: TextSearch
        public ActionResult Index()
        {
            return View();
        }

        // GET: TextSearch/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TextSearch/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TextSearch/Create
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

        internal List<Dictionary<string, string>> FindProduct(string textQuery)
        {
            return new ProductsController().GetItems(textQuery);
        }


        // GET: TextSearch/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TextSearch/Edit/5
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

        // GET: TextSearch/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TextSearch/Delete/5
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
