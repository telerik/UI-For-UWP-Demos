using System;
using Telerik.UI.Xaml.Controls.Grid;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Grid.Customization
{
    public class RegionStyleSelector : StyleSelector
    {
        public Style RegionStyle
        {
            get;
            set;
        }

        protected override Style SelectStyleCore(object item, DependencyObject container)
        {
            var context = item as GroupHeaderContext;
            if (context.Level == 1)
            {
                return this.RegionStyle;
            }

            return null;
        }
    }
}
