using QSF.Common.Examples;
using System;

namespace Chart.Stock
{
    public class OhlcModel : ViewModelBase
    {
        private double open;
        private double high;
        private double low;
        private double close;
        private double volume;
        private double adjacentClose;
        private DateTime date;
        private static int counter;

        public OhlcModel()
        {
        }

        public OhlcModel(double offset, params double[] values)
        {
            this.open = values[0] + ((counter % 2) == 0 ? offset : -offset);
            this.high = values[1] + 2 * offset;
            this.low = values[2] - 1;
            this.close = values[3] - ((counter % 2) == 0 ? offset : -offset);
            this.volume = values[4];
            this.adjacentClose = values[5] + 2 * offset;

            counter++;
        }

        public OhlcModel(OhlcModel source, double offset)
        {
            this.date = source.date;
            this.open = source.open + offset;
            this.high = source.high + offset;
            this.low = source.low + offset;
            this.close = source.close + offset;
            this.volume = source.volume + offset;
            this.adjacentClose = source.adjacentClose + offset;
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                if (this.date == value)
                {
                    return;
                }

                this.date = value;
                this.OnPropertyChanged("Date");
            }
        }

        public double Open
        {
            get
            {
                return this.open;
            }
            set
            {
                if (this.open == value)
                {
                    return;
                }

                this.open = value;
                this.OnPropertyChanged("Open");
            }
        }

        public double High
        {
            get
            {
                return this.high;
            }
            set
            {
                if (this.high == value)
                {
                    return;
                }

                this.high = value;
                this.OnPropertyChanged("High");
            }
        }

        public double Low
        {
            get
            {
                return this.low;
            }
            set
            {
                if (this.low == value)
                {
                    return;
                }

                this.low = value;
                this.OnPropertyChanged("Low");
            }
        }

        public double Close
        {
            get
            {
                return this.close;
            }
            set
            {
                if (this.close == value)
                {
                    return;
                }

                this.close = value;
                this.OnPropertyChanged("Close");
            }
        }

        public double Volume
        {
            get
            {
                return this.volume;
            }
            set
            {
                if (this.volume == value)
                {
                    return;
                }

                this.volume = value;
                this.OnPropertyChanged("Volume");
            }
        }

        public double AdjacentClose
        {
            get
            {
                return this.adjacentClose;
            }
            set
            {
                if (this.adjacentClose == value)
                {
                    return;
                }

                this.adjacentClose = value;
                this.OnPropertyChanged("AdjacentClose");
            }
        }
    }
}
