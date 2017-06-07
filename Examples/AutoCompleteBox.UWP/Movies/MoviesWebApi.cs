using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Reflection;
using Windows.UI.Xaml;
using Windows.Data.Json;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCompleteBox
{
    public delegate void MoviesContextDeliveredCallback(MoviesQueryContext context);

    public struct MovieQuery
    {
        public MoviesContextDeliveredCallback CallBack;
        public HttpWebRequest Request;
        public MovieQuery(MoviesContextDeliveredCallback callBack, HttpWebRequest request)
        {
            this.CallBack = callBack;
            this.Request = request;
        }
    }

    public static class MoviesWebApi
    {
        public async static void GetMovies(string movieTitle, Action<IEnumerable<Movie>> callback)
        {
            var path = "AutoCompleteBox.Movies.top_rental_movies.txt";
            var assembly = typeof(MoviesWebApi).GetTypeInfo().Assembly;

            MoviesQueryContext queryResult = new MoviesQueryContext();

            using (Stream stream = assembly.GetManifestResourceStream(path))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string stringResult = reader.ReadToEnd();
                    queryResult = JsonConvert.DeserializeObject<MoviesQueryContext>(stringResult.Trim());
                   
                }
            }
            var movies = queryResult.Movies.Where(movie => movie.Title.ToLower().Contains(movieTitle)).ToList();

            await Task.Delay(3000);

            callback(movies);
        }
    }
}