using System;
using System.Linq;

namespace QSF.ViewModel
{
    public sealed class ViewModelFactory
    {
        private static readonly ViewModelFactory instance = new ViewModelFactory();

        private ViewModelFactory()
        {
        }

        public static ViewModelFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public HomeViewModel CreateHomeViewModel()
        {
            return new HomeViewModel();
        }

        public ExampleViewModel CreateExampleViewModel()
        {
            return new ExampleViewModel();
        }

        public SearchResultsViewModel CreateSearchResultsViewModel()
        {
            return new SearchResultsViewModel();
        }

        public ControlExamplesViewModel CreateControlExamplesViewModel()
        {
            return new ControlExamplesViewModel();
        }
    }
}
