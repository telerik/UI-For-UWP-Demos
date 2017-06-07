using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QSF.Model
{
    /// <summary>
    /// Info for the group of an example.
    /// </summary>
	public interface IExampleGroupInfo
	{
        /// <summary>
        /// Control info for the example.
        /// </summary>
		IControlInfo Control { get; }

        /// <summary>
        /// Name of the group.
        /// </summary>
		string Name { get; }

        /// <summary>
        /// Examples that the group contains.
        /// </summary>
		List<IExampleInfo> Examples { get; }
	}
}
