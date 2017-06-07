using System;
using System.Collections.Generic;
using System.Linq;

namespace QSF.Model
{
    /// <summary>
    /// Info for the control.
    /// </summary>
	public interface IControlInfo : ICommonModelObject
	{
        /// <summary>
        /// Control's example groups - ex. "Highlights", "Data visualization", etc.
        /// </summary>
		List<IExampleGroupInfo> ExampleGroups { get; }

        /// <summary>
        /// All the examples of the control.
        /// </summary>
		List<IExampleInfo> Examples { get; }

        /// <summary>
        /// Default example to display.
        /// </summary>
        IExampleInfo DefaultExample { get; }
	}
}
