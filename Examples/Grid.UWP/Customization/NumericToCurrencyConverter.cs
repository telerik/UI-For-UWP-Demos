using System;
using Windows.UI.Xaml.Data;

namespace Grid.Customization
{
    public class NumericToCurrencyConverter : IValueConverter
    {
        public string Format
        {
            get;
            set;
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return string.Format(this.Format, value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
