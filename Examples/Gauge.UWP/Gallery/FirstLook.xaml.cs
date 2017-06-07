using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using QSF.Common.Examples;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Gauge.Gallery
{
    public sealed partial class FirstLook : UserControl
    {
        public FirstLook()
        {
            this.InitializeComponent();

            this.Loaded += this.OnLoaded;
            this.Unloaded += this.OnUnloaded;

            RandomViewModel model = new RandomViewModel();
            for (int i = 1; i <= 3; i++)
            {
                GalleryItemModel item = new GalleryItemModel("Gauge/Gallery") { TemplateName = "Gauge" + i };
                model.Items.Add(item);
            }

            model.SelectedItem = model.Items[0];

            this.DataContext = model;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            (this.DataContext as RandomViewModel).StartTimer();
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            (this.DataContext as RandomViewModel).StopTimer();
        }
    }
}
