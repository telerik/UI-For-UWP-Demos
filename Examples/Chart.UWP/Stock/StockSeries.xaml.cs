using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Telerik.UI.Xaml.Controls.Chart;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Chart.Stock
{
    public sealed partial class StockSeries : UserControl
    {
        public StockSeries()
        {
            this.InitializeComponent();

            this.DataContext = new StockViewModel();

            var series = new CandlestickSeries();
            UpdateSeries(series);
            this.Chart.Series.Add(series);

            this.Indicators.SelectedIndex = 0;
            this.Indicators2.SelectedIndex = 0;
        }

        private void CandleSticksRadioButton_Click(object sender, RoutedEventArgs e)
        {
            this.Chart.Series.Clear();

            var series = new CandlestickSeries();
            UpdateSeries(series);

            this.Chart.Series.Insert(0, series);
        }

        private void UpdateSeries(OhlcSeriesBase series)
        {
            series.HighBinding = new PropertyNameDataPointBinding("High");
            series.LowBinding = new PropertyNameDataPointBinding("Low");
            series.OpenBinding = new PropertyNameDataPointBinding("Open");
            series.CloseBinding = new PropertyNameDataPointBinding("Close");
            series.CategoryBinding = new PropertyNameDataPointBinding("Date");
            series.SetBinding(CandlestickSeries.ItemsSourceProperty, new Binding { Path = new PropertyPath("Data") });

            series.Transitions = null;
            series.PaletteIndex = 0;

            var template = LayoutRoot.Resources["TrackInfoTemplate"] as DataTemplate;
            ChartTrackBallBehavior.SetTrackInfoTemplate(series, template);

            string styleKey = series is CandlestickSeries ? "CandleStickStyle" : "StickStyle";
            series.DefaultVisualStyle = this.Chart.Resources[styleKey] as Style;
        }

        private void OhlcSticksRadioButton_Click(object sender, RoutedEventArgs e)
        {
            this.Chart.Series.Clear();

            var series = new OhlcSeries();
            UpdateSeries(series);

            this.Chart.Series.Insert(0, series);
        }

        private void Indicators_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Any())
            {

                var indicator = (e.AddedItems[0] as ComboBoxItem).DataContext as IndicatorBase;

                if (indicator != null)
                {
                    // ConfigureAxis(BottomChart, indicator);
                    Chart.Indicators.Clear();
                    Chart.Indicators.Add(indicator);
                    var template = LayoutRoot.Resources["EmptyTemplate"] as DataTemplate;

                    ChartTrackBallBehavior.SetTrackInfoTemplate(indicator, template);
                }
            }
        }

        private void Indicators2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Any())
            {

                var indicator = (e.AddedItems[0] as ComboBoxItem).DataContext as IndicatorBase;

                if (indicator != null)
                {
                    // ConfigureAxis(BottomChart, indicator);
                    BottomChart.Indicators.Clear();
                    BottomChart.Indicators.Add(indicator);
                }
            }
        }
    }
}
