using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chart.FirstLook
{
    public class RevenueData : INotifyPropertyChanged
    {
        private RevenueDataType dataType;

        public RevenueDataType DataType
        {
            get { return dataType; }
            set
            {
                dataType = value;
                this.OnPropertyChanged("DataType");
            }
        }

        private double amount;

        public double Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                this.OnPropertyChanged("Amount");
            }
        }


        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                this.OnPropertyChanged("Date");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public enum RevenueDataType
    {
        Actual,
        ActualVSTarget,
        ActualVSLastYear
    }
}
