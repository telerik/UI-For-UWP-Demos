using System;
using System.Linq;
using System.Threading.Tasks;
using QSF.Infrastructure.Extensions;
using Windows.UI.Popups;
using Windows.UI.StartScreen;
using Windows.UI.Xaml;

namespace QSF.Infrastructure.Helpers
{
    /// <summary>
    /// A static class that facilitates pin and unpin actions of items
    /// </summary>
    public static class PinnedItemsHelper
    {
        /// <summary>
        /// Returns true if an tile with ID equal to the specified parameter is pinned
        /// </summary>
        /// <param name="tileId"></param>
        /// <returns></returns>
        public static async Task<bool> ItemIsPinned(string tileId)
        {
            var secondaryTiles = await SecondaryTile.FindAllForPackageAsync();
            
            bool isPinned = secondaryTiles.Any(t => t.TileId.Equals(tileId));

            return isPinned;  
        }

        /// <summary>
        /// Pins the item to the StartScreen and shows confirmation popup 
        /// at the specified placement, relative to the sourceElement
        /// </summary>
        /// <param name="tileId"></param>
        /// <param name="shortName"></param>
        /// <param name="displayName"></param>
        /// <param name="logo"></param>
        /// <param name="sourceElement"></param>
        /// <param name="placement"></param>
        /// <returns></returns>
        public static async Task<bool> PinItem(string tileId, string shortName, string displayName, Uri logo, FrameworkElement sourceElement, Placement placement)
        {
            string arguments = tileId;

			var newTile = new SecondaryTile(tileId, displayName, arguments, logo, TileSize.Square150x150);
			newTile.VisualElements.ForegroundText = ForegroundText.Dark;
			newTile.VisualElements.ShowNameOnSquare150x150Logo = true;
            
            bool pinSuccess = await newTile.RequestCreateForSelectionAsync(VisualTreeHelperExtensions.GetElementRect(sourceElement), placement);

            return pinSuccess;
        }

        /// <summary>
        /// Unpins the item from the StartScreen and shows confirmation popup 
        /// at the specified placement, relative to the sourceElement
        /// </summary>
        /// <param name="tileId"></param>
        /// <param name="shortName"></param>
        /// <param name="displayName"></param>
        /// <param name="logo"></param>
        /// <param name="sourceElement"></param>
        /// <param name="placement"></param>
        /// <returns></returns>
        public static async Task<bool> UnpinItem(string tileId, FrameworkElement sourceElement, Placement placement)
        {
            var tileToDelete = new SecondaryTile(tileId);

            bool unpinSuccess = await tileToDelete.RequestDeleteForSelectionAsync(VisualTreeHelperExtensions.GetElementRect(sourceElement), placement);

            return unpinSuccess;
        }
    }
}
