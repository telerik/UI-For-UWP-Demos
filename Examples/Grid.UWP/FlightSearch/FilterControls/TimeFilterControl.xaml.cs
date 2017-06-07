using System;
using Telerik.Data.Core;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Grid.FlightSearch.FilterControls
{
    public sealed partial class TimeFilterControl : BaseFilterControl
    {
        public TimeFilterControl()
        {
            this.InitializeComponent();
        }

        public override FilterDescriptorBase BuildDescriptor()
        {
            var fromDescriptor = new DateTimeFilterDescriptor() { Part = DateTimePart.Time };
            fromDescriptor.PropertyName = this.PropertyName;
            fromDescriptor.Value = this.fromPicker.Value;
            fromDescriptor.Operator = NumericalOperator.IsGreaterThanOrEqualTo;

            var toDescriptor = new DateTimeFilterDescriptor() { Part = DateTimePart.Time };
            toDescriptor.PropertyName = this.PropertyName;
            toDescriptor.Value = this.toPicker.Value;
            toDescriptor.Operator = NumericalOperator.IsLessThanOrEqualTo;

            return new CompositeFilterDescriptor(new FilterDescriptorBase[] { fromDescriptor, toDescriptor }) { Operator = LogicalOperator.And };
        }

        protected override void Initialize()
        {
            var compositeDescriptor = this.AssociatedDescriptor as CompositeFilterDescriptor;
            if (compositeDescriptor == null || compositeDescriptor.Descriptors.Count != 2)
            {
                return;
            }

            var fromDescriptor = compositeDescriptor.Descriptors[0] as DateTimeFilterDescriptor;
            var toDescriptor = compositeDescriptor.Descriptors[1] as DateTimeFilterDescriptor;
            if (fromDescriptor == null || toDescriptor == null)
            {
                return;
            }

            this.fromPicker.Value = (DateTime?)fromDescriptor.Value;
            this.toPicker.Value = (DateTime?)toDescriptor.Value;
        }
    }
}
