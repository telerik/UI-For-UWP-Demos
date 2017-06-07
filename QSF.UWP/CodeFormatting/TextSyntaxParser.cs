using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI;

namespace QSF.CodeFormatting
{
    internal class TextSyntaxParser : SyntaxParser
    {
        protected override void LoadLanguageSyntax(List<LanguageSyntaxStructure> languageSyntax)
        {
            Color foreground = Colors.Black;
            string other = @"\G(?<other>.+)";
            languageSyntax.Add(new LanguageSyntaxStructure(other, "other", foreground));
        }
    }
}
