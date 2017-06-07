using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Telerik.UI.Xaml.Controls.Primitives.Menu;
using Telerik.UI.Xaml.Controls.Primitives.Menu.Commands;

namespace RadialMenu.Customization
{
    public class CloseMenuCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            RadialMenuItemContext context = parameter as RadialMenuItemContext;
            var viewModel = context.CommandParameter as ViewModel;

            viewModel.lastPictureInfo.IsOpen = false;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
            }
            remove
            {
            }
        }
    }
}
