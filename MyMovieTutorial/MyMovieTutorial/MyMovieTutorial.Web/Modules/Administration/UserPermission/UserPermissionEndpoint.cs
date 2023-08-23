using Microsoft.AspNetCore.Mvc;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Services;
using System.Data;
using System.Linq;
using MyRepository = MyMovieTutorial.Administration.Repositories.UserPermissionRepository;
using MyRow = MyMovieTutorial.Administration.UserPermissionRow;

namespace MyMovieTutorial.Administration.Endpoints
{
    [Route("Services/Administration/UserPermission/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class UserPermissionController : ServiceEndpoint
    {
        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, UserPermissionUpdateRequest request,
    [FromServices] ITypeSource typeSource,
    [FromServices] ISqlConnections sqlConnections)
        {
            return new MyRepository(Context, typeSource, sqlConnections).Update(uow, request);
        }

        public ListResponse<MyRow> List(IDbConnection connection, UserPermissionListRequest request,
            [FromServices] ITypeSource typeSource,
            [FromServices] ISqlConnections sqlConnections)
        {
            return new MyRepository(Context, typeSource, sqlConnections).List(connection, request);
        }

        public ListResponse<string> ListRolePermissions(IDbConnection connection, UserPermissionListRequest request,
            [FromServices] ITypeSource typeSource,
            [FromServices] ISqlConnections sqlConnections)
        {
            return new MyRepository(Context, typeSource, sqlConnections).ListRolePermissions(connection, request);
        }

        public ListResponse<string> ListPermissionKeys(
            [FromServices] ISqlConnections sqlConnections,
            [FromServices] ITypeSource typeSource)
        {
            return new ListResponse<string>
            {
                Entities = MyRepository.ListPermissionKeys(Cache, sqlConnections, typeSource,
                    includeRoles: false).ToList()
            };
        }
    }
}