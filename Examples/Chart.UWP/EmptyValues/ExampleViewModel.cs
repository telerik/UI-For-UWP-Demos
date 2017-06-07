using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Chart.EmptyValues
{
    public class ExampleViewModel : INotifyPropertyChanged
    {
        private IEnumerable<FootballTeam> data;
        private FootballTeam selectedTeam;
        private bool showLabels;

        public ExampleViewModel()
        {
            LoadData();
        }

        public IEnumerable<FootballTeam> Data
        {
            get
            {
                return this.data;
            }
            set
            {
                if (this.data == value)
                {
                    return;
                }

                this.data = value;
                this.OnPropertyChanged("Data");
            }
        }

        public FootballTeam SelectedTeam
        {
            get
            {
                return this.selectedTeam;
            }
            set
            {
                if (this.selectedTeam == value)
                {
                    return;
                }

                this.selectedTeam = value;
                this.OnPropertyChanged("SelectedTeam");
            }
        }

        public bool ShowLabels
        {
            get
            {
                return this.showLabels;
            }
            set
            {
                if (this.showLabels != value)
                {
                    this.showLabels = value;
                    this.OnPropertyChanged("ShowLabels");
                }
            }
        }

        private void LoadData()
        {
            Assembly assembly = typeof(ExampleViewModel).GetTypeInfo().Assembly;
            string path = "Chart.EmptyValues.Data.Premierleaguedata.csv";

            using (StreamReader reader = new StreamReader(assembly.GetManifestResourceStream(path)))
            {
                this.GetDataCompleted(this.ParseData(reader));
            } 
        }

        protected  void GetDataCompleted(IEnumerable data)
        {
            var footballTeamStats = data as IEnumerable<FootballTeamStats>;
            var query = from teamStats in footballTeamStats
                        group teamStats by new { teamStats.Name, teamStats.LogoPath }
                            into team
                            select new FootballTeam()
                            {
                                Name = team.Key.Name,
                                LogoPath = team.Key.LogoPath,
                                Stats = team.ToArray(),
                                TotalWins = team.Where(c => c.Wins.HasValue).Sum(c => c.Wins.Value),
                                TotalDraws = team.Where(c => c.Draws.HasValue).Sum(c => c.Draws.Value),
                                TotalLosses = team.Where(c => c.Losses.HasValue).Sum(c => c.Losses.Value),
                            };
            this.Data = query.ToArray();
            this.SelectedTeam = this.Data.ElementAt(2);
        }

        protected  IEnumerable ParseData(TextReader dataReader)
        {
            string line;
            List<FootballTeamStats> dataList = new List<FootballTeamStats>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] data = line.Split(',');

                var stat = new FootballTeamStats();
                stat.Name = data[0].Trim();
                stat.Season = data[1].Trim();
                if (!string.IsNullOrEmpty(data[2]))
                {
                    stat.Wins = int.Parse(data[2], CultureInfo.InvariantCulture);
                }
                if (!string.IsNullOrEmpty(data[3]))
                {
                    stat.Draws = int.Parse(data[3], CultureInfo.InvariantCulture);
                }
                if (!string.IsNullOrEmpty(data[4]))
                {
                    stat.Losses = int.Parse(data[4], CultureInfo.InvariantCulture);
                }
                if (!string.IsNullOrEmpty(data[5]))
                {
                    stat.GoalDifference = int.Parse(data[5], CultureInfo.InvariantCulture);
                }
                if (!string.IsNullOrEmpty(data[6]))
                {
                    stat.Points = int.Parse(data[6], CultureInfo.InvariantCulture);
                }
                if (!string.IsNullOrEmpty(data[7]))
                {
                    stat.Position = int.Parse(data[7], CultureInfo.InvariantCulture);
                }
                stat.LogoPath = string.Format("Images/{0}", data[8].Trim());

                dataList.Add(stat);
            }

            return dataList;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
