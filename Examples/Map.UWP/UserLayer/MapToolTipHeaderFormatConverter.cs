using System;
using Windows.UI.Xaml.Data;

namespace Map.UserLayer
{
    public class MapToolTipHeaderFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string header = (string)value;

            // Internet usage data is for Australia & Oceania combined so we need to display the proper toolTip header.
            if (header == "Australia" || header == "Oceania")
            {
                return "Australia & Oceania";
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
