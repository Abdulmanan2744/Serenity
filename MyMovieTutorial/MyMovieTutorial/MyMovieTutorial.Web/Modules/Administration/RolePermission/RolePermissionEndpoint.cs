using Microsoft.AspNetCore.Mvc;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Services;
using System.Data;
using MyRepository = MyMovieTutorial.Administration.Repositories.RolePermissionRepository;
using MyRow = MyMovieTutorial.Administration.RolePermissionRow;

namespace MyMovieTutorial.Administration.Endpoints
{
    [Route("Services/Administration/RolePermission/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class RolePermissionController : ServiceEndpoint
    {
        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, RolePermissionUpdateRequest request,
     [FromServices] ITypeSource typeSource,
     [FromServices] ISqlConnections sqlConnections)
        {
            return new MyRepository(Context, typeSource, sqlConnections).Update(uow, request);
        }

        public RolePermissionListResponse List(IDbConnection connection, RolePermissionListRequest request,
            [FromServices] ITypeSource typeSource,
            [FromServices] ISqlConnections sqlConnections)
        {
            return new MyRepository(Context, typeSource, sqlConnections).List(connection, request);
        }
    }
}
