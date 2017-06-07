using QSF.Common.Examples;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Chart.Gallery.Range
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FirstLook : UserControl
    {
        public FirstLook()
        {
            this.InitializeComponent();

            ChartGalleryModel model = new ChartGalleryModel();
            for (int i = 1; i <= 2; i++)
            {
                GalleryItemModel item = new GalleryItemModel("Chart/Gallery/Range") { TemplateName = "Range" + i };
                model.Items.Add(item);
            }

            model.Data1 = ChartGalleryModel.GetTemperatureData();
            model.SelectedItem = model.Items[0];
            model.Title = "NYC temperature ranges";

            this.DataContext = model;
        }
    }
}
