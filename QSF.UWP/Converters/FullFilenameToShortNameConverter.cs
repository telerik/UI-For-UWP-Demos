using System;
using System.Linq;
using Windows.UI.Xaml.Data;

namespace QSF.Converters
{
    public class FullFilenameToShortNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var filename = value as string;
            if (!string.IsNullOrEmpty(filename))
            {
                foreach (var extension in Constants.AllowedFileExtensions)
                {
                    if (filename.EndsWith(extension))
                    {
                        var extensionIndex = filename.LastIndexOf(extension);
                        string noExtension = filename.Substring(0, extensionIndex);
                        int lastPoint = noExtension.LastIndexOf('.');
                        string result = string.Format("{0}{1}", noExtension.Substring(lastPoint + 1), extension.ToUpper());
                        return result;
                    }
                }
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}