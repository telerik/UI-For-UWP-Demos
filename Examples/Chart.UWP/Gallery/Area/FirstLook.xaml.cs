using QSF.Common.Examples;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Chart.Gallery.Area
{
    public sealed partial class FirstLook : UserControl
    {
        public FirstLook()
        {
            this.InitializeComponent();

            ChartGalleryModel model = new ChartGalleryModel();
            for (int i = 1; i <= 5; i++)
            {
                GalleryItemModel item = new GalleryItemModel("Chart/Gallery/Area") { TemplateName = "Area" + i };
                model.Items.Add(item);
            }

            model.Data1 = ChartGalleryModel.GetCategoricalData();
            model.Data2 = ChartGalleryModel.GetCategoricalData();
            model.SelectedItem = model.Items[0];
            model.Title = "MONTLY SALES REVENUE, 2011";

            this.DataContext = model;
        }
    }
}
