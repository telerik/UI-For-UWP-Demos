using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Telerik.Data.Core;
using Telerik.UI.Xaml.Controls.Primitives.LoopingList;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace LoopingList.Orientation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Example : Page
    {
        private string[] dates = new string[11];
        private string[] captions = new string[11];

        public Example()
        {
            this.InitializeComponent();

            this.loopingList.SelectedIndexChanged += this.OnSelectedIndexChanged;
            this.PrepareDatesAndCaptions();
            this.loopingList.SelectedIndex = 1;
        }

        private void PrepareDatesAndCaptions()
        {
            dates[0] = "july 2015";
            dates[1] = "october 2014";
            dates[2] = "june 2013";
            dates[3] = "april 2014";
            dates[4] = "april 2014";
            dates[5] = "april 2014";
            dates[6] = "may 2015";
            dates[7] = "july 2015";
            dates[8] = "july 2015";
            dates[9] = "march  2015";
            dates[10] = "july 2012";

            captions[0] = "the great beach party";
            captions[1] = "oktoberfest in munich";
            captions[2] = "at the concert";
            captions[3] = "mary's birthday";
            captions[4] = "mary's birthday";
            captions[5] = "mary's birthday";
            captions[6] = "disneyland visit";
            captions[7] = "the great beach party";
            captions[8] = "the great beach party";
            captions[9] = "in brazil";
            captions[10] = "the great beach party";

            List<PictureLoopingItem> list = new List<PictureLoopingItem>();

            for (int i = 0; i < dates.Length; i++)
            {
                list.Add(new PictureLoopingItem() { Picture = new Uri("ms-appx:///LoopingList/Orientation/Images/" + (i + 1) + ".png", UriKind.Absolute), Place = this.captions[i], Date = this.dates[i] });
            }


            this.loopingList.ItemsSource = list;
        }

        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateCaption();
        }

        private void UpdateCaption()
        {
            int selectedIndex = this.loopingList.SelectedIndex;
            //this.txtWhere.Text = this.captions[selectedIndex];
            //this.txtWhen.Text = this.dates[selectedIndex];
        }

    }

    public class PictureLoopingItem : INotifyPropertyChanged
    {
        private Uri pictureSource;
        public Uri Picture
        {
            get
            {
                return this.pictureSource;
            }
            set
            {
                if (value != this.pictureSource)
                {
                    this.pictureSource = value;
                    this.OnPropertyChanged("Picture");
                }
            }
        }

        private string date;

        public string Date
        {
            get { return date; }
            set
            {
                date = value;
                this.OnPropertyChanged("Date");
            }
        }


        private string place;

        public string Place
        {
            get { return place; }
            set
            {
                place = value;
                this.OnPropertyChanged("Place");
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
    }
}
