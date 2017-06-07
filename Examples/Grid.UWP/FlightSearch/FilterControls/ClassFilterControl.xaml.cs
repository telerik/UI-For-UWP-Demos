using System;
using Telerik.Data.Core;
using Telerik.UI.Xaml.Controls.Grid;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Grid.FlightSearch.FilterControls
{
    public sealed partial class ClassFilterControl : BaseFilterControl
    {
        public ClassFilterControl()
        {
            this.InitializeComponent();
        }

        public override FilterDescriptorBase BuildDescriptor()
        {
            var descriptor = new DelegateFilterDescriptor();
            descriptor.Filter = new FlightClassFilter((FlightClass)this.classCombo.SelectedIndex);

            return descriptor;
        }

        protected override void Initialize()
        {
            this.classCombo.ItemsSource = Enum.GetNames(typeof(FlightClass));

            var descriptor = this.AssociatedDescriptor as DelegateFilterDescriptor;
            if (descriptor != null)
            {
                var filter = descriptor.Filter as FlightClassFilter;
                this.classCombo.SelectedIndex = (int)filter.Class;
            }
            else
            {
                this.classCombo.SelectedIndex = 0;
            }
        }
    }

    public class FlightClassFilter : IFilter
    {
        public FlightClassFilter(FlightClass cls)
        {
            this.Class = cls;
        }

        public FlightClass Class
        {
            get;
            set;
        }

        public bool PassesFilter(object item)
        {
            var entry = item as ResultEntry;
            return entry.Class == this.Class;
        }
    }
}
