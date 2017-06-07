using System.Collections.Generic;

namespace QSF.CodeFormatting
{
	internal class SyntaxPicker
	{
        private List<SyntaxParser> parsers = new List<SyntaxParser>();

		internal SyntaxPicker()
		{
            this.parsers.Add(new CSharpSyntaxParser());
            this.parsers.Add(new XamlSyntaxParser());
            this.parsers.Add(new HTMLSyntaxParser());
		}

		internal SyntaxParser FindParserByExtension(string extension)
		{
			foreach (SyntaxParser parser in this.parsers)
			{
                if (parser.Extension == extension)
                {
                    return parser;
                }
			}

			return null;
		}
	}
}
