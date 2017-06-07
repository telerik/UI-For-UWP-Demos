using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace RadialMenu.Customization
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Position menuPosition;
        private List<PictureInfo> picturesInfo;
        public PictureInfo lastPictureInfo { get; set; }

        public List<PictureInfo> PicturesInfo
        {
            get
            {
                return this.picturesInfo;
            }
            set
            {
                this.picturesInfo = value;
                this.OnPropertyChanged("PicturesInfo");
            }
        }

        public Position MenuPosition
        {
            get
            {
                return this.menuPosition;
            }
            set
            {
                this.menuPosition = value;
                this.OnPropertyChanged("MenuPosition");
            }
        }

        public ViewModel()
        {
            this.picturesInfo = new List<PictureInfo>();
            this.menuPosition = Customization.Position.Right;

            this.picturesInfo.Add(new PictureInfo(this) { Url = "Images/image1.png", Description = "Ski time" });
            this.picturesInfo.Add(new PictureInfo(this) { Url = "Images/image2.png", Description = "Not so bad for first time playing" });
            this.picturesInfo.Add(new PictureInfo(this) { Url = "Images/image3.png", Description = "Wow! These waves are amazing" });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            PropertyChangedEventHandler eh = this.PropertyChanged;
            if (eh != null)
            {
                eh(this, new PropertyChangedEventArgs(propName));
            }
        }
    }

    public class PictureInfo : INotifyPropertyChanged
    {
        private double menuStartAngle = 90d;
        private bool isOpen;
        public string Url { get; set; }
        public string Description { get; set; }

        public ViewModel Owner
        {
            get;
            set;
        }

        public bool IsOpen
        {
            get
            {
                return this.isOpen;
            }

            set
            {
                this.isOpen = value;
              
                if (value)
                {
                    this.Owner.lastPictureInfo = this;
                }

                this.OnPropertyChanged("IsOpen");
            }
        }

        public PictureInfo(ViewModel owner)
        {
            this.Owner = owner;
        }

        public double MenuStartAngle
        {
            get
            {
                return this.menuStartAngle;
            }
            set
            {
                this.menuStartAngle = value;
                this.OnPropertyChanged("MenuStartAngle");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
