using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Telerik.UI.Xaml.Controls.Chart;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Chart.EmptyValues
{
    public sealed partial class Example : UserControl
    {
        private static SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(0xFF, 0x02, 0x8C, 0xFD));

        public Example()
        {
            this.InitializeComponent();
            CreateSeries("Line");
        }

        private string seriesType;
        private void OnComboBoxSeriesChanged(object sender, SelectionChangedEventArgs e)
        {
            this.seriesType = Convert.ToString((e.AddedItems[0] as ComboBoxItem).Content);
            CreateSeries(seriesType);
        }

        private void CreateSeries(string seriesType)
        {
            RadCartesianChart chart = this.chart as RadCartesianChart;
            CategoricalSeries series = null;

            if (chart == null)
            {
                return;
            }
            chart.Series.Clear();

            switch (seriesType)
            {
                case "Bar":
                    series = new BarSeries()
                    {
                        DefaultVisualStyle = chart.Resources["BorderStyle"] as Style
                    };
                    break;
                case "Line":
                    series = new LineSeries()
                    {
                        Stroke = brush,
                        StrokeThickness = 3,
                        PointTemplate = chart.Resources["PointTemplate"] as DataTemplate
                    };
                    break;
                case "Spline":
                    series = new SplineSeries()
                    {
                        Stroke = brush,
                        StrokeThickness = 3,
                        PointTemplate = chart.Resources["PointTemplate"] as DataTemplate
                    };
                    break;
                case "Area":
                    series = new AreaSeries()
                    {
                        Fill = brush,
                        PointTemplate = chart.Resources["PointTemplate"] as DataTemplate
                    };
                    break;
                case "SplineArea":
                    series = new SplineAreaSeries()
                    {
                        Fill = brush,
                        PointTemplate = chart.Resources["PointTemplate"] as DataTemplate
                    };
                    break;
            }
            series.CategoryBinding = new PropertyNameDataPointBinding("Season");
            series.ValueBinding = new PropertyNameDataPointBinding("Points");
            series.SetBinding(CategoricalSeries.ItemsSourceProperty, new Binding() { Path = new PropertyPath("SelectedTeam.Stats") });
            series.SetBinding(CategoricalSeries.ShowLabelsProperty, new Binding() { Path = new PropertyPath("ShowLabels") });
            series.ClipToPlotArea = false;

            chart.Series.Add(series);
        }

        private void OnLeftButtonPressed(object sender, RoutedEventArgs e)
        {
            if (this.listBox.SelectedIndex - 1 >= 0)
            {
                this.PART_RightArrow.IsEnabled = true;
                this.listBox.SelectedIndex = this.listBox.SelectedIndex - 1;
                this.listBox.ScrollIntoView(this.listBox.SelectedItem);
            }
        }

        private void OnRightButtonPressed(object sender, RoutedEventArgs e)
        {
            if (this.listBox.SelectedIndex + 1 < this.listBox.Items.Count())
            {              
                this.listBox.SelectedIndex = this.listBox.SelectedIndex + 1;
                this.listBox.ScrollIntoView(this.listBox.SelectedItem);
            }
        }
        private void ModifyArrowButtons()
        {         
                this.PART_RightArrow.IsEnabled = true;
                this.PART_LeftArrow.IsEnabled = true;
            
            if (this.listBox.SelectedIndex == 0)
            {
                this.PART_LeftArrow.IsEnabled = false;
                this.PART_LeftArrow.BorderThickness = new Thickness(0);
            }
            if (this.listBox.SelectedIndex == this.listBox.Items.Count() - 1)
            {
                this.PART_RightArrow.IsEnabled = false;
                this.PART_RightArrow.BorderThickness = new Thickness(0);
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ModifyArrowButtons();
        }
    }
}
