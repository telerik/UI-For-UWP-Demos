using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;

namespace QSF.CodeFormatting
{
	internal class SyntaxParser
	{
		public SyntaxParser()
		{
		}

		public virtual string Extension
		{
			get
			{
				return ".default";
			}
		}

        protected virtual void LoadLanguageSyntax(List<LanguageSyntaxStructure> languageSyntax)
		{
		}

        internal virtual List<Token> Tokenize(string code)
        {
            List<LanguageSyntaxStructure> syntax = new List<LanguageSyntaxStructure>();
            this.LoadLanguageSyntax(syntax);

            Regex regex = new Regex(this.GenerateRegEx(syntax), RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
            MatchCollection matches = regex.Matches(code);

            List<Token> tokens = new List<Token>();

            for (int i = 0; i < matches.Count; i++)
            {
                Token t = this.TokenizeMatch(matches[i], syntax);
                tokens.Add(t);
            }

            return tokens;
        }

        private Token TokenizeMatch(Match match, List<LanguageSyntaxStructure> syntaxList)
        {
            foreach (LanguageSyntaxStructure syntax in syntaxList)
            {
                Group group = match.Groups[syntax.Description];
                if (group.Success)
                {
                    return this.CreateToken(group, syntax);
                }
            }

            return new Token(null, null);
        }

        internal virtual Token CreateToken(Group group, LanguageSyntaxStructure syntax)
        {
            return new Token(group.Value, syntax.Color);
        }

        private string GenerateRegEx(List<LanguageSyntaxStructure> syntax)
        {
            StringBuilder regEx = new StringBuilder();
            regEx.Append(@"\s*");
            if (syntax.Count > 0)
            {
                for (int i = 0; i < syntax.Count - 1; i++)
                {
                    regEx.AppendFormat("{0}|", syntax[i].RegexString);
                }
                regEx.AppendFormat("{0}", syntax[syntax.Count - 1].RegexString);
            }
            regEx.Append(@"\s*");
            return regEx.ToString();
        }
	}
}
