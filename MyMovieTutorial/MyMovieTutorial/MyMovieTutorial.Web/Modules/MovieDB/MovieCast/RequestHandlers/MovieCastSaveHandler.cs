using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<MyMovieTutorial.MovieDB.MovieCastRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = MyMovieTutorial.MovieDB.MovieCastRow;

namespace MyMovieTutorial.MovieDB;

public interface IMovieCastSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

public class MovieCastSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IMovieCastSaveHandler
{
    public MovieCastSaveHandler(IRequestContext context)
            : base(context)
    {
    }
}