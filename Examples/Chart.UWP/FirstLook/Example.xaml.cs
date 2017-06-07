using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Telerik.UI.Xaml.Controls.Chart;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Chart.FirstLook
{
    public sealed partial class Example : UserControl
    {
        public Example()
        {
            this.InitializeComponent();
        }

        void RevenuesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var data = e.AddedItems[0] as RevenueData;

                switch (data.DataType)
                {
                    case RevenueDataType.Actual:
                        RevenueView.ContentTemplate = LayoutRoot.Resources["RevenueChart"] as DataTemplate;
                        break;
                    case RevenueDataType.ActualVSTarget:
                        RevenueView.ContentTemplate = LayoutRoot.Resources["ActualVSTargetChart"] as DataTemplate;
                        break;
                    case RevenueDataType.ActualVSLastYear:
                        RevenueView.ContentTemplate = LayoutRoot.Resources["ActualVSLastYearChart"] as DataTemplate;
                        break;
                    default:
                        break;
                }
            }
        }

        private void ChartSelectionBehavior_SelectionChanged(object sender, EventArgs e)
        {
            var selectedPoints = ((ChartSelectionBehavior)sender).SelectedPoints;

            if (selectedPoints.Any())
            {
                var selectedItem = selectedPoints.First().DataItem as MonthRevenue;

                var vm = LayoutRoot.DataContext as MainViewModel;

                vm.UpdateRevenueDataList(selectedItem.Date);
            }
        }

        private void ChartTrackBallBehavior_TrackInfoUpdated(object sender, TrackBallInfoEventArgs e)
        {
            if (e.Context.ClosestDataPoint != null)
            {
                var currentItem = e.Context.ClosestDataPoint.DataPoint.DataItem as MonthRevenue;

                var vm = LayoutRoot.DataContext as MainViewModel;

                vm.UpdateRevenueDataList(currentItem.Date);
            }
        }


    }
}
