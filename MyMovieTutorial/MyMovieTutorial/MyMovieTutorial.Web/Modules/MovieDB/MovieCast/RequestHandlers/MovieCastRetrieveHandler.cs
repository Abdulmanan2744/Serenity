using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<MyMovieTutorial.MovieDB.MovieCastRow>;
using MyRow = MyMovieTutorial.MovieDB.MovieCastRow;

namespace MyMovieTutorial.MovieDB;

public interface IMovieCastRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

public class MovieCastRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IMovieCastRetrieveHandler
{
    public MovieCastRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}