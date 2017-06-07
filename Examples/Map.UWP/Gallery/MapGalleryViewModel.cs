using QSF.Common.Examples;

namespace Map.Gallery
{
    public class MapGalleryViewModel : GalleryModel
    {
        public MapGalleryViewModel()
        {
            this.BuildGalleryItemModels();
        }

        private void BuildGalleryItemModels()
        {
            for (int i = 1; i <= 8; i++)
            {
                GalleryItemModel item = new GalleryItemModel("Map/Gallery") { TemplateName = "Map" + i };
                this.Items.Add(item);
            }

            this.SelectedItem = this.Items[0];
        }
    }
}
