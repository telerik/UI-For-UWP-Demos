using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace QSF.Common.Examples
{
    public sealed partial class VerticalGalleryControl : UserControl
    {
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(String), typeof(GalleryControl), new PropertyMetadata(string.Empty));

        public VerticalGalleryControl()
        {
            this.InitializeComponent();
        }
        public string Title
        {
            get
            {
                return (string)this.GetValue(TitleProperty);
            }
            set
            {
                this.SetValue(TitleProperty, value);
            }
        }


        protected override Size MeasureOverride(Size availableSize)
        {
            if (this.galleryList.SelectedItem == null)
            {
                GalleryModel dataContext = this.DataContext as GalleryModel;
                if (dataContext != null)
                {
                    this.galleryList.SelectedItem = dataContext.SelectedItem;
                }
            }
            return base.MeasureOverride(availableSize);
        }

        private void OnGalleryItemSelected(object sender, SelectionChangedEventArgs e)
        {
            (this.DataContext as GalleryModel).SelectedItem = this.galleryList.SelectedItem as GalleryItemModel;
        }
    }
}
