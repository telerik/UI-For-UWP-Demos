using QSF.Common.Examples;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Chart.Gallery.Polar
{
    public sealed partial class FirstLook : UserControl
    {
        public FirstLook()
        {
            this.InitializeComponent();

            ChartGalleryModel model = new ChartGalleryModel();
            for (int i = 1; i <= 5; i++)
            {
                GalleryItemModel item = new GalleryItemModel("Chart/Gallery/Polar") { TemplateName = "Polar" + i };
                model.Items.Add(item);
            }

            model.Data1 = ChartGalleryModel.GetPolarData(50, 100);
            model.Data2 = ChartGalleryModel.GetPolarData(50, 70);
            model.Data3 = ChartGalleryModel.GetPolarData(50, 50);
            model.SelectedItem = model.Items[0];
            model.Title = "RANDOMLY GENERATED POLAR DATA (ANGLE/VALUE)";

            this.DataContext = model;
        }
    }
}
