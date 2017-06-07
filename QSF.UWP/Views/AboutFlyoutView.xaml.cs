using System;
using System.Linq;
using Windows.UI.ApplicationSettings;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace QSF.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class AboutFlyoutView : QSF.Common.LayoutAwarePage
    {
        public AboutFlyoutView()
        {
            this.InitializeComponent();
            this.versionTextBlock.Text = "Version: " + QSFVersion.GetReleaseVersion();
        }

        /// <summary>
        /// This is the click handler for the back button on the Flyout.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MySettingsBackClicked(object sender, RoutedEventArgs e)
        {
            // First close our Flyout.
            Popup parent = this.Parent as Popup;
            if (parent != null)
            {
                parent.IsOpen = false;
            }

            //SettingsPane.Show();
        }
    }
}
