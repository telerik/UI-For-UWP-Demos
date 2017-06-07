using System;
using System.Collections.Generic;
using System.Text;
using Telerik.Data.Core;
using Telerik.UI.Xaml.Controls.Data.DataForm.Commands;

namespace DataForm
{
    public class CustomValidateCommand : DataFormCommand
    {
        public CustomValidateCommand()
        {
            this.Id = CommandId.Validate;
        }

        public override bool CanExecute(object parameter)
        {
            base.CanExecute(parameter);
            return true;
        }

        public override void Execute(object parameter)
        {
            base.Execute(parameter);

            var property = parameter as EntityProperty;

            property.Errors.Clear();

            if (property.PropertyName == "Name" && string.IsNullOrEmpty(property.PropertyValue as string))
            {
                property.Errors.Add("Please fill in the guest name");
            }

            if (property.PropertyName == "Date" && ((DateTime)property.PropertyValue) <= DateTime.Now)
            {
                property.Errors.Add("Reservation date should be set in the future.");
            }
        }
    }
}
