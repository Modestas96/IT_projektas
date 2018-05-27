﻿using System;
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
            if (updatedParameters != null)
            {
                db.Search_parameters.Add(updatedParameters);
                db.SaveChanges();
            }
            return View("LearningParametersForm", updatedParameters);
        }

        public ActionResult LearningParametersForm()
        {
            ITProjektasDB db = new ITProjektasDB();
            
            Search_parameters param = db.Search_parameters.SingleOrDefault(x => x.id_Search_parameters == 2);

            return View(param);
        }
    }
}