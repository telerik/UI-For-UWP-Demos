using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace RangeSlider.FirstLook
{
    public sealed partial class Example : UserControl
    {
        private ViewModel viewModel;

        public Example()
        {
            this.InitializeComponent();
            this.viewModel = this.Resources["viewModel"] as ViewModel;
            this.LoadMovies();
        }

        private void OnApplyFilterClick(object sender, RoutedEventArgs e)
        {
            if (this.viewModel != null)
            {
                this.viewModel.UpdateDurationRange();
                this.viewModel.FilterMovies();
            }
        }

        private void OnClearFilterClick(object sender, RoutedEventArgs e)
        {
            if (this.viewModel != null)
            {
                this.viewModel.ClearFilter();
            }
        }

        private void LoadMovies()
        {
            MoviesApi.GetMovies(this.OnMoviesDelivered);
        }

        private void OnMoviesDelivered(MoviesQueryContext context)
        {
            this.viewModel.AllMovies = context.Movies;
            this.viewModel.FilterMovies();
        }
    }
}
