using System.Collections.ObjectModel;
using System.Text;
using Windows.UI.Xaml.Media;
using System.Windows;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI;

namespace QSF.CodeFormatting
{
	internal class CSharpSyntaxParser : SyntaxParser
	{
        public const string DefaultExtension = ".cs";

		private string[] keywords = new string[]
		{
            "abstract",
            "as",
            "base",
            "break",
            "byte",
            "bool",
            "char",
            "catch",
            "case",
            "checked",
            "class",
            "continue",
            "const", 
            "decimal",
            "default",
            "delegate",
            "double",
            "do",
            "event",
            "explicit",
            "extern",
            "else", 
            "enum", 
            "finally",
            "false",
            "fixed",
            "float",
            "for",
            "foreach",
            "goto",
            "if",
            "implicit",
            "in", 
            "int",
            "interface",
            "is",
            "internal",
            "lock", 
            "long",
            "new",
            "namespace",
            "null",
            "object",
            "operator",
            "out",
            "override",
            "params",
            "private",
            "protected",
            "public",
            "partial",
            "return",
            "readonly",
            "ref",
            "struct",
            "switch",
            "sbyte",
            "sealed",
            "sizeof",
            "short",
            "stackalloc", 	 
            "static", 	 
            "string",
            "this",
            "throw",
            "true",
            "try",
            "typeof",
            "uint",
            "ulong",
            "unchecked",
            "unsafe",
            "ushort",
            "using",
            "virtual",
            "volatile",
            "void",
            "while"
        };

        public override string Extension
        {
            get
            {
                return DefaultExtension;
            }
        }

		protected override void LoadLanguageSyntax(List<LanguageSyntaxStructure> languageSyntax)
		{
			 ////Load comments
			string comments = @"\G(?<comment>(\/\/[ \t\S]*\s*\s*)|(\/\*\s*[\s\S]*\s*\*/\s))";
            languageSyntax.Add(new LanguageSyntaxStructure(comments, "comment", "#FF008000"));

			 ////Load Keywords
			StringBuilder kwrds = new StringBuilder();
			kwrds.Append(@"\G(?<keyword>(");
			for (int i = 0; i < this.keywords.Length; i++)
			{
				kwrds.Append(this.keywords[i] + "|");
			}
			kwrds.Append(this.keywords[this.keywords.Length - 1]);
			kwrds.Append(@")(?=(\.)|(\s+)))");
            languageSyntax.Add(new LanguageSyntaxStructure(kwrds.ToString(), "keyword", "#FF0000FF"));

			 ////Load string
			string strings = "\\G(?<string>\"\\s*((\\\\\")|[^\\\"])*\\s*\"\\s*)";
            languageSyntax.Add(new LanguageSyntaxStructure(strings, "string", "#FFA31515"));

            Color foreground = (Color)Colors.Black;

			////Load identifier
			string identifier = @"\G(?<identifier>[\w]+\s*)";
            languageSyntax.Add(new LanguageSyntaxStructure(identifier, "identifier", foreground));

			////Load other
			string other = @"\G(?<other>[\s\S]\s*)";
            languageSyntax.Add(new LanguageSyntaxStructure(other, "other", foreground));
		}
	}
}
