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

        // GET: Stats
        public ActionResult Index()
        {
            return View();
        }

        /*  public ActionResult GenreCount()
          {
              var rentals = db.Rentals;
              var rentalsGenre = rentals.Join(db.Movies, r => r.rentalMovie, m => m.movieName, (r, m) => new RentalViewModel { movie = r.rentalMovie, genre = m.genre.genreName, rentalUser = r.rentalUser, rentalExpiration = r.rentalExpiration });
              var pieGenreCollection = rentalsGenre.GroupBy(t => t.genre).Select(i => new { genre = i.Key, Count = i.Count() });
              StringBuilder genreBuilder = new StringBuilder();

              genreBuilder.AppendLine("genre,count");

              foreach (var currGenre in pieGenreCollection)
              {
                  genreBuilder.AppendFormat("{0},{1}\\n", currGenre.genre, currGenre.Count);
              }
              Stats stats = new Stats() { genreCsv = genreBuilder.ToString() };
              return View("Index", stats);

          }

          public ActionResult TypeCount()
          {

              var userGroups = db.Users.GroupBy(x => x.membershipTypeID).Select(x => new { ID = x.Key, Count = x.Count() });

              int premiumCount = userGroups.Single(x => x.ID == db.MembershipTypes.FirstOrDefault(mem => mem.membershipType.Equals("Premium")).ID).Count;
              int freeCount = userGroups.Single(x => x.ID == db.MembershipTypes.FirstOrDefault(mem => mem.membershipType.Equals("Free")).ID).Count;

              string memTypesCSV = string.Format("type,count\\nPremium,{0}\\nFree,{1}", premiumCount, freeCount);

              Stats stats = new Stats() { memTypeCsv = memTypesCSV };
              return View("TypeCount", stats);

          }*/



        // GET: Posts/StatsByDate/
       /* public ActionResult Stats(int type)
        {
            var results = db.Posts.ToList().OrderBy(post => post.PublishedDate);

            if (type == 1)
            {
                var res = results.GroupBy(post2 => post2.PublishedDate.ToShortDateString(), (key, g) =>
                {
                    var arr = new String[2];
                    arr[0] = g.Count().ToString();
                    arr[1] = key;

                    return arr;
                }).ToArray();

                ViewBag.Title = "Posts per date";

                return View("Stats", res);

            }
            else
            {
                var res = results.GroupBy(post2 => post2.Fan.Username, (key, g) => {
                    var arr = new String[2];
                    arr[0] = g.Count().ToString();
                    arr[1] = key;

                    return arr;
                }).ToArray();

                ViewBag.Title = "Posts per User";

                return View("Stats", res);

            }
        }*/
    }
}