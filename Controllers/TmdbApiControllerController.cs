using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TheMoviesHub.Models;

namespace TheMoviesHub.Controllers
{
    public class TmdbApiControllerController : Controller
    {
       public ActionResult Index(string peopleName, int? page) 
       {
            if(page !=  null) 
                CallAPI(peopleName, Convert.ToInt32(page));

            Models.TheMovieDb theMovieDb = new Models.TheMovieDb();
            theMovieDb.searchText = peopleName;
            return View(theMovieDb);
       }
    }

    [HttpPost]

    public ActionResult Index(Models.TheMovieDb theMovieDb, string searchText) 
    {
        if (ModelState.IsValid) 
        {
            CallAPI(searchText, 0);
        }
        return View(theMovieDb);
    }

    public void CallAPI(string searchText, int page) 
    {
        int pageNo = Convert.ToInt32(page) == 0 ? 1 : Convert.ToInt32(page);

        /*Calling API https://developers.themoviedb.org/3/search/search-poeple */
    }
}
