using FluentMigrator;
using Serenity.Extensions;

namespace MultiTenancy.Migrations.DefaultDB
{
    [Migration(20161029130001)]
    public class DefaultDB_20230822_130001_MultiTenant : AutoReversingMigration
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