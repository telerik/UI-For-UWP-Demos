using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;

namespace QSF.Common
{
    public class Hint : FrameworkElement
    {
        public string Content { get; set; }

        public PlacementMode Placement { get; set; }
        
        public string PlacementTargetName { get; set; }
    }
}