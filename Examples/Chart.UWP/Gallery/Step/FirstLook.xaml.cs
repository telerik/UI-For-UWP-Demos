using QSF.Common.Examples;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Chart.Gallery.Step
{
    public sealed partial class FirstLook : UserControl
    {
        public FirstLook()
        {
            this.InitializeComponent();

            ChartGalleryModel model = new ChartGalleryModel();
            for (int i = 1; i <= 2; i++)
            {
                GalleryItemModel item = new GalleryItemModel("Chart/Gallery/Step") { TemplateName = "Step" + i };
                model.Items.Add(item);
            }

            model.Data1 = ChartGalleryModel.GetStepSeriesData(true);
            model.Data2 = ChartGalleryModel.GetStepSeriesData(false);
            model.SelectedItem = model.Items[0];
            model.Title = "MONTHLY SALES REVENUE, 2010";

            this.DataContext = model;
        }
    }
}
