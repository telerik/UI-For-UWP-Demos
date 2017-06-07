using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Telerik.UI.Xaml.Controls.Input;
using Windows.UI.Xaml;

namespace Calendar.SpecialDates
{
    public class ExampleViewModel : INotifyPropertyChanged
    {
        private Random random = new Random();
        private DateTime selectedDate;
        private DateTime displayDate;
        private Dictionary<DateTime, List<EventData>> events;
        private List<EventData> eventsResult;
        private List<DateTime> randomSpecialDates;
        private Visibility noEventsMessageVisibility = Visibility.Collapsed;
        private EventData selectedEvent;

        public ExampleViewModel()
        {
            this.randomSpecialDates = new List<DateTime>();
            this.events = new Dictionary<DateTime, List<EventData>>();
            this.GenerateEvents();
            this.SelectedDate = this.Events.FirstOrDefault().Key;
            this.DisplayDate = DateTime.Today;
        }

        public EventData SelectedEvent
        {
            get
            {
                return this.selectedEvent;
            }
            set
            {
                this.selectedEvent = value;

                if (this.selectedEvent != null)
                {
                    this.DisplayDate = this.selectedEvent.Date;
                }

                this.OnPropertyChanged("SelectedEvent");
            }

        }

        public Visibility NoEventsMessageVisibility
        {
            get
            {
                return this.noEventsMessageVisibility;
            }

            set
            {
                this.noEventsMessageVisibility = value;
                this.OnPropertyChanged("NoEventsMessageVisibility");
            }

        }
        public List<EventData> EventsResult
        {
            get
            {
                return this.eventsResult;
            }

            set
            {
                this.eventsResult = value;
                this.OnPropertyChanged("EventsResult");
            }

        }

        public Dictionary<DateTime, List<EventData>> Events
        {
            get
            {
                return this.events;
            }

            set
            {
                if (this.events != value)
                {
                    this.events = value;

                    this.OnPropertyChanged("Events");
                }
            }
        }

        public DateTime DisplayDate
        {
            get
            {
                return this.displayDate;
            }

            set
            {
                if (this.displayDate != value)
                {
                    this.displayDate = value;

                    this.OnPropertyChanged("DisplayDate");
                }
            }
        }

        public DateTime SelectedDate
        {
            get
            {
                return this.selectedDate;
            }

            set
            {
                if (this.selectedDate != value)
                {
                    this.selectedDate = value;
                    this.GetEvents(this.selectedDate);

                    this.OnPropertyChanged("SelectedDate");
                }
            }
        }

        private void GetEvents(DateTime dateTime)
        {
            List<EventData> eventsResult = new List<EventData>();

            if (this.Events.TryGetValue(dateTime, out eventsResult))
            {
                this.NoEventsMessageVisibility = Visibility.Collapsed;
                this.EventsResult = eventsResult;

            }
            else
            {
                this.EventsResult = null;
                this.NoEventsMessageVisibility = Visibility.Visible;
            }
        }

        private void GenerateEvents()
        {
            GenerateMonthEvents(DateTime.Today);
            GenerateMonthEvents(DateTime.Today.AddMonths(1));
            GenerateMonthEvents(DateTime.Today.AddMonths(-1));
            GenerateMonthEvents(DateTime.Today.AddMonths(2));
            GenerateMonthEvents(DateTime.Today.AddMonths(-2));
        }

        private void GenerateMonthEvents(DateTime eventDate)
        {
            int specialDatesCount = 5;

            DateTime firstDate = new DateTime(eventDate.Year, eventDate.Month, 1);
            DateTime lastDate = (firstDate.AddMonths(1).AddDays(-1));

            firstDate = firstDate.AddDays(3);
            lastDate = lastDate.AddDays(3);

            while (specialDatesCount != -1)
            {
                DateTime randomDate = this.RandomDay(firstDate, lastDate);

                if (this.randomSpecialDates.Contains(randomDate))
                {
                    continue;
                }

                this.randomSpecialDates.Add(randomDate);
                this.events.Add(randomDate, this.CreateEvents(randomDate));
                specialDatesCount--;
            }
        }

        private List<EventData> CreateEvents(DateTime randomDate)
        {
            List<EventData> newEvents = new List<EventData>();

            for (int i = 0; i < this.random.Next(1, 5); i++)
            {
                EventData newEvent = new EventData()
                {
                    Date = randomDate,
                    Person = Data.EventsList[i].Person,
                    Time = Data.EventsList[i].Time,
                    Title = Data.EventsList[i].Title
                };

                newEvents.Add(newEvent);
            }

            return newEvents;
        }

        private DateTime RandomDay(DateTime startDate, DateTime endDate)
        {
            int range = (endDate - startDate).Days;
            return startDate.AddDays(this.random.Next(range));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
