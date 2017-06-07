using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Core;
using Windows.UI.Xaml;

namespace Grid.Update
{
    public class DataUpdateViewModel : ViewModelBase
    {
        private static readonly int Deviation = 2;

        private DispatcherTimer timer;

        private double updateProgress;

        public DataUpdateViewModel()
        {
            this.Data = GetData();

            lastTick = DateTime.Now;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(50);
            timer.Tick += timer_Tick;
        }

        public void OnLoaded()
        {
            timer.Start();
        }

        public void OnUnloaded()
        {
            this.timer.Stop();
        }

        private IList<Stock> GetData()
        {
            var data = new ObservableCollection<Stock>();

            data.Add(new Stock
            {
                Symbol = "E-Mini S&P 500 Mar 13",
                Price = 1513.5,
                Continent = "US",
                PriceHistory = new ObservableCollection<Tuple<int, double>>(from c in Enumerable.Range(0, 20) select new Tuple<int, double>(c, (rand.Next(0, 2 * Deviation) - Deviation) / 100.0))

            });

            data.Add(new Stock
            {
                Symbol = "Mini Dow Jones Indus.-$5 Mar 13",
                Price = 13950,
                Continent = "US",
                PriceHistory = new ObservableCollection<Tuple<int, double>>(from c in Enumerable.Range(0, 20) select new Tuple<int, double>(c, (rand.Next(0, 2 * Deviation) - Deviation) / 100.0))

            });

            data.Add(new Stock
            {
                Symbol = "Nasdaq 100 Mar 13",
                Price = 2774,
                Continent = "US",
                PriceHistory = new ObservableCollection<Tuple<int, double>>(from c in Enumerable.Range(0, 20) select new Tuple<int, double>(c, (rand.Next(0, 2 * Deviation) - Deviation) / 100.0))

            });

            data.Add(new Stock
            {
                Symbol = "EUR/USD",
                Price = 1.3368,
                Continent = "US",
                PriceHistory = new ObservableCollection<Tuple<int, double>>(from c in Enumerable.Range(0, 20) select new Tuple<int, double>(c, (rand.Next(0, 2 * Deviation) - Deviation) / 100.0))
            });

            data.Add(new Stock
            {
                Symbol = "FTSE 100",
                Price = 6274,
                Continent = "Europe",
                PriceHistory = new ObservableCollection<Tuple<int, double>>(from c in Enumerable.Range(0, 20) select new Tuple<int, double>(c, (rand.Next(0, 2 * Deviation) - Deviation) / 100.0))
            });

            data.Add(new Stock
            {
                Symbol = "DAX",
                Price = 7631,
                Continent = "Europe",
                PriceHistory = new ObservableCollection<Tuple<int, double>>(from c in Enumerable.Range(0, 20) select new Tuple<int, double>(c, (rand.Next(0, 2 * Deviation) - Deviation) / 100.0))
            });

            data.Add(new Stock
            {
                Symbol = "CAC 40",
                Price = 3651,
                Continent = "Europe",
                PriceHistory = new ObservableCollection<Tuple<int, double>>(from c in Enumerable.Range(0, 20) select new Tuple<int, double>(c, (rand.Next(0, 2 * Deviation) - Deviation) / 100.0))
            });

            data.Add(new Stock
            {
                Symbol = "NIKKEI 225",
                Price = 11153,
                Continent = "Asia",
                PriceHistory = new ObservableCollection<Tuple<int, double>>(from c in Enumerable.Range(0, 20) select new Tuple<int, double>(c, (rand.Next(0, 2 * Deviation) - Deviation) / 100.0))
            });

            data.Add(new Stock
            {
                Symbol = "HANG SENG",
                Price = 23215,
                Continent = "Asia",
                PriceHistory = new ObservableCollection<Tuple<int, double>>(from c in Enumerable.Range(0, 20) select new Tuple<int, double>(c, (rand.Next(0, 2 * Deviation) - Deviation) / 100.0))
            });

            data.Add(new Stock
            {
                Symbol = "STRAITS TIMES",
                Price = 3270,
                Continent = "Asia",
                PriceHistory = new ObservableCollection<Tuple<int, double>>(from c in Enumerable.Range(0, 20) select new Tuple<int, double>(c, (rand.Next(0, 2 * Deviation) - Deviation) / 100.0))
            });

            return data;

        }

        public double UpdateProgress
        {
            get { return updateProgress; }
            set
            {
                updateProgress = value;
                this.OnPropertyChanged();
            }
        }

        public IList<Stock> Data { get; set; }

        private Random rand = new Random();

        private DateTime lastTick;

        void timer_Tick(object sender, object e)
        {
            if (this.UpdateProgress > 99)
            {
                timer.Stop();
                this.UpdateData();
                timer.Start();

                this.UpdateProgress = 0;
            }
            else
            {
                this.UpdateProgress += (DateTime.Now - lastTick).TotalMilliseconds / this.timer.Interval.TotalMilliseconds;
            }
            lastTick = DateTime.Now;
        }

        private void UpdateData()
        {
            foreach (var item in this.Data)
            {
                item.ChangePercent = (rand.Next(0, 200 * Deviation) - 100 * Deviation) / 10000.0;
                item.Change = item.Price * item.ChangePercent;
                item.Price += item.Change;

                item.PriceHistory.Add(new Tuple<int, double>(item.PriceHistory.Last().Item1 + 1, item.ChangePercent));
                item.PriceHistory.RemoveAt(0);
            }
        }
    }
}
