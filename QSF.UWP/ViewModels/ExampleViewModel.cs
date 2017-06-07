using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using QSF.Common;
using QSF.Infrastructure;
using QSF.Infrastructure.CodeView;
using QSF.Infrastructure.Helpers;
using QSF.Infrastructure.Model;
using QSF.Model;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using QSF.Common.Examples;

namespace QSF.ViewModel
{
    public class ExampleViewModel : NavigatingViewModel
    {
        private object configuratorObject;

        private IControlInfo control;
        private IExampleInfo example;
        private IEnumerable<CodeFileInfo> exampleCodeFiles;
        private CollectionViewSource exampleCodeFilesCollectionViewSource;
        private bool exampleHintsAreVisible;

        private bool exampleIsPinned;
        private object exampleObject;
        private HintsCollection hints;
        private Views.ExamplePage examplePage;

        private object navigationContext;

        public ExampleViewModel()
        {
            this.TogglePinnedCommand = new DelegateCommand(this.OnTogglePinnedCommandExecuted);
        }

        public ExampleViewModel(Views.ExamplePage examplePage)
        {
            // TODO: Complete member initialization
            this.examplePage = examplePage;
        }

        public object NavigationContext
        {
            get { return navigationContext; }
            set
            {
                navigationContext = value;
                this.OnPropertyChanged();
            }
        }


        public object ConfiguratorObject
        {
            get
            {
                if (this.configuratorObject == null && this.ExampleObject != null)
                {
                    this.configuratorObject = (this.ExampleObject as DependencyObject).GetValue(ExampleHelper.ConfigurationPanelProperty);
                }

                return this.configuratorObject;
            }
        }

        public IControlInfo Control
        {
            get
            {
                return this.control;
            }
            set
            {
                this.control = value;
                this.OnPropertyChanged("Control");
            }
        }

        public IExampleInfo Example
        {
            get
            {
                return this.example;
            }
            set
            {
                this.example = value;
                this.OnPropertyChanged("Example");
                this.OnPropertyChanged("ExampleObject");
                this.OnPropertyChanged("ConfiguratorObject");
                this.OnPropertyChanged("ExampleHintsCollection");
                this.OnPropertyChanged("ExampleHasConfigurator");
                this.OnPropertyChanged("ExampleHasHints");
                this.OnPropertyChanged("NextExample");
                this.OnPropertyChanged("PreviousExample");
                this.OnPropertyChanged("CanExamplePinToDesktop");
            }
        }

        public IEnumerable<CodeFileInfo> ExampleCodeFiles
        {
            get
            {
                return this.exampleCodeFiles;
            }
            set
            {
                this.exampleCodeFiles = value;
                this.OnPropertyChanged("ExampleCodeFiles");
            }
        }

        public CollectionViewSource ExampleCodeFilesCollectionViewSource
        {
            get
            {
                return this.exampleCodeFilesCollectionViewSource;
            }
            set
            {
                this.exampleCodeFilesCollectionViewSource = value;
                this.OnPropertyChanged("ExampleCodeFilesCollectionViewSource");
            }
        }

        public object ExampleHasConfigurator
        {
            get
            {
                return this.ConfiguratorObject != null;
            }
        }

        public bool ExampleHasHints
        {
            get
            {
                return this.ExampleHintsCollection != null && this.ExampleHintsCollection.Count > 0;
            }
        }

        public bool ExampleHintsAreVisible
        {
            get
            {
                return this.exampleHintsAreVisible && this.ExampleHintsCollection != null && this.ExampleHintsCollection.Count > 0;
            }
            set
            {
                this.exampleHintsAreVisible = value;

                // add a flag in app storage that this example's hint has already been seen
                HintsHelper.AddOpenedHint(this.Example.Name);

                this.OnPropertyChanged("ExampleHintsAreVisible");
            }
        }

        public HintsCollection ExampleHintsCollection
        {
            get
            {
                if (this.hints == null)
                {
                    this.hints = (this.ExampleObject as DependencyObject).GetValue(ExampleHelper.HintsCollectionProperty) as HintsCollection;
                }

                return this.hints;
            }
        }

