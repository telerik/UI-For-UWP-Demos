using QSF.Common.Examples;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Chart.Gallery.Financial
{
    public sealed partial class FirstLook : UserControl
    {
        public FirstLook()
        {
            this.InitializeComponent();

            ChartGalleryModel model = new ChartGalleryModel();
            for (int i = 1; i <= 2; i++)
            {
                GalleryItemModel item = new GalleryItemModel("Chart/Gallery/Financial") { TemplateName = "Financial" + i };
                model.Items.Add(item);
            }

            model.Data1 = ChartGalleryModel.GetFinancialData();
            model.SelectedItem = model.Items[0];
            model.Title = "STOCK INDEX, WEDNESDAY, JULY 11, 2012";

            this.DataContext = model;
        }
    }
}
