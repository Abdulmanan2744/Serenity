using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace MyMovieTutorial.MovieDB.Pages;

[PageAuthorize(typeof(GenreRow))]
public class GenrePage : Controller
{
    [Route("MovieDB/Genre")]
    public ActionResult Index()
    {
        return this.GridPage("@/MovieDB/Genre/GenrePage",
            GenreRow.Fields.PageTitle());
    }
}