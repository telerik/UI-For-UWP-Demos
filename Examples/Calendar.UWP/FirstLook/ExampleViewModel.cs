using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Telerik.UI.Xaml.Controls.Input;

namespace Calendar.FirstLook
{
    public class ExampleViewModel : INotifyPropertyChanged
    {
        private CustomStyleSelector datesStyleSelector;

        private List<int> optionsList = new List<int>() { 1, 2, 3 };

        private List<HotelData> hotelsResult;
        private List<string> cities;
        private string selectedCity;

        private DateTime startDate;
        private DateTime endDate;
        private CalendarDateRange selectedRange;
        private int roomsCount;
        private int adultsCount;
        private int childrenCount;
        private DateTime checkInDisplayDate;
        private DateTime checkOutDisplayDate;

        Dictionary<string, List<HotelData>> hotelsInfo;
        Dictionary<string, Tuple<List<string>, List<string>>> hotelsNames;

        public ExampleViewModel()
        {
            this.datesStyleSelector = new CustomStyleSelector();
            this.CheckInDisplayDate = DateTime.Today;
            this.CheckInDisplayDate = DateTime.Today;

            this.startDate = DateTime.Today;
            this.endDate = DateTime.Today.AddDays(6);
            this.SelectedRange = new CalendarDateRange(this.startDate, this.endDate);

            this.hotelsInfo = new Dictionary<string, List<HotelData>>();

            this.cities = new List<string>();
            this.cities.Add("London");
            this.cities.Add("Miami");
            this.cities.Add("Barcelona");

            this.RoomsCount = this.optionsList[0];
            this.ChildrenCount = this.optionsList[1];
            this.AdultsCount = this.optionsList[0];

            this.hotelsNames = this.GetHotelsNames();

            this.hotelsInfo.Add("London", this.GetHotelData("London"));
            this.hotelsInfo.Add("Miami", this.GetHotelData("Miami"));
            this.hotelsInfo.Add("Barcelona", this.GetHotelData("Barcelona"));

            this.SelectedCity = this.cities.ElementAt(0);
        }

        public CustomStyleSelector DatesStyleSelector
        {
            get
            {
                return this.datesStyleSelector;
            }
            set
            {
                this.datesStyleSelector = value;
                this.OnPropertyChanged("DatesStyleSelector");
            }
        }

        public DateTime Today
        {
            get
            {
                return DateTime.Today;
            }
        }

        public CalendarDateRange SelectedRange
        {
            get
            {
                return this.selectedRange;
            }
            set
            {
                this.selectedRange = value;
                this.OnPropertyChanged("SelectedRange");
            }
        }

        public DateTime CheckInDisplayDate
        {
            get
            {
                return this.checkInDisplayDate;
            }
            set
            {
                this.checkInDisplayDate = value;
                this.OnPropertyChanged("CheckInDisplayDate");
            }
        }

        public DateTime CheckOutDisplayDate
        {
            get
            {
                return this.checkOutDisplayDate;
            }
            set
            {
                this.checkOutDisplayDate = value;
                this.OnPropertyChanged("CheckOutDisplayDate");
            }
        }

        public List<int> OptionsList
        {
            get
            {
                return this.optionsList;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return this.startDate;
            }
            set
            {
                if (this.startDate != value)
                {
                    this.startDate = value;

                    if (this.startDate > this.checkOutDisplayDate)
                    {
                        this.CheckOutDisplayDate = this.startDate;
                    }

                    if (this.startDate > this.EndDate)
                    {
                        this.EndDate = this.startDate;
                    }

                    this.SelectedRange = new CalendarDateRange(this.StartDate, this.EndDate);

                    this.HotelsResult = this.GetHotelsResult(selectedCity);
                    this.OnPropertyChanged("StartDate");

                    this.ForceRefreshCellStyleSelector();
                }
            }
        }

        public DateTime EndDate
        {
            get
            {
                return this.endDate;
            }
            set
            {
                if (this.endDate != value)
                {
                    this.endDate = value;

                    if (this.endDate < this.StartDate)
                    {
                        this.StartDate = this.endDate;

                        if (this.endDate < this.checkInDisplayDate)
                        {
                            this.CheckInDisplayDate = this.endDate;
                        }
                    }

                    this.SelectedRange = new CalendarDateRange(this.StartDate, this.EndDate);

                    this.HotelsResult = this.GetHotelsResult(this.selectedCity);
                    this.OnPropertyChanged("EndDate");

                    this.ForceRefreshCellStyleSelector();
                }
            }
        }

        public string SelectedCity
        {
            get
            {
                return this.selectedCity;
            }

            set
            {
                if (selectedCity != value)
                {
                    this.selectedCity = value;
                    this.HotelsResult = this.GetHotelsResult(this.selectedCity);
                    this.OnPropertyChanged("SelectedCity");
                }
            }
        }

