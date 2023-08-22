using MyMovieTutorial.MovieDB;
using Serenity.ComponentModel;
using System;

namespace MyMovieTutorial.MovieDB.Columns
{
    [ColumnsScript("MovieDB.PersonMovie")]
    [BasedOnRow(typeof(MovieCastRow))]
    public class PersonMovieColumns
    {
        [Width(220)]
        public string MovieTitle { get; set; }
        [Width(100)]
        public int MovieYear { get; set; }
        [Width(200)]
        public string Character { get; set; }
    }
}