using System;
using Telerik.UI.Xaml.Controls.Grid;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Grid.Customization
{
    public class TerritorySalesToForegroundConverter : IValueConverter
    {
        public Brush UpForeground
        {
            get;
            set;
        }

        public Brush DownForeground
        {
            get;
            set;
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            GroupHeaderContext context = value as GroupHeaderContext;
            if (context == null)
            {
                return value;
            }

            var person = context.Group.ChildItems[0] as SalesPerson;
            if (person.TerritorySalesYTD > person.TerritorySalesLastYear)
            {
                return this.UpForeground;
            }

            return this.DownForeground;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
