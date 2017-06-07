using System.Linq;
using Telerik.UI.Xaml.Controls.Grid;
using Telerik.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Grid.Customization
{
    public sealed partial class Example : UserControl
    {
        public Example()
        {
            this.InitializeComponent();

            this.DataContext = new SalesByPerson();
        }

        private void OnShowVerticalLinesToggled(object sender, RoutedEventArgs e)
        {
            if (this.radDataGrid == null)
            {
                return;
            }

            var gridLines = this.radDataGrid.GridLinesVisibility;
            var toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch.IsOn)
            {
                gridLines |= GridLinesVisibility.Vertical;
            }
            else
            {
                gridLines &= ~GridLinesVisibility.Vertical;
            }

            this.radDataGrid.GridLinesVisibility = gridLines;
        }

        private void OnCustomGroupHeadersToggled(object sender, RoutedEventArgs e)
        {
            if (this.radDataGrid == null)
            {
                return;
            }

            var isOn = (sender as ToggleSwitch).IsOn;
            if (isOn)
            {
                this.radDataGrid.GroupHeaderTemplateSelector = this.Resources["RegionTemplateSelector"] as DataTemplateSelector;
                this.radDataGrid.GroupHeaderStyleSelector = this.Resources["RegionStyleSelector"] as StyleSelector;
            }
            else
            {
                this.radDataGrid.ClearValue(RadDataGrid.GroupHeaderStyleSelectorProperty);
                this.radDataGrid.ClearValue(RadDataGrid.GroupHeaderTemplateSelectorProperty);
            }
        }

        private void OnConditionalFormattingToggled(object sender, RoutedEventArgs e)
        {
            if (this.radDataGrid == null)
            {
                return;
            }

            var column = this.radDataGrid.Columns.Last() as DataGridTemplateColumn;
            var isOn = (sender as ToggleSwitch).IsOn;
            if (isOn)
            {
                column.CellDecorationStyleSelector = this.Resources["UpDownDecorationStyleSelector"] as StyleSelector;
                column.CellContentTemplateSelector = this.Resources["UpDownTemplateSelector"] as DataTemplateSelector;
            }
            else
            {
                column.ClearValue(DataGridTemplateColumn.CellContentTemplateSelectorProperty);
                column.ClearValue(DataGridTemplateColumn.CellDecorationStyleSelectorProperty);
            }
        }

        private void OnCustomColumnStyleToggled(object sender, RoutedEventArgs e)
        {
            if (this.radDataGrid == null)
            {
                return;
            }

            var column = this.radDataGrid.Columns[2];
            var isOn = (sender as ToggleSwitch).IsOn;
            if (isOn)
            {
                column.CellDecorationStyle = this.Resources["SalesYTDDecorationStyle"] as Style;
            }
            else
            {
                column.ClearValue(DataGridColumn.CellDecorationStyleProperty);
            }
        }

        private void OnCustomColumnHeaderToggled(object sender, RoutedEventArgs e)
        {
            if (this.radDataGrid == null)
            {
                return;
            }

            var column = this.radDataGrid.Columns[2];
            var isOn = (sender as ToggleSwitch).IsOn;
            if (isOn)
            {
                column.HeaderStyle = this.Resources["ColumnHeaderStyle"] as Style;
            }
            else
            {
                column.ClearValue(DataGridColumn.HeaderStyleProperty);
            }
        }

        private void OnAlternateRowToggled(object sender, RoutedEventArgs e)
        {
            if (this.radDataGrid == null)
            {
                return;
            }

            var isOn = (sender as ToggleSwitch).IsOn;
            if (isOn)
            {
                this.radDataGrid.AlternationStep = 2;
            }
            else
            {
                this.radDataGrid.AlternationStep = 0;
            }
        }

        private void OnCellFormattingToggled(object sender, RoutedEventArgs e)
        {
            if (this.radDataGrid == null)
            {
                return;
            }

            var column = this.radDataGrid.Columns[2] as DataGridTextColumn;
            var isOn = (sender as ToggleSwitch).IsOn;
            if (isOn)
            {
                column.CellContentFormat = "{0,0:C0}";
            }
            else
            {
                column.ClearValue(DataGridTextColumn.CellContentFormatProperty);
            }
        }
    }
}
