using System;
using System.Linq;
using QSF.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace QSF.TemplateSelectors
{
    public class ExampleItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ExampleDataTemplate { get; set; }
        public DataTemplate HighlightedExampleDataTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var customGridViewItemInfo = item as CustomGridViewItemInfo;

            if(customGridViewItemInfo != null && customGridViewItemInfo.ExampleHighlightInfo != null)
            {
                return this.HighlightedExampleDataTemplate;
            }

            return this.ExampleDataTemplate;
        }
    }
}
