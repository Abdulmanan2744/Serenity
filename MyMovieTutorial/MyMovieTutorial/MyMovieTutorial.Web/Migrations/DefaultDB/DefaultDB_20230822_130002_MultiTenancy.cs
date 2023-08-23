using FluentMigrator;
using Serenity.Extensions;

namespace MyMovieTutorial.Migrations.DefaultDB
{
    [Migration(20230822130002)]
    public class DefaultDB_20230822_130002_MultiTenancy : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("Person")
               .AddColumn("TenantId").AsInt32()
                   .NotNullable().WithDefaultValue(1);

            Alter.Table("Genre")
                .AddColumn("TenantId").AsInt32()
                    .NotNullable().WithDefaultValue(1);

            Alter.Table("Movie")
                .AddColumn("TenantId").AsInt32()
                    .NotNullable().WithDefaultValue(1);
        }
    }
}