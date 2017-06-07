using System;
using Telerik.UI.Xaml.Controls.Grid;
using Windows.UI.Xaml.Data;

namespace Grid.Customization
{
    public class GroupToTerritorySalesConverter : IValueConverter
    {
        public string FormatString
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
            return string.Format(this.FormatString, person.TerritorySalesYTD);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
