using System;
using System.Globalization;
using Telerik.UI.Xaml.Controls.Map;
using Windows.UI.Xaml.Data;

namespace Map.FirstLook
{
    public class MapAreaToCountryAreaPercentageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var context = value as MapShapeToolTipContext;

            double adminArea = (double)context.Shape.GetAttribute("SQMI_ADMIN");
            double countryArea = (double)context.Shape.GetAttribute("SQMI_CNTRY");

            double ratio = adminArea / countryArea;

            return ratio.ToString("P1", CultureInfo.InvariantCulture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
