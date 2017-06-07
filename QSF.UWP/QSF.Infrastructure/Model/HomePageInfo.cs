using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace QSF.Model
{
	public class HomePageInfo
	{
		public HighlightInfo Headline { get; internal set; }

		public IList<HighlightInfo> Highlights { get; internal set; }
	}
}
