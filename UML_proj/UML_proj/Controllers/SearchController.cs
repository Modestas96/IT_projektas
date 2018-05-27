using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UML_proj.Models;

namespace UML_proj.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Open()
        {
            var res = new ProductsController().GetItems("svog");

            return View("Search", new SearchViewModel());
        }

        [HttpPost]
        public ActionResult Search(SearchViewModel searchParams)
        {
            int type = QueryType(searchParams);
            if(type == 0)
            {

            }
           
            TextSearchController TSC = new TextSearchController();

            var res = TSC.FindProduct(searchParams.SearchEntry.TextQuery);
            var passableObj = new List<Dictionary<String, String> >();

            foreach (var x in res){
                
                var tempMap = new Dictionary<String, String>();
                tempMap["name"] = x.Item1.name;
                tempMap["picture"] = x.Item1.picture;
                tempMap["price"] = x.Item1.price.ToString();
                tempMap["description"] = x.Item1.description;
                tempMap["barcode"] = x.Item1.barcode;
                tempMap["bestDeal"] = x.Item2;
                passableObj.Add(tempMap);
            }

            searchParams.SearchResult = passableObj;
            return View("Search", searchParams);
        }

        private int QueryType(SearchViewModel searchParams) {         
            if(searchParams == null)
                return 0;
            else if(searchParams.SearchEntry.TextQuery != null)
                return 1;
            return 2;
        }

        // GET: Search/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Search/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Search/Create
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

        // GET: Search/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Search/Edit/5
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

        // GET: Search/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Search/Delete/5
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
