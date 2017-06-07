using Telerik.Charting;
using Telerik.UI.Xaml.Controls.Chart;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Chart.Annotations
{
    public sealed partial class AppleChart : UserControl
    {
        public AppleChart()
        {
            this.InitializeComponent();
        }

        public event ClosestDataPointChangedEventHandler ClosestDataPointChanged;

        private void OnClosestDataPointChanged(CategoricalDataPoint dataPoint)
        {
            if (this.ClosestDataPointChanged != null)
            {
                this.ClosestDataPointChanged(this, new DataPointEventArgs(dataPoint));
            }
        }

        private void ChartTrackBallBehavior_TrackInfoUpdated(object sender, TrackBallInfoEventArgs e)
        {
            CategoricalDataPoint closestDataPoint = e.Context.ClosestDataPoint.DataPoint as CategoricalDataPoint;
            this.OnClosestDataPointChanged(closestDataPoint);
        }
    }
}
