using System;
using Telerik.UI.Xaml.Controls.Grid;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Grid.Customization
{
    public class GroupToTerritorySalesTemplateConverter : IValueConverter
    {
        public DataTemplate UpTemplate
        {
            get;
            set;
        }

        public DataTemplate DownTemplate
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
                return this.UpTemplate;
            }

            return this.DownTemplate;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
