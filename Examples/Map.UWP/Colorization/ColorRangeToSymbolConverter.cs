using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.UI.Drawing;
using Telerik.UI.Xaml.Controls.Map;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;

namespace Map.Colorization
{
    public class ColorRangeToSymbolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var range = value as ColorRange;
            
            var textBlock = new TextBlock();
            textBlock.Foreground = new SolidColorBrush((range.Fill as D2DSolidColorBrush).Color);

            for (int i = 0; i <= range.Index; i++)
            {
                textBlock.Inlines.Add(new Run() { Text = "\uE13D" });
            }

            return textBlock;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
