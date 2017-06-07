using System;

namespace Calendar.SpecialDates
{
    public class EventData
    {
        public string Time
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string Person
        {
            get;
            set;
        }

        public string EventDate
        {
            get
            {
                return this.Date.Day + ", " + this.Date.DayOfWeek;
            }
        }

        public DateTime Date
        {
            get;
            set;
        }
    }
}
