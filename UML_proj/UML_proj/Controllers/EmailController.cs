using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UML_proj.Models;


namespace UML_proj.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }
        public bool send_entry(Newsletter_entry entry,string msg)
        {
            // contact api here

            // SIMULATING API CALL
            bool reply = true;
            // SIMULATING API CALL

            return reply;
        }

        public bool notify_admin_of_error(Newsletter_entry entry)
        {
            // SIMULATING API CALL
            bool reply = true;
            // SIMULATING API CALL

            return reply;
        }
    }
}