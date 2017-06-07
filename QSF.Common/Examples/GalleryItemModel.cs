using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace QSF.Common.Examples
{
    public class GalleryItemModel : ViewModelBase
    {
        public GalleryItemModel(string pathToFolder)
        {
            this.PathToFolder = pathToFolder;
        }

        public string PathToFolder
        {
            get;
            set;
        }

        public string TemplateName
        {
            get;
            set;
        }

        public Uri Thumbnail
        {
            get
            {
                return new Uri("ms-appx:///" + this.PathToFolder + "/Thumbnails/" + this.TemplateName + ".png", UriKind.Absolute);
            }
        }

        public DataTemplate Content
        {
            get
            {
                ResourceDictionary dictionary = new ResourceDictionary();
                dictionary.Source = new Uri("ms-appx:///" + this.PathToFolder + "/Templates/" + this.TemplateName + ".xaml");
                return dictionary["Item"] as DataTemplate;
            }
        }
    }
}
