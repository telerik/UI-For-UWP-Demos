using Telerik.Geospatial;
using Telerik.UI.Xaml.Controls.Map;

namespace Map.Gallery
{
    /// <summary>
    /// This command is used to set the best view for each respective map based on the visualized shapefile.
    /// </summary>
    public class MapShapeLayerSourceChangedCommand : MapCommand
    {
        public MapShapeLayerSourceChangedCommand()
        {
            this.Id = CommandId.ShapeLayerSourceChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            base.Execute(parameter);

            var shapeLayer = parameter as MapShapeLayer;

            this.Owner.SetView(shapeLayer.Bounds);

            // Manually apply final adjustments to ZoomLevel and Center due to shape outliers in some of the shapefiles.
            if (shapeLayer.Tag != null)
            {
                if (shapeLayer.Tag.ToString() == "Asia")
                {
                    this.Owner.ZoomLevel += 0.33;
                    this.Owner.Center = new Location(55.2347, 101.0969);
                }
                else if (shapeLayer.Tag.ToString() == "North America")
                {
                    this.Owner.ZoomLevel += 0.33;
                    this.Owner.Center = new Location(65.269, -83.2978);
                }
                else if (shapeLayer.Tag.ToString() == "Oceania")
                {
                    this.Owner.ZoomLevel += 1.66;
                    this.Owner.Center = new Location(-28.82, 139.663);
                }
            }

            this.Owner.CommandService.ExecuteDefaultCommand(CommandId.ShapeLayerSourceChanged, parameter);
        }
    }
}
