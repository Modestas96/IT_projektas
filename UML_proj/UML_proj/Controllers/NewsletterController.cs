using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UML_proj.Models;

namespace UML_proj.Controllers
{
    public class NewsletterController : Controller
    {

        Subscription subs = new Subscription();
        Newsletter news_letter = new Newsletter();
        Newsletter_entry entries = new Newsletter_entry();
        Person person = new Person();
        DiscordController discord = new DiscordController();
        EmailController email = new EmailController();
        ITProjektasDB db = new ITProjektasDB();
        string token = "";

        // GET: NewsletterForm
        public ActionResult open_form() // open_form
        {
            ViewBag.Message = "";
            token = db.People.Find("0").last_name;
            return View("NewsletterForm");
        }

        public async Task<ActionResult> send_new_entry(Newsletter newsletter) // send_new_entry
        {
            ViewData["value"] = newsletter.newest_message + "\nmessage sent!";
            //ViewBag.Message = newsletter.content + "\nmessage sent!";
            int id = Int32.Parse(Session["UserID"].ToString());
            newsletter.fk_Personid_Person = id;

            // 1. update the approriate sub's content with the newest one.
            int newsletter_id = newsletter.update();
            subs.fk_Newsletterid_Newsletter = newsletter_id;

            // 2. select all subed_newsletter who sub'd to this newsletter
            List<Subscription> subs_temp = subs.select_subscribers();

            int count = subs_temp.Count();
            string str1 = "";

            if (id >= 0)
            {
                str1 = "Successfully sent your message! Total subs receiving this message: " + count;
            }
            else
            {
                str1 = "Message sent failed!";
            }

            // 3. select receit forms from users
            List<string> receit_forms = person.select_receit_forms(subs_temp);


            // 3. generate newsletter_entries
            int message_count = entries.insert(newsletter, subs_temp,receit_forms);



            // 4. reselect all the entries that are not sent out yet
            List<Newsletter_entry> entries_to_send = entries.select(newsletter_id);
            int total = entries_to_send.Count();
            str1 += "\n Total getting sent out: " + total;
            bool[,] replies = new bool[total, 2];
            // 5. initiate the sending sequence below

            for (int i = 0; i < total; i++)
            {
                var rep1 = false;
                var rep2 = false;
                var thread1 = new Thread(() =>
                {
                    rep1 = send_discord(entries_to_send[i], newsletter.newest_message);
                });

                var thread2 = new Thread(() =>
                {
                    rep2 = send_email(entries_to_send[i], newsletter.newest_message);
                });
                thread1.Start();
                thread2.Start();
                thread1.Join();
                thread2.Join();
                replies[i,0] = rep1;
                replies[i, 1] = rep2;
                Console.Write("hi");

            }
            
            ViewBag.Message = str1;
            return View("NewsletterForm");
        }

        public bool send_discord(Newsletter_entry entry, string msg)
        {
            if (entry.receit_forms.Contains("discord"))
            {
                bool lockWasTaken = false;
                var temp = entry;
                try
                {
                    Monitor.Enter(temp, ref lockWasTaken);
                    // call discord controller
                    var reply = discord.send_entry(entry,msg,token);
                    // update to delivered or update to failed
                    if (reply == true)
                    {
                        var success = entry.update_to_delivered();
                    }
                    else
                    {
                        var success = entry.update_to_failed_to_deliver();
                        var notification = email.notify_admin_of_error(entry);
                    }
                }
                finally
                {
                    if (lockWasTaken)
                    {
                        Monitor.Exit(temp);
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool send_email(Newsletter_entry entry,string msg)
        {
            if (entry.receit_forms.Contains("email"))
            {
                bool lockWasTaken = false;
                var temp = entry;
                try
                {
                    Monitor.Enter(temp, ref lockWasTaken);
                    // call discord controller
                    var reply = email.send_entry(entry,msg);
                    // update to delivered or update to failed
                    if (reply == true)
                    {
                        var success = entry.update_to_delivered();
                    }
                    else
                    {
                        var success = entry.update_to_failed_to_deliver();
                        var notification = email.notify_admin_of_error(entry);
                    }
                }
                finally
                {
                    if (lockWasTaken)
                    {
                        Monitor.Exit(temp);
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

    }
    
}