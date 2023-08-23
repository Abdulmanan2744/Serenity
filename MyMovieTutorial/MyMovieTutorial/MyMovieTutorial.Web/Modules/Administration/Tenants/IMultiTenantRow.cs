using Serenity.Data;

namespace MyMovieTutorial.Web.Modules.Administration.Tenants
{
    public interface IMultiTenantRow
    {
        Int32Field TenantIdField { get; }
    }
}
