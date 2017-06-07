using System;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace Chart.BurndownChart
{
    public sealed partial class Example : UserControl
    {
        public Example()
        {
            this.InitializeComponent();
            this.DataContext = new ExampleViewModel();
        }
    }
}