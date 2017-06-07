using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.UI.Xaml.Controls.Input.AutoCompleteBox;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace AutoCompleteBox.InlineSuggestions
{
    public sealed partial class Example : UserControl
    {
        private WebServiceTextSearchProvider provider;
        private Movie lastSuggestedMovie;
        private string lastInputSearch;

        public Example()
        {
            this.InitializeComponent();

            this.provider = new WebServiceTextSearchProvider();
            this.provider.InputChanged += webServiceProvider_InputChanged;
            this.autoCompleteBox.InitializeSuggestionsProvider(this.provider);
            this.ProgressBar.Visibility = Visibility.Collapsed;
            this.ItemDetails.Visibility = Visibility.Collapsed;
            this.NoMovieText.Visibility = Visibility.Collapsed;
            this.ListViewItems.AddHandler(UIElement.PointerPressedEvent, new PointerEventHandler(ListViewItemsPointerPressed), true);
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
                this.CheckFlixsterPanelVisibility();
                this.provider.Reset();
            }
        }

        private void OnMoviesDelivered(IEnumerable<Movie> movies)
        {
            if (!this.provider.HasItems)
            {
                this.NoMovieText.Visibility = Visibility.Visible;
                this.FlixsterPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.NoMovieText.Visibility = Visibility.Collapsed;
                var item = this.ListViewItems.Items.ElementAt(0);
                if (item != null)
                {
                    this.ListViewItems.ScrollIntoView(item);
                }
            }

            if (!string.IsNullOrEmpty(this.provider.InputString))
            {
                this.provider.LoadItems(movies);
                this.ProgressBar.Visibility = Visibility.Collapsed;
                this.FlixsterPanel.Visibility = Visibility.Collapsed;
                if (this.provider.HasItems)
                {
                    this.NoMovieText.Visibility = Visibility.Collapsed;
                }
                else
                {
                    this.NoMovieText.Visibility = Visibility.Visible;
                }
            }
            else
            {
                this.provider.Reset();
                this.CheckFlixsterPanelVisibility();
                this.NoMovieText.Visibility = Visibility.Collapsed;

            }
        }

        private void autoCompleteBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.autoCompleteBox.Text != this.lastInputSearch)
            {
                this.ProgressBar.Visibility = Visibility.Collapsed;
            }
            this.NoMovieText.Visibility = Visibility.Collapsed;

            if (string.IsNullOrEmpty(this.autoCompleteBox.Text))
            {
                this.CheckFlixsterPanelVisibility();
            }
            if (this.ItemDetails.Visibility == Visibility.Visible && this.autoCompleteBox.Text != this.lastSuggestedMovie.Title)
            {
                this.ListViewItems.Visibility = Visibility.Visible;
                this.ItemDetails.Visibility = Visibility.Collapsed;
            }

            if (string.IsNullOrEmpty(this.autoCompleteBox.Text))
            {
                this.CheckFlixsterPanelVisibility();
            }
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            this.autoCompleteBox.Suggest(this.lastInputSearch);

            this.ItemDetails.Visibility = Visibility.Collapsed;
            this.ListViewItems.Visibility = Visibility.Visible;
        }

        private void ListViewItemsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.autoCompleteBox.FilteredItems != null)
            {
                this.lastInputSearch = this.autoCompleteBox.Text;
                this.lastSuggestedMovie = (e.AddedItems[0] as Movie);
                this.ItemDetails.DataContext = lastSuggestedMovie;
                this.ItemDetails.Visibility = Visibility.Visible;
                this.ListViewItems.Visibility = Visibility.Collapsed;
                this.autoCompleteBox.Text = lastSuggestedMovie.Title;
                this.FlixsterPanel.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }

            this.FlixsterPanel.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void ListViewItemsPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            this.LostFocusButton.Focus(FocusState.Pointer);
        }

        private void CheckFlixsterPanelVisibility()
        {
            if (this.ItemDetails.Visibility == Visibility.Visible)
            {
                this.FlixsterPanel.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
            else
            {
                this.FlixsterPanel.Visibility = Visibility.Visible;
                this.NoMovieText.Visibility = Visibility.Collapsed;
            }
        }
    }
}
