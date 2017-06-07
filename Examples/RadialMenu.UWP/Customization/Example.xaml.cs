using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Telerik.UI.Xaml.Controls.Primitives;
using Telerik.UI.Xaml.Controls.Primitives.Menu;
using Telerik.UI.Xaml.Controls.Primitives.Menu.Commands;
using Windows.Foundation;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace RadialMenu.Customization
{
    public sealed partial class Example : UserControl
    {
        public Example()
        {
            this.InitializeComponent();
            this.SizeChanged += Example_SizeChanged;

            this.PositionComboBox.ItemsSource = Enum.GetValues(typeof(Position)).Cast<Position>();
        }

        private void Example_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var width = e.NewSize.Width;
            if (width < 1008)
            {
                this.listView.ItemsPanel = this.Resources["narrowItemsPanelTemplate"] as ItemsPanelTemplate;
                this.listView.Margin = new Thickness(0);
            }
            else
            {
                this.listView.ItemsPanel = this.Resources["wideItemsPanelTemplate"] as ItemsPanelTemplate;
            }
        }

        private void ListViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = sender as ListView;

            foreach (var item in listView.Items)
            {
                var selecter = item as PictureInfo;
                selecter.IsOpen = false;
            }

            listView.SelectedItem = null;
        }
    }
}
