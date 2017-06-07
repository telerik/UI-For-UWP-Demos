using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QSF.Common.Examples;
using Windows.UI.Xaml;

namespace Gauge.Gallery
{
    public class RandomViewModel : GalleryModel
    {
        private DispatcherTimer timer;
        private Random r;

        public RandomViewModel()
        {
            r = new Random();
            timer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) };
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

        private double expenses;

        public double Expenses
        {
            get { return expenses; }
            set
            {
                expenses = value;
                this.OnPropertyChanged("Expenses");
            }
        }

        private double expensePercent;

        public double ExpensePercent
        {
            get { return expensePercent; }
            set
            {
                expensePercent = value;
                this.OnPropertyChanged("ExpensePercent");
            }
        }

        private double revenuesPercent;

        public double RevenuesPercent
        {
            get { return revenuesPercent; }
            set
            {
                revenuesPercent = value;
                this.OnPropertyChanged("RevenuesPercent");
            }
        }

        private double revenues;

        public double Revenues
        {
            get { return revenues; }
            set
            {
                revenues = value;
                this.OnPropertyChanged("Revenues");
            }
        }

        private double revenuesVSExpenses;

        public double RevenuesVSExpenses
        {
            get { return revenuesVSExpenses; }
            set
            {
                revenuesVSExpenses = value;
                this.OnPropertyChanged("RevenuesVSExpenses");
            }
        }


        void timer_Tick(object sender, object e)
        {
            this.UpdateIndicators();
        }

        private void LoadData()
        {
            UpdateIndicators();
        }

        private void UpdateIndicators()
        {
            this.Expenses = r.Next(1, 80);
            this.ExpensePercent = r.Next(0, 120);
            this.RevenuesPercent = r.Next(0, 120);
            this.Revenues = r.Next(0, 80);
            this.RevenuesVSExpenses = Math.Round(Revenues / Expenses, 2);
        }


    }
}
