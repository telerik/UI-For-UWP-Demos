using Windows.System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using QSF.Infrastructure.Helpers;
using System.Windows.Input;

namespace QSF.Controls
{
    public class NavigationListView: Windows.UI.Xaml.Controls.ListView
    {
        protected override void OnKeyDown(KeyRoutedEventArgs e)
        {
            switch (e.Key)
            {
                case VirtualKey.Up:
                    FocusManager.TryMoveFocus(FocusNavigationDirection.Up);
                    e.Handled = true;
                    break;

                case VirtualKey.Down:
                    FocusManager.TryMoveFocus(FocusNavigationDirection.Down);
                    e.Handled = true;
                    break;
                case VirtualKey.Space:
                    // By default Space doesn't raise ItemClick, so we need to manually navigate.
                    var focusedItem = FocusManager.GetFocusedElement() as ListViewItem;
                    if (focusedItem != null && !focusedItem.IsSelected)
                    {
                        // Let base.OnKeyDown to select the item
                        base.OnKeyDown(e);

                        // Execute the navigate command
                        var navigateCommand = this.GetValue(ListViewBaseHelper.ItemClickCommandProperty) as ICommand;
                        if (navigateCommand != null)
                        {
                            var commandParameter = this.GetValue(ListViewBaseHelper.ItemClickCommandParameterProperty) ?? this.SelectedItem;
                            navigateCommand.Execute(commandParameter);
                        }
                    }

                    e.Handled = true;
                    break;
                default:
                    base.OnKeyDown(e);
                    break;
            }
        }
    }
}
