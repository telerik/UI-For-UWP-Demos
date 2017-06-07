using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Core;
using Windows.UI.Xaml;

namespace Grid.Update
{
    public class Stock : ViewModelBase
    {
        private string symbol;

        public string Symbol
        {
            get
            {
                return symbol;
            }
            set
            {
                this.OnPropertyChanged();
                symbol = value;
            }
        }

        private double price;

        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                this.OnPropertyChanged();
            }
        }

        private double change;

        public double Change
        {
            get { return change; }
            set
            {
                change = value;
                this.OnPropertyChanged();
            }
        }

        private double changePercent;

        public double ChangePercent
        {
            get { return changePercent; }
            set
            {
                changePercent = value;
                this.OnPropertyChanged();
            }
        }

        private string continent;

        public string Continent
        {
            get { return continent; }
            set
            {
                continent = value;
                this.OnPropertyChanged();
            }
        }

        public IList<Tuple<int, double>> PriceHistory { get; set; }


    }
}
