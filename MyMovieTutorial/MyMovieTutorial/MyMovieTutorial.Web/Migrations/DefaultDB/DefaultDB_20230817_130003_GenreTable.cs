using FluentMigrator;
using Serenity.Extensions;

namespace MyMovieTutorial.Migrations.DefaultDB
{
    [Migration(20230817130003)]
    public class DefaultDB_20230817_130003_GenreTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Genre")
               .WithColumn("GenreId").AsInt32().NotNullable()
                   .PrimaryKey().Identity()
               .WithColumn("Name").AsString(100).NotNullable();

            Alter.Table("Movie")
                .AddColumn("GenreId").AsInt32().Nullable()
                    .ForeignKey("FK_Movie_GenreId", "dbo", "Genre", "GenreId");
        }
    }
}