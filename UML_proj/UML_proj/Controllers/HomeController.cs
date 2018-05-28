using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UML_proj.Models;

namespace UML_proj.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
			
			
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Person objUser)
        {
            if (ModelState.IsValid)
            {
                ITProjektasDB db = new ITProjektasDB();
                //Search_parameters param = db.Search_parameters.SingleOrDefault(x => x.id_Search_parameters == 2);
                
                var obj = db.People.Where(a => a.user_name.Equals(objUser.user_name) && a.password.Equals(objUser.password)).FirstOrDefault();
                if (obj != null)
                {
                    Session["UserID"] = obj.id_Person.ToString();
                    Session["UserName"] = obj.name.ToString();
                    return RedirectToAction("UserDashBoard");
                }
            }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page222.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}