using QSF.Common.Examples;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubTile.Gallery
{
    public class ViewModel : GalleryModel
    {
        public IEnumerable MosaicPictures
        {
            get
            {
                for (int i = 1; i <= 9; i++)
                {
                    yield return "ms-appx:///HubTile/Gallery/Images/MosaicTile/" + i + ".jpg";
                }
            }
        }

        public ViewModel()
        {
            for (int i = 1; i <= 5; i++)
            {
                this.Items.Add(new GalleryItemModel("HubTile/Gallery") { TemplateName = "Tile" + i });
            }

            this.SelectedItem = this.Items[0];
        }
    }
}
