using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = MyMovieTutorial.Administration.TenantsRow;

namespace MyMovieTutorial.Administration;

public interface ITenantsDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

public class TenantsDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, ITenantsDeleteHandler
{
    public TenantsDeleteHandler(IRequestContext context)
            : base(context)
    {
    }
}