using Newtonsoft.Json;
using System.Collections.Generic;

namespace RangeSlider
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