        public List<string> Cities
        {
            get
            {
                return this.cities;
            }

            set
            {
                if (this.cities != value)
                {
                    this.cities = value;
                    this.OnPropertyChanged("Cities");
                }
            }
        }

        public int RoomsCount
        {
            get
            {
                return this.roomsCount;
            }

            set
            {
                if (this.roomsCount != value)
                {
                    this.roomsCount = value;
                    if (this.selectedCity != null)
                    {
                        this.HotelsResult = this.GetHotelsResult(this.selectedCity);
                    }
                    this.OnPropertyChanged("RoomsCount");
                }
            }
        }

        public int AdultsCount
        {
            get
            {
                return this.adultsCount;
            }

            set
            {
                if (this.adultsCount != value)
                {
                    this.adultsCount = value;
                    if (this.selectedCity != null)
                    {
                        this.HotelsResult = this.GetHotelsResult(this.selectedCity);
                    }
                    this.OnPropertyChanged("AdultsCount");
                }
            }
        }

        public int ChildrenCount
        {
            get
            {
                return this.childrenCount;
            }

            set
            {
                if (this.childrenCount != value)
                {
                    this.childrenCount = value;
                    if (this.selectedCity != null)
                    {
                        this.HotelsResult = this.GetHotelsResult(this.selectedCity);
                    }
                    this.OnPropertyChanged("ChildrenCount");
                }
            }
        }

        public List<HotelData> HotelsResult
        {
            get
            {
                return this.hotelsResult;
            }
            set
            {
                if (this.hotelsResult != value)
                {
                    this.hotelsResult = value;
                    this.OnPropertyChanged("HotelsResult");
                }
            }
        }

        private List<HotelData> GetHotelsResult(string cityName)
        {
            if (this.endDate == DateTime.MaxValue)
            {
                return this.hotelsInfo[cityName];
            }

            List<HotelData> hotelsList = new List<HotelData>();

            TimeSpan selectedRangeDifference = this.endDate - this.startDate;
            int settingsSum = this.RoomsCount + this.adultsCount + this.ChildrenCount;
            double days = (selectedRangeDifference.TotalDays + 1) / 2;

            double ratio = Math.Round(6 * (days / settingsSum));

            foreach (HotelData hotel in this.hotelsInfo[cityName])
            {
                if (hotel.PositionRatio <= ratio)
                {
                    hotelsList.Add(hotel);
                }
            }

            return hotelsList;
        }

        private Dictionary<string, Tuple<List<string>, List<string>>> GetHotelsNames()
        {
            Dictionary<string, Tuple<List<string>,List<string>>> hotelsNames = new Dictionary<string,Tuple<List<string>,List<string>>>();

            List<string> names = new List<string>() {
                "Buckingham Gate" ,
                "King's Court" ,
                "Three Lords Hotel" ,
                "Oxford Palace" ,
                "Queen's Hotel" ,
                "London Palace" 
            };
            List<string> prices = new List<string>() {
                "265 £" ,
                "165 £" ,
                "75 £" ,
                "123 £" ,
                "170 £" ,
                "347 £" 
            };

            hotelsNames.Add("London", new Tuple<List<string>, List<string>>(names, prices));
            
            names = new List<string>() {
                "Blue Laguna Hotel" ,
                "The Sun Hotel" ,
                "Long Beach Resort" ,
                "White Sea Hotel" ,
                "Six Oceans" ,
                "Miami Central" 
            };

            prices = new List<string>() {
                "$155" ,
                "$187" ,
                "$256" ,
                "$360" ,
                "$147" ,
                "$269 £" 
            };

            hotelsNames.Add("Miami", new Tuple<List<string>, List<string>>(names, prices));

            names = new List<string>() {
                "Plaza Hotel" ,
                "Barcelona Central" ,
                "Flamenco Resort" ,
                "Barcelona Seaside" ,
                "Six Saints Hotel" ,
                "Park Hotel Barcelona" 
            };

            prices = new List<string>() {
                "€ 58" ,
                "€ 158" ,
                "€ 89" ,
                "€ 199" ,
                "€ 105" ,
                "€ 69" 
            };

            hotelsNames.Add("Barcelona", new Tuple<List<string>, List<string>>(names, prices));

            return hotelsNames;
        }

        private List<HotelData> GetHotelData(string cityName)
        {
            List<HotelData> hotelData = new List<HotelData>();
            List<int> positionsList = new List<int>() { 6, 1, 4, 3, 2, 5 };

            for (int i = 0; i < 6; i++)
            {
                hotelData.Add(new HotelData()
                {
                    HotelName = this.hotelsNames[cityName].Item1[i],
                    HotelPrice = this.hotelsNames[cityName].Item2[i],
                    ImageUri = "Images/" + cityName + i + ".jpg",
                    PositionRatio = positionsList[i]
                });
            }

            return hotelData;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void ForceRefreshCellStyleSelector()
        {
            var temp = this.DatesStyleSelector;
            this.DatesStyleSelector = null;
            this.DatesStyleSelector = temp;
        }
    }
}
