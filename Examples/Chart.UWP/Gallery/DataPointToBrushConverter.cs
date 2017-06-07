using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Charting;
using Telerik.UI.Xaml.Controls;
using Telerik.UI.Xaml.Controls.Chart;
using Windows.UI.Xaml.Data;

namespace Chart.Gallery
{
    public class DataPointToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DataPoint point = value as DataPoint;
            if (point == null)
            {
                return value;
            }

            var series = point.Presenter as ChartSeries;
            if (point.Parent == null)
            {
                return value;
            }

            return series.Chart.Palette.GetBrush(point.Parent.CollectionIndex, PaletteVisualPart.Fill);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
