// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace HubTile.Gallery
{
    public sealed partial class Example : ExampleBase
    {
        public Example()
        {
            this.InitializeComponent();

            this.DataContext = new ViewModel();
        }

        public override string GroupTag
        {
            get
            {
                return "Gallery";
            }
        }
    }
}
