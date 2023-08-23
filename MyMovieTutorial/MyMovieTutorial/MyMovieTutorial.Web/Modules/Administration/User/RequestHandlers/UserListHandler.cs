using MyMovieTutorial.Web.Modules.Administration;
using Serenity.Data;
using Serenity.Services;
using MyRequest = MyMovieTutorial.Administration.UserListRequest;
using MyResponse = Serenity.Services.ListResponse<MyMovieTutorial.Administration.UserRow>;
using MyRow = MyMovieTutorial.Administration.UserRow;

namespace MyMovieTutorial.Administration
{
    public interface IUserListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

    public class UserListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IUserListHandler
    {
        public UserListHandler(IRequestContext context)
             : base(context)
        {
        }
        protected override void ApplyFilters(SqlQuery query)
        {
            base.ApplyFilters(query);

            if (Permissions.HasPermission(PermissionKeys.Tenants))
                return;

            query.Where(MyRow.Fields.TenantId == User.GetTenantId());
        }
    }
}