using System.Globalization;
using Telerik.Charting;
using Telerik.UI.Xaml.Controls.Map;

namespace Map.UserLayer
{
    public class InternetUsage : MapDataItem
    {
        public double Usage
        {
            get;
            set;
        }

        public double UsagePercentage
        {
            get
            {
                return this.Usage / this.TotalUsage;
            }
        }

        public double TotalUsage
        {
            get;
            set;
        }

        public double[] DoughnutItemsSource
        {
            get
            {
                return new double[] { this.UsagePercentage, 1 - this.UsagePercentage };
            }
        }

        public string UsageLabel
        {
            get
            {
                return this.UsagePercentage.ToString("P0", CultureInfo.InvariantCulture);
            }
        }

        public AngleRange DoughnutRange
        {
            get
            {
                return new AngleRange(-90, 360);
            }
        }

        public string Continent 
        { 
            get;
            set; 
        }
    }
}
