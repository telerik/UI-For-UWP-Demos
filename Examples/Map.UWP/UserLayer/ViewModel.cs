using System.Collections.Generic;
using Telerik.Geospatial;

namespace Map.UserLayer
{
    public class ViewModel
    {
        private List<InternetUsage> items;

        public ViewModel()
        {
            this.items = new List<InternetUsage>();

            this.items.Add(new InternetUsage() { Continent = "Africa", Usage = 167335676, TotalUsage = 2405518376, Location = new Location(14.4825321104746, 18.7191367149353) });
            this.items.Add(new InternetUsage() { Continent = "Asia", Usage = 1166681514, TotalUsage = 2405518376, Location = new Location(52.9135863568401, 96.6630363464357) });
            this.items.Add(new InternetUsage() { Continent = "Europe", Usage = 518512109, TotalUsage = 2405518376, Location = new Location(49.7429249244701, 22.5130248069764) });
            this.items.Add(new InternetUsage() { Continent = "North America", Usage = 273785413, TotalUsage = 2405518376, Location = new Location(47.8401588693269, -98.113462328911) });
            this.items.Add(new InternetUsage() { Continent = "South America", Usage = 254915745, TotalUsage = 2405518376, Location = new Location(-13.8954312649356, -60.5830550193788) });
            this.items.Add(new InternetUsage() { Continent = "Australia", Usage = 24287919, TotalUsage = 2405518376, Location = new Location(-24.5761630851608, 134.120106697083) });
        }

        public IEnumerable<InternetUsage> Items
        {
            get
            {
                return this.items;
            }
        }
    }
}
