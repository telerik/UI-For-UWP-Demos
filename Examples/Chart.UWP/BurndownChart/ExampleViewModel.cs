using System.Collections.Generic;
using System.ComponentModel;
using QSF.Common.Examples;

namespace Chart.BurndownChart
{
    public class ExampleViewModel : ViewModelBase
    {
        public ExampleViewModel()
        {
            this.Data = new List<DataModel>
            {
                new DataModel { Day = "day1", RemainingWork = 130 },
                new DataModel { Day = "day2", RemainingWork = 135 },
                new DataModel { Day = "day3", RemainingWork = 105 },
                new DataModel { Day = "day4", RemainingWork = 88 },
                new DataModel { Day = "day5", RemainingWork = 74 },
                new DataModel { Day = "day6", RemainingWork = 75 },
                new DataModel { Day = "day7", RemainingWork = 31 },
                new DataModel { Day = "day8", RemainingWork = 23 },
                new DataModel { Day = "day9", },
                new DataModel { Day = "day10", }
            };

            this.StartItems = 130;
            this.EndItems = 0;
            this.TodayItems = 23;
            this.StartDay = "day1";
            this.EndDay = "day10";
            this.Today = "day8";
        }


        public int StartItems { get; set; }

        public int EndItems { get; set; }

        public int TodayItems { get; set; }

        public string StartDay { get; set; }

        public string EndDay { get; set; }

        public string Today { get; set; }

        public IList<DataModel> Data { get; set; }
    }
}