using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace Map.FirstLook
{
    public class MapAttributeFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((double)value).ToString("N2", CultureInfo.InvariantCulture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
