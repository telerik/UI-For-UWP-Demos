using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chart.EmptyValues
{
    public class FootballTeamStats
    {
        public string Name { get; set; }
        public string LogoPath { get; set; }
        public string Season { get; set; }
        public int? Wins { get; set; }
        public int? Draws { get; set; }
        public int? Losses { get; set; }
        public int? GoalDifference { get; set; }
        public int? Points { get; set; }
        public int? Position { get; set; }
    }

    public class FootballTeam
    {
        public string Name { get; set; }
        public string LogoPath { get; set; }
        public int TotalWins { get; set; }
        public int TotalDraws { get; set; }
        public int TotalLosses { get; set; }
        public IEnumerable<FootballTeamStats> Stats { get; set; }
    }
}
