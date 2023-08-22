using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<MyMovieTutorial.MovieDB.PersonRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = MyMovieTutorial.MovieDB.PersonRow;

namespace MyMovieTutorial.MovieDB;

public interface IPersonSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

public class PersonSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IPersonSaveHandler
{
    public PersonSaveHandler(IRequestContext context)
            : base(context)
    {
    }
}