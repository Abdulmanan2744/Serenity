using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<MyMovieTutorial.Administration.TenantsRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = MyMovieTutorial.Administration.TenantsRow;

namespace MyMovieTutorial.Administration;

public interface ITenantsSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

public class TenantsSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ITenantsSaveHandler
{
    public TenantsSaveHandler(IRequestContext context)
            : base(context)
    {
    }
}