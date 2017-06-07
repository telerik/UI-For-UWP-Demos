using System;
using Windows.UI.Xaml.Data;

namespace AutoCompleteBox.Configurator
{
    public class StringToTimeSpan : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            TimeSpan seconds;
            bool result = TimeSpan.TryParse(value.ToString(), out seconds);

            if (result)
            {
                return seconds;
            }
            else
            {
                return TimeSpan.Zero;
            }
        }
    }
}
