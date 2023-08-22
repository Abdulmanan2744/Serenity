using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace MyMovieTutorial.MovieDB.Pages;

[PageAuthorize(typeof(MovieRow))]
public class MoviePage : Controller
{
    [Route("MovieDB/Movie")]
    public ActionResult Index()
    {
        return this.GridPage("@/MovieDB/Movie/MoviePage",
            MovieRow.Fields.PageTitle());
    }
}