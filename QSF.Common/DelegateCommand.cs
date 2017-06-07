using System;
using System.Windows.Input;

namespace QSF.Common
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> _action;
        private readonly Func<object, bool> _CanExecute;

        public DelegateCommand(Action<object> action) : this(action, (o) => true)
        {
        }

        public DelegateCommand(Action<object> action, Func< object, bool> canExecute)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }
            this._action = action;
            this._CanExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return this._CanExecute == null ? true : this._CanExecute(parameter);
        }

        public void Execute(object parameter)
        {
            if (this.CanExecute(parameter))
            {
                this._action(parameter);
            }
        }

        public void RaiseCanExecuteChanged()
        {
            if (this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}