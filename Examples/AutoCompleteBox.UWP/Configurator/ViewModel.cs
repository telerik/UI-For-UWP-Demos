using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Telerik.UI.Xaml.Controls.Input;

namespace AutoCompleteBox.Configurator
{
    public class ViewModel : INotifyPropertyChanged
    {
        private bool shouldHighlightMatches;
        private bool shouldIgnoreCaseSwitch;
        private bool shouldAutosuggestFirstItem;
        private StringComparison shouldIgnoreCase;
        private string watermark;
        private int filterStartThreshold;
        private TimeSpan filterDelay;
        private AutoCompleteBoxFilterMode filterMode = AutoCompleteBoxFilterMode.Contains;

        public ViewModel()
        {
            this.Suggestions = CountriesHelper.GenerateSuggestionsSource();
            this.shouldHighlightMatches = true;
            this.shouldIgnoreCaseSwitch = true;
            this.shouldAutosuggestFirstItem = true;
            this.shouldIgnoreCase = StringComparison.CurrentCultureIgnoreCase;
            this.watermark = string.Empty;
            this.filterDelay = TimeSpan.Zero;
            this.filterStartThreshold = 0;
            this.FilterMode = AutoCompleteBoxFilterMode.StartsWith;
        }

        public bool ShouldIgnoreCaseSwitch
        {
            get 
            { 
                return shouldIgnoreCaseSwitch; 
            }
            set
            {
                this.shouldIgnoreCaseSwitch = value;
                this.ShouldIgnoreCase = value == true ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture;
                this.OnPropertyChanged("ShouldIgnoreCaseSwitch");
            }
        }

        public StringComparison ShouldIgnoreCase
        {
            get
            {
                return this.ShouldIgnoreCaseSwitch == true ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture;
            }
            set
            {
                this.shouldIgnoreCase = value;
                this.OnPropertyChanged("ShouldIgnoreCase");
            }
        }

        public bool ShouldHighlightMatches
        {
            get 
            { 
                return this.shouldHighlightMatches; 
            }
            set
            {
                this.shouldHighlightMatches = value;
                this.OnPropertyChanged("ShouldHighlightMatches");
            }
        }

        public bool ShouldAutosuggestFirstItem
        {
            get 
            {
                return this.shouldAutosuggestFirstItem;
            }
            set
            {
                this.shouldAutosuggestFirstItem = value;
                this.OnPropertyChanged("ShouldAutosuggestFirstItem");
            }
        }

        public string Watermark
        {
            get 
            { 
                return this.watermark; 
            }
            set
            {
                this.watermark = value;
                this.OnPropertyChanged("Watermark");
            }
        }

        public int FilterStartThreshold
        {
            get
            { 
                return this.filterStartThreshold;
            }
            set
            {
                this.filterStartThreshold = value;
                this.OnPropertyChanged("FilterStartThreshold");    
            }
        }

        public TimeSpan FilterDelay
        {
            get
            { 
                return this.filterDelay;
            }
            set
            {
                this.filterDelay = value;
                this.FilterStartThreshold = 0;
                this.OnPropertyChanged("FilterDelay");
            }
        }

        public AutoCompleteBoxFilterMode FilterMode
        {
            get 
            { 
                return this.filterMode;
            }
            set
            {
                this.filterMode = value;
                this.OnPropertyChanged("FilterMode");
            }
        }

        public IEnumerable<AutoCompleteBoxFilterMode> MyFilterModeTypeValues
        {
            get
            {
               return Enum.GetValues(typeof(AutoCompleteBoxFilterMode))
                 .Cast<AutoCompleteBoxFilterMode>();
            }
        }

        public List<string> Suggestions
        {
            get;
            set;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
