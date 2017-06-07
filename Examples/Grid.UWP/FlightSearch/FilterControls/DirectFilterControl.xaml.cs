using Telerik.Data.Core;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Grid.FlightSearch.FilterControls
{
    public sealed partial class DirectFilterControl : BaseFilterControl
    {
        public DirectFilterControl()
        {
            this.InitializeComponent();
        }

        public override FilterDescriptorBase BuildDescriptor()
        {
            var descriptor = new BooleanFilterDescriptor() { PropertyName = this.PropertyName };
            descriptor.Value = checkBox.IsChecked;

            return descriptor;
        }

        protected override void Initialize()
        {
            var descriptor = this.AssociatedDescriptor as BooleanFilterDescriptor;
            if (descriptor != null)
            {
                this.checkBox.IsChecked = (bool?)descriptor.Value;
            }
        }
    }
}
