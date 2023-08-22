using FluentMigrator;
using Serenity.Extensions;

namespace MyMovieTutorial.Migrations.DefaultDB
{
    [Migration(20230817130002)]
    public class DefaultDB_20230817_130002_MovieKind : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("Movie")
               .AddColumn("Kind").AsInt32().NotNullable()
                   .WithDefaultValue(1);
        }
    }
}