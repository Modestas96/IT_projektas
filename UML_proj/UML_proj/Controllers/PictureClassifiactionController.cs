using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UML_proj.Models;

namespace UML_proj.Controllers
{
    public class PictureClassifiactionController : Controller
    {
        // GET: PictureClassifiaction
        public ActionResult getUnClassifiedPictures()
        {
            ITProjektasDB db = new ITProjektasDB();
            

            return View();
        }
    }
}