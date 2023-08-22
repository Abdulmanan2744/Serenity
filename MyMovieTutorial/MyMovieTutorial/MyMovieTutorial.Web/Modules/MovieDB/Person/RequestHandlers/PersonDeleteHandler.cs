using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = MyMovieTutorial.MovieDB.PersonRow;

namespace MyMovieTutorial.MovieDB;

public interface IPersonDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

public class PersonDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IPersonDeleteHandler
{
    public PersonDeleteHandler(IRequestContext context)
            : base(context)
    {
    }
}