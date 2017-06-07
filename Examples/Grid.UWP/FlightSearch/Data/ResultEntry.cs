using System;

namespace Grid.FlightSearch
{
    public class ResultEntry
    {
        public DateTime Departure
        {
            get;
            set;
        }

        public DateTime Arrival
        {
            get;
            set;
        }

        public string Carrier
        {
            get;
            set;
        }

        public int FlightId
        {
            get;
            set;
        }

        public bool IsDirect
        {
            get;
            set;
        }

        public TimeSpan Duration
        {
            get;
            set;
        }

        public double DurationHours
        {
            get
            {
                return this.Duration.Hours;
            }
        }

        public double Price
        {
            get;
            set;
        }

        public FlightClass Class
        {
            get;
            set;
        }

        public bool IsReturning
        {
            get;
            set;
        }
    }
}
