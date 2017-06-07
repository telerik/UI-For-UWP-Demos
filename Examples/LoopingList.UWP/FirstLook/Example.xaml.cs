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

namespace LoopingList.FirstLook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Example : Page
    {
        private Random random;
        public Example()
        {
            this.InitializeComponent();

            this.list1.ItemsSource = GetPictureDataSource(0);
            this.list2.ItemsSource = GetPictureDataSource(1);
            this.list3.ItemsSource = GetPictureDataSource(2);

            this.list1.SelectedIndex = this.list2.SelectedIndex = this.list3.SelectedIndex = 1;

            random = new Random();
        }

        private System.Collections.IList GetPictureDataSource(int columnIndex)
        {
            var list = new List<PictureDataItem>();

            for (int i = 0; i < 8; i++)
            {
                PictureDataItem item = new PictureDataItem();
                string theme = "dark";
                string uri = "ms-appx:///LoopingList/FirstLook/Images/" + theme + "/" + (columnIndex + 1) + "." + (i + 1) + ".png";
                item.Picture = uri;

                list.Add(item);
            }

            return list;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.ScrollList(this.list1);
            this.ScrollList(this.list2);
            this.ScrollList(this.list3);
        }

        private void ScrollList(RadLoopingList list)
        {
            int duration = this.random.Next(1500, 3000);
            double offset = this.random.Next(3000, 5000);

            // list.SelectedIndex = 6;

            list.AnimateVerticalOffset(new Duration(TimeSpan.FromMilliseconds(duration)), new CubicEase(), list.VerticalOffset + offset - offset % list.ItemHeight);


        }

    }

    public class PictureDataItem : INotifyPropertyChanged
    {
        private string picture;

        public PictureDataItem()
        {
        }

        public string Picture
        {
            get
            {
                return this.picture;
            }
            set
            {
                this.picture = value;
                this.OnPropertyChanged("Picture");
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
