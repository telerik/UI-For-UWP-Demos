using DataForm.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace DataForm
{
    public class InformationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (parameter.ToString().Equals("table"))
            {
                return String.Format("Table #{0}", (int)value + 1);
            }
            if (parameter.ToString().Equals("guest"))
            {
                 return String.Format(" for {0}", (double)value);
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
