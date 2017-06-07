using DataForm.Data;
using DataForm.FirstLook;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace DataForm.FirstLook
{
    public class TableNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var isTable = value is TableNumber;
            if (isTable)
            {
                return string.Format("# {0}",(int)value + 1);
            }

            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
