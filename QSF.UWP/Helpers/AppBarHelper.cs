using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace QSF.Helpers
{
    public class AppBarHelper
    {
        // Using a DependencyProperty as the backing store for CanOpen.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanOpenProperty =
            DependencyProperty.RegisterAttached("CanOpen", typeof(bool), typeof(AppBarHelper), new PropertyMetadata(true, OnCanOpenPropertyChanged));

        public static bool GetCanOpen(DependencyObject obj)
        {
            return (bool)obj.GetValue(CanOpenProperty);
        }

        public static void SetCanOpen(DependencyObject obj, bool value)
        {
            obj.SetValue(CanOpenProperty, value);
        }

        static readonly Action<AppBar> unhookFromEvents = (AppBar appBar) =>
        {
            appBar.Unloaded -= unloadedHandler;
            appBar.Opened -= openedHandler;
        };

        static readonly EventHandler<object> openedHandler = (s, args) => 
        {
            (s as AppBar).IsOpen = false;
        };

        static readonly RoutedEventHandler unloadedHandler = (s, args) =>
        {
                //unhookFromEvents();
        };

        private static void OnCanOpenPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var canOpen = (bool)e.NewValue;
            var appBar = d as AppBar;

            if (canOpen)
            {
                unhookFromEvents(appBar);

                appBar.Visibility = Visibility.Visible;
            }
            else
            {
                // close app bar if opened
                appBar.IsOpen = false;

                appBar.Unloaded += unloadedHandler;
                appBar.Opened += openedHandler;

                appBar.Visibility = Visibility.Collapsed;
            }
        }
    }
}