using QSF.Common.Examples;
using Telerik.Charting;
using Telerik.Geospatial;
using Telerik.UI.Xaml.Controls.Chart;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace Map.FirstLook
{
    public class ExampleViewModel : ViewModelBase
    {
        private Location center;
        private double zoomLevel, maxZoomLevel;
        private ChartPalette doughnutPalette;
        private AngleRange doughnutAngleRange;

        public ExampleViewModel()
        {
            this.ZoomLevel = 2.7;
            this.MaxZoomLevel = 8;
            this.Center = new Location(33.3283678740514, 0.160481929779053);

            ChartPalette palette = new ChartPalette();
            palette.FillEntries.Brushes.Add(new SolidColorBrush(Color.FromArgb(255, 236, 191, 52)));
            palette.FillEntries.Brushes.Add(new SolidColorBrush(Color.FromArgb(255, 255, 247, 220)));

            this.DoughnutPalette = palette;

            this.DoughnutAngleRange = new AngleRange(-90, 360);
        }

        public double ZoomLevel
        {
            get
            {
                return this.zoomLevel;
            }
            set
            {
                if (this.zoomLevel != value)
                {
                    this.zoomLevel = value;
                    this.OnPropertyChanged("ZoomLevel");
                }
            }
        }

        public double MaxZoomLevel
        {
            get
            {
                return this.maxZoomLevel;
            }
            set
            {
                if (this.maxZoomLevel != value)
                {
                    this.maxZoomLevel = value;
                    this.OnPropertyChanged("MaxZoomLevel");
                }
            }
        }

        public Location Center
        {
            get
            {
                return this.center;
            }
            set
            {
                if (this.center != value)
                {
                    this.center = value;
                    this.OnPropertyChanged("Center");
                }
            }
        }

        public ChartPalette DoughnutPalette
        {
            get
            {
                return this.doughnutPalette;
            }
            set
            {
                if (this.doughnutPalette != value)
                {
                    this.doughnutPalette = value;
                    this.OnPropertyChanged("DoughnutPalette");
                }
            }
        }

        public AngleRange DoughnutAngleRange
        {
            get
            {
                return this.doughnutAngleRange;
            }
            set
            {
                if (this.doughnutAngleRange != value)
                {
                    this.doughnutAngleRange = value;
                    this.OnPropertyChanged("DoughnutAngleRange");
                }
            }
        }
    }
}
