using System;
using Telerik.UI.Xaml.Controls.Map;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Map.Colorization
{
    public sealed partial class Example : UserControl
    {
        public Example()
        {
            this.InitializeComponent();
        }

        private void ShapefileDataSource_ShapeProcessingCompleted(object sender, EventArgs e)
        {
            var dataSource = (ShapefileDataSource)sender;

            foreach (var shape in dataSource.Shapes)
            {
                object value = shape.GetAttribute("POP_CNTRY");

                double factoredValue = 0;
                if (value != null)
                {
                    double doubleValue = (double)value;
                    if (doubleValue > 0)
                    {
                        factoredValue = doubleValue * 0.000001;
                    }
                }

                shape.SetAttribute("POP_CNTRY_FACTORED", factoredValue);
            }
        }
    }
}
