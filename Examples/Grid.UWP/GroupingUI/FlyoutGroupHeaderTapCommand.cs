using System;
using Telerik.UI.Xaml.Controls.Grid.Commands;

namespace Grid.GroupingUI
{
    public class FlyoutGroupHeaderTapCommand : DataGridCommand
    {
        public FlyoutGroupHeaderTapCommand()
        {
            this.Id = CommandId.FlyoutGroupHeaderTap;
        }

        public override bool CanExecute(object parameter)
        {
            return parameter is FlyoutGroupHeaderTapContext;
        }

        public override void Execute(object parameter)
        {
            var context = parameter as FlyoutGroupHeaderTapContext;
            if (context.Action == DataGridFlyoutGroupHeaderTapAction.ChangeSortOrder)
            {
                this.Owner.CommandService.ExecuteDefaultCommand(CommandId.FlyoutGroupHeaderTap, parameter);
            }
        }
    }
}
