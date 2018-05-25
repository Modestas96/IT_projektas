using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UML_proj.Controllers
{
    public class NewsletterController : Controller
    {
        // GET: NewsletterForm
        public ActionResult NewsletterForm() // open_form
        {
            return View();
        }
        public void Send_new_entry() // send_new_entry
        {
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
        }
    }
}