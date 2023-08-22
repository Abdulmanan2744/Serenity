using FluentMigrator;
using Serenity.Extensions;
using System;

namespace MyMovieTutorial.Migrations.DefaultDB
{
    [Migration(20230817130000)]
    public class DefaultDB_20230817_130000_MovieTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Movie")
                 .WithColumn("MovieId").AsInt32()
                     .Identity().PrimaryKey().NotNullable()
                 .WithColumn("Title").AsString(200).NotNullable()
                 .WithColumn("Description").AsString(1000).Nullable()
                 .WithColumn("Storyline").AsString(Int32.MaxValue).Nullable()
                 .WithColumn("Year").AsInt32().Nullable()
                 .WithColumn("ReleaseDate").AsDateTime().Nullable()
                 .WithColumn("Runtime").AsInt32().Nullable();
        }
    }
}