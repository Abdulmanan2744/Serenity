using Serenity.ComponentModel;

namespace MyMovieTutorial.Administration.Forms;

[FormScript("Administration.Tenants")]
[BasedOnRow(typeof(TenantsRow), CheckNames = true)]
public class TenantsForm
{
    public string TenantName { get; set; }
}