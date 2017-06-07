using System;
using System.Collections.Generic;
using System.Linq;

namespace QSF.Model
{
    /// <summary>
    /// Info for the example.
    /// </summary>
    public interface IExampleInfo : ICommonModelObject
    {
        /// <summary>
        /// Example group to which this example belongs.
        /// </summary>
		IExampleGroupInfo ExampleGroup { get; }

        /// <summary>
        /// Contains the highlights of an example.
        /// </summary>
        IEnumerable<ExampleHighlightInfo> Highlights { get; set; }

        /// <summary>
        /// Shows whether this example is the default one for its control.
        /// </summary>
		bool IsDefault { get; }

        /// <summary>
        /// Shows whether this example is added to favourites.
        /// </summary>
        bool IsFavourite { get; set; }

        /// <summary>
        /// Control name to which this example belongs, if this is an integration example.
        /// Ex. if this belongs to Chart, but it's an integration with GridView, PackageName will be "GridView", ControlName will be "Chart".
        /// </summary>
		string PackageName { get; }

        /// <summary>
        /// Comma-delimited string of folders which contain the code files to display.
        /// </summary>
		List<string> CommonFolders { get; }

        /// <summary>
        /// Type of the example. Ex. Theming or normal.
        /// </summary>
		Enums.ExampleType Type { get; }

        string HeaderText { get; }

		/// <summary>
		/// Shows whether the example has a "pin to desktop" button enabled
		/// </summary>
        bool CanPinToDesktop { get; }
    }
}
