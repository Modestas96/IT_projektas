using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UML_proj.Controllers
{
    public class SearchEngineController : Controller
    {
        // GET: SearchEngine
        public ActionResult OpenSearchEngine()
        {
            return View();
        }

    }
}