using Windows.UI.Xaml.Controls;

namespace HexView.FirstLook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Example : UserControl
    {
        public Example()
        {
            this.InitializeComponent();
            this.DataContext = new ViewModel();
        }
    }
}
