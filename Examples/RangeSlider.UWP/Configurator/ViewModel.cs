using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Controls;

namespace RangeSlider.Configurator
{
    public class ViewModel:INotifyPropertyChanged
    {
        private RangeSliderTrackTapMode trackTapMode;
        private SnapsTo snapsTo;
        private Orientation orientationMode;
        private string labelFormat;
        private string tooltipFormat;
        private double tickFrequency;
        private double largeChange;
        private double smallChange;
        private List<Orientation> orientationModeTypeValues;
        private List<string> labelFormatTypeValues;
      
        public event PropertyChangedEventHandler PropertyChanged;

        public SnapsTo SnapsTo
        {
            get
            {
                return this.snapsTo;
            }
            set
            {
                this.snapsTo = value;
                this.OnPropertyChanged("SnapsTo");
            }
        }

        public RangeSliderTrackTapMode TrackTapMode
        {
            get
            {
                return this.trackTapMode;
            }
            set
            {
                this.trackTapMode = value;
                this.OnPropertyChanged("TrackTapMode");
            }
        }

        public double TickFrequency
        {
            get
            {
                return this.tickFrequency;
            }
            set
            {
                this.tickFrequency = value;
                this.OnPropertyChanged("TickFrequency");
            }
        }

        public double LargeChange
        {
            get
            {
                return this.largeChange;
            }
            set
            {
                this.largeChange = value;
                this.OnPropertyChanged("LargeChange");
            }
        }

        public double SmallChange
        {
            get
            {
                return this.smallChange;
            }
            set
            {
                this.smallChange = value;
                this.OnPropertyChanged("SmallChange");
            }
        }

        public Orientation OrientationMode
        {
            get
            {
                return this.orientationMode;
            }
            set
            {
                this.orientationMode = value;
                this.OnPropertyChanged("OrientationMode");
            }
        }

        public string LabelFormat
        {
            get
            {
                return this.labelFormat;
            }
            set
            {
                this.labelFormat = value;
                this.OnPropertyChanged("LabelFormat");
            }
        }

        public string TooltipFormat
        {
            get
            {
                return this.tooltipFormat;
            }
            set
            {
                this.tooltipFormat = value;
                this.OnPropertyChanged("TooltipFormat");
            }
        }

        public List<Orientation> OrientationModeTypeValues
        {
            get
            {
                return this.orientationModeTypeValues;
            }
        }

        public List<string> LabelFormatTypeValues
        {
            get
            {
                return this.labelFormatTypeValues;
            }
        }

        public IEnumerable<SnapsTo> SnapsToModeTypeValues
        {
            get
            {
                return Enum.GetValues(typeof(SnapsTo))
                  .Cast<SnapsTo>();
            }
        }

        public IEnumerable<RangeSliderTrackTapMode> TrackTapModeTypeValues
        {
            get
            {
                return Enum.GetValues(typeof(RangeSliderTrackTapMode))
                  .Cast<RangeSliderTrackTapMode>();
            }
        }

        public ViewModel()
        {
            this.orientationModeTypeValues = new List<Orientation>();
            this.labelFormatTypeValues = new List<string>();

            this.orientationModeTypeValues.Add(Orientation.Horizontal);
            this.orientationModeTypeValues.Add(Orientation.Vertical);
            this.OrientationMode = this.orientationModeTypeValues[0];

            this.labelFormatTypeValues.Add("{0:0}");
            this.labelFormatTypeValues.Add("{0:0.0}");
            this.labelFormatTypeValues.Add("{0:0.00}");
            this.LabelFormat = this.labelFormatTypeValues[0];
            this.TooltipFormat = this.labelFormatTypeValues[0];

            this.smallChange = 1;
            this.largeChange = 5;
            this.tickFrequency = 20;
            this.trackTapMode = RangeSliderTrackTapMode.IncrementByLargeChange;
            this.snapsTo = Telerik.UI.Xaml.Controls.Primitives.SnapsTo.SmallChange;
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
