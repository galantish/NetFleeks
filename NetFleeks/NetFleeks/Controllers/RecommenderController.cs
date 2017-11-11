using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.IO;
using System.Net;
using System.Threading;
using System.Web.Script.Serialization;

using System.Web.Security;

using NReco.CF.Taste.Model;
using NReco.CF.Taste.Impl.Model.File;
using NReco.CF.Taste.Impl.Eval;
using NReco.CF.Taste.Eval;
using NReco.CF.Taste.Impl.Similarity;
using NReco.CF.Taste.Impl.Neighborhood;
using NReco.CF.Taste.Impl.Recommender;
using NReco.CF.Taste.Impl.Recommender.SVD;
using NReco.CF.Taste.Impl.Model;
using NReco.CF.Taste.Recommender;

using CsvHelper;
using NetFleeks.Models;

namespace Controllers
{

    public class RecommenderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        static IDataModel dataModel;

        public ActionResult GetRecommendedFilms()
        {
            var csv = new CsvReader(new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/movies.csv")));
            var records = csv.GetRecords<MovieRecord>();
            int favouriteGenre = db.Users.Where(u => u.UserName == User.Identity.Name).Select(u => u.genreID).SingleOrDefault();
            var userRentals = db.Rentals.Where(m => m.rentalUser == User.Identity.Name).Join(db.Movies,
                                                                                                       r => r.rentalMovie,
                                                                                                       m => m.movieName,
                                                                                                       (r, m) => new
                                                                                                       {
                                                                                                           genreId = m.genreID,
                                                                                                           movieName = m.movieName,
                                                                                                           rentalUer = r.rentalUser
                                                                                                       });
            if (userRentals.Count() == 0)
            {
                return Json(new Dictionary<string, object>() {
                {"film_id", 0},
                {"rating", 0},
            });
            }
            else if (userRentals.Where(m => m.genreId == favouriteGenre).Count() != 0)
                userRentals = userRentals.Where(m => m.genreId == favouriteGenre);

            long[] filmIdsTemp = new long[userRentals.Count()];
            int movieCounter = 0;
            foreach (var item in userRentals)
            {
                foreach (var record in records)
                {
                    if (item.movieName == record.title)
                    {
                        if (!filmIdsTemp.Contains(record.movieId)) { 
                            filmIdsTemp[movieCounter] = record.movieId;
                            movieCounter++;
                        }
                    }
                }
            }
            long[] filmIds = new long[movieCounter];
            for (int i = 0; i < movieCounter; i++)
                filmIds[i] = filmIdsTemp[i];

            var dataModel = GetDataModel();

            // recommendation is performed for the user that is missed in the preferences data
            var plusAnonymModel = new PlusAnonymousUserDataModel(dataModel);
            var prefArr = new GenericUserPreferenceArray(userRentals.Count());

            prefArr.SetUserID(0, PlusAnonymousUserDataModel.TEMP_USER_ID);
            for (int i = 0; i < filmIds.Length; i++)
            {
                prefArr.SetItemID(i, filmIds[i]);

                // in this example we have no ratings of movies preferred by the user
                prefArr.SetValue(i, 5); // lets assume max rating
            }
            plusAnonymModel.SetTempPrefs(prefArr);

            var similarity = new LogLikelihoodSimilarity(plusAnonymModel);
            var neighborhood = new NearestNUserNeighborhood(15, similarity, plusAnonymModel);
            var recommender = new GenericUserBasedRecommender(plusAnonymModel, neighborhood, similarity);
            var recommendedItems = recommender.Recommend(PlusAnonymousUserDataModel.TEMP_USER_ID, 1, null);

            if (recommendedItems.Count() == 0)
            {
                return Json(new Dictionary<string, object>() {
                {"film_id", 0},
                {"rating", 0},
            });
            }

            return Json(recommendedItems.Select(ri => new Dictionary<string, object>() {
                {"film_id", ri.GetItemID() },
                {"rating", ri.GetValue() },
            }).ToArray()[0]);
        }

        /// <summary>
        /// Loads data model (preferences data) from the file. In the same manner data can be loaded from SQL database (or MongoDb).
        /// </summary>
        /// <remarks>
        /// Data model is cached to avoid CSV parsing on each request.
        /// </remarks>
        IDataModel GetDataModel()
        {
            var pathToDataFile = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/ratings.csv");

            var cacheKey = "RecommenderDataModel:" + pathToDataFile;
            var dataModel = HttpRuntime.Cache.Get(cacheKey) as IDataModel;
            if (dataModel == null)
            {
                dataModel = new FileDataModel(pathToDataFile, false, FileDataModel.DEFAULT_MIN_RELOAD_INTERVAL_MS, false);
                HttpRuntime.Cache[cacheKey] = dataModel;
            }
            return dataModel;
        }

        public ActionResult GetMovies()
        {
            var csv = new CsvReader(new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/movies.csv")));
            var records = csv.GetRecords<MovieRecord>();
            return Json(records, JsonRequestBehavior.AllowGet);
        }

        public class MovieRecord
        {
            public int movieId { get; set; }
            public string title { get; set; }
        }

    }
}
