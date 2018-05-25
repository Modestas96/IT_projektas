using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LearningParametersController : Controller
    {
        
        public ActionResult LearningParameterForm()
        {
            var parameters = new SearchParameter(0.1, "SGD", null, false);

            return View(parameters);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}