using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace BulletGraph.FirstLook
{
    public class ValueToColorConverter : IValueConverter
    {
        private SolidColorBrush RedBrush = new SolidColorBrush(Colors.Red);
        private SolidColorBrush NormalBrush = new SolidColorBrush(Colors.Black);

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            double treshold = double.Parse((string)parameter);

            double actualValue = 0.0;
            if (value.GetType() == typeof(double))
            {
                actualValue = (double)value;
            }
            else
            {
                actualValue = (int)value;
            }

            return actualValue > treshold ? NormalBrush : RedBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
