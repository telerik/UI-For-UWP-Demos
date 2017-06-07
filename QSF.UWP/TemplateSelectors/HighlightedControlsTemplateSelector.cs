using System;
using System.Linq;
using QSF.Model;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace QSF.Selectors
{
    public class HighlightedControlsTemplateSelector : DataTemplateSelector 
    {
        public DataTemplate AllControlsButtonDataTemplate { get; set; }
        public DataTemplate ControlDataTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item is IControlInfo)
            {
                return this.ControlDataTemplate;
            }

            return this.AllControlsButtonDataTemplate;
        }
    }
}
