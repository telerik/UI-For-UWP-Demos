using QSF.Common;
using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace QSF.Controls
{
    public class CustomGridView : GridView
    {
        // Using a DependencyProperty as the backing store for IsActive.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LayoutSizeProperty =
            DependencyProperty.Register("LayoutSize", typeof(LayoutSize), typeof(CustomGridView), new PropertyMetadata(LayoutSize.Large));

        public LayoutSize LayoutSize
        {
            get { return (LayoutSize) GetValue(LayoutSizeProperty); }
            set { SetValue(LayoutSizeProperty, value); }
        }

        private void SetRowAndColumnSpan(GridViewItem gridItem, int rowSpan, int columnSpan)
        {
            VariableSizedWrapGrid.SetRowSpan(gridItem, rowSpan);
            VariableSizedWrapGrid.SetColumnSpan(gridItem, columnSpan);
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            CustomGridViewItemInfo tile = item as CustomGridViewItemInfo;
            if (tile != null)
            {
                GridViewItem griditem = element as GridViewItem;
                if (griditem != null)
                {
                    griditem.HorizontalContentAlignment = Windows.UI.Xaml.HorizontalAlignment.Stretch;
                    griditem.VerticalContentAlignment = Windows.UI.Xaml.VerticalAlignment.Stretch;

                    if (this.LayoutSize == LayoutSize.Small && tile.ExampleHighlightInfo != null)
                    {
                        this.SetRowAndColumnSpan(griditem, 3, 3); 
                    }
                    else if (this.LayoutSize == LayoutSize.Medium && tile.ColumnSpan >= 4)
                    {
                        this.SetRowAndColumnSpan(griditem, tile.RowSpan - 2, tile.ColumnSpan - 2);
                    }
                    else
                    {
                        this.SetRowAndColumnSpan(griditem, tile.RowSpan, tile.ColumnSpan);
                    }
                }
            }

            base.PrepareContainerForItemOverride(element, item);
        }
    }
}
