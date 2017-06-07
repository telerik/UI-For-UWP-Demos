using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chart.Gallery
{
    public class LowHighMeasurementWeatherData
    {
        public DateTime Date { get; set; }
        public double LowMeasurement { get; set; }
        public double HighMeasurement { get; set; }

        public LowHighMeasurementWeatherData(DateTime date, double lowMeasurement, double highMeasurement)
        {
            this.Date = date;
            this.LowMeasurement = lowMeasurement;
            this.HighMeasurement = highMeasurement;
        }
    }
}
