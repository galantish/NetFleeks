using NetFleeks.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NetFleeks.Models
{
    public class StatsController : Controller
    {
      
        private ApplicationDbContext db = new ApplicationDbContext();

       

          public ActionResult GenreCount()
          {
              var rentals = db.Rentals;
              var rentalsGenre = rentals.Join(db.Movies, r => r.rentalMovie, m => m.movieName, (r, m) => new RentalViewModel { movie = r.rentalMovie, genre = m.genre.genreName, rentalUser = r.rentalUser, rentalExpiration = r.rentalExpiration }).ToList();
            
              var pieGenreCollection = rentalsGenre.GroupBy(t => t.genre, (key, g) =>
            {
                var arr = new String[2];
                arr[0] = g.Count().ToString();
                arr[1] = key;

                return arr;
            }).ToArray();

            ViewBag.Title = "Rentals per Genre";


            return View("TypeCount", pieGenreCollection);

          }

        public ActionResult MoviesCount()
        {
            var movies = db.Movies;
            var moviesGenres = movies.Join(db.Genres, r => r.genreID, m => m.ID, (r, m) => new InfoMovieViewModel { movie = r.movieName, genre = m.genreName }).ToList();

            var pieGenreCollection = moviesGenres.GroupBy(t => t.genre, (key, g) =>
            {
                var arr = new string[2];
                arr[0] = g.Count().ToString();
                arr[1] = key;

                return arr;
            }).ToArray();

            ViewBag.Title = "Movies Per Genre";


            return View("TypeCount", pieGenreCollection);

        }

        
    }
}