using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UML_proj.Controllers
{
    public class SubscriptionController : Controller
    {
         // GET: ProfilePage
        public ActionResult open_profile_page() // open_profile_page()
        {
            return View("ProfilePage");
        }
 
        public ActionResult open_subscription_list() // open_subscription_list()
        {
            return View("SubscriptionList");
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