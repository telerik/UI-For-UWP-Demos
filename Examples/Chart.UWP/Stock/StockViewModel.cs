using QSF.Common.Examples;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Telerik.UI.Xaml.Controls.Chart;

namespace Chart.Stock
{
    public class StockViewModel : ViewModelBase
    {
        public StockViewModel()
        {
            this.Data = FinancialDataModel.DailyData;

            this.ChangeDataPeriodCommand = new DelegateCommand((s) =>
                {
                    switch (s.ToString())
                    {
                        case "Daily":
                            this.Data = FinancialDataModel.DailyData;
                            break;
                        case "Weekly":
                            this.Data = FinancialDataModel.WeeklyData;
                         
                            break;
                        case "Monthly":
                            this.Data = FinancialDataModel.MonthlyData;
                       
                            break;

                        default:
                            break;
                    }
                });

        }

        private bool usingDailyData;

        public bool UsingDailyData
        {
            get { return usingDailyData; }
            set
            {
                usingDailyData = value;
                this.OnPropertyChanged("UsingDailyData");
            }
        }

        private bool usingWeeklyData;

        public bool UsingWeeklyData
        {
            get { return usingWeeklyData; }
            set
            {
                usingWeeklyData = value;
                this.OnPropertyChanged("UsingWeeklyData");
            }
        }


        private bool usingMonthlyData;

        public bool UsingMonthlyData
        {
            get { return usingMonthlyData; }
            set
            {
                usingMonthlyData = value;
                this.OnPropertyChanged("UsingMonthlyData");
            }
        }


        private List<OhlcModel> data;

        public List<OhlcModel> Data
        {
            get { return data; }
            set
            {
                data = value;
                this.OnPropertyChanged("Data");

                this.UpdateValues();
            }
        }

        private void UpdateValues()
        {
            this.UsingDailyData = this.Data == FinancialDataModel.DailyData;
            this.UsingWeeklyData = this.Data == FinancialDataModel.WeeklyData;
            this.UsingMonthlyData = this.Data == FinancialDataModel.MonthlyData;
        }

        public ICommand ChangeDataPeriodCommand { get; set; }
    }
}
