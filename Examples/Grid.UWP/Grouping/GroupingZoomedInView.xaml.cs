using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Telerik.Data.Core;
using Telerik.UI.Xaml.Controls.Grid;
using Telerik.UI.Xaml.Controls.Grid.Commands;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Grid.Grouping
{
    public sealed partial class GroupingZoomedInView : UserControl, ISemanticZoomInformation
    {
        public GroupingZoomedInView()
        {
            this.InitializeComponent();
        }

        public void CompleteViewChange()
        {
            // throw new NotImplementedException();
        }

        public void CompleteViewChangeFrom(SemanticZoomLocation source, SemanticZoomLocation destination)
        {
            var list = this.SemanticZoomOwner.ZoomedOutView as GridView;

            if (list != null)
            {
                list.ItemsSource = source.Item;
            }
        }

        public void CompleteViewChangeTo(SemanticZoomLocation source, SemanticZoomLocation destination)
        {
            // throw new NotImplementedException();
        }

        public void InitializeViewChange()
        {
            // throw new NotImplementedException();
        }

        public bool IsActiveView
        {
            get;
            set;
        }

        public bool IsZoomedInView
        {
            get;
            set;
        }

        public void MakeVisible(SemanticZoomLocation item)
        {

        }

        public SemanticZoom SemanticZoomOwner
        {
            get;
            set;
        }

        public void StartViewChangeFrom(SemanticZoomLocation source, SemanticZoomLocation destination)
        {
            source.Item = this.dataGrid.GetDataView().Items.OfType<IDataGroup>().Select(c => c.Key);
        }

        public void StartViewChangeTo(SemanticZoomLocation source, SemanticZoomLocation destination)
        {
            var dataview = this.dataGrid.GetDataView();
            var group = dataview.Items.OfType<IDataGroup>().Where(c => c.Key.Equals(source.Item)).FirstOrDefault();

            var lastGroup = dataview.Items.Last() as IDataGroup;
            if (group != null && lastGroup != null)
            {
                this.dataGrid.ScrollItemIntoView(lastGroup.ChildItems[lastGroup.ChildItems.Count - 1], () =>
                    {
                        this.dataGrid.ScrollItemIntoView(group.ChildItems[0]);
                    });
            }
        }
    }

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
            if (context.Descriptor is DelegateGroupDescriptor && context.Action == DataGridFlyoutGroupHeaderTapAction.RemoveDescriptor)
            {
                // do not allow removal of our custom Delegate descriptor
                return;
            }

            this.Owner.CommandService.ExecuteDefaultCommand(CommandId.FlyoutGroupHeaderTap, parameter);
        }
    }
}
