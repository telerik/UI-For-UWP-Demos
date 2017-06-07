using System;
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

namespace Grid.GroupingUI
{
    public sealed partial class Example : UserControl
    {
        public Example()
        {
            this.InitializeComponent();

            this.DataContext = new SalesViewModel();
        }

        private void OnShowGroupingPanelToggled(object sender, RoutedEventArgs e)
        {
            if (this.radGrid == null)
            {
                return;
            }

            var toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch.IsOn)
            {
                this.radGrid.UserGroupMode = DataGridUserGroupMode.Auto;
            }
            else
            {
                this.radGrid.UserGroupMode = DataGridUserGroupMode.Disabled;
            }
        }

        private void OnEnableColumnGroupingToggled(object sender, RoutedEventArgs e)
        {
            if (this.radGrid == null)
            {
                return;
            }

            var toggleSwitch = sender as ToggleSwitch;
            (this.radGrid.DragBehavior as ExampleDragBehavior).IsGroupByColumnEnabled = toggleSwitch.IsOn;
        }

        private void OnEnableUngroupingToggled(object sender, RoutedEventArgs e)
        {
            if (this.radGrid == null)
            {
                return;
            }

            var toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch.IsOn)
            {
                this.radGrid.Commands.Clear();
            }
            else
            {
                this.radGrid.Commands.Add(new FlyoutGroupHeaderTapCommand());
            }
        }

        private void OnEnableGroupReorderingToggled(object sender, RoutedEventArgs e)
        {
            if (this.radGrid == null)
            {
                return;
            }

            var toggleSwitch = sender as ToggleSwitch;
            (this.radGrid.DragBehavior as ExampleDragBehavior).IsGroupHeaderReorderEnabled = toggleSwitch.IsOn;
        }
    }
}
