using QSF.Common.Examples;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Chart.Gallery.Radar
{
    public sealed partial class FirstLook : UserControl
    {
        public FirstLook()
        {
            this.InitializeComponent();

            ChartGalleryModel model = new ChartGalleryModel();
            for (int i = 1; i <= 5; i++)
            {
                GalleryItemModel item = new GalleryItemModel("Chart/Gallery/Radar") { TemplateName = "Radar" + i };
                model.Items.Add(item);
            }

            model.Data1 = ChartGalleryModel.GetCategoricalData();
           // model.Data2 = GalleryModel.GetSimpleData(2);
            model.SelectedItem = model.Items[0];
            model.Title = "AVG CUSTOMERS' SATISFACTION FROM CASA HOTEL, 2011";

            this.DataContext = model;
        }
    }
}
