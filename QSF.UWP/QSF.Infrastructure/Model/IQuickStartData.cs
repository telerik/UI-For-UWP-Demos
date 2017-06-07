using System;
using System.Collections.Generic;
using System.Linq;

namespace QSF.Model
{
    /// <summary>
    /// Represents all of the data needed for the controls, examples, etc.
    /// </summary>
    public interface IQuickStartData
    {
        /// <summary>
        /// List of all of the controls in the QuickStart Framework.
        /// </summary>
        IEnumerable<IControlInfo> AllControls { get; }

        /// <summary>
        /// List of all the examples in the QuickStart Framework
        /// </summary>
        IEnumerable<IExampleInfo> Examples { get; }

        IEnumerable<AppHighlightInfo> HighlightedApps { get; set; }

        /// <summary>
        /// List of the highlighted controls in the app.
        /// </summary>
        IEnumerable<IControlInfo> HighlightedControls { get; }

        /// <summary>
        /// List of the highlighted examples in the app.
        /// </summary>
        IEnumerable<HomePageExampleHighlightInfo> HighlightedExamples { get; }

        /// <summary>
        /// Gets an ICommonModelObject with the specified id.
        /// </summary>
        /// <param name="id">Id of the object to find.</param>
        /// <returns>The object, if it exists or null if it doesn't.</returns>
        ICommonModelObject FindObject(Guid id);

        /// <summary>
        /// Gets an ICommonModelObject with the specified id.
        /// </summary>
        /// <param name="id">Id of the object to find.</param>
        /// <returns>The object, if it exists or null if it doesn't.</returns>
        ICommonModelObject FindObject(string guid);
    }
}