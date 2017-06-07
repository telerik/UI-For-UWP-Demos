using System;
using System.Collections.Generic;

namespace QSF.Model
{
    /// <summary>
    /// A class representing a general highlight
    /// </summary>
	public class HighlightInfo
	{
		public string Text { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
	}

    /// <summary>
    /// Represents a highlight of a particular example with properties describing the aspect ratio of the highlight area
    /// </summary>
    public class ExampleHighlightInfo : HighlightInfo
    {
        public int WidthMultiplier { get; set; }
        public int HeightMultiplier { get; set; }
    }

    /// <summary>
    /// Represents a highlight of a particular example displayed on Home page
    /// </summary>
    public class HomePageExampleHighlightInfo : ExampleHighlightInfo
    {
        public IExampleInfo Example { get; set; }
    }

    /// <summary>
    /// Represents a highlight of a an app 
    /// </summary>
    public class AppHighlightInfo
    {
        public string ShortDescription  { get; set; }
        public string DetailedDescription { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public string Icon { get; set; }

        public IList<HighlightInfo> Highlights { get; set; }
    }
}