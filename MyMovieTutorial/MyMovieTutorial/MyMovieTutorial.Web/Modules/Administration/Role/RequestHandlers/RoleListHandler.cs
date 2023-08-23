using MyMovieTutorial.Web.Modules.Administration;
using Serenity.Data;
using Serenity.Services;
using System.ComponentModel;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<MyMovieTutorial.Administration.RoleRow>;
using MyRow = MyMovieTutorial.Administration.RoleRow;


namespace MyMovieTutorial.Administration
{
    public interface IRoleListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

    public class RoleListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IRoleListHandler
    {
        public RoleListHandler(IRequestContext context)
             : base(context)
        {
        }

        //revert every change we made in RoleRepository.cs


       /* private static MyRow.RowFields Fld { get { return MyRow.Fields; } }
        protected override void ApplyFilters(SqlQuery query)
        {
            base.ApplyFilters(query);

            if (!Permissions.HasPermission(PermissionKeys.Tenants))
                query.Where(Fld.TenantId == User.GetTenantId());
        }*/
    }
}