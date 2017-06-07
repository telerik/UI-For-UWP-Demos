using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Telerik.UI.Xaml.Controls.Grid;
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

namespace Grid.Selection
{
    public sealed partial class Example : UserControl
    {
        public Example()
        {
            this.InitializeComponent();

            //Ensure that xaml bindings have been updated and the combobox has updated its selecteditem to cell selection mode.
            var warningSuppression = this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Low, () => PresectCells());
        }

        private void PresectCells()
        {
            var items = this.dataGrid.ItemsSource as IList;

            for (int i = 2; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    this.dataGrid.SelectCell(new DataGridCellInfo(items[i],this.dataGrid.Columns[j]));
                }
            }
        }     
    }
}
