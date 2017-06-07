using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Geospatial;
using Telerik.UI.Xaml.Controls.Map;

namespace Map.Colorization
{
    public class ExamplePaletteColorizer : PaletteColorizer
    {
        protected override void OnShapeAssociated(IMapShape shape, ColorRange range)
        {
            base.OnShapeAssociated(shape, range);

            shape.SetAttribute("RANGE", range);
        }
    }
}
