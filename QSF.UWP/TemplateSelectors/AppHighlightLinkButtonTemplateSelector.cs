using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace QSF.TemplateSelectors
{
    public class AppHighlightLinkButtonTemplateSelector : DataTemplateSelector
    {
        public DataTemplate GetFromStoreDataTemplate { get; set; }

        public DataTemplate LearnMoreDataTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item != null && item.ToString().Contains("Data Storage"))
            {
                return this.LearnMoreDataTemplate;
            }

            return this.GetFromStoreDataTemplate;
        }
    }
}