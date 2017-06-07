using QSF.ViewModel;
using System;
using Windows.ApplicationModel.DataTransfer;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace QSF
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppShell : Page
    {
        public Frame AppFrame
        {
            get
            {
                return this.frameHolder.Content as Frame;
            }
            set
            {
                this.frameHolder.Content = value;
            }
        }

        public AppShellViewModel ViewModel
        {
            get
            {
                return this.DataContext as AppShellViewModel;
            }
        }

        public string HeaderImagePath
        {
            get { return (string)GetValue(HeaderImagePathProperty); }
            set { SetValue(HeaderImagePathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsMobileLayout.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderImagePathProperty =
            DependencyProperty.Register("HeaderImagePath", typeof(string), typeof(AppShell), new PropertyMetadata("ms-appx:///Assets/ProgressLogo.png"));

        public AppShell()
        {
            this.DataContext = new AppShellViewModel();
            this.InitializeComponent();
            NavigationService.Instance.Frame.Navigated += this.OnNavigated;
        }

        private void OnNavigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            this.ViewModel.UpdateSelection(e.Parameter);
            this.RootSplitView.IsPaneOpen = false;
        }

        private async void OnDownloadTrialButtonClick(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri(@"http://www.telerik.com/download/ui-for-universal-windows-platform"));
        }

        private async void OnFeedbackButtonClick(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri(@"http://feedback.telerik.com/Project/167"));
        }

        private void OnShareButtonClick(object sender, RoutedEventArgs e)
        {
            DataTransferManager.ShowShareUI();
        }

        private async void OnWebPageButtonButtonClick(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri(@"http://www.telerik.com/universal-windows-platform-ui"));
        }
    }
}
