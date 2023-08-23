using Serenity.ComponentModel;
using System.ComponentModel;

namespace MyMovieTutorial.Administration.Columns;

[ColumnsScript("Administration.Tenants")]
[BasedOnRow(typeof(TenantsRow), CheckNames = true)]
public class TenantsColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int TenantId { get; set; }
    [EditLink]
    public string TenantName { get; set; }
}