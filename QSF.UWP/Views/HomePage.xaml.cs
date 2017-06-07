using QSF.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace QSF.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    [TemplateVisualState(Name = "SmallState")]
    public sealed partial class HomePage : QSF.Common.LayoutAwarePage
    {
        public HomePage()
        {
            this.InitializeComponent();
        }

        public HomeViewModel ViewModel
        {
            get
            {
                return this.DataContext as HomeViewModel ?? new HomeViewModel();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var viewModel = this.ViewModel;
            this.DataContext = viewModel;
            base.OnNavigatedTo(e);
        }
    }
}