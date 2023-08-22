using Serenity.Services;
using System.Collections.Generic;

namespace MyMovieTutorial.MovieDB
{
    public class MovieListRequest : ListRequest
    {
        public List<int> Genres { get; set; }
    }
}
