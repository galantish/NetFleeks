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
    public class RentalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rentals
        public ActionResult Index()
        {


            
            var userRentals = db.Rentals.Where(m => m.rentalUser == User.Identity);

            return View(userRentals.ToList());

            /*if (User.IsInRole("Manager"))
                return View("Index", movies.ToList());*/
        }

        // GET: Rentals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rentals rentals = db.Rentals.Find(id);
            if (rentals == null)
            {
                return HttpNotFound();
            }
            return View(rentals);
        }

        // GET: Rentals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rentals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,rentalExpiration")] Rentals rentals)
        {
            if (ModelState.IsValid)
            {
                db.Rentals.Add(rentals);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rentals);
        }

        // GET: Rentals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rentals rentals = db.Rentals.Find(id);
            if (rentals == null)
            {
                return HttpNotFound();
            }
            return View(rentals);
        }

        // POST: Rentals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,rentalExpiration")] Rentals rentals)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentals).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rentals);
        }

        // GET: Rentals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rentals rentals = db.Rentals.Find(id);
            if (rentals == null)
            {
                return HttpNotFound();
            }
            return View(rentals);
        }

        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rentals rentals = db.Rentals.Find(id);
            db.Rentals.Remove(rentals);
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
