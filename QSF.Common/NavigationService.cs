using System;
using Windows.UI.Xaml.Controls;

namespace QSF
{
    public sealed class NavigationService
    {
        private static readonly NavigationService instance = new NavigationService() { IsBackNavigationAllowed = true };
        private Frame frame;
        private Type subExamplePageType;

        /// <summary>
        /// Initializes this navigation service with an empty instance of Frame.
        /// </summary>
        private NavigationService()
        {
            this.frame = new Frame();
        }

        public static NavigationService Instance
        {
            get
            {
                return instance;
            }
        }

        public bool IsBackNavigationAllowed { get; set; }

        /// <summary>
        /// Frame to use when navigating.
        /// </summary>
        public Frame Frame
        {
            get
            {
                return this.frame;
            }
        }

        public void SetSubExamplePageType(Type type)
        {
            Instance.subExamplePageType = type;
        }

        public void GoBack()
        {
            if (this.IsBackNavigationAllowed)
            {
                this.frame.GoBack();
            }
        }

        public void GoForward()
        {
            this.frame.GoForward();
        }

        /// <summary>
        /// Navigate to the view, passing the specified parameter.
        /// </summary>
        /// <typeparam name="T">Type of the view to navigate to.</typeparam>
        /// <param name="parameter">Parameter to pass to the view.</param>
        /// <returns>True if navigation is not canceled; otherwise, false.</returns>
        public bool Navigate<T>(object parameter = null)
        {
            var type = typeof(T);

            return this.Navigate(type, parameter);
        }

        /// <summary>
        /// Navigate to the view, passing the specified parameter.
        /// <summary>
        /// <param name="source">Type of the view to navigate to</param>
        /// <param name="parameter">Parameter to pass to the view.</param>
        /// <returns>True if navigation is not canceled; otherwise, false.</returns>
        public bool Navigate(Type source, object parameter = null)
        {
            return this.frame.Navigate(source, parameter);
        }

        public bool NavigateToExample(object parameter = null)
        {
            var source = subExamplePageType;

            if (source == null)
            {
                return false;
            }

            return this.frame.Navigate(source, parameter);
        }
    }
}