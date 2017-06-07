using System.Collections.Generic;
using System.Linq;
using Telerik.UI.Xaml.Controls.Map;
using Windows.UI.Xaml.Controls;

namespace Map.FirstLook
{
    public sealed partial class Example : UserControl
    {
        public Example()
        {
            this.InitializeComponent();
        }

        private void SubCountryDataSource_ShapeProcessingCompleted(object sender, System.EventArgs e)
        {
            var dataSource = sender as ShapefileDataSource;

            Dictionary<string, double> accumulatedValues = new Dictionary<string, double>();
            var shapesByCountry = dataSource.Shapes.GroupBy(shape => shape.GetAttribute("CNTRY_NAME"));
            foreach (var group in shapesByCountry)
            {
                accumulatedValues[group.Key.ToString()] = group.Sum(shape => (double)shape.GetAttribute("SQMI_ADMIN"));
            }

            // Add custom calculated attribute SQMI_CNTRY for each shape record that represents the total country area in sq. miles.
            foreach (var shape in dataSource.Shapes)
            {
                string countryName = shape.GetAttribute("CNTRY_NAME").ToString();
                shape.SetAttribute("SQMI_CNTRY", accumulatedValues[countryName]);
            }
        }
    }
}
