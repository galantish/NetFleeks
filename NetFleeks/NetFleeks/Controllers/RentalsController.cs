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

        [HttpPost]
        public ActionResult Search(string genreID, string membershipTypeID, string date)
        {
            int queryParams = 0;
            int membershipCheck;
            int genreCheck;
            DateTime dateCheck;

            if (Int32.TryParse(membershipTypeID, out membershipCheck))
            {
                if (membershipCheck > 0)
                    queryParams += 1;
            }
            if (Int32.TryParse(genreID, out genreCheck))
            {
                if (genreCheck > 0)
                    queryParams += 2;
            }
            if (DateTime.TryParse(date, out dateCheck))
            {
                queryParams += 4;
            }

            var movies = db.Movies.Include(m => m.genre);
            IEnumerable<Movies> moviesQuery = movies;
            var rentals = db.Rentals;
            IEnumerable<Rentals> rentalsQuery = rentals;

            switch (queryParams)
            {
                case 1:
                    moviesQuery = movies.Where(m => m.membershipType == membershipCheck);
                    break;
                case 2:
                    moviesQuery = movies.Where(m => m.genreID == genreCheck);
                    break;
                case 3:
                    moviesQuery = movies.Where(m => m.membershipType == membershipCheck && m.genreID == genreCheck);
                    break;
                case 4:
                    rentalsQuery = rentals.Where(m => m.rentalExpiration >= dateCheck);
                    break;
                case 5:
                    moviesQuery = movies.Where(m => m.membershipType == membershipCheck);
                    rentalsQuery = rentals.Where(m => m.rentalExpiration >= dateCheck);
                    break;
                case 6:
                    moviesQuery = movies.Where(m => m.genreID == genreCheck);
                    rentalsQuery = rentals.Where(m => m.rentalExpiration >= dateCheck);
                    break;
                case 7:
                    moviesQuery = movies.Where(m => m.membershipType == membershipCheck && m.genreID == genreCheck);
                    rentalsQuery = rentals.Where(m => m.rentalExpiration >= dateCheck);
                    break;
                default:
                    break;
            }

            var rentalsGenre = rentalsQuery.Join(moviesQuery, r => r.rentalMovie, m => m.movieName, (r, m) => new RentalViewModel { movie = r.rentalMovie, genre = m.genre.genreName, rentalUser = r.rentalUser, rentalExpiration = r.rentalExpiration });
            return View("Index", rentalsGenre.ToList());
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