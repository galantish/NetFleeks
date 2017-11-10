using System;
using System.Collections.Generic;
using System.Linq;
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
            return View();
        }

        public ActionResult Rent(Movies movie)
        {
            var rental = new Rentals
            {
                rentalUser = User.Identity.Name,
                rentalExpiration = DateTime.Today.AddDays(3),
                rentalMovie = movie
            };

            db.Rentals.Add(rental);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}