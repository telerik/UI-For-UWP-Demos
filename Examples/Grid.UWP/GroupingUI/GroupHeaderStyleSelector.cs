using System;
using Telerik.Data.Core;
using Telerik.UI.Xaml.Controls.Grid;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Grid.GroupingUI
{
    public class GroupHeaderStyleSelector : StyleSelector
    {
        public Style SalesNumberStyle
        {
            get;
            set;
        }

        protected override Style SelectStyleCore(object item, DependencyObject container)
        {
            var context = item as GroupHeaderContext;
            var descriptor = context.Descriptor as PropertyGroupDescriptor;

            if (descriptor.PropertyName == "OrderId")
            {
                return this.SalesNumberStyle;
            }

            return null;
        }
    }
}
