using System;
using Telerik.UI.Xaml.Controls.Input;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Calendar.FirstLook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Example : UserControl
    {
        public Example()
        {
            this.InitializeComponent();
        }

        private void CheckInCalendar_SelectionChanged(object sender, EventArgs e)
        {
            var viewModel = (this.DataContext as ExampleViewModel);

            var currentDate = (sender as RadCalendar).SelectedDateRange.Value.StartDate;
            viewModel.StartDate = currentDate;

            if (currentDate > this.checkOutCalendar.DisplayDate)
            {
                this.checkOutCalendar.DisplayDate = currentDate;
            }

            if (viewModel.EndDate == DateTime.MaxValue)
            {
                return;
            }

            if (currentDate > viewModel.EndDate)
            {
                viewModel.EndDate = currentDate;
                this.checkOutCalendar.SelectedDateRange = new CalendarDateRange(viewModel.EndDate, viewModel.EndDate);
            }

            viewModel.SelectedRange = new CalendarDateRange(viewModel.StartDate, viewModel.EndDate);

            // Invalidate calendar UI so CellStyleSelectors can be evaluated again.
            (sender as RadCalendar).InvalidateUI();
            this.checkOutCalendar.InvalidateUI();
        }

        private void CheckOutCalendar_SelectionChanged(object sender, EventArgs e)
        {
            var viewModel = (this.DataContext as ExampleViewModel);

            var currentDate = (sender as RadCalendar).SelectedDateRange.Value.StartDate;

            if (currentDate < viewModel.StartDate)
            {
                viewModel.StartDate = currentDate;
                this.checkInCalendar.SelectedDateRange = new CalendarDateRange(viewModel.StartDate, viewModel.StartDate);

                if (currentDate < this.checkInCalendar.DisplayDate)
                {
                    this.checkInCalendar.DisplayDate = currentDate;
                }
            }

            viewModel.EndDate = currentDate;
            viewModel.SelectedRange = new CalendarDateRange(viewModel.StartDate, viewModel.EndDate);

            // Invalidate calendar UI so CellStyleSelectors can be evaluated again.
            (sender as RadCalendar).InvalidateUI();
            this.checkInCalendar.InvalidateUI();
        }

        private void OnRadioButtonChecked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            if (button.Name == "checkOutButton")
            {
                this.checkInCalendar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                this.checkOutCalendar.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            else
            {
                this.checkInCalendar.Visibility = Windows.UI.Xaml.Visibility.Visible;
                this.checkOutCalendar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
        }
    }
}
