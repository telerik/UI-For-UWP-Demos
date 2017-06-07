using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DataForm.Data
{
        public static class ViewModel
        {
            static ViewModel()
            {
                var date = DateTime.Now;
                Reservations = new ObservableCollection<Reservation>();
                Reservations.Add(new Reservation() { Name = "Chris Heilmann", Date = new DateTime(date.Year, date.Month, date.Day, 18, 30, 0), GuestNumber = 3, PhoneNumber = "359-55-1236", Section = Section.Patio, TableNumber = TableNumber.Fifth, Origin = Origin.Online });
                Reservations.Add(new Reservation() { Name = "Aaron White", Date = new DateTime(date.Year, date.Month, date.Day, 19,30,0), GuestNumber = 3, PhoneNumber = "359-55-1237", Section = Section.FirstFloor, TableNumber = TableNumber.Second, Origin = Origin.Online });
                Reservations.Add(new Reservation() { Name = "Rachel Nabors", Date = new DateTime(date.Year, date.Month, date.Day,20,0,0), GuestNumber = 3, PhoneNumber = "359-55-1238", Section = Section.Patio, TableNumber = TableNumber.Fifth, Origin = Origin.Phone });
                Reservations.Add(new Reservation() { Name = "Thomas Drake", Date = new DateTime(date.Year, date.Month, date.Day,15,45,0), GuestNumber = 2, PhoneNumber = "359-55-1239", Section = Section.SecondFloor, TableNumber = TableNumber.Third, Origin = Origin.Online });
            }

            public static ObservableCollection<Reservation> Reservations { get; set; }
        }
}
