using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace MyMovieTutorial.MovieDB.Pages;

[PageAuthorize(typeof(MovieGenresRow))]
public class MovieGenresPage : Controller
{
    [Route("MovieDB/MovieGenres")]
    public ActionResult Index()
    {
        return this.GridPage("@/MovieDB/MovieGenres/MovieGenresPage",
            MovieGenresRow.Fields.PageTitle());
    }
}