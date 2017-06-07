using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.UI.Xaml.Controls.Map;
using Windows.UI.Xaml.Data;

namespace Map.Colorization
{
    public class ColorRangeTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var range = value as ColorRange;
            if (range.Max == 5)
            {
                return "<5";
            }
            if (range.Max == 10)
            {
                return "5-10";
            }
            if (range.Max == 25)
            {
                return "10-25";
            }
            if (range.Max == 50)
            {
                return "25-50";
            }

            return "50+";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
