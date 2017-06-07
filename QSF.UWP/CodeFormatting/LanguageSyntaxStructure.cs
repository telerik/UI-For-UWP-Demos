using System;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace QSF.CodeFormatting
{
	internal class LanguageSyntaxStructure
	{
		private string regexString = null;
		private Brush segmentColor = null;
		private string description;

		public LanguageSyntaxStructure(string regEx, string description, string color)
            : this(regEx, description, ColorConverter.ConvertFromString(color))
		{
		}

        public LanguageSyntaxStructure(string regularExpression, string description, Color color)
        {
            this.regexString = regularExpression;
            this.segmentColor = new SolidColorBrush(color);
            this.description = description;
        }

		public string RegexString
		{
			get
			{
				return this.regexString;
			}
		}

		public string Description
		{
			get
			{
				return this.description;
			}
		}

		public Brush Color
		{
			get
			{
				return this.segmentColor;
			}
		}
	}
}
