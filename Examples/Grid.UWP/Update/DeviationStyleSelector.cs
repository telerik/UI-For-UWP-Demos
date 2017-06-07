using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.UI.Xaml.Controls.Grid;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Grid.Update
{
    public class DeviationStyleSelector:StyleSelector
    {
        public Style NegativeStyle
        {
            get;
            set;
        }

        public Style PositiveStyle
        {
            get;
            set;
        }

        protected override Style SelectStyleCore(object item, DependencyObject container)
        {
            var cellInfo = item as DataGridCellInfo;
            var stock = cellInfo.Item as Stock;

            if (stock.Change == 0)
                return null;

            return stock.Change > 0 ? PositiveStyle : NegativeStyle;
        }
    }
}
