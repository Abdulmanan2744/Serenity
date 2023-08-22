namespace MyMovieTutorial.MovieDB.Columns
{
    using Serenity.ComponentModel;
    using System;

    [ColumnsScript("MovieDB.MovieCast")]
    [BasedOnRow(typeof(MovieCastRow))]
    public class MovieCastColumns
    {
        [EditLink, Width(220)]
        public string PersonFullname { get; set; }
        [EditLink, Width(150)]
        public string Character { get; set; }
    }
}