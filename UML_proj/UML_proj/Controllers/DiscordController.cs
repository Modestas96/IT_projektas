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

        public void start(string token)
        {
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bot " + token);
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Felkin#0101 (For a project, short term)");
        }
 
        // GET: Discord
        public ActionResult Index()
        {
            return View();
        }

        public bool send_entry(Newsletter_entry entry,string message)
        {
            // contact api here          
            string[] parts = entry.receit_forms.Split(' ');
            string channel = parts[1];
            var t = Task.Run(() => request(channel,message));
            t.Wait();
            bool reply = t.Result;

                
            return reply;
        }

        static async System.Threading.Tasks.Task<bool> request(string channel,string message)
        {
            if (channel.Length < 5)
            {
                return false;
            }
            //string token = "insert_key_here";
            //string channel = "399455712603799565"; // archi test land

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