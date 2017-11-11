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

namespace Controllers
{

    public class RecommenderController : Controller
    {

        public ActionResult RecommendFilmPage()
        {
            return View();
        }

        static IDataModel dataModel;

        public ActionResult GetRecommendedFilms(string filmIdsJson)
        {
            var filmIds = (new JavaScriptSerializer()).Deserialize<long[]>(filmIdsJson);

            var dataModel = GetDataModel();

            // recommendation is performed for the user that is missed in the preferences data
            var plusAnonymModel = new PlusAnonymousUserDataModel(dataModel);
            var prefArr = new GenericUserPreferenceArray(filmIds.Length);
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

            return Json(recommendedItems.Select(ri => new Dictionary<string, object>() {
                {"film_id", ri.GetItemID() },
                {"rating", ri.GetValue() },
            }).ToArray());
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
