using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.UI.Xaml.Controls.Primitives.Pagination;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Pagination.FirstLook
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public IList<ImageView> Images { get; private set; }

        private PaginationControlDisplayMode displayMode;

        public PaginationControlDisplayMode DisplayMode
        {
            get { return displayMode; }
            set
            {
                displayMode = value;
                this.OnPropertyChanged("DisplayMode");
            }
        }

        private bool shouldDisplayThumbnails;

        public bool ShouldDisplayThumbnails
        {
            get { return shouldDisplayThumbnails; }
            set
            {
                shouldDisplayThumbnails = value;
                this.OnPropertyChanged("ShouldDisplayThumbnails");
                this.UpdateThumbnailTemplate();
            }
        }

        private void UpdateThumbnailTemplate()
        {
            this.CurrentThumbnailTemplate = this.ShouldDisplayThumbnails ? this.DefaultThumbnailTemplate : null;
        }


        private DataTemplate defaultThumbnailTemplate;

        public DataTemplate DefaultThumbnailTemplate
        {
            get { return defaultThumbnailTemplate; }
            set
            {
                defaultThumbnailTemplate = value;
                this.OnPropertyChanged("DefaultThumbnailTemplate");
                this.UpdateThumbnailTemplate();
            }
        }




        private DataTemplate currentThumbnailTemplate;

        public DataTemplate CurrentThumbnailTemplate
        {
            get { return currentThumbnailTemplate; }
            set
            {
                currentThumbnailTemplate = value;
                this.OnPropertyChanged("CurrentThumbnailTemplate");
            }
        }

        private bool displayButtons;

        public bool DisplayButtons
        {
            get { return displayButtons; }
            set
            {
                displayButtons = value;
                this.OnPropertyChanged("DisplayButtons");
                this.UpdateDisplayMode();
            }
        }

        private bool displayNumbers;

        public bool DisplayNumbers
        {
            get { return displayNumbers; }
            set
            {
                displayNumbers = value;
                this.OnPropertyChanged("DisplayNumbers");
                this.UpdateDisplayMode();
            }

        }

        private void UpdateDisplayMode()
        {
            if (this.DisplayButtons && this.DisplayNumbers)
            {
                this.DisplayMode = PaginationControlDisplayMode.All;
            }
            else if (!this.DisplayButtons && this.DisplayNumbers)
            {
                this.DisplayMode = PaginationControlDisplayMode.ThumbnailsAndIndex;
            }
            else if (this.DisplayButtons && !this.DisplayNumbers)
            {
                this.DisplayMode = PaginationControlDisplayMode.ArrowsAndThumbnails;
            }
            else
            {
                this.DisplayMode = PaginationControlDisplayMode.Thumbnails;
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public MainViewModel()
        {
            this.Images =
                (from c in Enumerable.Range(1, 6)
                 select CreateView(c)).ToList();

            this.DisplayButtons = true;
            this.DisplayNumbers = true;
            this.ShouldDisplayThumbnails = true;
        }

        private static ImageView CreateView(int index)
        {
            return new ImageView
            {
                Image = new BitmapImage(new Uri(
                    string.Format("ms-appx:///Pagination/Assets/FirstLook/{0}.jpg", index), UriKind.Absolute)),
                Thumbnail = new BitmapImage(new Uri(
                    string.Format("ms-appx:///Pagination/Assets/FirstLook/{0}s.jpg", index), UriKind.Absolute))
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class ImageView
    {
        public ImageSource Image { get; set; }
        public ImageSource Thumbnail { get; set; }
    }
}
