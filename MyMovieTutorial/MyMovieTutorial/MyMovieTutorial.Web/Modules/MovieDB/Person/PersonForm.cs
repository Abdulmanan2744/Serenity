using Serenity.ComponentModel;
using System;

namespace MyMovieTutorial.MovieDB.Forms;

[FormScript("MovieDB.Person")]
[BasedOnRow(typeof(PersonRow), CheckNames = true)]
public class PersonForm
{
    [Tab("Person")]
    public string FirstName { get; set; }
    public string Lastname { get; set; }
    public string PrimaryImage { get; set; }
    public string GalleryImages { get; set; }
    public DateTime BirthDate { get; set; }
    public string BirthPlace { get; set; }
    public int Gender { get; set; }
    public int Height { get; set; }
    [Tab("Movies"), IgnoreName, PersonMovieGrid, LabelWidth("0")]
    public string MoviesGrid { get; set; }
}