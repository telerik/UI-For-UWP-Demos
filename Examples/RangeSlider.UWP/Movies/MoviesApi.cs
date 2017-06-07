using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Net;
using Windows.UI.Xaml;
using System.Reflection;
using System.Net.Http;

namespace RangeSlider
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

    public static class MoviesApi
    {	
        public static void GetMovies(MoviesContextDeliveredCallback callback)
        {
            var path = "RangeSlider.Movies.top_rental_movies.txt";
            var assembly = typeof(MoviesApi).GetTypeInfo().Assembly;

            MoviesQueryContext queryResult = new MoviesQueryContext();

            using (Stream stream = assembly.GetManifestResourceStream(path))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string stringResult = reader.ReadToEnd();
                    queryResult = JsonConvert.DeserializeObject<MoviesQueryContext>(stringResult.Trim());
                }
            }

            callback(queryResult);
        }
    }
}