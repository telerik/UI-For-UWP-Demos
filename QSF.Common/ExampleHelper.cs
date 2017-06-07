using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace QSF.Common
{
    public static class ExampleHelper
    {
        // Using a DependencyProperty as the backing store for ConfigurationPanel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ConfigurationPanelProperty =
            DependencyProperty.RegisterAttached("ConfigurationPanel", typeof(Panel), typeof(ExampleHelper), new PropertyMetadata(null));

        // Using a DependencyProperty as the backing store for ConfigurationPanelIsOnTop.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ConfigurationPanelShrinksExampleProperty =
            DependencyProperty.RegisterAttached("ConfigurationPanelShrinksExample", typeof(bool), typeof(ExampleHelper), new PropertyMetadata(false));

        // Using a DependencyProperty as the backing store for HintsLayer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HintsCollectionProperty =
            DependencyProperty.RegisterAttached("HintsCollection", typeof(HintsCollection), typeof(ExampleHelper), new PropertyMetadata(null));

        public static Panel GetConfigurationPanel(DependencyObject obj)
        {
            return (Panel)obj.GetValue(ConfigurationPanelProperty);
        }

        public static bool GetConfigurationPanelShrinksExample(DependencyObject obj)
        {
            return (bool)obj.GetValue(ConfigurationPanelShrinksExampleProperty);
        }

        public static HintsCollection GetHintsCollection(DependencyObject obj)
        {
            return (HintsCollection)obj.GetValue(HintsCollectionProperty);
        }

        public static void SetConfigurationPanel(DependencyObject obj, Panel value)
        {
            obj.SetValue(ConfigurationPanelProperty, value);
        }

        public static void SetConfigurationPanelShrinksExample(DependencyObject obj, bool value)
        {
            obj.SetValue(ConfigurationPanelShrinksExampleProperty, value);
        }

        public static void SetHintsCollection(DependencyObject obj, HintsCollection value)
        {
            obj.SetValue(HintsCollectionProperty, value);
        }
    }
}