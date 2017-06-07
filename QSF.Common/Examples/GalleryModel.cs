using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace QSF.Common.Examples
{
    public class GalleryModel : ViewModelBase
    {
        private string title;
        private GalleryItemModel selectedItem;
        private List<GalleryItemModel> items = new List<GalleryItemModel>();

        public List<GalleryItemModel> Items
        {
            get
            {
                return this.items;
            }
        }

        public GalleryItemModel SelectedItem
        {
            get
            {
                return this.selectedItem;
            }
            set
            {
                this.selectedItem = value;
                this.OnPropertyChanged("SelectedItem");
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
                this.OnPropertyChanged("Title");
            }
        }
    }
}
