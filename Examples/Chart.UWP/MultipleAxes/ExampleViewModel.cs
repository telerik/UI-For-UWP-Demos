using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Telerik.UI.Xaml.Controls.Chart;

namespace Chart.MultipleAxes
{
    public class ExampleViewModel : INotifyPropertyChanged
    {
        private IEnumerable gdpSelection;
        private bool isSavingsChecked;
        private bool isInvestmentChecked;
        private bool isGrowthChecked;
        private string gdpLabel;
        private string gdpLabelFormat = "GDP, bln {0}";
        private string selectedCountryName;

        public ExampleViewModel()
        {
            this.SelectedCountryName = "United Kingdom";

            this.IsSavingsChecked = true;
            this.IsGrowthChecked = true;


            this.IsInvestmentChecked = true;

            this.GetData("GDPDetails.csv");
        }

        public string SelectedCountryName
        {
            get
            {
                return this.selectedCountryName;
            }
            set
            {
                if (this.selectedCountryName != value)
                {
                    this.selectedCountryName = value;
                    this.OnPropertyChanged("SelectedCountryName");

                    this.GdpLabel = string.Format(gdpLabelFormat, localCurrency[value]);
                    this.UpdateGdpDataSelection(value);
                }
            }
        }

        public string GdpLabel
        {
            get
            {
                return this.gdpLabel;
            }
            set
            {
                if (this.gdpLabel != value)
                {
                    this.gdpLabel = value;
                    this.OnPropertyChanged("GdpLabel");
                }
            }
        }

        public bool IsAdditionalAxisAdded
        {
            get
            {
                return IsSavingsChecked || IsInvestmentChecked || IsGrowthChecked;
            }
        }

        public bool IsSavingsChecked
        {
            get
            {
                return this.isSavingsChecked;
            }
            set
            {
                if (this.isSavingsChecked != value)
                {
                    this.isSavingsChecked = value;
                    this.OnPropertyChanged("IsSavingsChecked");

                    this.OnPropertyChanged("IsAdditionalAxisAdded");
                }
            }
        }

        public bool IsInvestmentChecked
        {
            get
            {
                return this.isInvestmentChecked;
            }
            set
            {
                if (this.isInvestmentChecked != value)
                {
                    this.isInvestmentChecked = value;
                    this.OnPropertyChanged("IsInvestmentChecked");

                    this.OnPropertyChanged("IsAdditionalAxisAdded");
                }
            }
        }

        public bool IsGrowthChecked
        {
            get
            {
                return this.isGrowthChecked;
            }
            set
            {
                if (this.isGrowthChecked != value)
                {
                    this.isGrowthChecked = value;
                    this.OnPropertyChanged("IsGrowthChecked");

                    this.OnPropertyChanged("IsAdditionalAxisAdded");
                }
            }
        }

        public IEnumerable GdpSelection
        {
            get
            {
                return this.gdpSelection;
            }
            set
            {
                if (this.gdpSelection != value)
                {
                    this.gdpSelection = value;
                    this.OnPropertyChanged("GdpSelection");
                }
            }
        }

        public IEnumerable Countries
        {
            get
            {
                return localCurrency.Keys.ToArray();
            }
        }

        private IEnumerable<IGrouping<string, GdpDetailsInfo>> GdpDataDetails
        {
            get;
            set;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void GetData(string fileName)
        {
            Assembly assembly = typeof(ExampleViewModel).GetTypeInfo().Assembly;
            string path = "Chart.MultipleAxes.Data." + fileName;

            using (StreamReader reader = new StreamReader(assembly.GetManifestResourceStream(path)))
            {
                GetDataCompleted(this.ParseData(reader));
            }

        }

        protected IEnumerable ParseData(System.IO.TextReader dataReader)
        {
            string line;
            List<GdpDetailsInfo> dataList = new List<GdpDetailsInfo>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] data = line.Split(',');

                var gdpDetails = new GdpDetailsInfo();
                gdpDetails.CountryName = data[0].Trim();
                if (!string.IsNullOrEmpty(data[1]))
                    gdpDetails.Year = int.Parse(data[1], CultureInfo.InvariantCulture);
                if (!string.IsNullOrEmpty(data[2]))
                    gdpDetails.Value = double.Parse(data[2], CultureInfo.InvariantCulture);
                if (!string.IsNullOrEmpty(data[3]))
                    gdpDetails.Savings = double.Parse(data[3], CultureInfo.InvariantCulture);
                if (!string.IsNullOrEmpty(data[4]))
                    gdpDetails.Investment = double.Parse(data[4], CultureInfo.InvariantCulture);
                if (!string.IsNullOrEmpty(data[5]))
                    gdpDetails.Inflation = double.Parse(data[5], CultureInfo.InvariantCulture);
                if (!string.IsNullOrEmpty(data[6]))
                    gdpDetails.TotalGovernmentNetDebt = double.Parse(data[6], CultureInfo.InvariantCulture);
                if (!string.IsNullOrEmpty(data[7]))
                    gdpDetails.GeneralGovernmentRevenue = double.Parse(data[7], CultureInfo.InvariantCulture);
                if (!string.IsNullOrEmpty(data[8]))
                    gdpDetails.GeneralGovernmentTotalExpenditure = double.Parse(data[8], CultureInfo.InvariantCulture);
                if (!string.IsNullOrEmpty(data[9]))
                    gdpDetails.GdpGrowth = double.Parse(data[9], CultureInfo.InvariantCulture);
                if (!string.IsNullOrEmpty(data[10]))
                    gdpDetails.AccountBalance = double.Parse(data[10], CultureInfo.InvariantCulture);

                dataList.Add(gdpDetails);
            }

            return dataList.Where(c => c.Year >= 2001);
        }

        protected void GetDataCompleted(IEnumerable data)
        {
            this.GdpDataDetails = data.Cast<GdpDetailsInfo>().GroupBy(item => item.CountryName);
            this.UpdateGdpDataSelection(this.SelectedCountryName);
        }

        private void UpdateGdpDataSelection(string country)
        {
            if (this.GdpDataDetails == null)
                return;

            this.GdpSelection = this.GdpDataDetails.Single(group => (string)group.Key == country);
        }

        private readonly Dictionary<string, string> localCurrency = new Dictionary<string, string>()
            {
                { "Austria", "euro" },
                { "Belgium", "euro" },
                { "Bulgaria", "lev" },
                { "Cyprus", "euro" },
                { "Czech Republic", "koruna" }, 
                { "Denmark", "krone" },
                { "Estonia", "kroon" },
                { "Finland", "euro" },
                { "France", "euro" },
                { "Germany", "euro" },
                { "Greece", "euro" },
                { "Hungary", "forint" },
                { "Ireland", "euro" },
                { "Italy", "euro" },
                { "Latvia", "lats" },
                { "Lithuania", "litas" },
                { "Luxembourg", "euro" },
                { "Malta", "euro" },
                { "Netherlands", "euro" },
                { "Poland", "zloty" },
                { "Portugal", "euro" },
                { "Romania", "lei" },
                { "Slovakia", "koruna" },
                { "Slovenia", "euro" },
                { "Spain", "euro" },
                { "Sweden", "krona" },
                { "United Kingdom", "pound" }
            };

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
