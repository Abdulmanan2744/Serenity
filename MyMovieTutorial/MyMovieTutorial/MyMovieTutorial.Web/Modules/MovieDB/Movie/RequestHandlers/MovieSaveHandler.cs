using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<MyMovieTutorial.MovieDB.MovieRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = MyMovieTutorial.MovieDB.MovieRow;

namespace MyMovieTutorial.MovieDB;

public interface IMovieSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

public class MovieSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IMovieSaveHandler
{
    public MovieSaveHandler(IRequestContext context)
            : base(context)
    {

    }
}