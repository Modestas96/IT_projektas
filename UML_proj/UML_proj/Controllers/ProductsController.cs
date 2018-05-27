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

        public List<Dictionary<string, string>> GetItems(String textQuery)
        {
            ITProjektasDB db = new ITProjektasDB();

            var res = new List<Dictionary<string, string> >();
            var intermed = db.Products.Where(
                x => x.name.Contains(textQuery) || textQuery.Contains(x.name)
               );
            Func<List<Product>> dd = intermed.ToList;
            return res;
        }
    }
}