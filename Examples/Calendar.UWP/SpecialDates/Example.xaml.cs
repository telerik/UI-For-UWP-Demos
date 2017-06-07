using System;
using Telerik.UI.Xaml.Controls.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Calendar.SpecialDates
{
	public sealed partial class Example : UserControl
	{
		public Example()
		{
			this.InitializeComponent();

			var viewModel = (this.DataContext as ExampleViewModel);
			this.Calendar.SelectedDateRanges.Add(new CalendarDateRange(viewModel.SelectedDate, viewModel.SelectedDate));
		}

		private void OnTodayButtonClicked(object sender, RoutedEventArgs e)
		{
			this.Calendar.MoveToDate(DateTime.Today);

			if (this.Calendar.DisplayMode != CalendarDisplayMode.MonthView)
			{
				this.Calendar.DisplayMode = CalendarDisplayMode.MonthView;
			}
		}
	}
}
