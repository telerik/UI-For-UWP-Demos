using System;
using System.Collections.Generic;

namespace QSF.CodeFormatting
{
	internal class Tokenizer
	{
		private SyntaxPicker picker = new SyntaxPicker();

		public enum ParserType
		{
			/// <summary>
			/// 
			/// </summary>
			CSharp,

			/// <summary>
			/// 
			/// </summary>
			XAML
		}

		public List<Token> TokenizeCode(string code, string extension)
		{
			SyntaxParser parser = this.picker.FindParserByExtension(extension) ?? new TextSyntaxParser();
			if (parser == null)
			{
				throw new ArgumentException("No Syntax Parser found that can parse this file!", "extension");
			}

            return parser.Tokenize(code);
		}
	}
}