        public bool ExampleIsPinned
        {
            get
            {
                return this.exampleIsPinned;
            }
            set
            {
                this.exampleIsPinned = value;
                this.OnPropertyChanged("ExampleIsPinned");
            }
        }

        public bool CanExamplePinToDesktop
        {
            get
            {
                return this.Example.CanPinToDesktop;
            }
        }

        public object ExampleObject
        {
            get
            {
                if (this.exampleObject == null && this.example != null)
                {
                    this.exampleObject = ExampleLoader.LoadExampleContent(this.example);
                }

                return this.exampleObject;
            }
        }

        public IExampleInfo NextExample
        {
            get
            {
                int currentIndex = ModelFactory.GetQuickStartDataSingleton().Examples.ToList().IndexOf(this.example);
                int nextIndex = currentIndex + 1;

                if (nextIndex < ModelFactory.GetQuickStartDataSingleton().Examples.Count())
                {
                    return ModelFactory.GetQuickStartDataSingleton().Examples.ToList()[nextIndex];
                }

                return null;
            }
        }

        public IExampleInfo PreviousExample
        {
            get
            {
                int currentIndex = ModelFactory.GetQuickStartDataSingleton().Examples.ToList().IndexOf(this.example);
                int prevIndex = currentIndex - 1;

                if (prevIndex >= 0)
                {
                    return ModelFactory.GetQuickStartDataSingleton().Examples.ToList()[prevIndex];
                }

                return null;
            }
        }

        public ICommand TogglePinnedCommand { get; private set; }

        public void Initialize(IExampleInfo exampleInfo)
        {
            this.exampleObject = null;
            this.configuratorObject = null;
            this.hints = null;
            this.Example = exampleInfo;
            this.Control = exampleInfo.ExampleGroup.Control;
            this.ExampleCodeFilesCollectionViewSource = new CollectionViewSource()
            {
                Source = ExampleSourceCodeHelper.GetCodeFilesForExample(exampleInfo)
            };

            var warningSuppression = this.RefreshAsyncProperties();
        }

        public void Initialize(ISubExample exampleInfo)
        {
            this.exampleObject = null;
            this.configuratorObject = null;
            this.hints = null;
            this.Example = new ExampleInfo { ControlName = exampleInfo.PackageName, PackageName = exampleInfo.PackageName, Name = exampleInfo.Name, HeaderText = exampleInfo.Title };// exampleInfo;
            this.Control = null;// exampleInfo.ExampleGroup.Control;
            this.ExampleCodeFilesCollectionViewSource = new CollectionViewSource()
            {
                Source = ExampleSourceCodeHelper.GetCodeFilesForExample(exampleInfo)
            };

            this.NavigationContext = exampleInfo.NavigationParameter;

            var warningSuppression = this.RefreshAsyncProperties();
        }

        public void InitializeHints()
        {
            this.ExampleHintsAreVisible = !HintsHelper.CheckHintHasAlreadyBeenSeen(this.example.Name);
        }

        public async Task RefreshAsyncProperties()
        {
            this.ExampleIsPinned = await PinnedItemsHelper.ItemIsPinned(this.Example.Name);
        }

        protected override bool OnNavigateCommandCanExecute(object parameter)
        {
            return parameter != null;
        }

        protected override void OnNavigateCommandExecuted(object parameter)
        {
            var control = parameter as IControlInfo;

            // navigate to Home if the control to navigate has only one example 
            if (control != null && control.Examples.Count == 1)
            {
                parameter = "QSF.Views.HomePage";
            }

            base.OnNavigateCommandExecuted(parameter);
        }

        private async void OnTogglePinnedCommandExecuted(object parameter)
        {
            var commandSender = parameter as FrameworkElement;

            await this.RefreshAsyncProperties();

            if (this.ExampleIsPinned)
            {
                var warningSuppression = PinnedItemsHelper.UnpinItem(this.example.Name, commandSender, Placement.Above);
            }
            else
            {
                Uri logo = new Uri(this.Control.PinnedImage);
                var warningSuppression = PinnedItemsHelper.PinItem(this.example.Name, this.example.HeaderText, this.example.HeaderText, logo, commandSender, Placement.Above);
            }
        }
    }
}
