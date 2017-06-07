using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Chart.Gallery.Point
{
    public class AxisLabelConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime date = (DateTime)value;
            if (date.Month == 1)
                return String.Format("{0:MMM}" + Environment.NewLine + "{0:yyyy}", date);
            else
                return String.Format("{0:MMM}", date);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
