using System;
using System.Net;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Windows.UI.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Shapes;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Windows.UI.Xaml;

namespace QSF.CodeFormatting
{
    internal class HTMLSyntaxParser : SyntaxParser
    {
        public const string DefaultExtension = ".txt";

        public override string Extension
        {
            get
            {
                return DefaultExtension;
            }
        }

        internal override List<Token> Tokenize(string code)
        {
            List<Token> tokens = new List<Token>();

            XmlReader reader = XmlReader.Create(new StringReader("<xml>" + code + "</xml>"));
            bool bold = false;
            bool italic = false;
            SolidColorBrush brush;

            Color accent = (Color)Color.FromArgb(0xFF, 0xCC, 0xFA, 0x00);
            Color foreground = (Color)Colors.White;

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                    case XmlNodeType.EndElement:

                        string nodeName = reader.Name.ToLower();
                        switch (nodeName)
                        {
                            case "b":
                            case "bold":
                            case "strong":
                                bold = !bold;
                                break;
                            case "i":
                                italic = !italic;
                                break;
                            case "br":
                                tokens.Add(new LineBreakToken());
                                break;
                        }

                        break;
                    case XmlNodeType.Text:
                        brush = new SolidColorBrush(bold || italic ? accent : foreground);
                        tokens.Add(new Token(reader.Value, brush, bold, italic));
                        break;
                }
            }

            reader.Dispose();

            return tokens;
        }
    }
}
