using QSF.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;

namespace QSF.Infrastructure.Helpers
{
    public class AutoSuggestBoxHelper
    {
        public static readonly DependencyProperty IsHelperEnabledProperty =
            DependencyProperty.RegisterAttached("IsHelperEnabled", typeof(bool), typeof(AutoSuggestBoxHelper), new PropertyMetadata(false, OnIsHelperEnabledChanged));

        public static readonly DependencyProperty NavigateCommandProperty =
            DependencyProperty.RegisterAttached("NavigateCommand", typeof(ICommand), typeof(AutoSuggestBoxHelper), new PropertyMetadata(null));

        public static bool GetIsHelperEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsHelperEnabledProperty);
        }

        public static void SetIsHelperEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsHelperEnabledProperty, value);
        }

        public static ICommand GetNavigateCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(NavigateCommandProperty);
        }

        public static void SetNavigateCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(NavigateCommandProperty, value);
        }

        private static void OnIsHelperEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var autoSuggestBox = d as AutoSuggestBox;
            if (autoSuggestBox != null && e.NewValue != e.OldValue)
            {
                autoSuggestBox.QuerySubmitted -= OnAutoSuggestBoxQuerySubmitted;
                autoSuggestBox.TextChanged -= OnAutoSuggestBoxTextChanged;

                if ((bool)e.NewValue)
                {
                    autoSuggestBox.QuerySubmitted += OnAutoSuggestBoxQuerySubmitted;
                    autoSuggestBox.TextChanged += OnAutoSuggestBoxTextChanged;
                }
            }
        }

        private static ICollectionView FilterExamplesByText(string text = null)
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                return null;
            }

            var examples = ModelFactory.GetQuickStartDataSingleton().Examples;
            if (!string.IsNullOrEmpty(text))
            {
                // Filter the examples if there is user input
                examples = examples.Where(
                    ex => 
                    ex.HeaderText.ContainsLowerCase(text) || 
                    ex.Keywords.ContainsLowerCase(text));

                if (!examples.Any())
                {
                    return null;
                }
            }

            var cvs = new CollectionViewSource();
            cvs.IsSourceGrouped = true;
            cvs.Source = examples.GroupBy(ex => (ex as ExampleInfo).ControlName);
            return cvs.View;
        }

        private static void OnAutoSuggestBoxQuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            var autoSuggestBox = sender as AutoSuggestBox;
            if (autoSuggestBox != null)
            {
                var navigateCommand = autoSuggestBox.GetValue(AutoSuggestBoxHelper.NavigateCommandProperty) as ICommand;
                if (navigateCommand != null)
                {
                    var navigationTarget = args.ChosenSuggestion ?? autoSuggestBox.Items[0] as ExampleInfo;
                    if (navigationTarget != null)
                    {
                        // Navigate to target example.
                        navigateCommand.Execute(navigationTarget);
                        // Move the keyboard focus out of the control.
                        FocusManager.TryMoveFocus(FocusNavigationDirection.Next);
                    }
                }

                // Clear the input.
                autoSuggestBox.Text = string.Empty;
            }
        }

        private static void OnAutoSuggestBoxTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var autoSuggestBox = sender as AutoSuggestBox;
                var text = autoSuggestBox.Text;

                if (string.IsNullOrEmpty(text))
                {
                    autoSuggestBox.IsSuggestionListOpen = false;
                    autoSuggestBox.ItemsSource = null;
                    return;
                }

                object filteredItems = FilterExamplesByText(text);
                if (filteredItems == null)
                {
                    filteredItems = new List<EmptyTextHolder> { new EmptyTextHolder() };
                }

                autoSuggestBox.ItemsSource = filteredItems;
            }
        }

        private class EmptyTextHolder
        {
            public string HeaderText { get; set; }
            public EmptyTextHolder()
            {
                this.HeaderText = "No Results";
            }
        }
    }
}
