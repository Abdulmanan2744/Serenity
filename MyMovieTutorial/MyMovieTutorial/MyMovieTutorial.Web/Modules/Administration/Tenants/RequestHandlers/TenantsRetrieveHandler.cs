using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<MyMovieTutorial.Administration.TenantsRow>;
using MyRow = MyMovieTutorial.Administration.TenantsRow;

namespace MyMovieTutorial.Administration;

public interface ITenantsRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

public class TenantsRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ITenantsRetrieveHandler
{
    public TenantsRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}