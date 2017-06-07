using System;
using System.Linq;
using Windows.UI.Xaml.Data;

namespace QSF.Converters
{
    public class DoubleToRectConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (true)
            {
                return new Windows.Foundation.Rect(0,0,(double)value,768);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}