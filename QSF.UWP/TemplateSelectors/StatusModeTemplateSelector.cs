using System;
using System.Linq;
using QSF.Model;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace QSF.Selectors
{
    public class StatusModeTemplateSelector : DataTemplateSelector
    {
        public DataTemplate NewDataTemplate { get; set; }
        public DataTemplate BetaDataTemplate { get; set; }
        public DataTemplate CtpDataTemplate { get; set; }
        public DataTemplate UpdatedDataTemplate { get; set; }
        public DataTemplate UniversalDataTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item == null)
            {
                return base.SelectTemplateCore(item, container);
            }

            var statusMode = (Enums.StatusMode)item;

            switch(statusMode)
            {
                case Enums.StatusMode.Beta: return this.BetaDataTemplate;
                case Enums.StatusMode.Ctp: return this.CtpDataTemplate;
                case Enums.StatusMode.New: return this.NewDataTemplate;
                case Enums.StatusMode.Updated: return this.UpdatedDataTemplate;
#if !WINDOWS_UWP
                case Enums.StatusMode.Universal: return this.UniversalDataTemplate;
#endif
            }

            // return empty DataTemplate for Normal and Obsolete statuses
            return new DataTemplate();
        }
    }
}
