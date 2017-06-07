using System;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace QSF.Common.Examples.UWP
{
    public sealed partial class UWPGalleryControl : UserControl
    {
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(String), typeof(GalleryControl), new PropertyMetadata(string.Empty));

        public UWPGalleryControl()
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
