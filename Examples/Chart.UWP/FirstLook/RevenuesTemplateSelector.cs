using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Chart.FirstLook
{
    public class RevenuesTemplateSelector : DataTemplateSelector
    {
        protected override Windows.UI.Xaml.DataTemplate SelectTemplateCore(object item, Windows.UI.Xaml.DependencyObject container)
        {
            var revenueData = item as RevenueData;
            switch (revenueData.DataType)
            {
                case RevenueDataType.Actual:
                    return this.ActualTemplate;
                case RevenueDataType.ActualVSTarget:
                    return this.ActualVSTargetTemplate;
                case RevenueDataType.ActualVSLastYear:
                    return this.ActualVSLastYearTemplate;
                default:
                    break;
            }

            return base.SelectTemplateCore(item, container);
        }


        public DataTemplate ActualTemplate { get; set; }

        public DataTemplate ActualVSTargetTemplate { get; set; }

        public DataTemplate ActualVSLastYearTemplate { get; set; }

    }
}
