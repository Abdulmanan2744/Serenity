using Serenity.ComponentModel;
using System.ComponentModel;

namespace MyMovieTutorial.MovieDB.Columns;

[ColumnsScript("MovieDB.MovieGenres")]
[BasedOnRow(typeof(MovieGenresRow), CheckNames = true)]
public class MovieGenresColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int MovieGenreId { get; set; }
    public string MovieTitle { get; set; }
    public string GenreName { get; set; }
}