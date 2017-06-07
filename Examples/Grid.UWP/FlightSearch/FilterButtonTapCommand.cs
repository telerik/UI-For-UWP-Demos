using Grid.FlightSearch.FilterControls;
using System;
using Telerik.UI.Xaml.Controls.Grid;
using Telerik.UI.Xaml.Controls.Grid.Commands;

namespace Grid.FlightSearch
{
    public class FilterButtonTapCommand : DataGridCommand
    {
        public FilterButtonTapCommand()
        {
            this.Id = CommandId.FilterButtonTap;

            this.CustomTimeFilter = true;
            this.CustomDirectFilter = true;
            this.CustomDurationFilter = true;
            this.CustomPriceFilter = true;
        }

        public bool CustomTimeFilter
        {
            get;
            set;
        }

        public bool CustomDirectFilter
        {
            get;
            set;
        }

        public bool CustomDurationFilter
        {
            get;
            set;
        }

        public bool CustomPriceFilter
        {
            get;
            set;
        }

        public override bool CanExecute(object parameter)
        {
            return parameter is FilterButtonTapContext;
        }

        public override void Execute(object parameter)
        {
            var context = parameter as FilterButtonTapContext;
            var propertyName = (context.Column as DataGridTypedColumn).PropertyName;

            if (this.CustomTimeFilter && (propertyName == "Departure" || propertyName == "Arrival"))
            {
                context.FirstFilterControl = new TimeFilterControl() { PropertyName = propertyName };
                context.SecondFilterControl = null;
            }
            else if (this.CustomDirectFilter && propertyName == "IsDirect")
            {
                context.FirstFilterControl = new DirectFilterControl() { PropertyName = propertyName };
                context.SecondFilterControl = null;
            }
            else if (this.CustomPriceFilter && propertyName == "Price")
            {
                context.FirstFilterControl = new PriceFilterControl() { PropertyName = propertyName };
                context.SecondFilterControl = null;
            }
            else if (this.CustomDurationFilter && propertyName == "Duration")
            {
                context.FirstFilterControl = new DurationFilterControl() { PropertyName = "DurationHours" };
                context.SecondFilterControl = null;
            }
            else if (propertyName == "Class")
            {
                context.FirstFilterControl = new ClassFilterControl() { PropertyName = propertyName };
                context.SecondFilterControl = null;
            }

            this.Owner.CommandService.ExecuteDefaultCommand(CommandId.FilterButtonTap, context);
        }
    }
}
