using Telerik.Data.Core;
using Telerik.UI.Xaml.Controls.Grid.Primitives;
using Windows.UI.Xaml.Controls;

namespace Grid.FlightSearch.FilterControls
{
    public abstract class BaseFilterControl : UserControl, IFilterControl
    {
        public BaseFilterControl()
        {
            this.Loaded += BaseFilterControl_Loaded;
        }

        void BaseFilterControl_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Initialize();
        }

        public string PropertyName
        {
            get;
            set;
        }

        public FilterDescriptorBase AssociatedDescriptor
        {
            get;
            set;
        }

        public bool IsFirst
        {
            get;
            set;
        }

        public abstract FilterDescriptorBase BuildDescriptor();

        protected abstract void Initialize();
    }
}
