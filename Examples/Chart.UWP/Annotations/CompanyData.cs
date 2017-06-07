using System;

namespace Chart.Annotations
{
    public class CompanyData
    {
        private DateTime _date;
        private double _value;

        public CompanyData(DateTime date, double value)
        {
            this._date = date;
            this._value = value;
        }

        public DateTime Date
        {
            get
            {
                return this._date;
            }
        }

        public double Value
        {
            get
            {
                return this._value;
            }
        }
    }
}
