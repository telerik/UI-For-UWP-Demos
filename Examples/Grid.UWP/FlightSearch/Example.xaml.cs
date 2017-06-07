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

namespace Grid.FlightSearch
{
    public sealed partial class Example : UserControl
    {
        public Example()
        {
            this.InitializeComponent();

            this.DataContext = new SearchResult();
        }

        private void OnCustomTimeFilterToggled(object sender, RoutedEventArgs e)
        {
            if (this.radDataGrid == null)
            {
                return;
            }

            var command = this.radDataGrid.Commands[0] as FilterButtonTapCommand;
            command.CustomTimeFilter = (sender as ToggleSwitch).IsOn;
        }

        private void OnCustomDirectFilterToggled(object sender, RoutedEventArgs e)
        {
            if (this.radDataGrid == null)
            {
                return;
            }

            var command = this.radDataGrid.Commands[0] as FilterButtonTapCommand;
            command.CustomDirectFilter = (sender as ToggleSwitch).IsOn;
        }

        private void OnCustomDurationFilterToggled(object sender, RoutedEventArgs e)
        {
            if (this.radDataGrid == null)
            {
                return;
            }

            var command = this.radDataGrid.Commands[0] as FilterButtonTapCommand;
            command.CustomDurationFilter = (sender as ToggleSwitch).IsOn;
        }

        private void OnCustomPriceFilterToggled(object sender, RoutedEventArgs e)
        {
            if (this.radDataGrid == null)
            {
                return;
            }

            var command = this.radDataGrid.Commands[0] as FilterButtonTapCommand;
            command.CustomPriceFilter = (sender as ToggleSwitch).IsOn;
        }
    }
}
