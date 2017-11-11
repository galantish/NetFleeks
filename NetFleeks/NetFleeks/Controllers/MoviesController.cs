using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NetFleeks.Models;
using NetFleeks.ViewModel;


namespace NetFleeks.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Movies
        public ActionResult Index()
        {
            var infoMovie = db.Movies.Join(
                                        db.MembershipTypes,
                                        r => r.membershipType,
                                        m => m.ID,
                                        (r, m) => new InfoMovieViewModel{
                                        genre = r.genre.genreName,
                                        movie = r.movieName,
                                        ID = r.ID,
                                        dateAdded =r.dateAdded,
                                        releaseDate =r.releaseDate,
                                        actors = r.actors,
                                        summary = r.summary,
                                        membershipType =m.membershipType });

            if (User.IsInRole("Manager"))
                return View("Index",infoMovie.ToList());
            else
                return View("ReadOnlyIndex", infoMovie.ToList());  
        }

        // GET: Movies/MoviesByGenre/1
        public ActionResult MoviesByGenre(int? genreID)
        {
            var movies = db.Movies.Include(m => m.genre);
            IEnumerable<Movies> query = movies;
            query = movies.Where(m => m.genreID == genreID);

            if (User.IsInRole("Manager"))
                return View("Index", query.ToList());
            else
                return View("ReadOnlyIndex", query.ToList());

        }

        // GET: Movies
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
            if (DateTime.TryParse(date, out dateCheck)){
                queryParams += 4;
            }

            var movies = db.Movies.Include(m => m.genre);
            IEnumerable<Movies> query = movies;

            switch (queryParams)
            {
                case 1:
                    query = movies.Where(m => m.membershipType == membershipCheck);
                    break;
                case 2:
                    query = movies.Where(m => m.genreID == genreCheck);
                    break;
                case 3:
                    query = movies.Where(m => m.membershipType == membershipCheck && m.genreID == genreCheck);
                    break;
                case 4:
                    query = movies.Where(m => m.releaseDate > dateCheck);
                    break;
                case 5:
                    query = movies.Where(m => m.membershipType == membershipCheck && m.releaseDate > dateCheck);
                    break;
                case 6:
                    query = movies.Where(m => m.genreID == genreCheck && m.releaseDate > dateCheck);
                    break;
                case 7:
                    query = movies.Where(m => m.membershipType == membershipCheck && m.genreID == genreCheck && m.releaseDate > dateCheck);
                    break;
                default:
                    query = movies;
                    break;
            }

            //var movies = db.Movies.Include(m => m.genre);
            //return View(movies.ToList());
            var infoMovie = query.Join(
                                        db.MembershipTypes,
                                        r => r.membershipType,
                                        m => m.ID,
                                        (r, m) => new InfoMovieViewModel
                                        {
                                            genre = r.genre.genreName,
                                            movie = r.movieName,
                                            ID = r.ID,
                                            dateAdded = r.dateAdded,
                                            releaseDate = r.releaseDate,
                                            actors = r.actors,
                                            summary = r.summary,
                                            membershipType = m.membershipType
                                        });
            if (User.IsInRole("Manager"))
                return View("Index", infoMovie.ToList());
            else
                return View("ReadOnlyIndex", infoMovie.ToList());
        }


        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movies movies = db.Movies.Find(id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            return View(movies);
        }


        // GET: Movies/Create
        [Authorize(Roles = "Manager")]
        public ActionResult Create()
        {
            ViewBag.genreID = new SelectList(db.Genres, "ID", "ID");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public ActionResult Create([Bind(Include = "ID,genreID,movieName,dateAdded,releaseDate,actors,summary, membershipType")] Movies movies)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movies);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.genreID = new SelectList(db.Genres, "ID", "ID", movies.genreID);
            return View(movies);
        }

        // GET: Movies/Edit/5
        [Authorize(Roles = "Manager")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movies movies = db.Movies.Find(id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            ViewBag.genreID = new SelectList(db.Genres, "ID", "ID", movies.genreID);
            return View(movies);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public ActionResult Edit([Bind(Include = "ID,genreID,movieName,dateAdded,releaseDate,actors,summary,membershipType")] Movies movies)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movies).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.genreID = new SelectList(db.Genres, "ID", "ID", movies.genreID);
            return View(movies);
        }

        // GET: Movies/Delete/5
        [Authorize(Roles = "Manager")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movies movies = db.Movies.Find(id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            return View(movies);
        }

        

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movies movies = db.Movies.Find(id);
            db.Movies.Remove(movies);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Manager")]
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
