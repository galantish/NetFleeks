using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NetFleeks.Models;

namespace NetFleeks.Controllers
{
    public class CinemasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cinemas
        public ActionResult Index()
        {
            if (User.IsInRole("Manager"))
                return View("ManageCinemas", db.Cinemas.ToList());
            else
                return View("Index", db.Cinemas.ToList());
        }

        // GET: Cinemas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinemas cinemas = db.Cinemas.Find(id);
            if (cinemas == null)
            {
                return HttpNotFound();
            }
            return View(cinemas);
        }

        // GET: Cinemas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cinemas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,cinemaName,cinemaAddress")] Cinemas cinemas)
        {
            if (ModelState.IsValid)
            {
                db.Cinemas.Add(cinemas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cinemas);
        }

        // GET: Cinemas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinemas cinemas = db.Cinemas.Find(id);
            if (cinemas == null)
            {
                return HttpNotFound();
            }
            return View(cinemas);
        }

        // POST: Cinemas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,cinemaName,cinemaAddress")] Cinemas cinemas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cinemas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cinemas);
        }

        // GET: Cinemas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinemas cinemas = db.Cinemas.Find(id);
            if (cinemas == null)
            {
                return HttpNotFound();
            }
            return View(cinemas);
        }

        // POST: Cinemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cinemas cinemas = db.Cinemas.Find(id);
            db.Cinemas.Remove(cinemas);
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
