using System;
using System.Collections.Generic;
using System.Linq;
using QSF.Model;
using QSF.ViewModel;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237
namespace QSF.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    [TemplateVisualState(Name = "SmallState")]
    public sealed partial class ControlExamplesPage : QSF.Common.LayoutAwarePage
    {
        public ControlExamplesPage()
        {
            this.InitializeComponent();
        }

        public ControlExamplesViewModel ViewModel
        {
            get
            {
                var viewModel = this.DataContext as ControlExamplesViewModel ?? ViewModelFactory.Instance.CreateControlExamplesViewModel();

                return viewModel;
            }
        }
        
        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var viewModel = this.ViewModel;
            viewModel.CurrentControlInfo = e.Parameter as IControlInfo;

            this.DataContext = viewModel;
            
            base.OnNavigatedTo(e);
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }
    }
}