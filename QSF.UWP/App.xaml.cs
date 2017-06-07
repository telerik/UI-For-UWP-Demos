using QSF.Common;
using QSF.Infrastructure;
using QSF.Model;
using QSF.Views;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.DataTransfer;
using Windows.Graphics.Display;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.ViewManagement;
using Windows.UI;

namespace QSF
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        private IQuickStartData quickStartData;
        private DataTransferManager shareManager;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.RequestedTheme = ApplicationTheme.Light;
            this.InitializeComponent();
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Landscape;
            this.Suspending += this.OnSuspending;
            this.UnhandledException += this.OnAppUnhandledException;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected async override void OnLaunched(LaunchActivatedEventArgs e)
        {
            await this.InitializeXMLResourcesIfNeeded();

            AppShell appShell = Window.Current.Content as AppShell;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (appShell == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                var rootFrame = NavigationService.Instance.Frame;
                rootFrame.NavigationFailed += OnNavigationFailed;
                rootFrame.Navigated += OnNavigated;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                if (string.IsNullOrEmpty(e.Arguments))
                {
                    NavigationService.Instance.Navigate(typeof(HomePage));
                }
                else
                {
                    NavigationService.Instance.Navigate(typeof(ExamplePage), e.Arguments);
                }

                this.UpdateBackButtonVisibility(rootFrame);
                SystemNavigationManager.GetForCurrentView().BackRequested += this.OnNavigationBackRequested;

                var appView = ApplicationView.GetForCurrentView();
                appView.SetPreferredMinSize(new Windows.Foundation.Size { Width = 320, Height = 569 });
                appView.TitleBar.ButtonBackgroundColor = CodeFormatting.ColorConverter.ConvertFromString("#01FFFFFF");
                appView.TitleBar.ButtonHoverBackgroundColor = CodeFormatting.ColorConverter.ConvertFromString("#FFE6E6E6");
                appView.TitleBar.ButtonHoverForegroundColor = CodeFormatting.ColorConverter.ConvertFromString("#FF000000");
                appView.TitleBar.ButtonPressedBackgroundColor = CodeFormatting.ColorConverter.ConvertFromString("#FFCCCCCC");
                appView.TitleBar.ButtonPressedForegroundColor = CodeFormatting.ColorConverter.ConvertFromString("#FF000000");

                // Place the frame in the current Window and ensure that it is active
                appShell = new AppShell();
                appShell.AppFrame = rootFrame;
                Window.Current.Content = appShell;

                // Checks whether the device has StatusBar and hides it
                if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
                {
                    await StatusBar.GetForCurrentView().HideAsync();
                }
            }

            if (e.PrelaunchActivated == false)
            {
                if (appShell.AppFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    NavigationService.Instance.Navigate(typeof(HomePage), e.Arguments);
                }
            }

            Window.Current.Activate();
        }

        protected override void OnActivated(IActivatedEventArgs args)
        {
            if (this.shareManager == null)
            {
                this.shareManager = DataTransferManager.GetForCurrentView();
                this.shareManager.DataRequested += this.OnShareManagerDataRequested;
            }

            base.OnActivated(args);
        }

        private async Task InitializeXMLResourcesIfNeeded()
        {
            if (this.quickStartData == null)
            {
                XElement xmlRootElement = (await this.GetExamplesXMLRootElementAsync()).Root;
                ModelFactory.InitializeQuickStartData(xmlRootElement);
                this.quickStartData = ModelFactory.GetQuickStartDataSingleton();
            }
        }

        private async Task<XDocument> GetExamplesXMLRootElementAsync()
        {
            const string filePath = "Examples.xml";
            var sampleFile = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(filePath);
            var readStream = await sampleFile.OpenAsync(FileAccessMode.Read);
            XDocument document = XDocument.Load(readStream.AsStreamForRead());
            return document;
        }

        private void UpdateBackButtonVisibility(Frame frame)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    frame.Content is HomePage
                    ? AppViewBackButtonVisibility.Collapsed
                    : AppViewBackButtonVisibility.Visible;
        }

        private void OnNavigationBackRequested(object sender, BackRequestedEventArgs e)
        {
            var frameContent = NavigationService.Instance.Frame.Content;
            if (frameContent is ExamplePage)
            {
                // If we are on example page -> navigate to the control page if there are more than one examples.
                var examplePage = frameContent as ExamplePage;

                if (examplePage.ViewModel.Control.Examples.Count > 1)
                {
                    NavigationService.Instance.Navigate(typeof(ControlExamplesPage), examplePage.ViewModel.Control);
                }
                else
                {
                    NavigationService.Instance.Navigate(typeof(HomePage));
                }
            }
            else if (frameContent is ControlExamplesPage)
            {
                // If we are on control page -> navigate to the home page.
                NavigationService.Instance.Navigate(typeof(HomePage));
            }

            e.Handled = true;
        }

        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            this.UpdateBackButtonVisibility((Frame)sender);
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        private async void OnAppUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LoggerService.LogAsync(string.Format("Exception occured: {0}", e.Exception.Message));
            await new Windows.UI.Popups.MessageDialog(string.Format("Exception occured: {0}", e.Exception.Message)).ShowAsync();
        }

        private void OnShareManagerDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            string dataPackageTitle = "Telerik UI for Windows 10";
            string uriValue = "http://www.telerik.com/products/windows-metro.aspx";
            string dataPackageDescription = "The number One Native Toolset for Building Windows Store Apps for the enterprises and consumers with either XAML or HTML.";

            Uri dataPackageUri = new Uri(uriValue);
            DataPackage requestData = args.Request.Data;

            requestData.Properties.Description = dataPackageDescription;
            requestData.Properties.Title = dataPackageTitle;
            requestData.SetApplicationLink(dataPackageUri);
        }
    }
}
