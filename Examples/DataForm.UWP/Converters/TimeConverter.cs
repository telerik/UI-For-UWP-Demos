using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace DataForm
{
    public class TimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var time = (DateTime)value;
            if (parameter.ToString().Equals("daypart"))
            {
                return time.ToString("tt").ToLower();
            }
            else if(parameter.ToString().Equals("numbers"))
            {
                var hour = time.Hour < 13 ? time.Hour : time.Hour - 12; 
                return String.Format("{0}:{1:D2}", hour, time.Minute);
            }
            else if (parameter.ToString().Equals("FilterDate"))
            {
                return String.Format("{0:D2}.{1:D2}", time.Day, time.Month);
            }
            else if (parameter.ToString().Equals("FilterDayName"))
            {
                return time.DayOfWeek;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
