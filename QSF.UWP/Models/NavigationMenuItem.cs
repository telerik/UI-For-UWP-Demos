using Windows.UI.Xaml.Controls;

namespace QSF.Model
{
    public class NavigationMenuItem
    {
        public NavigationMenuItem()
        {
        }

        public NavigationMenuItem(IControlInfo controlInfo)
        {
            this.Label = controlInfo.Name;
            this.Header = controlInfo.Text;
            this.IconPath = string.Format("ms-appx:///Assets/Icons/white/{0}.png", controlInfo.Name.ToLowerInvariant());
            this.NavigationParameter = controlInfo;
        }

        public string Label { get; set; }
        public string Header { get; set; }
        public string IconPath { get; set; }
        public Symbol Glyph { get; set; }
        public IControlInfo NavigationParameter { get; set; }

        public char GlyphAsChar
        {
            get
            {
                return (char)this.Glyph;
            }
        }
    }
}
