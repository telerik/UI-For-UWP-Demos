using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Telerik.UI.Xaml.Controls;
using Telerik.UI.Xaml.Controls.Chart;

namespace Chart.FirstLook
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private int selectedRevenueIndex;

        public ChartPalette DefaultPalette
        {
            get
            {
                return ChartPalettes.DefaultLight;
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private List<MonthRevenue> targetRevenues;

        public List<MonthRevenue> TargetRevenues
        {
            get { return targetRevenues; }
            set
            {
                targetRevenues = value;
                this.OnPropertyChanged("TargetRevenues");
            }
        }

        private List<MonthRevenue> lastYearRevenues;

        public List<MonthRevenue> LastYearRevenues
        {
            get { return lastYearRevenues; }
            set
            {
                lastYearRevenues = value;
                this.OnPropertyChanged("LastYearRevenues");
            }
        }

        private List<MonthRevenue> actualRevenues;

        public List<MonthRevenue> ActualRevenues
        {
            get { return actualRevenues; }
            set
            {
                actualRevenues = value;
                this.OnPropertyChanged("ActualRevenues");
            }
        }

        private List<ProductRevenue> productRevenues;

        public List<ProductRevenue> ProductRevenues
        {
            get
            {
                return this.productRevenues;
            }
            set
            {
                this.productRevenues = value;
                this.OnPropertyChanged("ProductRevenues");
            }
        }

        private List<StoreRevenue> storeRevenues;

        public List<StoreRevenue> StoreRevenues
        {
            get { return storeRevenues; }
            set
            {
                storeRevenues = value;
                this.OnPropertyChanged("StoreRevenues");
            }
        }

        private List<RevenueData> revenueDataList;

        public List<RevenueData> RevenueDataList
        {
            get { return revenueDataList; }
            set
            {
                revenueDataList = value;
                this.OnPropertyChanged("RevenueDataList");
                this.SelectedRevenueIndex = 0;
            }
        }

        public int SelectedRevenueIndex
        {
            get
            {
                return selectedRevenueIndex;
            }
            set
            {
                selectedRevenueIndex = value;
                this.OnPropertyChanged("SelectedRevenueIndex");
            }
        }


        public MainViewModel()
        {
            LoadData();
        }

        private async void LoadData()
        {
            var text = await Windows.Storage.PathIO.ReadTextAsync("ms-appx:///Chart/FirstLook/Data/FirstLookData.xml");
            var doc = XDocument.Parse(text);

            this.LoadActualRevenues(doc);
            this.LoadLastYearRevenues(doc);
            this.LoadTargetRevenues(doc);

            this.UpdateRevenueDataList(this.ActualRevenues.First().Date);

            this.LoadStoreRevenues(doc);

            this.LoadProductRevenues(doc);
        }

        private void LoadProductRevenues(XDocument doc)
        {
            var productRevenues = from c in doc.Descendants("ProductRevenues").First().Descendants("ProductRevenue")
                                  select new ProductRevenue
                                  {
                                      Amount = double.Parse(c.Element("Amount").Value, CultureInfo.InvariantCulture),
                                      ProductName = c.Element("ProductName").Value.Trim()
                                  };
            this.ProductRevenues = new List<ProductRevenue>(productRevenues);
        }

        private void LoadStoreRevenues(XDocument doc)
        {
            var storeRevenues = from c in doc.Descendants("StoreRevenues").First().Descendants("StoreRevenue")
                                select new StoreRevenue
                                {
                                    Amount = double.Parse(c.Element("Amount").Value, CultureInfo.InvariantCulture),
                                    StoreName = c.Element("StoreName").Value
                                };
            this.StoreRevenues = new List<StoreRevenue>(storeRevenues);
        }



        public void UpdateRevenueDataList(DateTime selectedDate)
        {
            var actualItem = this.ActualRevenues.Where(c => c.Date.Month == selectedDate.Month).First();
            var targetItem = this.TargetRevenues.Where(c => c.Date.Month == selectedDate.Month).First();
            var lastYearItem = this.LastYearRevenues.Where(c => c.Date.Month == selectedDate.Month).First();

            var actualVSTargetPercent = targetItem.Amount != 0 ? (actualItem.Amount - targetItem.Amount) / targetItem.Amount : 0;
            var actualVSLastYearPercent = lastYearItem.Amount != 0 ? (actualItem.Amount - lastYearItem.Amount) / lastYearItem.Amount : 0;


            if (RevenueDataList == null)
            {
                var revenueDatas = new List<RevenueData>();

                revenueDatas.Add(new RevenueData { Amount = actualItem.Amount, DataType = RevenueDataType.Actual, Date = selectedDate });
                revenueDatas.Add(new RevenueData { Amount = actualVSTargetPercent, DataType = RevenueDataType.ActualVSTarget, Date = selectedDate });
                revenueDatas.Add(new RevenueData { Amount = actualVSLastYearPercent, DataType = RevenueDataType.ActualVSLastYear, Date = selectedDate });

                this.RevenueDataList = revenueDatas;
            }
            else 
            {
                var actualData = this.RevenueDataList.Where(c => c.DataType == RevenueDataType.Actual).First();
                actualData.Date = selectedDate;
                actualData.Amount = actualItem.Amount;

               var actualVSTargetData =  this.RevenueDataList.Where(c => c.DataType == RevenueDataType.ActualVSTarget).First();
               actualVSTargetData.Date = selectedDate;
               actualVSTargetData.Amount = actualVSTargetPercent;

               var actualVSLastYearData = this.RevenueDataList.Where(c => c.DataType == RevenueDataType.ActualVSLastYear).First();
               actualVSLastYearData.Date = selectedDate;
               actualVSLastYearData.Amount = actualVSLastYearPercent;
            }
        }

        private void LoadActualRevenues(XDocument doc)
        {
            var actualRevenues = from c in doc.Descendants("ActualRevenues").First().Descendants("MonthRevenue")
                                 select new MonthRevenue
                                 {
                                     Amount = double.Parse(c.Element("Amount").Value, CultureInfo.InvariantCulture),
                                     Date = DateTime.Parse(c.Element("Date").Value, CultureInfo.InvariantCulture)
                                 };
            this.ActualRevenues = new List<MonthRevenue>(actualRevenues);

        }

        private void LoadLastYearRevenues(XDocument doc)
        {
            var actualRevenues = from c in doc.Descendants("LastYearRevenues").First().Descendants("MonthRevenue")
                                 select new MonthRevenue
                                 {
                                     Amount = double.Parse(c.Element("Amount").Value, CultureInfo.InvariantCulture),
                                     Date = DateTime.Parse(c.Element("Date").Value, CultureInfo.InvariantCulture)
                                 };
            this.LastYearRevenues = new List<MonthRevenue>(actualRevenues);
        }

        private void LoadTargetRevenues(XDocument doc)
        {
            var actualRevenues = from c in doc.Descendants("TargetRevenues").First().Descendants("MonthRevenue")
                                 select new MonthRevenue
                                 {
                                     Amount = double.Parse(c.Element("Amount").Value, CultureInfo.InvariantCulture),
                                     Date = DateTime.Parse(c.Element("Date").Value, CultureInfo.InvariantCulture)
                                 };
            this.TargetRevenues = new List<MonthRevenue>(actualRevenues);
        }
    }
}
