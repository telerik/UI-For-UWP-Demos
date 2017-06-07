using System;
using Windows.UI.Xaml.Data;

namespace AutoCompleteBox.Configurator
{
    public class StringToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            int number;
            bool result = Int32.TryParse(value.ToString(), out number);

            if (result)
            {
                return number;
            }
            else
            {
                return 0;
            }
        }
    }
}
