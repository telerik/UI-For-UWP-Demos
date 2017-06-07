using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chart.MultipleAxes
{
    public class GdpDetailsInfo
    {
        public string CountryName
        {
            get;
            set;
        }

        public int Year
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or set GDP (Constant Prices, National Currency).
        /// </summary>
        public double? Value
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Gross National Savings (% of GDP).
        /// </summary>
        public double? Savings
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Investment (% of GDP).
        /// </summary>
        public double? Investment
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Inflation (Average Consumer Price Change %).
        /// </summary>
        public double? Inflation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the total government net debt (% of GDP).
        /// </summary>
        public double? TotalGovernmentNetDebt
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the general government revenue (% of GDP).
        /// </summary>
        public double? GeneralGovernmentRevenue
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the general government total expenditure (% of GDP).
        /// </summary>
        public double? GeneralGovernmentTotalExpenditure
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets GDP Growth (Constant Prices, National Currency, annual % change).
        /// </summary>
        public double? GdpGrowth
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Current Account Balance (% GDP).
        /// </summary>
        public double? AccountBalance
        {
            get;
            set;
        }
    }
}
