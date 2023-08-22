using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;

namespace MyMovieTutorial.MovieDB;

[ConnectionKey("Default"), Module("MovieDB"), TableName("MovieGenres")]
[DisplayName("Movie Genres"), InstanceName("Movie Genres")]
[ReadPermission("Administration:General")]
[ModifyPermission("Administration:General")]
public sealed class MovieGenresRow : Row<MovieGenresRow.RowFields>, IIdRow
{
    const string jMovie = nameof(jMovie);
    const string jGenre = nameof(jGenre);

    [DisplayName("Movie Genre Id"), Identity, IdProperty]
    public int? MovieGenreId
    {
        get => fields.MovieGenreId[this];
        set => fields.MovieGenreId[this] = value;
    }

    [DisplayName("Movie"), NotNull, ForeignKey("Movie", "MovieId"), LeftJoin(jMovie), TextualField(nameof(MovieTitle))]
    public int? MovieId
    {
        get => fields.MovieId[this];
        set => fields.MovieId[this] = value;
    }

    [DisplayName("Genre"), NotNull, ForeignKey("Genre", "GenreId"), LeftJoin(jGenre), TextualField(nameof(GenreName))]
    public int? GenreId
    {
        get => fields.GenreId[this];
        set => fields.GenreId[this] = value;
    }

    [DisplayName("Movie Title"), Expression($"{jMovie}.[Title]")]
    public string MovieTitle
    {
        get => fields.MovieTitle[this];
        set => fields.MovieTitle[this] = value;
    }

    [DisplayName("Genre Name"), Expression($"{jGenre}.[Name]")]
    public string GenreName
    {
        get => fields.GenreName[this];
        set => fields.GenreName[this] = value;
    }

    public class RowFields : RowFieldsBase
    {
        public Int32Field MovieGenreId;
        public Int32Field MovieId;
        public Int32Field GenreId;

        public StringField MovieTitle;
        public StringField GenreName;
    }
}