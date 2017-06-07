using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grid.FlightSearch
{
    public class SearchResult
    {
        private List<ResultEntry> results;
        private static readonly string[] Carriers = new string[]
        {
            "SkyRocket Airways",
            "Amazing Airlines",
            "Save Wings Airways",
            "Silver Lightning Airline",
            "Butterfly Airways",
            "SkyLine Air",
            "Air Comfort"
        };

        public SearchResult()
        {
            this.results = new List<ResultEntry>();
            this.BuildResults();
        }

        public IEnumerable Results
        {
            get
            {
                return this.results;
            }
        }

        private void BuildResults()
        {
            var startDate = new DateTime(2013, 5, 14);
            var endDate = new DateTime(2013, 5, 18);

            Random random = new Random();

            for (int i = 0; i < 30; i++)
            {
                var item = new ResultEntry()
                {
                    IsReturning = i % 2 == 0,
                    IsDirect = !(i % 3 == 0)
                };

                var date = item.IsReturning ? endDate : startDate;

                item.Departure = date.Add(TimeSpan.FromMinutes(random.Next(100, 1200)));
                item.Arrival = item.Departure.Add(TimeSpan.FromMinutes(random.Next(450, 500)));
                item.FlightId = random.Next(100, 6000);
                item.Class = (FlightClass)random.Next(0, 4);
                item.Carrier = Carriers[random.Next(0, 7)];
                item.Duration = item.Arrival - item.Departure;
                item.Price = random.Next(430, 1500);

                this.results.Add(item);
            }
        }
    }
}
