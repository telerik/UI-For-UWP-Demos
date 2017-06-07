using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeSlider.FirstLook
{
    public class ViewModel : INotifyPropertyChanged
    {
        private string ratingHint;
        private string mpaaRating;   
        private string durationRange;
        private double rating;
        private double durationStartValue;
        private double durationEndValue;
        private List<Movie> filteredMovies;
        private List<Movie> allMovies;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Movie> AllMovies
        {
            get
            {
                return this.allMovies;
            }
            set
            {
                this.allMovies = value;
                this.OnPropertyChanged("AllMovies");
            }
        }

        public List<Movie> FilteredMovies
        {
            get
            {
                return this.filteredMovies;
            }
            set
            {
                this.filteredMovies = value;
                this.OnPropertyChanged("FilteredMovies");
            }
        }

        public double Rating
        {
            get
            {
                return this.rating;
            }
            set
            {
                this.rating = value;
                this.OnPropertyChanged("Rating");
            }
        }

        public double DurationStartValue
        {
            get
            {
                return this.durationStartValue;
            }
            set
            {
                this.durationStartValue = value;
                this.UpdateDurationRange();
                this.OnPropertyChanged("DurationStartValue");
            }
        }

        public double DurationEndValue
        {
            get
            {
                return this.durationEndValue;
            }
            set
            {
                this.durationEndValue = value;
                this.UpdateDurationRange();
                this.OnPropertyChanged("DurationEndValue");
            }
        }

        public string DurationRange
        {
            get
            {
                return this.durationRange;
            }
            set
            {
                this.durationRange = value;
                this.OnPropertyChanged("DurationRange");
            }
        }
        
       

        public void UpdateDurationRange()
        {
            this.DurationRange = "FROM " + this.DurationStartValue + " TO " + this.DurationEndValue;
        }
        
        public void ClearFilter()
        {
            this.DurationStartValue = 89;
            this.DurationEndValue = 169;
            this.Rating = 2;
            
            this.UpdateDurationRange();
            this.FilterMovies();
        }

        public ViewModel()
        {
            this.filteredMovies = new List<Movie>();
            this.DurationEndValue = 169;
            this.DurationStartValue = 89;
            this.Rating = 2;
            
            this.UpdateDurationRange();
        }

        public void FilterMovies()
        {
            this.FilteredMovies = this.allMovies.Where(x => Double.Parse(x.Rating) >= Math.Round(this.rating, 1) && (Int32.Parse(x.Duration) <= this.DurationEndValue && Int32.Parse(x.Duration) >= this.DurationStartValue)).ToList();
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChangedEventHandler eh = this.PropertyChanged;
            if (eh != null)
            {
                eh(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
