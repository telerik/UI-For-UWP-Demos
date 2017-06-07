using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Grid.Customization
{
    public class UpDownTemplateSelector : DataTemplateSelector
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

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var person = item as SalesPerson;

            if (person.SalesLastYear < person.SalesYTD)
            {
                return this.UpTemplate;
            }

            return this.DownTemplate;
        }
    }
}
