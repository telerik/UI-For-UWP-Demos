using System;
using System.Globalization;
using System.Linq;
using Telerik.UI.Xaml.Controls.Map;
using Windows.UI.Xaml.Data;

namespace Map.UserLayer
{
    public class MapUserToShapeLayerDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var context = value as MapShapeToolTipContext;
            string continentName = context.Shape.GetAttribute("CONTINENT").ToString();

            // Internet usage data is for Australia & Oceania combined and is stored under Australia key.
            if (continentName == "Oceania")
            {
                continentName = "Australia";
            }

            var viewModel = context.Layer.DataContext as ViewModel;
            if (viewModel != null)
            {
                var continentRecord = viewModel.Items.Where(item => item.Continent == continentName).FirstOrDefault();
                if (continentRecord != null)
                {
                    return continentRecord.Usage.ToString("N0", CultureInfo.InvariantCulture);
                }
            }

            return "n/a";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
