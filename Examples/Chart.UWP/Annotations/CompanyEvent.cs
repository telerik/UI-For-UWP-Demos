using System;

namespace Chart.Annotations
{
    public class CompanyEvent
    {
        private string _eventDescription;
        private object _timeOfEvent;
        private object _eventEnd;
        private double _value;

        public CompanyEvent()
        {
        }

        public CompanyEvent(DateTime time, string description)
        {
            this._timeOfEvent = time;
            this._eventDescription = description;
        }

        public CompanyEvent(object eventStart, object eventEnd, string eventDescription)
        {
            this._timeOfEvent = eventStart;
            this._eventEnd = eventEnd;
            this._eventDescription = eventDescription;
        }

        public string EventDescription
        {
            get
            {
                return _eventDescription;
            }
            set
            {
                _eventDescription = value;
            }
        }

        public object EventStart
        {
            get
            {
                return _timeOfEvent;
            }
            set
            {
                _timeOfEvent = value;
            }
        }

        public object EventEnd
        {
            get
            {
                return this._eventEnd;
            }
            set
            {
                this._eventEnd = value;
            }
        }

        public double Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }
    }
}
