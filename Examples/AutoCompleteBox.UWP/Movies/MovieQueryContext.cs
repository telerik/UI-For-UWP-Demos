using Newtonsoft.Json;
using System.Collections.Generic;

namespace AutoCompleteBox
{
    public class MoviesQueryContext
    {
        [JsonProperty("total")]
        public string TotalMovies
        {
            get;
            set;
        }

        [JsonProperty("movies")]
        public List<Movie> Movies
        {
            get;
            set;
        }
    }
}
