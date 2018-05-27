using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UML_proj.Models;

namespace UML_proj.Controllers
{
    public class ProductsController : Controller
    {
        Product productModel = new Product();

        public List<Tuple<Product, String > > GetItems(String textQuery)
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
    }
}