using System;
using System.Linq;
using QSF.Common;
using QSF.Controls;
using QSF.Helpers;
using QSF.Infrastructure;
using QSF.Model;
using QSF.ViewModel;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237
namespace QSF.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    [TemplateVisualState(Name = "SmallState")]
    public sealed partial class ExamplePage : QSF.Common.LayoutAwarePage
    {
        private IExampleInfo previousExample;

        public ExamplePage()
        {
            this.InitializeComponent();

            EventHandler<object> navigationToNextAnimationCompleted = null;
            navigationToNextAnimationCompleted = (s, e) =>
            {
                this.NavigationToNextAnimation.Completed -= navigationToNextAnimationCompleted;
                this.ViewModel.InitializeHints();
            };

            this.NavigationToNextAnimation.Completed += navigationToNextAnimationCompleted;

        }

        public ExampleViewModel ViewModel
        {
            get
            {
                var viewModel = this.DataContext as ExampleViewModel ?? new ExampleViewModel();

                return viewModel;
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            // close configurator in order to be closed for the next example that will be opened
            this.configuratorButton.IsChecked = false;
            this.CloseConfigurator();

            // set previousExample in order to be able to track whether we've been 
            // navigating from and determine how to animate the example area
            this.previousExample = this.ViewModel.Example;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var viewModel = this.ViewModel;
            IExampleInfo exampleInfo = e.Parameter as IExampleInfo ?? ModelFactory.GetQuickStartDataSingleton().Examples.Single(ex => ex.Name.Equals(e.Parameter));

            viewModel.Initialize(exampleInfo);

            this.DataContext = viewModel;

            base.OnNavigatedTo(e);

            this.rootPivot.SelectedIndex = 0;

            this.BeginEntranceAnimation();
        }

        private void BeginEntranceAnimation()
        {
            int indexOfPrevious = -1;
            int indexOfCurrent = 0;

            if (this.previousExample != null)
            {
                indexOfPrevious = ModelFactory.GetQuickStartDataSingleton().Examples.ToList().IndexOf(this.previousExample);
                indexOfCurrent = ModelFactory.GetQuickStartDataSingleton().Examples.ToList().IndexOf(this.ViewModel.Example);
            }

            if (indexOfCurrent > indexOfPrevious)
            {
                this.NavigationToNextAnimation.Begin();
            }
            else
            {
                this.NavigationToPreviousAnimation.Begin();
            }
        }

        private void CloseConfigurator()
        {
            bool configPanelIsOnTopOfExample = (bool)(this.example.Content as DependencyObject).GetValue(ExampleHelper.ConfigurationPanelShrinksExampleProperty);

            if (configPanelIsOnTopOfExample)
            {
                VisualStateManager.GoToState(this, "ConfiguratorClosedOnTop", false);
                this.CloseConfiguratorOnTop.Begin();
            }
            else
            {
                VisualStateManager.GoToState(this, "ConfiguratorClosed", false);
                this.CloseConfiguratorAnimation.Begin();
            }
        }

        private void OnDecreaseFontSizeClicked(object sender, RoutedEventArgs e)
        {
            if (this.codeViewer.FontSize > 8)
            {
                this.codeViewer.FontSize = this.codeViewer.FontSize - 2;
            }
        }

        private void OnDescriptionFlyoutButtonClick(object sender, RoutedEventArgs e)
        {
            var flyout = new FlyoutControl();
            flyout.Show(new DescriptionFlyoutView { DataContext = this.DataContext }, null);
        }

        private void OnIncreaseFontSizeButtonClicked(object sender, RoutedEventArgs e)
        {
            if (this.codeViewer.FontSize < 32)
            {
                this.codeViewer.FontSize = this.codeViewer.FontSize + 2;
            }
        }

        private void OnSettingChanged(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            bool isConfiguratorOpen = (sender as ToggleButton).IsChecked.Value;

            if (isConfiguratorOpen)
            {
                this.OpenConfigurator();
            }
            else
            {
                this.CloseConfigurator();
            }
        }

        private void OpenConfigurator()
        {
            bool configPanelIsOnTopOfExample = (bool)(this.example.Content as DependencyObject).GetValue(ExampleHelper.ConfigurationPanelShrinksExampleProperty);

            if (configPanelIsOnTopOfExample)
            {
                VisualStateManager.GoToState(this, "ConfiguratorOpenedOnTop", false);
                this.OpenConfiguratorOnTop.Begin();
            }
            else
            {
                VisualStateManager.GoToState(this, "ConfiguratorOpened", false);
                this.OpenConfiguratorAnimation.Begin();
            }
        }
    }
}
