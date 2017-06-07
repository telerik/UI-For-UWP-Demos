using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chart.MultipleAxes
{
    public class GdpInfo
    {
        public GdpInfo(string name, double gdp)
        {
            this.CountryName = name;
            this.Value = gdp;
        }

        public GdpInfo(string name, double gdp, double latitude, double longitude)
            : this(name, gdp)
        {
         //   this.Location = new Location(latitude, longitude);
        }

        public string CountryName
        {
            get;
            set;
        }

        public double Value
        {
            get;
            set;
        }

        public double Size
        {
            get
            {
                if (this.Value <= 10000)
                    return 6d;
                else if (this.Value <= 100000)
                    return 12d;
                else if (this.Value <= 1000000)
                    return 24d;
                else
                    return 48d;
            }
        }

        public static IEnumerable Create()
        {
            return new List<GdpInfo>()
            {
                new GdpInfo("Austria",284410,47.5968599775987,14.5537109375),
                new GdpInfo("Belgium",352941,50.50343132019043,4.4696997404098511),
                new GdpInfo("Bulgaria",36033,42.7045941632251,25.3642578125),
                new GdpInfo("Cyprus",17465),
                new GdpInfo("Czech Republic",145049,49.8175392150879,15.5288572311401),
                new GdpInfo("Denmark",234005,56.1213264465332,11.6268391609192),
                new GdpInfo("Estonia",14501,58.579683303833,25.0388298034668),
                new GdpInfo("Finland",180253,60.6879415510559,23.9580078125),
                new GdpInfo("France",1932802,46.5191416559141,2.42480468749997),
                new GdpInfo("Germany",2498800,51.5275027742503,10.0712890625),
                new GdpInfo("Greece",230173,39.1875123702475,21.8486328125),
                new GdpInfo("Hungary",98446,47.1649608612061,19.5035161972046),
                new GdpInfo("Ireland",153938,53.1911862850231,-7.68261718750005),
                new GdpInfo("Italy",1548816,41.8592858578218,13.4111328125),
                new GdpInfo("Latvia",17971,56.8760395050049,24.6052722930908),
                new GdpInfo("Lithuania",27410,55.168571472168,23.8490314483643),
                new GdpInfo("Luxembourg",41597,49.8083629608154,6.1358757019043),
                new GdpInfo("Malta",6233,35.8955249786377,14.4537568092346),
                new GdpInfo("Netherlands",591477,52.5546072095382,5.32519531249998),
                new GdpInfo("Poland",354316,51.9203319549561,19.1303663253784),
                new GdpInfo("Portugal",172699,39.7303764577865,-8.20996093750005),
                new GdpInfo("Romania",121941,46.0331580429645,25.1005859375),
                new GdpInfo("Slovakia",65905,48.6690330505371,19.6992673873901),
                new GdpInfo("Slovenia",35974,46.1479759216309,14.9951300621033),
                new GdpInfo("Spain",1062591,40.2019037563023,-2.84863281250004),
                new GdpInfo("Sweden",346667,59.6385672511104,14.8173828125),
                new GdpInfo("United Kingdom",1696583,52.5011367218104,-1.53027343750004)
            };
        }
    }
}
