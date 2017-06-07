using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Map.Colorization
{
    public class PopulationToSymbolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            double doubleValue = (double)value;
            if (doubleValue < 0)
            {
                doubleValue = 0;
            }

            //int index = (int)(doubleValue / 5000000) + 1;

            //string symbol = string.Empty;
            //for (int i = 0; i < index; i++)
            //{
            //    symbol += "\uE13D";
            //    if (i < index - 1)
            //    {
            //        symbol += " ";
            //    }
            //}

            //return symbol;

            return "\uE13D";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
