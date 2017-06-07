using System;
using Telerik.UI.Xaml.Controls.Grid;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Grid.FirstLook
{
    public class TotalActualStyleSelector : StyleSelector
    {
        public Style LowStyle
        {
            get;
            set;
        }

        public Style NormalStyle
        {
            get;
            set;
        }

        protected override Style SelectStyleCore(object item, DependencyObject container)
        {
            var cellInfo = item as DataGridCellInfo;
            var product = cellInfo.Item as ProductStatistic;

            if (product.TotalActual < product.TotalTarget)
            {
                return this.LowStyle;
            }

            return NormalStyle;
        }
    }
}
