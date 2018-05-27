using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UML_proj.Controllers
{
    public class ImageSearchController : Controller
    {
        

        public String RecognizeImage(String address)
        {
            if (!Validate(address))
            {
                return "-1";
            }
            // After API call..
            return "svogunas";
        }

        private bool Validate(string address)
        {
            // Check if its ok..
            return true;
        }

        // GET: ImageSeaerch
        public ActionResult Index()
        {
            return View();
        }

        // GET: ImageSeaerch/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ImageSeaerch/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImageSeaerch/Create
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

        // GET: ImageSeaerch/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ImageSeaerch/Edit/5
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

        // GET: ImageSeaerch/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ImageSeaerch/Delete/5
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
