using Serenity.ComponentModel;
using System;
using System.Collections.Generic;

namespace MyMovieTutorial.MovieDB.Forms;

[FormScript("MovieDB.Movie")]
[BasedOnRow(typeof(MovieRow), CheckNames = true)]
public class MovieForm
{
    public string Title { get; set; }
    [TextAreaEditor(Rows = 3)]
    public string Description { get; set; }

    [MovieCastEditor, IgnoreName]
    public List<MovieCastRow> CastList { get; set; }

    public string PrimaryImage { get; set; }
    public string GalleryImages { get; set; }

    [TextAreaEditor(Rows = 8)]
    public string Storyline { get; set; }
    public int Year { get; set; }
    public DateTime ReleaseDate { get; set; }
    public List<int> GenreList { get; set; }
    public int Runtime { get; set; }
    public MovieKind Kind { get; set; }
    
}