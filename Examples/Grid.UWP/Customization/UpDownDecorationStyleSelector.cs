using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.UI.Xaml.Controls.Grid;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Grid.Customization
{
    public class UpDownDecorationStyleSelector : StyleSelector
    {
        public Style UpStyle
        {
            get;
            set;
        }

        public Style DownStyle
        {
            get;
            set;
        }

        protected override Style SelectStyleCore(object item, DependencyObject container)
        {
            var cellInfo = item as DataGridCellInfo;
            var person = cellInfo.Item as SalesPerson;

            if (person.SalesLastYear < person.SalesYTD)
            {
                return this.UpStyle;
            }

            return this.DownStyle;
        }
    }
}
