using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace Chart.Interactivity
{
    public sealed partial class Example : UserControl
    {
        private ExampleViewModel ViewModel;

        public Example()
        {
            this.InitializeComponent();
            this.ViewModel = new ExampleViewModel();

            this.DataContext = this.ViewModel;
        }

        private void ChartTrackBallBehavior_TrackInfoUpdated(object sender, Telerik.UI.Xaml.Controls.Chart.TrackBallInfoEventArgs e)
        {
            this.ViewModel.TrackBallContext = e.Context;
        }
    }
}
