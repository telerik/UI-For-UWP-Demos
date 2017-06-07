using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telerik.UI.Xaml.Controls.Input.AutoCompleteBox;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AutoCompleteBox.FirstLook
{
    public sealed partial class Example : UserControl
    {
        private WebServiceTextSearchProvider provider;

        public Example()
        {
            this.InitializeComponent();

            this.provider = new WebServiceTextSearchProvider();
            this.provider.InputChanged += webServiceProvider_InputChanged;
            this.autoCompleteBox.InitializeSuggestionsProvider(this.provider);

            this.ProgressBar.Visibility = Visibility.Collapsed;
        }

        private void webServiceProvider_InputChanged(object sender, EventArgs e)
        {
            string inputString = this.provider.InputString;
            if (!string.IsNullOrEmpty(inputString))
            {
                this.ProgressBar.Visibility = Visibility.Visible;

                MoviesWebApi.GetMovies(inputString, this.OnMoviesDelivered);
            }
            else
            {
                this.provider.Reset();
            }
        }

        private void OnMoviesDelivered(IEnumerable<Movie> movies)
        {
            if (!string.IsNullOrEmpty(this.provider.InputString))
            {
                this.provider.LoadItems(movies);
            }
            else
            {
                this.provider.Reset();
            }

            this.ProgressBar.Visibility = Visibility.Collapsed;
        }

        private void autoCompleteBoxLostFocus(object sender, RoutedEventArgs e)
        {
            this.LostFocusButton.Focus(FocusState.Pointer);
        }

        private void autoCompleteBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                this.MovieDetails.Visibility = Visibility.Visible;
            }
            else
            {
                this.MovieDetails.Visibility = Visibility.Collapsed;
            }
        }
    }
}
