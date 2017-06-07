using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Chart.FirstLook
{
    public class ForegroundConverter : IValueConverter
    {
        private SolidColorBrush positiveBrush = new SolidColorBrush(Colors.Green);
        private SolidColorBrush negativeBrush = new SolidColorBrush(Colors.Red);

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((double)value) > 0 ? positiveBrush : negativeBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
