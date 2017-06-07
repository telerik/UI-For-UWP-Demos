using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Charting;
using Telerik.UI.Xaml.Controls;
using Telerik.UI.Xaml.Controls.Chart;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Chart.Gallery
{
    public class PieLabelStrategy : ChartSeriesLabelStrategy
    {
        private string format = "{0}\n{1:P2}";

        public PropertyNameDataPointBinding Binding { get; set; }

        public override LabelStrategyOptions Options
        {
            get { return LabelStrategyOptions.Content | LabelStrategyOptions.DefaultVisual; }
        }

        public PieLabelStrategy()
        {
        }

        public override FrameworkElement CreateDefaultVisual(DataPoint point, int labelIndex)
        {
            ChartSeries series = point.Presenter as ChartSeries;
            return new TextBlock() { Foreground = series.Chart.Palette.GetBrush(point.CollectionIndex, PaletteVisualPart.Fill) };
            // return base.CreateDefaultVisual(point, labelIndex);
        }

        public override object GetLabelContent(DataPoint point, int labelIndex)
        {
            if (point == null || labelIndex < 0)
            {
                return base.GetLabelContent(point, labelIndex);
            }

            return string.Format(this.format, Binding.GetValue(point.DataItem), ((PieDataPoint)point).Percent/100);
        }
    }
}
