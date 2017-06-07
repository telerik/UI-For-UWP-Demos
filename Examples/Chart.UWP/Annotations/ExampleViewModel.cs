using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Chart.Annotations
{
    public class ExampleViewModel : INotifyPropertyChanged
    {
        private IEnumerable<Company> companies;
        private Company selectedCompany;
        private double minYSparkline = 0;
        private double maxYSparkline = 800;

        public ExampleViewModel()
        {
            this.Companies = LoadData();
            this.SelectedCompany = this.Companies.First();
        }

        public IEnumerable<Company> Companies
        {
            get
            {
                return this.companies;
            }
            set
            {
                if (this.companies != value)
                {
                    this.companies = value;
                    this.OnPropertyChanged("Companies");
                }
            }
        }

        public Company SelectedCompany
        {
            get
            {
                return this.selectedCompany;
            }
            set
            {
                if (this.selectedCompany != value)
                {
                    this.selectedCompany = value;
                    
                    this.UpdateRange();
                    this.OnPropertyChanged("SelectedCompany");
                }
            }
        }

        public double MinYSparkline
        {
            get
            {
                return this.minYSparkline;
            }
            set
            {
                if (this.minYSparkline != value)
                {
                    this.minYSparkline = value;
                    this.OnPropertyChanged("MinYSparkline");
                }
            }
        }

        public double MaxYSparkline
        {
            get
            {
                return this.maxYSparkline;
            }
            set
            {
                if (this.maxYSparkline != value)
                {
                    this.maxYSparkline = value;
                    this.OnPropertyChanged("MaxYSparkline");
                }
            }
        }

        private IEnumerable<Company> LoadData()
        {
            List<Company> companies = new List<Company>();
            List<CompanyData> chartData = new List<CompanyData>();

            Assembly assembly = typeof(ExampleViewModel).GetTypeInfo().Assembly;
            string path = "Chart.Annotations.Data.USRecessionCompanyData.csv";

            using (StreamReader reader = new StreamReader(assembly.GetManifestResourceStream(path)))
            {
                string line = string.Empty;
                Company company = null;

                while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                {
                    string[] data = line.Split(',');
                    string name = data[0];

                    if (company != null && company.Name != name)
                    {
                        companies.Add(company);
                        company = null;
                        chartData = new List<CompanyData>();
                    }
                    else if (company == null)
                    {
                        string shortName = name.Split(' ')[0].ToUpper();
                        company = new Company(name, shortName, chartData);
                    }

                    DateTime date = DateTime.Parse(data[1], CultureInfo.InvariantCulture);
                    double value = double.Parse(data[2], CultureInfo.InvariantCulture);
                    CompanyData companyData = new CompanyData(date, value);
                    chartData.Add(companyData);
                }

                if (company != null)
                {
                    companies.Add(company);
                }
            }

            companies[0].SignificantEvents = GetGoogleEvents();
            companies[1].SignificantEvents = GetMicrosoftEvents();
            companies[2].SignificantEvents = GetAppleEvents();

            return companies;
        }

        private void UpdateRange()
        {
            if (this.SelectedCompany == null)
                return;

            if (this.SelectedCompany.Name == "GOOGLE INC.")
            {
                MinYSparkline = 0;
                MaxYSparkline = 800;
            }
            else if (this.SelectedCompany.Name == "MICROSOFT CORPORATION")
            {
                MinYSparkline = 0;
                MaxYSparkline = 40;
            }
            else if (this.SelectedCompany.Name == "APPLE INC.")
            {
                MinYSparkline = 0;
                MaxYSparkline = 700;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private static List<CompanyEvent> GetGoogleEvents()
        {
            return new List<CompanyEvent>()
            {
                // horizontal line
                new CompanyEvent() { Value = 515.26 , EventDescription = "515.25 AVG value" },
                // vertical plot band
                new CompanyEvent(515.26,800, ""),
                // events
                new CompanyEvent(new DateTime(2007, 12, 31), "") { Value = 702.53 },
                new CompanyEvent(new DateTime(2008, 11, 28), "") { Value = 283.34 },
                // vertical lines
                new CompanyEvent(new DateTime(2007, 11, 1), string.Format("Nov 01, 2007{0}Android is announced", Environment.NewLine)),
                new CompanyEvent(new DateTime(2008, 9, 1), string.Format("Sep 01, 2008{0}Google introduced new open source browser - Chrome", Environment.NewLine)),
                new CompanyEvent(new DateTime(2009, 6, 1), string.Format("Jun, 2009{0}The Google Translator Toolkit is released", Environment.NewLine)),
                new CompanyEvent(new DateTime(2009, 12, 1), string.Format("Dec, 2009{0}New real-time search feature is added", Environment.NewLine)),
                new CompanyEvent(new DateTime(2010, 3, 1), string.Format("Mar, 2010{0}The Google Apps Market-place is live", Environment.NewLine)),
                new CompanyEvent(new DateTime(2011, 2, 1), string.Format("Feb, 2011{0}A new search algorithm is implemented", Environment.NewLine)),
                new CompanyEvent(new DateTime(2011, 6, 1), string.Format("Jun, 2011{0}The Google+ project is launched", Environment.NewLine))
            };
        }

        private static List<CompanyEvent> GetMicrosoftEvents()
        {
            return new List<CompanyEvent>()
            {
                // horizontal line
                new CompanyEvent() { Value = 26.85 , EventDescription = "26.85 AVG value" },
                // vertical plot band
                new CompanyEvent(26.85,800, ""),
                // events
                new CompanyEvent(new DateTime(2007, 12, 31), "") { Value = 36.12 },
                new CompanyEvent(new DateTime(2009, 3, 20), "") { Value = 16.49 },
                // vertical lines
                new CompanyEvent(new DateTime(2007, 1, 30), string.Format("Jan 30, 2007{0}Microsoft releases Windows Vista and Office 2007 to the general public", Environment.NewLine)),
                new CompanyEvent(new DateTime(2008, 10, 27), string.Format("Oct 27, 2008{0}Microsoft launched Azure Services Platform", Environment.NewLine)),
                new CompanyEvent(new DateTime(2009, 10, 22), string.Format("Oct 22, 2009{0}Microsoft officially released Windows 7", Environment.NewLine)),
                new CompanyEvent(new DateTime(2011, 2, 11), string.Format("Feb 11, 2011{0}Microsoft in partnership with Nokia", Environment.NewLine)),
            };
        }

        private static List<CompanyEvent> GetAppleEvents()
        {
            return new List<CompanyEvent>()
            {
                // horizontal line
                new CompanyEvent() { Value = 225.74 , EventDescription = "225.74 AVG value" },
                // vertical plot band
                new CompanyEvent(225.74,800, ""),
                // events
                new CompanyEvent(new DateTime(2012, 4, 5), "") { Value = 612.98 },
                new CompanyEvent(new DateTime(2009, 1, 23), "") { Value = 85.26 },
                // vertical lines
                new CompanyEvent(new DateTime(2007, 6, 29), string.Format("Jun 29, 2007{0}The first Iphone was released", Environment.NewLine)),
                new CompanyEvent(new DateTime(2007, 9, 1), string.Format("Sep, 2007{0}iPod touch was released", Environment.NewLine)),
                new CompanyEvent(new DateTime(2008, 1, 1), string.Format("Jan, 2008{0}MacBook Air - the thin-nest Apple laptop was announced", Environment.NewLine)),
                new CompanyEvent(new DateTime(2010, 1, 27), string.Format("Jan 27, 2010{0}Apple announced a large screen, table-like media device known as the iPad", Environment.NewLine)),
                new CompanyEvent(new DateTime(2010, 6, 1), string.Format("Jun, 2010{0}Apple introduced iPhone 4", Environment.NewLine)),
                new CompanyEvent(new DateTime(2011, 3, 1), string.Format("Mar, 2011{0}iPad2 was introduced", Environment.NewLine)),
                new CompanyEvent(new DateTime(2011, 6, 1), string.Format("Jun, 2011{0}Steve Jobs Unveiled iCloud", Environment.NewLine)),
                new CompanyEvent(new DateTime(2011, 8, 24), string.Format("Aug 24, 2011{0}Steve Jobs resigned his position as CEO", Environment.NewLine)),
            };
        }
    }
}
