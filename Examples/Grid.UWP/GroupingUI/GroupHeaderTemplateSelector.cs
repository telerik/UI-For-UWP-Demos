using System;
using Telerik.Data.Core;
using Telerik.UI.Xaml.Controls.Grid;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Grid.GroupingUI
{
    public class GoupHeaderTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Template
        {
            get;
            set;
        }

        public DataTemplate SalesOrderTemplate
        {
            get;
            set;
        }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            GroupHeaderContext context = item as GroupHeaderContext;
            var propertyDescriptor = context.Descriptor as PropertyGroupDescriptor;

            if (propertyDescriptor.PropertyName == "OrderId")
            {
                return this.SalesOrderTemplate;
            }

            return this.Template;
        }
    }
}
