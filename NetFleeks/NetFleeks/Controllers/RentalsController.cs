using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetFleeks.Models;
using System.Data.Entity;
using System.Collections;
using NetFleeks.ViewModel;
using System.Data;

namespace NetFleeks.Controllers
{
    public class RentalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rentals
        
        public ActionResult Index()
        {
            var user = User.Identity.Name;

            var rentals = db.Rentals.Where(m => m.rentalExpiration >= DateTime.Today);

            if (User.IsInRole("Manager"))
            {
                //IEnumerable<Rentals> groupByRentals = rentals.GroupBy(rentals,user);
                var rentalsGenre = rentals.Join(db.Movies, r => r.rentalMovie, m => m.movieName, (r,m) => new RentalViewModel {movie = r.rentalMovie, genre = m.genre.genreName, rentalUser = r.rentalUser , rentalExpiration = r.rentalExpiration});       
                return View("Index", rentalsGenre.ToList());
            }
            else
            {
                IEnumerable<Rentals> userRentals = rentals.Where(m => m.rentalUser == user);
                return View("ReadOnlyIndex", userRentals.ToList());
            }
        }
        public ActionResult IndexAll()
        {
            var user = User.Identity.Name;
            var rentals = db.Rentals;

            if (User.IsInRole("Manager"))
            {
                var rentalsGenre = rentals.Join(db.Movies, r => r.rentalMovie, m => m.movieName, (r, m) => new RentalViewModel { movie = r.rentalMovie, genre = m.genre.genreName, rentalUser = r.rentalUser, rentalExpiration = r.rentalExpiration });
                return View("Index", rentalsGenre.ToList());
            }

            else { 
            IEnumerable<Rentals> userAllRentals = rentals.Where(m => m.rentalUser == user);
            return View("ReadOnlyIndex", userAllRentals.ToList());
            }

        }

        [Authorize (Roles = "Manager")]
        public ActionResult GroupBy1()
        {
            var rentals = db.Rentals;
            var rentalsGenre = rentals.Join(db.Movies, r => r.rentalMovie, m => m.movieName, (r, m) => new RentalViewModel { movie = r.rentalMovie, genre = m.genre.genreName, rentalUser = r.rentalUser, rentalExpiration = r.rentalExpiration });
            
            return View("GroupByUser", rentalsGenre.ToList());
           
        }

        [Authorize(Roles = "Manager")]
        public ActionResult GroupBy2()
        {
            var rentals = db.Rentals;
            var rentalsGenre = rentals.Join(db.Movies, r => r.rentalMovie, m => m.movieName, (r, m) => new RentalViewModel { movie = r.rentalMovie, genre = m.genre.genreName, rentalUser = r.rentalUser, rentalExpiration = r.rentalExpiration });
            
            return View("GroupByGenres", rentalsGenre.ToList());

        }


        public ActionResult Rent(string movie)
        {
            var user = User.Identity.Name;
            var rentals = db.Rentals;
            IEnumerable<Rentals> userRentals = rentals.Where(m => m.rentalUser == user && m.rentalExpiration>=DateTime.Today);
            var dupCheck = false;

            foreach(Rentals rental in userRentals)
            {
                if (rental.rentalMovie == movie)
                    dupCheck = true;               
            }
            if (dupCheck)
            {
             return RedirectToAction("Index");

            }

            else
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
}