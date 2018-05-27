using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UML_proj.Models;

namespace UML_proj.Controllers
{
    public class SubscriptionController : Controller
    {
        Subscribed_newsletter sub_letters = new Subscribed_newsletter();
        IT_PROJEKTASEntities db = new IT_PROJEKTASEntities();

        // GET: ProfilePage
        public ActionResult open_profile_page() // open_profile_page()
        {
            return View("ProfilePage");
        }
 
        public ActionResult open_subscription_list() // open_subscription_list()
        {

            int id = Int32.Parse(Session["UserID"].ToString());
            return View("SubscriptionList");
            //return View("SubscriptionList", sub_letters.select(id,false).ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscribed_newsletter sn = db.Subscribed_newsletter.Find(id);
            if (sn == null)
            {
                return HttpNotFound();
            }
            return View(sn);
        }



        public void delete_subscription()
        {

        }

        public void edit_receive_form()
        {

        }


        public void add_subscription()
        {

        }


        public void attempt_to_delete()
        {

        }


        public void get_subscriptions(int id)
        {

        }
    }
}