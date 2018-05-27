using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UML_proj.Models;

namespace UML_proj.Controllers
{
    public class LearningParametersController : Controller
    {
        // GET: LearningParameters
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update(Search_parameters updatedParameters)
        {
            ITProjektasDB db = new ITProjektasDB();
            Search_parameters notupdatedParameters = db.Search_parameters.SingleOrDefault(
                                                        x => x.id_Search_parameters == updatedParameters.id_Search_parameters
                                                     );
            if (notupdatedParameters != null)
            {
                db.Entry(notupdatedParameters).CurrentValues.SetValues(updatedParameters);
            }
            db.SaveChanges();

            return RedirectToAction("GetLearningParameters", "LearningParameters");
        }
        public ActionResult GetLearningParameters()
        {
            ITProjektasDB db = new ITProjektasDB();
            
            return View(db.Search_parameters);
        }
        public ActionResult LearningParametersForm(int id)
        {
            ITProjektasDB db = new ITProjektasDB();
            
            Search_parameters param = db.Search_parameters.SingleOrDefault(x => x.id_Search_parameters == id);

            return View(param);
        }
    }
}