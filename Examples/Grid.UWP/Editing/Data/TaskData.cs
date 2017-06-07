using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Core;

namespace Grid.Editing.Data
{
    public class TaskData : ViewModelBase
    {
        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                this.OnPropertyChanged();
            }
        }


        private string taskName;

        public string TaskName
        {
            get { return taskName; }
            set
            {
                taskName = value;
                this.OnPropertyChanged();
            }
        }


        private string role;

        public string Role
        {
            get { return role; }
            set
            {
                role = value;
                this.OnPropertyChanged();
            }
        }

        private int effort;

        public int Effort
        {
            get { return effort; }
            set
            {
                effort = value;
                this.OnPropertyChanged();
            }
        }

        private DateTime? startDate;

        public DateTime? StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                this.OnPropertyChanged();
            }
        }

        private DateTime? endDate;

        public DateTime? EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                this.OnPropertyChanged();
            }
        }

        private int cost;

        public int Cost
        {
            get { return cost; }
            set
            {
                cost = value;
                this.OnPropertyChanged();
            }
        }

        private int group;

        public int Group
        {
            get { return group; }
            set
            {
                group = value;
                this.OnPropertyChanged();
            }
        }




    }
}
