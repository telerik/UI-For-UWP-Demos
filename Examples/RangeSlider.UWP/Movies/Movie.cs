using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RangeSlider
{
    public class Movie
    {
        [JsonProperty("title")]
        public string Title
        {
            get;
            set;
        }

        [JsonProperty("director")]
        public string Director
        {
            get;
            set;
        }

        [JsonProperty("duration")]
        public string Duration
        {
            get;
            set;
        }
        
        [JsonProperty("rating")]
        public string Rating
        {
            get;
            set;
        }

        [JsonProperty("poster")]
        public string Poster
        {
            get;
            set;
        }
    }
}
