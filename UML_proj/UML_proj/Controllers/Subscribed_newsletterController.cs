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
    public class Subscribed_newsletterController : Controller
    {
        private IT_PROJEKTASEntities db = new IT_PROJEKTASEntities();

        // GET: Subscribed_newsletter
        public ActionResult Index()
        {
            var subscribed_newsletter = db.Subscribed_newsletter.Include(s => s.Newsletter).Include(s => s.Person);
            return View(subscribed_newsletter.ToList());
        }

        // GET: Subscribed_newsletter/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscribed_newsletter subscribed_newsletter = db.Subscribed_newsletter.Find(id);
            if (subscribed_newsletter == null)
            {
                return HttpNotFound();
            }
            return View(subscribed_newsletter);
        }

        // GET: Subscribed_newsletter/Create
        public ActionResult Create()
        {
            ViewBag.fk_newsletter_id = new SelectList(db.Newsletters, "pk_id", "content");
            ViewBag.fk_subscriber_id = new SelectList(db.People, "id_Person", "Vardas");
            return View();
        }

        // POST: Subscribed_newsletter/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "receit_form,id,fk_subscriber_id,fk_newsletter_id")] Subscribed_newsletter subscribed_newsletter)
        {
            if (ModelState.IsValid)
            {
                db.Subscribed_newsletter.Add(subscribed_newsletter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_newsletter_id = new SelectList(db.Newsletters, "pk_id", "content", subscribed_newsletter.fk_newsletter_id);
            ViewBag.fk_subscriber_id = new SelectList(db.People, "id_Person", "Vardas", subscribed_newsletter.fk_subscriber_id);
            return View(subscribed_newsletter);
        }

        // GET: Subscribed_newsletter/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscribed_newsletter subscribed_newsletter = db.Subscribed_newsletter.Find(id);
            if (subscribed_newsletter == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_newsletter_id = new SelectList(db.Newsletters, "pk_id", "content", subscribed_newsletter.fk_newsletter_id);
            ViewBag.fk_subscriber_id = new SelectList(db.People, "id_Person", "Vardas", subscribed_newsletter.fk_subscriber_id);
            return View(subscribed_newsletter);
        }

        // POST: Subscribed_newsletter/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "receit_form,id,fk_subscriber_id,fk_newsletter_id")] Subscribed_newsletter subscribed_newsletter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subscribed_newsletter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_newsletter_id = new SelectList(db.Newsletters, "pk_id", "content", subscribed_newsletter.fk_newsletter_id);
            ViewBag.fk_subscriber_id = new SelectList(db.People, "id_Person", "Vardas", subscribed_newsletter.fk_subscriber_id);
            return View(subscribed_newsletter);
        }

        // GET: Subscribed_newsletter/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscribed_newsletter subscribed_newsletter = db.Subscribed_newsletter.Find(id);
            if (subscribed_newsletter == null)
            {
                return HttpNotFound();
            }
            return View(subscribed_newsletter);
        }

        // POST: Subscribed_newsletter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subscribed_newsletter subscribed_newsletter = db.Subscribed_newsletter.Find(id);
            db.Subscribed_newsletter.Remove(subscribed_newsletter);
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
