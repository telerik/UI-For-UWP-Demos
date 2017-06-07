using Telerik.Data.Core;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Grid.FlightSearch.FilterControls
{
    public sealed partial class PriceFilterControl : BaseFilterControl
    {
        public PriceFilterControl()
        {
            this.InitializeComponent();
        }

        public override FilterDescriptorBase BuildDescriptor()
        {
            var descriptor = new NumericalFilterDescriptor() { PropertyName = this.PropertyName };
            descriptor.Value = this.numericBox.Value;
            descriptor.Operator = NumericalOperator.IsLessThan;

            return descriptor;
        }

        protected override void Initialize()
        {
            var descriptor = this.AssociatedDescriptor as NumericalFilterDescriptor;
            if (descriptor != null)
            {
                this.numericBox.Value = (double?)descriptor.Value;
            }
            else
            {
                this.numericBox.Value = 1200;
            }
        }
    }
}
