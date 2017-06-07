using System;
using Telerik.UI.Xaml.Controls.Grid;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Grid.Customization
{
    public class GoupHeaderTemplateSelector : DataTemplateSelector
    {
        public DataTemplate RegionTemplate
        {
            get;
            set;
        }

        public DataTemplate CountryTemplate
        {
            get;
            set;
        }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            GroupHeaderContext context = item as GroupHeaderContext;
            if (context.Level == 1)
            {
                return this.RegionTemplate;
            }

            return this.CountryTemplate;
        }
    }
}
