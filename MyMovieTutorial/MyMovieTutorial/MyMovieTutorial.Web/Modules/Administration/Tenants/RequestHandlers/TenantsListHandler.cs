using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<MyMovieTutorial.Administration.TenantsRow>;
using MyRow = MyMovieTutorial.Administration.TenantsRow;

namespace MyMovieTutorial.Administration;

public interface ITenantsListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

public class TenantsListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ITenantsListHandler
{
    public TenantsListHandler(IRequestContext context)
            : base(context)
    {
    }
}