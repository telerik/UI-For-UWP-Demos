using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace QSF.Common
{
    public partial class LayoutAwarePage
    {
        public string PageOrientation
        {
            get { return (string)GetValue(PageOrientationProperty); }
            set { SetValue(PageOrientationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageOrientation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageOrientationProperty =
            DependencyProperty.Register("PageOrientation", typeof(string), typeof(LayoutAwarePage), new PropertyMetadata(null));
    }
}
