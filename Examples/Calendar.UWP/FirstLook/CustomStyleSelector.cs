using Telerik.UI.Xaml.Controls.Input;
using Telerik.UI.Xaml.Controls.Input.Calendar;

namespace Calendar.FirstLook
{
    public class CustomStyleSelector : CalendarCellStyleSelector
    {
        protected override void SelectStyleCore(CalendarCellStyleContext context, RadCalendar container)
        {
            ExampleViewModel viewModel = container.DataContext as ExampleViewModel;
            CalendarDateRange selectedRange = viewModel.SelectedRange;

            if ((context.Date < selectedRange.StartDate || context.Date > selectedRange.EndDate) || container.DisplayMode != CalendarDisplayMode.MonthView)
            {
                return;
            }

            context.CellStyle = container.SelectedCellStyle;
        }
    }
}
