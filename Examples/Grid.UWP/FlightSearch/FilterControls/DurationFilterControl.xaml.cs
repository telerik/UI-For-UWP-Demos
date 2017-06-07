using System;
using Telerik.Data.Core;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Grid.FlightSearch.FilterControls
{
    public sealed partial class DurationFilterControl : BaseFilterControl
    {
        public DurationFilterControl()
        {
            this.InitializeComponent();
        }

        public override FilterDescriptorBase BuildDescriptor()
        {
            var descriptor = new NumericalFilterDescriptor() { PropertyName = this.PropertyName };
            descriptor.Operator = NumericalOperator.IsLessThan;
            descriptor.Value = this.slider.Value;

            return descriptor;
        }

        protected override void Initialize()
        {
            var descriptor = this.AssociatedDescriptor as NumericalFilterDescriptor;
            if (descriptor != null)
            {
                this.slider.Value = (double)descriptor.Value;
            }
        }
    }
}
