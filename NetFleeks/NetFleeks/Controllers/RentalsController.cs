using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetFleeks.Models;
using System.Data.Entity;

namespace NetFleeks.Controllers
{
    public class RentalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rentals
        public ActionResult Index()
        {
            var user = User.Identity.Name;
            var rentals = db.Rentals.Include(m => m.rentalMovie);

            if (User.IsInRole("Manager"))
                return View("Index", rentals.ToList());
            else
            {
                IEnumerable<Rentals> userRentals = rentals.Where(m => m.rentalUser == user);
                return View("ReadOnlyIndex", userRentals.ToList());
            }
        }

        public ActionResult Rent(Movies movie)
        {
            var rental = new Rentals
            {
                rentalUser = User.Identity.Name,
                rentalExpiration = DateTime.Today.AddDays(3),
                rentalMovie = movie.movieName
            };

            db.Rentals.Add(rental);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}