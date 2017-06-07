using QSF.Common.Examples;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Chart.Gallery.Bar
{
    public sealed partial class FirstLook : UserControl
    {
        public FirstLook()
        {
            this.InitializeComponent();

            ChartGalleryModel model = new ChartGalleryModel();
            for (int i = 1; i <= 8; i++)
            {
                GalleryItemModel item = new GalleryItemModel("Chart/Gallery/Bar") { TemplateName = "Bar" + i };
                model.Items.Add(item);
            }

            model.Data1 = ChartGalleryModel.GetCategoricalData();
            model.Data2 = ChartGalleryModel.GetCategoricalData();
            model.SelectedItem = model.Items[0];
            model.Title = "PERFORMANCE SUMMARY, 2011";

            this.DataContext = model;
        }
    }
}
