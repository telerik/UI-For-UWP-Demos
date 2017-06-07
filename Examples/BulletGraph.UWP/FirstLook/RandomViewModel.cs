using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QSF.Common.Examples;
using Windows.UI.Xaml;

namespace BulletGraph.FirstLook
{
    public class RandomViewModel : ViewModelBase
    {
        private DispatcherTimer timer;
        private Random r;

        private int callDuration;

        public int CallDuration
        {
            get { return callDuration; }
            set
            {
                callDuration = value;
                this.OnPropertyChanged("CallDuration");
            }
        }

        private int holdTime;

        public int HoldTime
        {
            get { return holdTime; }
            set
            {
                holdTime = value;
                this.OnPropertyChanged("HoldTime");
            }
        }


        private int abandonment;

        public int Abandoment
        {
            get { return abandonment; }
            set
            {
                abandonment = value;
                this.OnPropertyChanged("Abandoment");
            }
        }

        private double callVSResolution;

        public double CallsVSResolution
        {
            get { return callVSResolution; }
            set
            {
                callVSResolution = value;
                this.OnPropertyChanged("CallsVSResolution");
            }
        }

        private CallsData currentActiveCalls;

        public CallsData CurrentActiveCalls
        {
            get { return currentActiveCalls; }
            set
            {
                currentActiveCalls = value;
                this.OnPropertyChanged("CurrentActiveCalls");
            }
        }

        private ObservableCollection<CallsData> callHistory;

        public ObservableCollection<CallsData> CallHistory
        {
            get { return callHistory; }
            private set
            {
                callHistory = value;
                this.OnPropertyChanged("CallHistory");
            }
        }

        public RandomViewModel()
        {
            r = new Random();
            timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };
            timer.Tick += timer_Tick;
            this.LoadData();
        }

        public void StopTimer()
        {
            this.timer.Stop();
        }

        public void StartTimer()
        {
            this.timer.Start();
        }

        void timer_Tick(object sender, object e)
        {
            this.UpdateIndicators();

            var lastRecorderData = this.CallHistory.Last();
            this.CurrentActiveCalls = new CallsData { Date = lastRecorderData.Date.AddMilliseconds(500), ActiveCalls = r.Next(10, 30) };
            this.CallHistory.Add(CurrentActiveCalls);
            this.CallHistory.RemoveAt(0);
        }

        private void LoadData()
        {
            UpdateIndicators();

            var now = DateTime.Now;
            var historyData = from c in Enumerable.Range(0, 24)
                              select new CallsData { ActiveCalls = r.Next(10, 30), Date = now.AddMilliseconds(-500 * c) };

            this.CallHistory = new ObservableCollection<CallsData>(historyData.OrderBy(c => c.Date));
        }

        private void UpdateIndicators()
        {
            this.Abandoment = r.Next(0, 175);
            this.CallDuration = r.Next(0, 175);
            this.CallsVSResolution = r.Next(0, 30) / 10.0;
            this.HoldTime = r.Next(0, 175);
        }


    }

    public class CallsData : ViewModelBase
    {
        private int activeCalls;

        public int ActiveCalls
        {
            get { return activeCalls; }
            set
            {
                activeCalls = value;
                this.OnPropertyChanged("ActiveCalls");
            }
        }


        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                this.OnPropertyChanged("Date");
            }
        }
    }
}
