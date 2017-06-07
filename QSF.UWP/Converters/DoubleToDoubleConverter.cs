using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace QSF.Converters
{
    public class DoubleToDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return null;
            }
            
            if ((string)parameter == "infoOpacity")
            {
                Thickness input = (Thickness)value;
                return 1.4 - (input.Left / 385);
            }

            if ((string)parameter == "HomeSnappedStateParalax")
            {
                return -(double)value * 0.1;
            }

            if ((string)parameter == "AppHighlightsFlipView")
            {
                return (double)value * 0.6;
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}