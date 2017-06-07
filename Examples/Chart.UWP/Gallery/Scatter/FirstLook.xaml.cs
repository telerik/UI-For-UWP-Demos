using System;
using QSF.Common.Examples;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Chart.Gallery.Scatter
{
    public sealed partial class FirstLook : UserControl
    {
        public FirstLook()
        {
            this.InitializeComponent();

            ChartGalleryModel model = new ChartGalleryModel();
            for (int i = 1; i <= 5; i++)
            {
                GalleryItemModel item = new GalleryItemModel("Chart/Gallery/Scatter") { TemplateName = "Scatter" + i };
                model.Items.Add(item);
            }

            model.Data1 = ChartGalleryModel.GetNumericData(20, 30, 3, (i) => 60 * i + 450, (i) => 20 * (Math.Sin(0.13 * i)) + 6);
            model.Data2 = ChartGalleryModel.GetNumericData(20, 30, 5, (i) => 60 * i + 450, (i) => 20 * (Math.Sin(0.13 * i)) + 6);
            model.SelectedItem = model.Items[0];
            model.Title = "NY REAL ESTATE AGENCY PROPERTIES FOR RENT:AREA - PRICE RELATIONSHIP";

            this.DataContext = model;
        }
    }
}
