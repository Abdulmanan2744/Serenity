using FluentMigrator;
using Serenity.Extensions;

namespace MyMovieTutorial.Migrations.DefaultDB
{
    [Migration(20230822130000)]
    public class DefaultDB_20230822_130000_PersonMovieImages : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("Person")
            .AddColumn("PrimaryImage").AsString(100).Nullable()
            .AddColumn("GalleryImages").AsString(int.MaxValue).Nullable();

            Alter.Table("Movie")
                .AddColumn("PrimaryImage").AsString(100).Nullable()
                .AddColumn("GalleryImages").AsString(int.MaxValue).Nullable();
        }
    }
}