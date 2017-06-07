using System;
using Telerik.UI.Xaml.Controls.Grid;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Grid.FlightSearch
{
    public class GroupHeaderTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DepartTemplate
        {
            get;
            set;
        }

        public DataTemplate ReturnTemplate
        {
            get;
            set;
        }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var context = item as GroupHeaderContext;
            bool isReturn = (bool)context.Group.Key;

            return isReturn ? this.ReturnTemplate : this.DepartTemplate;
        }
    }
}
