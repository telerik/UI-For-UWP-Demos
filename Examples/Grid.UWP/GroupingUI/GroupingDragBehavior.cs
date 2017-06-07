using System;
using Telerik.Data.Core;
using Telerik.UI.Xaml.Controls.Grid;

namespace Grid.GroupingUI
{
    public class ExampleDragBehavior : DataGridDragBehavior
    {
        public bool IsGroupByColumnEnabled
        {
            get;
            set;
        }

        public bool IsGroupHeaderReorderEnabled
        {
            get;
            set;
        }

        public override bool CanGroupBy(DataGridColumn column)
        {
            if (!this.IsGroupByColumnEnabled)
            {
                return false;
            }

            return base.CanGroupBy(column);
        }

        public override bool CanStartReorder(GroupDescriptorBase groupDescriptorBase)
        {
            if (!this.IsGroupHeaderReorderEnabled)
            {
                return false;
            }

            return base.CanStartReorder(groupDescriptorBase);
        }
    }
}
