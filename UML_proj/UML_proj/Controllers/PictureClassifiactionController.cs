using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UML_proj.Models;
using UML_proj.ViewModels;

namespace UML_proj.Controllers
{
    public class PictureClassifiactionController : Controller
    {
        public ActionResult ClassifyPictures(Unclassified_pictures[] pictures)
        {
            ITProjektasDB db = new ITProjektasDB();
            foreach (var item in pictures)
            {
                Unclassified_pictures notupdatedParameters = db.Unclassified_pictures.SingleOrDefault(
                                                        x => x.id_Unclassified_pictures == item.id_Unclassified_pictures
                                                     );
                if (notupdatedParameters != null)
                {
                    db.Entry(notupdatedParameters).CurrentValues.SetValues(item);
                }
                db.SaveChanges();
            }
            return RedirectToAction("getUnClassifiedPictures", "PictureClassifiaction");
        }
        // GET: PictureClassifiaction
        public ActionResult getUnClassifiedPictures()
        {
            ITProjektasDB db = new ITProjektasDB();
            UnclassifiedPicutresModel liz = new UnclassifiedPicutresModel();
            liz.pictures = db.Unclassified_pictures.Where(x=>x.picture_class=="" || x.picture_class == null).ToList();
            return View(liz);
        }
    }
}