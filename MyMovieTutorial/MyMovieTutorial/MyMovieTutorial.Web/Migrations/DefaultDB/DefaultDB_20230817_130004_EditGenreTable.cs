using FluentMigrator;
using Serenity.Extensions;

namespace MyMovieTutorial.Migrations.DefaultDB
{
    [Migration(20230817130004)]
    public class DefaultDB_20230817_130004_EditGenreTable : AutoReversingMigration
    {
        public override void Up()
        {
            Insert.IntoTable("Genre")
                .Row(new
                {
                    Name = "Action"
                })
                .Row(new
                {
                    Name = "Drama"
                })
                .Row(new
                {
                    Name = "Comedy"
                })
                .Row(new
                {
                    Name = "Sci-fi"
                })
                .Row(new
                {
                    Name = "Fantasy"
                })
                .Row(new
                {
                    Name = "Documentary"
                });
        }
    }
}