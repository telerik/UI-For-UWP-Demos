using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace DataForm
{
    public class DateTimeConverter : IValueConverter
    {
        public DateTimeConverter()
        {
            this.Date = new DateTime();
        }

        public DateTime Date
        {
            get;
            set;
        }
        
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return this.ConvertValue(value, parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return this.ConvertValue(value, parameter);
        }

        private DateTime ConvertValue(object value, object parameter)
        {
            var dateTime = (DateTime)value;
            if (parameter.ToString().Equals("date"))
            {
                var date = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, this.Date.Hour, this.Date.Minute, this.Date.Second);
                this.Date = date;
                return date;
            }
            var time = new DateTime(this.Date.Year, this.Date.Month, this.Date.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
            this.Date = time;
            return time;
        }
    }
}
