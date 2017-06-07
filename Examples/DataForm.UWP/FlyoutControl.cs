using System;
using System.Linq;
using Windows.UI.ApplicationSettings;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media.Animation;

namespace DataForm
{
    public class FlyoutControl : Control
    {
        // Desired width for the settings UI.
        private double flyoutWidth = 320;

        // This is the container that will hold our custom content.
        private Popup settingsPopup;

        private Action closedCallback;

        public void Show(FrameworkElement child, Action closedCallback)
        {
            this.closedCallback = closedCallback;
            var windowBounds = Window.Current.Bounds;

            // Create a Popup window which will contain our flyout.
            this.settingsPopup = new Popup();
            this.settingsPopup.Closed += OnPopupClosed;

            this.settingsPopup.IsLightDismissEnabled = true;
            this.settingsPopup.Width = flyoutWidth;
            this.settingsPopup.Height = windowBounds.Height;

            // Add the proper animation for the panel.
            this.settingsPopup.ChildTransitions = new TransitionCollection();
            this.settingsPopup.ChildTransitions.Add(new EntranceThemeTransition()
            {
                FromVerticalOffset = 0,
                FromHorizontalOffset = this.flyoutWidth
            });

            // Create a SettingsFlyout the same dimenssions as the Popup.
            child.Width = flyoutWidth;
            child.Height = windowBounds.Height;

            // Place the SettingsFlyout inside our Popup window.
            this.settingsPopup.Child = child;

#if WINDOWS_APP
            // Let's define the location of our Popup.
            this.settingsPopup.HorizontalOffset = SettingsPane.Edge == SettingsEdgeLocation.Right ? (windowBounds.Width - flyoutWidth) : 0;
#endif
            this.settingsPopup.IsOpen = true;
        }

        /// <summary>
        /// When the Popup closes we no longer need to monitor activation changes.
        /// </summary>
        /// <param name="sender">Instance that triggered the event.</param>
        /// <param name="e">Event data describing the conditions that led to the event.</param>
        void OnPopupClosed(object sender, object e)
        {
            this.settingsPopup.Closed -= OnPopupClosed;
            this.settingsPopup.Child = null;

            if (this.closedCallback != null)
            {
                this.closedCallback();
            }
        }
    }
}
