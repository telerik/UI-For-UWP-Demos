using QSF.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace QSF.TemplateSelectors
{
    public class HighlightedItemsTemplateSelector: DataTemplateSelector
    {
        public DataTemplate HighlightedExampleDataTemplate { get; set; }
        public DataTemplate HighlightedControlDataTemplate { get; set; }
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var customGridViewItemInfo = item as CustomGridViewItemInfo;
            if (customGridViewItemInfo != null && customGridViewItemInfo.ExampleHighlightInfo != null)
            {
                return this.HighlightedExampleDataTemplate;
            }

            return this.HighlightedControlDataTemplate;
        }
    }
}
