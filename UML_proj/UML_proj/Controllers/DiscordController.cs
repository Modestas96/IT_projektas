using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UML_proj.Models;
using System.Net.Http;


namespace UML_proj.Controllers
{
    public class DiscordController : Controller
    {
        private static readonly HttpClient httpClient = new HttpClient { BaseAddress = new Uri("https://discordapp.com/api/v7/") };
        // GET: Discord
        public ActionResult Index()
        {
            return View();
        }

        public bool send_entry(Newsletter_entry entry,string message)
        {
            // contact api here


            // SIMULATING API CALL
            string[] parts = entry.receit_forms.Split(' ');
            string channel = parts[1];
            var t = Task.Run(() => request(channel,message));
            t.Wait();
            bool reply = t.Result;

            // SIMULATING API CALL
                
            return reply;
        }

        static async System.Threading.Tasks.Task<bool> request(string channel,string message)
        {
            if (channel != "399455712603799565")
            {
                return false;
            }
            string token = "Mzk5NDczNjQ4NjA1NTkzNjEx.DTNmeQ.wH7Uc-QR6219VYXC1iwlPPvZtWs";
            //string channel = "399455712603799565"; // archi test land
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bot " + token);
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Felkin#0101 (For a project, short term)");

            var values = new Dictionary<string, string>
                {
                    { "content", message }
                };

            var content = new FormUrlEncodedContent(values);
            string msg = "channels/" + channel + "/messages";
            using (var response = await httpClient.PostAsync(msg, content))
            {

                Console.WriteLine(response);
                string responseData = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    return true;
                else
                {
                    return false;
                }
            }


        }
    }
}