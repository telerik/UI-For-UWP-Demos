using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Chart.FirstLook
{
    public class PositiveVisibilityConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var number = (double)value;
            bool invert = parameter!=null && parameter.ToString() == "invert";

            if (number >= 0)
            {
                return invert ? Visibility.Collapsed : Visibility.Visible;
            }

            return invert ? Visibility.Visible : Visibility.Collapsed;

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
