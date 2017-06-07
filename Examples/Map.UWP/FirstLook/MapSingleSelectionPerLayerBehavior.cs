using System.Collections.Generic;
using Telerik.Geospatial;
using Telerik.UI.Xaml.Controls.Map;
using Windows.Foundation;

namespace Map.FirstLook
{
    /// <summary>
    /// Implements custom single selection mode per layer.
    /// </summary>
    public class MapSingleSelectionPerLayerBehavior : MapShapeSelectionBehavior
    {
        private Dictionary<MapLayer, IMapShape> selectedShapesPerLayer;
        private IList<object> shapesToRemove;

        /// <summary>
        /// Initializes a new instance of the <see cref="MapSingleSelectionPerLayerBehavior"/> class.
        /// </summary>
        public MapSingleSelectionPerLayerBehavior()
        {
            this.SelectionMode = MapShapeSelectionMode.MultiExtended;

            this.selectedShapesPerLayer = new Dictionary<MapLayer, IMapShape>();
            this.shapesToRemove = new List<object>();
        }

        /// <summary>
        /// Initiates a hit test on the specified <see cref="T:Windows.Foundation.Point" /> location.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <returns></returns>
        /// <remarks>
        /// The default <see cref="T:Telerik.UI.Xaml.Controls.Map.MapBehavior" /> logic returns only the top-most <see cref="T:Telerik.UI.Drawing.D2DShape" /> from the <see cref="T:Telerik.UI.Xaml.Controls.Map.MapShapeLayer" /> that matches the specific behavior requirements;
        /// you can override the default logic and return multiple <see cref="T:Telerik.UI.Drawing.D2DShape" /> instances (e.g. from layers that overlay one another) and the specific <see cref="T:Telerik.UI.Xaml.Controls.Map.MapBehavior" /> will
        /// manipulate all of them.
        /// </remarks>
        protected override IEnumerable<IMapShape> HitTest(Point location)
        {
            int layerCount = this.Map.Layers.Count;
            for (int i = layerCount - 1; i >= 0; i--)
            {
                var layer = this.Map.Layers[i] as MapShapeLayer;
                if (layer == null || !layer.IsSelectionEnabled)
                {
                    continue;
                }

                var newShape = this.Map.HitTest(location, layer);

                if (this.selectedShapesPerLayer.ContainsKey(layer))
                {
                    var oldShape = this.selectedShapesPerLayer[layer];

                    // Disallow toggle selection. 
                    if (newShape == null || newShape == oldShape)
                    {
                        continue;
                    }

                    if (oldShape != null)
                    {
                        this.shapesToRemove.Add(oldShape);
                    }
                }

                this.selectedShapesPerLayer[layer] = newShape;

                yield return newShape;
            }
        }

        /// <summary>
        /// Raises the <see cref="F:Telerik.UI.Xaml.Controls.Map.CommandId.ShapeSelectionChanged" /> command and the <see cref="E:Telerik.UI.Xaml.Controls.Map.MapShapeSelectionBehavior.SelectionChanged" /> event.
        /// </summary>
        /// <param name="removedItems">The removed items.</param>
        /// <param name="addedItems">The added items.</param>
        protected override void OnSelectionChanged(IList<object> removedItems, IList<object> addedItems)
        {
            base.OnSelectionChanged(this.shapesToRemove, addedItems);

            this.shapesToRemove.Clear();
        }
    }
}
