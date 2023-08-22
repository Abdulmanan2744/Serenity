using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<MyMovieTutorial.MovieDB.PersonRow>;
using MyRow = MyMovieTutorial.MovieDB.PersonRow;

namespace MyMovieTutorial.MovieDB;

public interface IPersonListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

public class PersonListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IPersonListHandler
{
    public PersonListHandler(IRequestContext context)
            : base(context)
    {
    }
}