using QSF.Common.Examples;
using System;
using Telerik.Data.Core;

namespace DataForm.Data
{
    public class Reservation : ViewModelBase
    {
        [Ignore]
        public bool IsNewItem { get; set; }

        private string name;
        [Display(Group = "RESERVATION INFORMATION", Position=1)]
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                OnPropertyChanged("Name");
            }
        }

        private DateTime date;
        [Display(Group="RESERVATION INFORMATION", Position=2)]
        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
                OnPropertyChanged("Date");
            }
        }

        private double guestNumber;
		[Display(Group = "RESERVATION INFORMATION", Position=4)]
        public double GuestNumber
        {
            get
            {
                return this.guestNumber;
            }
            set
            {
                this.guestNumber = value;
                OnPropertyChanged("GuestNumber");
            }
        }

        private string phoneNumber;
        [Display(Group="RESERVATION INFORMATION", Position=5)]
        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                this.phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        private TableNumber tableNumber;
		[Display(Group = "TABLE DETAILS", Position = 6, Header = "Table")]
        public TableNumber TableNumber
        {
            get
            {
                return this.tableNumber;
            }
            set
            {
                this.tableNumber = value;
                OnPropertyChanged("TableNumber");
            }
        }

        private Section section;
        [Display(Group ="TABLE DETAILS", Position=7, Header="Section")]
        public Section Section
        {
            get
            {
                return this.section;
            }
            set
            {
                this.section = value;
                OnPropertyChanged("Section");
            }
        }

        private Origin origin;
        [Display(Position=8, Header = "Origin")]
        public Origin Origin
        {
            get
            {
                return origin;
            }
            set
            {
                this.origin = value;
                OnPropertyChanged("Origin");
            }
        }
    }
}
