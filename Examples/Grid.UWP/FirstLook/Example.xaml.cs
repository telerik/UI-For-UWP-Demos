using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Grid.FirstLook
{
    public sealed partial class Example : UserControl
    {
        public Example()
        {
            this.InitializeComponent();

            this.DataContext = SalesStatistics.Load();
            this.categoriesList.SelectedIndex = 0;
        }
    }
}
