using FluentMigrator;
using Serenity.Extensions;

namespace MyMovieTutorial.Migrations.DefaultDB
{
    [Migration(20230817130005)]
    public class DefaultDB_20230817_130005_MovieGenres : Migration
    {
        public override void Up()
        {
            Create.Table("MovieGenres")
                .WithColumn("MovieGenreId").AsInt32()
                    .Identity().PrimaryKey().NotNullable()
                .WithColumn("MovieId").AsInt32().NotNullable()
                    .ForeignKey("FK_MovieGenres_MovieId",
                        "dbo", "Movie", "MovieId")
                .WithColumn("GenreId").AsInt32().NotNullable()
                    .ForeignKey("FK_MovieGenres_GenreId",
                        "dbo", "Genre", "GenreId");

            Execute.Sql(
              @"INSERT INTO dbo.MovieGenres (MovieId, GenreId) 
                    SELECT m.MovieId, m.GenreId 
                    FROM dbo.Movie m 
                    WHERE m.GenreId IS NOT NULL");

            Delete.ForeignKey("FK_Movie_GenreId")
                .OnTable("Movie");
            Delete.Column("GenreId")
                .FromTable("Movie");
        }

        public override void Down()
        {
        }
    }
}