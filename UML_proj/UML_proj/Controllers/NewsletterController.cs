using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UML_proj.Models;

namespace UML_proj.Controllers
{
    public class NewsletterController : Controller
    {

        Subscription subs = new Subscription();
        Newsletter news_letter = new Newsletter();
        // GET: NewsletterForm
        public ActionResult open_form() // open_form
        {
            ViewBag.Message = "";
            return View("NewsletterForm");
        }

        public ActionResult send_new_entry(Newsletter newsletter) // send_new_entry
        {
            ViewData["value"] = newsletter.newest_message + "\nmessage sent!";
            //ViewBag.Message = newsletter.content + "\nmessage sent!";
            int id = Int32.Parse(Session["UserID"].ToString());
            newsletter.fk_Personid_Person = id;

            // 1. update the approriate sub's content with the newest one.
            var state = newsletter.update();
            int count = subs.select();
            string str1 = "";
            if (state)
            {
                str1 = "Successfully sent your message! Total subs receiving this message: "+count;
            }
            else
            {
                str1 = "Message sent failed!";
            }


            // 2. select all subed_newsletter who sub'd to this newsletter
            //var entries = sub_letters.select(id, true);

            //str1 += entries.Count();
            str1 += 1;


            // 3. generate newsletter_entries
            // 4. reselect all the entries (not rly neccessary)
            // 5. initiate the sending sequence below

            /*
            newsletter_entries = newsletter_entry.select();
            total = newsletter_entries.count();

            for (int i = 0; i < total; i++)
            {
                discord_send = newsletter_entries[i].send_form.contains("Discord");
                email_send = newsletter_entries[i].send_form.contains("Email");

                if (discord_send && email_send)
                {
                    Thread thread1 = new Thread(discordCmd.send_entry(newsletter_entries[i]));
                    Thread thread1 = new Thread(emailCmd.send_entry(newsletter_entries[i]));
                    thread1.Start();
                    thread2.Start();

                }
                else if (discord_send)
                {
                    Thread thread1 = new Thread(discordCmd.send_entry(newsletter_entries[i]));
                    thread1.Start();
                }
                else if (email_send)
                {
                    Thread thread1 = new Thread(emailCmd.send_entry(newsletter_entries[i]));
                    thread1.Start();
                }

            }
            */
            ViewBag.Message = str1;
            return View("NewsletterForm");
        }


    }
}