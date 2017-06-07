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
    public class OpenMenuCommand : RadialMenuCommand
    {
        public OpenMenuCommand()
        {
            this.Id = CommandId.Open;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            base.Execute(parameter);

            var currentPictureInfo = this.Owner.DataContext as PictureInfo;
            var menuList = currentPictureInfo.Owner.PicturesInfo.Where(x => x != currentPictureInfo);

            foreach (PictureInfo item in menuList)
            {
                item.IsOpen = false;
            }
        }
    }
}
