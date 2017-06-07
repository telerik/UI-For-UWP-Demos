using System;
using Windows.UI.Xaml.Data;

namespace QSF.Common
{
    public class StringToUpperConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            if (value == null)
            {
                return string.Empty;
            }
            return value.ToString().ToUpper();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            throw new NotImplementedException();
        }
    }
}