using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UML_proj.Models;

namespace UML_proj.Controllers
{
    public class SubscriptionsController : Controller
    {
        private ITProjektasDB db = new ITProjektasDB();
        private Subscription subs = new Subscription();

        // GET: Subscriptions
        public ActionResult Index()
        {
            var subscriptions = db.Subscriptions.Include(s => s.Newsletter).Include(s => s.Person);
            return View(subscriptions.ToList());
        }
        public ActionResult open_subscription_list()
        {
            int id = Int32.Parse(Session["UserID"].ToString());
            subs.fk_Personid_Person = id;
            var subscriptions = subs.select_personal_subs();
            return View("Index",subscriptions);
        }

        public ActionResult open_profile_page()
        {

            return View("ProfilePage"); // open
        }

        // GET: Subscriptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription subscription = db.Subscriptions.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        // GET: Subscriptions/Create
        public ActionResult Create()
        {
            ViewBag.fk_Newsletterid_Newsletter = new SelectList(db.Newsletters, "id_Newsletter", "newest_message");
            ViewBag.fk_Personid_Person = new SelectList(db.People, "id_Person", "name");
            return View();
        }

        // POST: Subscriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Subscription,receit_discord,receit_email,fk_Personid_Person,fk_Newsletterid_Newsletter")] Subscription subscription)
        {
            if (ModelState.IsValid)
            {
                db.Subscriptions.Add(subscription);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_Newsletterid_Newsletter = new SelectList(db.Newsletters, "id_Newsletter", "newest_message", subscription.fk_Newsletterid_Newsletter);
            ViewBag.fk_Personid_Person = new SelectList(db.People, "id_Person", "name", subscription.fk_Personid_Person);
            return View(subscription);
        }

        // GET: Subscriptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription subscription = db.Subscriptions.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_Newsletterid_Newsletter = new SelectList(db.Newsletters, "id_Newsletter", "newest_message", subscription.fk_Newsletterid_Newsletter);
            ViewBag.fk_Personid_Person = new SelectList(db.People, "id_Person", "name", subscription.fk_Personid_Person);
            return View(subscription);
        }

        // POST: Subscriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Subscription,receit_discord,receit_email,fk_Personid_Person,fk_Newsletterid_Newsletter")] Subscription subscription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subscription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_Newsletterid_Newsletter = new SelectList(db.Newsletters, "id_Newsletter", "newest_message", subscription.fk_Newsletterid_Newsletter);
            ViewBag.fk_Personid_Person = new SelectList(db.People, "id_Person", "name", subscription.fk_Personid_Person);
            return View(subscription);
        }

        // GET: Subscriptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription subscription = db.Subscriptions.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        // POST: Subscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subscription subscription = db.Subscriptions.Find(id);
            db.Subscriptions.Remove(subscription);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
