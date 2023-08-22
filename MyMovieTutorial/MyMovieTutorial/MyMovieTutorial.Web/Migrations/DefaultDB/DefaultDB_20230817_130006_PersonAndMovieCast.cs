using FluentMigrator;
using Serenity.Extensions;

namespace MyMovieTutorial.Migrations.DefaultDB
{
    [Migration(20230817130006)]
    public class DefaultDB_20230817_130006_PersonAndMovieCast : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Person")
                .WithColumn("PersonId").AsInt32().Identity()
                    .PrimaryKey().NotNullable()
                .WithColumn("FirstName").AsString(50).NotNullable()
                .WithColumn("Lastname").AsString(50).NotNullable()
                .WithColumn("BirthDate").AsDateTime().Nullable()
                .WithColumn("BirthPlace").AsString(100).Nullable()
                .WithColumn("Gender").AsInt32().Nullable()
                .WithColumn("Height").AsInt32().Nullable();

            Create.Table("MovieCast")
                .WithColumn("MovieCastId").AsInt32().Identity()
                    .PrimaryKey().NotNullable()
                .WithColumn("MovieId").AsInt32().NotNullable()
                    .ForeignKey("FK_MovieCast_MovieId", "dbo", "Movie", "MovieId")
                .WithColumn("PersonId").AsInt32().NotNullable()
                    .ForeignKey("FK_MovieCast_PersonId", "dbo", "Person", "PersonId")
                .WithColumn("Character").AsString(50).Nullable();
        }
    }
}