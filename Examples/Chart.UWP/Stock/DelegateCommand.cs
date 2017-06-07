using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chart.Stock
{
    public class DelegateCommand : ICommand
    {
        private Predicate<object> canExecuteAction;
        private Action<object> executeAction;

        public DelegateCommand(Predicate<object> canExecute, Action<object> execute)
        {
            this.canExecuteAction = canExecute;
            this.executeAction = execute;
        }

        public DelegateCommand(Action<object> execute)
            : this((s) => true, execute)
        { }

        public bool CanExecute(object parameter)
        {
            return this.canExecuteAction(parameter);
        }

        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
            }
            remove
            {
            }
        }

        public void Execute(object parameter)
        {
            this.executeAction(parameter);
        }
    }
}
