using System.Collections.Generic;

namespace Calendar.SpecialDates
{
    public static class Data
    {
        public static List<EventData> EventsList = new List<EventData>()
        {
            { new EventData() { Person = "with Janet Leverling",  Title = "Javascript Training Course", Time = "10:00 - 12:00, Room 3"}},
            { new EventData() { Person="with Andrew Fuller", Title = "Lunch Time :-)", Time = "13:00 - 13:30, Room 5"}},
            { new EventData() {  Title = "Web Development Course", Time = "14:00 - 18:00"}},
            { new EventData() {  Title = "Party Time :-)", Time = "22:00"}}
        };
    }
}
