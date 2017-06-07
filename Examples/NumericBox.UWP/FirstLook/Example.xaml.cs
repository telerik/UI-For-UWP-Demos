using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace NumericBox.FirstLook
{
    public sealed partial class Example : UserControl
    {
        public Example()
        {
            this.InitializeComponent();

            var viewModel = new ExampleViewModel();
            viewModel.Background = Application.Current.Resources["TelerikSelectedBrush"] as Brush;

            this.DataContext = viewModel;
        }
    }
}
