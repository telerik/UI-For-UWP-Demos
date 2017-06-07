using System.Collections.Generic;
using System.Xml.Linq;

namespace QSF.Extensions
{
	public static class XElementExtensions
	{
        /// <summary>
        /// Gets the string content of an XElement attribute.<br/>
        /// </summary>
        /// <param name="element">XElement whose attribute to get.</param>
        /// <param name="name">Name of the attribute.</param>
        /// <param name="defaultValue">Default value to return if attribute can not be parsed or doesn't exist.</param>
        /// <returns>Returns the string attribute or the passed default value.</returns>
        public static string GetAttribute(this XElement element, string name, string defaultValue)
        {
			var attribute = element.Attribute(name);
			return attribute == null ? defaultValue : attribute.Value;
		}

        /// <summary>
        /// Gets the attribute of an XElement and parses it as a boolean.<br/>
        /// </summary>
        /// <param name="element">XElement whose attribute to get.</param>
        /// <param name="name">Name of the attribute.</param>
        /// <param name="defaultValue">Default value to return if attribute can not be parsed or doesn't exist.</param>
        /// <returns>Returns the parsed attribute or the passed default value.</returns>
		public static bool GetAttribute(this XElement element, string name, bool defaultValue)
		{
			var attribute = element.Attribute(name);
			if (attribute != null)
			{
				bool result;
				if (bool.TryParse(attribute.Value, out result))
				{
					return result;
				}
			}
			return defaultValue;
		}
	}
}