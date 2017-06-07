using System;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Chart.Annotations
{
    public sealed partial class Example : UserControl
    {
        public Example()
        {
            this.InitializeComponent();
        }

        private void OnClosestDataPointChanged(object sender, DataPointEventArgs e)
        {
            if (e.DataPoint != null)
            {
                this.date.Text = ((DateTime)(e.DataPoint.Category)).ToString("MMM dd, yyyy");
                this.price.Text = e.DataPoint.Value.ToString("0,0.00");
            }
        }
    }
}
