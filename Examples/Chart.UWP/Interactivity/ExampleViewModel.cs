using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Telerik.UI.Xaml.Controls.Chart;

namespace Chart.Interactivity
{
    public class ExampleViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IList<OhlcModel> Data { get; set; }

        public ExampleViewModel()
        {
            this.Data = LoadData();
        }

        private ChartDataContext trackBallContext;

        public ChartDataContext TrackBallContext
        {
            get { return trackBallContext; }
            set
            {
                trackBallContext = value;
                this.OnPropertyChanged("TrackBallContext");

                this.UpdateValues(this.TrackBallContext);
            }
        }

        private void UpdateValues(ChartDataContext chartDataContext)
        {
            var item = chartDataContext.ClosestDataPoint.DataPoint.DataItem as OhlcModel;
            this.DateLabel = item.Date.ToString("dd.MM.yyyy");

            this.MSFTValue = item.Close;

            this.EMAValue = (double)chartDataContext.DataPoints.Where(c => c.Series is IndicatorBase).First().DataPoint.Label;
        }

        private string dateLabel;

        public string DateLabel
        {
            get { return dateLabel; }
            set
            {
                dateLabel = value;
                this.OnPropertyChanged("DateLabel");
            }
        }

        private double eMAValue;

        public double EMAValue
        {
            get { return eMAValue; }
            set
            {
                eMAValue = value;
                this.OnPropertyChanged("EMAValue");
            }
        }

        private double mSFTValue;

        public double MSFTValue
        {
            get { return mSFTValue; }
            set
            {
                mSFTValue = value;
                this.OnPropertyChanged("MSFTValue");
            }
        }


        private static List<OhlcModel> LoadData()
        {
            var list = new List<OhlcModel>();

            Assembly assembly = typeof(ExampleViewModel).GetTypeInfo().Assembly;
            string path = "Chart.Interactivity.Data.MSFT.csv";

            using (StreamReader reader = new StreamReader(assembly.GetManifestResourceStream(path)))
            {
                //skip header
                reader.ReadLine();

                string line = string.Empty;
                while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                {

                    string[] values = line.Split(',');
                    double[] args = new double[values.Length - 1];

                    // first argument is the Date, start from the second splitted value
                    for (int i = 1; i < values.Length; i++)
                    {
                        args[i - 1] = double.Parse(values[i], CultureInfo.InvariantCulture);
                    }

                    OhlcModel model = new OhlcModel(0.5, args);
                    model.Date = DateTime.Parse(values[0], CultureInfo.InvariantCulture);

                    list.Add(model);

                }
            }

            return list;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}
