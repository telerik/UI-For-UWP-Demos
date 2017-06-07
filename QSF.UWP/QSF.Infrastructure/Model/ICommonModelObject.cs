using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSF.Model
{
    /// <summary>
    /// An interface containing the common properties of objects in the model.
    /// </summary>
    public interface ICommonModelObject
    {
        /// <summary>
        /// Type name of the object - "Chart.FirstLook.Example" for examples or "Chart" for controls.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Long description of the object.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Status of the object - normal, beta, new, obsolete, etc.
        /// </summary>
        Enums.StatusMode Status { get; }

        /// <summary>
        /// Platform type of the object - UWP or WindowsUniversal.
        /// </summary>
        Enums.PlatformType Platform { get; }

        /// <summary>
        /// Comma delimited keywords, used for searching.
        /// </summary>
        string Keywords { get; }

        /// <summary>
        /// Text that should be visualised in UI, instead of Name.
        /// </summary>
        string Text { get; }

        /// <summary>
        /// Path to the pinned image for the object - ex. "ms-appx:///Assets/Chart_Pinned.png"
        /// </summary>
        string PinnedImage { get; }

        /// <summary>
        /// Path to the small image for the object - ex. "ms-appx:///Assets/Chart_Small.png"
        /// </summary>
        string SmallImage { get; }

        /// <summary>
        /// Path to the medium image for the object - ex. "ms-appx:///Assets/Chart_Medium.png"
        /// </summary>
        string MediumImage { get; }

        /// <summary>
        /// Path to the large image for the object - ex. "ms-appx:///Assets/Chart_Small.png"
        /// </summary>
        string LargeImage { get; }

        /// <summary>
        /// An unique identifier, representing this object.
        /// </summary>
        Guid UniqueId { get; }

        /// <summary>
        /// Gets a human-readable name for this object. Instead of "Telerik.Windows.....FirstLook..." returns "FirstLook".
        /// </summary>
        /// <returns>Returns the human-readable name for this object.</returns>
        string GetReadableName();
    }
}
