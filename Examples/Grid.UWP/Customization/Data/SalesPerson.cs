using System;
using System.Collections;

namespace Grid.Customization
{
    public class SalesPerson
    {
        public string Name
        {
            get;
            set;
        }

        public string Country
        {
            get;
            set;
        }

        public string Region
        {
            get;
            set;
        }

        public IEnumerable SalesChartData
        {
            get;
            set;
        }

        public double SalesQuota
        {
            get;
            set;
        }

        public double SalesLastYear
        {
            get;
            set;
        }

        public double SalesYTD
        {
            get;
            set;
        }

        public double TerritorySalesLastYear
        {
            get;
            set;
        }

        public double TerritorySalesYTD
        {
            get;
            set;
        }
    }
}
