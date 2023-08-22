using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<MyMovieTutorial.MovieDB.GenreRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = MyMovieTutorial.MovieDB.GenreRow;

namespace MyMovieTutorial.MovieDB;

public interface IGenreSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

public class GenreSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IGenreSaveHandler
{
    public GenreSaveHandler(IRequestContext context)
            : base(context)
    {
    }
}