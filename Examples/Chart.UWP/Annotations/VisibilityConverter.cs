using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Chart.Annotations
{
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int index = System.Convert.ToInt32(parameter);
            int selectedIndex = System.Convert.ToInt32(value);
            if (selectedIndex == index)
            {
                return Visibility.Visible;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
