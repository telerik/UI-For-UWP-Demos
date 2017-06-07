using QSF.Common.Examples;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Chart.Gallery.Doughnut
{
    public sealed partial class FirstLook : UserControl
    {
        public FirstLook()
        {
            this.InitializeComponent();

            ChartGalleryModel model = new ChartGalleryModel();
            for (int i = 1; i <= 2; i++)
            {
                GalleryItemModel item = new GalleryItemModel("Chart/Gallery/Doughnut") { TemplateName = "Doughnut" + i };
                model.Items.Add(item);
            }

            model.Data1 = ChartGalleryModel.GetSimpleData(3, -1);
            model.Data2 = ChartGalleryModel.GetSimpleData(3, 0);
            model.Data3 = ChartGalleryModel.GetSimpleData(2, -1);
            model.SelectedItem = model.Items[0];
            model.Title = "INTERNATIONAL SALES BY COUNTRY, 2011";

            this.DataContext = model;
        }
    }
}
