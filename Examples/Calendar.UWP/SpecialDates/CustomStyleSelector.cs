using System;
using System.Collections.Generic;
using Telerik.UI.Xaml.Controls.Input;
using Telerik.UI.Xaml.Controls.Input.Calendar;
using Windows.UI.Xaml;

namespace Calendar.SpecialDates
{
    public class CustomStyleSelector : CalendarCellStyleSelector
    {
        private Random random = new Random();

        public DataTemplate NormalAppointmentEvent
        {
            get;
            set;
        }

        public DataTemplate AnotherMonthAppointmentEvent
        {
            get;
            set;
        }

        public DataTemplate SelectedAppointmentEvent
        {
            get;
            set;
        }

        public DataTemplate NormalEvent
        {
            get;
            set;
        }

        public DataTemplate AnotherMonthEvent
        {
            get;
            set;
        }

        public DataTemplate SelectedEvent
        {
            get;
            set;
        }

        private List<EventData> eventsForDate;

        protected override void SelectStyleCore(CalendarCellStyleContext context, RadCalendar container)
        {
            if (container.DisplayMode != CalendarDisplayMode.MonthView)
            {
                return;
            }

            var events = (container.DataContext as ExampleViewModel).Events;
            if (events.TryGetValue(context.Date, out this.eventsForDate))
            {
                bool appointmentEvent = context.Date.Day % 2 == 0;

                if (context.IsFromAnotherView)
                {
                    context.CellTemplate = appointmentEvent ? this.AnotherMonthAppointmentEvent : this.AnotherMonthEvent;
                }
                else if (!context.IsSelected)
                {
                    context.CellTemplate = appointmentEvent ? this.NormalAppointmentEvent : this.NormalEvent;
                }
                else if (context.IsSelected)
                {
                    context.CellTemplate = appointmentEvent ? this.SelectedAppointmentEvent : this.SelectedEvent;
                }
            }
        }
    }
}
