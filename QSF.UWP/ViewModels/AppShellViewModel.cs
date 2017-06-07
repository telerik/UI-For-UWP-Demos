using QSF.Infrastructure;
using QSF.Model;
using QSF.Views;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace QSF.ViewModel
{
    public class AppShellViewModel : NavigatingViewModel
    {
        private NavigationMenuItem selectedNavMenuItem;

        public AppShellViewModel()
        {
            this.NavMenuItems = this.PrepareNavigationItems();
            this.SelectedNavMenuItem = this.NavMenuItems.FirstOrDefault();
        }

        public ObservableCollection<NavigationMenuItem> NavMenuItems { get; set; }

        public NavigationMenuItem SelectedNavMenuItem
        {
            get
            {
                return this.selectedNavMenuItem;
            }

            set
            {
                if (this.selectedNavMenuItem != value)
                {
                    this.selectedNavMenuItem = value;
                    this.OnPropertyChanged();
                }
            }
        }

        protected override void OnNavigateCommandExecuted(object parameter)
        {
            if (parameter == this.NavMenuItems.First())
            {
                // Navigate to Home.
                NavigationService.Instance.Navigate(typeof(HomePage));
                return;
            }

            base.OnNavigateCommandExecuted(parameter);
        }

        internal void UpdateSelection(object parameter)
        {
            if (parameter == null)
            {
                // Select "Home" menu item.
                this.SelectedNavMenuItem = this.NavMenuItems.FirstOrDefault();
                return;
            }

            var exampleInfo = parameter as ExampleInfo;
            if (exampleInfo != null)
            {
                // If parameter is example => select the menu item with corresponding control.
                this.SelectedNavMenuItem =
                    this.NavMenuItems.FirstOrDefault(i => i.NavigationParameter != null && i.NavigationParameter.Examples.Contains(exampleInfo));
                return;
            }

            var controlInfo = parameter as ControlInfo;
            if (controlInfo != null)
            {
                this.SelectedNavMenuItem = this.NavMenuItems.FirstOrDefault(n => n.NavigationParameter == controlInfo);
                return;
            }
        }

        private ObservableCollection<NavigationMenuItem> PrepareNavigationItems()
        {
            var allControls = ModelFactory.GetQuickStartDataSingleton().AllControls.ToList();
            var navItems = allControls.Select(i => new NavigationMenuItem(i)).ToList();
            navItems.Insert(0, new NavigationMenuItem { Label = "Home", Header = "Home", Glyph = Symbol.Home });
            return new ObservableCollection<NavigationMenuItem>(navItems);
        }
    }
}
