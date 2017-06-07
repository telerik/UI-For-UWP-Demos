using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Grid.Selection
{
    public class CountryFlagsConverter : IValueConverter
    {
        private static readonly ImageSource UsFlag = new BitmapImage(new Uri("ms-appx:///Grid/Selection/Images/usd.png", UriKind.Absolute));
        private static readonly ImageSource GbFlag = new BitmapImage(new Uri("ms-appx:///Grid/Selection/Images/gbp.png", UriKind.Absolute));
        private static readonly ImageSource AuFlag = new BitmapImage(new Uri("ms-appx:///Grid/Selection/Images/aud.png", UriKind.Absolute));
        private static readonly ImageSource CaFlag = new BitmapImage(new Uri("ms-appx:///Grid/Selection/Images/cad.png", UriKind.Absolute));

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return null;
            }

            switch ((string)value)
            {
                case "US":
                    return UsFlag;
                case "AU":
                    return AuFlag;
                case "CA":
                    return CaFlag;
                case "GB":
                    return GbFlag;
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
