using System.Windows;
using Windows.UI.Text;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;

namespace QSF.CodeFormatting
{
    internal class LineBreakToken : Token
    {
        public LineBreakToken()
        {
        }

        public override Inline GetInline()
        {
            return new LineBreak();
        }
    }

	internal class Token
	{
        public Token()
        {
        }

		public Token(string value, Brush color)
			: this(value, color, false, false)
		{
		}

		public Token(string value, Brush color, bool isBold, bool isItalic)
		{
			this.Value = value;
			this.Color = color;
			this.IsBold = isBold;
			this.IsItalic = isItalic;
		}

		public enum TokenType
		{
			/// <summary>
			/// 
			/// </summary>
			KeyWord,

			/// <summary>
			/// 
			/// </summary>
			Comment,

			/// <summary>
			/// 
			/// </summary>
			String,

			/// <summary>
			/// 
			/// </summary>
			Identifier,

			/// <summary>
			/// 
			/// </summary>
			Other, 

			/// <summary>
			/// 
			/// </summary>
			None
		}

		public string Value
		{
			get;
			set;
		}

		public Brush Color
		{
			get;
			set;
		}

        public bool IsBold
        {
            get;
            set;
        }
        public bool IsItalic
        {
            get;
            set;
        }

		public virtual Inline GetInline()
		{
			return new Run()
			{
				Text = this.Value,
				Foreground = this.Color,
				FontWeight = this.IsBold ? FontWeights.ExtraBlack : FontWeights.Normal,
				FontStyle = this.IsItalic ? FontStyle.Italic : FontStyle.Normal
			};
		}
	}
}
