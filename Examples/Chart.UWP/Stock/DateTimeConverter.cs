using System;
using Windows.UI.Xaml.Data;

namespace Chart.Stock
{
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string format = parameter as string;
            if (string.IsNullOrEmpty(format))
            {
                return value;
            }

            DateTime dateTime = (DateTime)value;
            return dateTime.ToString(format);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
