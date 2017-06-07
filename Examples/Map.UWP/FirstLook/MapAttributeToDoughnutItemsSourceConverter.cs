using System;
using Telerik.UI.Xaml.Controls.Map;
using Windows.UI.Xaml.Data;

namespace Map.FirstLook
{
    public class MapAttributeToDoughnutItemsSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var context = value as MapShapeToolTipContext;

            double adminArea = (double)context.Shape.GetAttribute("SQMI_ADMIN");
            double countryArea = (double)context.Shape.GetAttribute("SQMI_CNTRY");

            return new double[] { adminArea, countryArea - adminArea };
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
