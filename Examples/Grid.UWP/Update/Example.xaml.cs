using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Grid.Update
{
    public sealed partial class Example : UserControl
    {
        public Example()
        {
            this.InitializeComponent();

            this.Loaded += Example_Loaded;
            this.Unloaded += Example_Unloaded;
        }

        void Example_Loaded(object sender, RoutedEventArgs e)
        {
            var model = this.layoutRoot.Resources["Model"] as DataUpdateViewModel;
            model.OnLoaded();
        }

        void Example_Unloaded(object sender, RoutedEventArgs e)
        {
            var model = this.layoutRoot.Resources["Model"] as DataUpdateViewModel;
            model.OnUnloaded();
        }
    }
}
