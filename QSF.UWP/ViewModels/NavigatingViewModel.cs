using System;
using System.Linq;
using System.Windows.Input;
using QSF.Common;
using QSF.Model;
using QSF.Views;

namespace QSF.ViewModel
{
    /// <summary>
    /// Represents a viewmodel that has navigation functionality using the NavigationService.
    /// </summary>
    public abstract class NavigatingViewModel : BindableBase
    {
        public NavigatingViewModel()
        {
            this.NavigateCommand = new DelegateCommand(this.OnNavigateCommandExecuted, this.OnNavigateCommandCanExecute);
        }

        public ICommand NavigateCommand { get; private set; }

        protected virtual void OnNavigateCommandExecuted(object parameter)
        {

            if (parameter is IExampleInfo)
            {
                //NavigationService.Instance.Navigate(typeof(ExampleView), parameter);
                NavigationService.Instance.Navigate(typeof(ExamplePage), parameter);
            }

            else if (parameter is IControlInfo)
            {
                var control = parameter as IControlInfo;

                if (control.Examples.Count == 1)
                {
                    // skip controls page if there's only one example in the control being navigated
                    // and open up the example directly
                    this.OnNavigateCommandExecuted(control.DefaultExample);
                }
                else
                {
                    NavigationService.Instance.Navigate(typeof(ControlExamplesPage), parameter);
                }
            }
#if WINDOWS_APP
            else if (parameter is AppHighlightInfo)
            {
                NavigationService.Instance.Navigate(typeof(AppHighlightPage), parameter);
            }

            else
#endif
            if (parameter.GetType() == typeof(string))
            {
                var type = Type.GetType(parameter.ToString());
                if (type != null)
                {
                    NavigationService.Instance.Navigate(type, null);
                }
            }
        }

        protected virtual bool OnNavigateCommandCanExecute(object parameter)
        {
            return true;
        }
    }
}