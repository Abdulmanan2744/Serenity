using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<MyMovieTutorial.MovieDB.MovieCastRow>;
using MyRow = MyMovieTutorial.MovieDB.MovieCastRow;

namespace MyMovieTutorial.MovieDB;

public interface IMovieCastListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

public class MovieCastListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IMovieCastListHandler
{
    public MovieCastListHandler(IRequestContext context)
            : base(context)
    {
    }
}