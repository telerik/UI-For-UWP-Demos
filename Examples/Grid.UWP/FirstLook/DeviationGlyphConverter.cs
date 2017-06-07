using System;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Grid.FirstLook
{
    public class DeviationGlyphToBrushConverter : IValueConverter
    {
        public const string UpGlyph = "\u25B2";
        public const string DownGlyph = "\u25BC";

        public Brush UpBrush
        {
            get;
            set;
        }

        public Brush DownBrush
        {
            get;
            set;
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string text = value as string;

            return text == UpGlyph ? this.UpBrush : this.DownBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
