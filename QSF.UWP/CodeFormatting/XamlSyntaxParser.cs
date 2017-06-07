using System.Collections.ObjectModel;
using Windows.UI.Xaml.Media;
using System.Windows;
using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Xaml;

namespace QSF.CodeFormatting
{
	internal class XamlSyntaxParser : SyntaxParser
	{
        public const string DefaultExtension = ".xaml";

        public override string Extension
        {
            get
            {
                return DefaultExtension;
            }
        }

		protected override void LoadLanguageSyntax(List<LanguageSyntaxStructure> languageSyntax)
		{
            Color accent = (Color)Color.FromArgb(0xFF, 0xCC, 0xFA, 0x00);

			////Load attributes
			string attributes = @"\G(?<attribute>[a-zA-Z][a-zA-Z0-9.:*_]*\s*(?==))";
			languageSyntax.Add(new LanguageSyntaxStructure(attributes, "attribute", "#FFFF0000"));

			////Load elements
			string elements = @"\G(?<element>(?<=(<)|(</))[a-zA-Z][a-zA-Z0-9.:*_]*\s*)";
            languageSyntax.Add(new LanguageSyntaxStructure(elements, "element", "#FFA31515"));

			////Load comments
			string comments = @"\G(?<comment><!--\s*[\s\S]*\s*-->\s*)";
            languageSyntax.Add(new LanguageSyntaxStructure(comments, "comment", "#FF008000"));

			////Load tags
			string tags = @"\G(?<tag>(</|<|/>|>)\s*)";
            languageSyntax.Add(new LanguageSyntaxStructure(tags, "tag", "#FF0000FF"));

			////Load attribute strings
			string strings = "\\G(?<string>=\\s*\"[_=#{}a-zA-Z0-9.:;\\s-/,*]*\\s*\"\\s*)";
            languageSyntax.Add(new LanguageSyntaxStructure(strings, "string", "#FF0000FF"));

			////Load content
			string content = @"\G(?<content>[^<]+\s*)";
            languageSyntax.Add(new LanguageSyntaxStructure(content, "content", "#FF000000"));
		}
	}
}
