using MyMovieTutorial.Web.Modules.Administration;
using Serenity;
using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = MyMovieTutorial.Administration.RoleRow;


namespace MyMovieTutorial.Administration
{
    public interface IRoleDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }
    public class RoleDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IRoleDeleteHandler
    {
        public RoleDeleteHandler(IRequestContext context)
             : base(context)
        {
        }

        //revert every change we made in RoleRepository.cs

       /* protected override void ValidateRequest()
        {
            base.ValidateRequest();

            if (Row.TenantId != User.GetTenantId())
                Permissions.ValidatePermission(PermissionKeys.Tenants, Localizer);
        }*/
    }
}