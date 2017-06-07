using QSF.Common.Examples;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Chart.Gallery.Point
{
    public sealed partial class FirstLook : UserControl
    {
        public FirstLook()
        {
            this.InitializeComponent();

            //ChartGalleryModel model = new ChartGalleryModel();
            //GalleryItemModel item = new GalleryItemModel("Chart/Gallery/Point") { TemplateName = "Point1"};
            //model.Items.Add(item);
            //model.Data1 = ChartGalleryModel.LoadData("Point.Data.Earthquakes.csv");
            //model.SelectedItem = model.Items[0];
            //model.Title = "The L'Aquila Seismic Activity From August 2009 to February 2010";

            PointSeriesGalleryModel model = new PointSeriesGalleryModel();
            GalleryItemModel item = new GalleryItemModel("Chart/Gallery/Point") { TemplateName = "Point1" };
            model.Items.Add(item);
            model.Data1 = PointSeriesGalleryModel.LoadData("Point.Data.Earthquakes.csv");
            model.SelectedItem = model.Items[0];
            model.Title = "The L'Aquila Seismic Activity From August 2009 to February 2010";

            this.DataContext = model;
        }
    }
}
