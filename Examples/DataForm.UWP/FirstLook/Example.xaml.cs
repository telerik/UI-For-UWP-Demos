using DataForm.Data;
using System;
using Telerik.Data.Core;
using Telerik.UI.Xaml.Controls.Data;
using Telerik.UI.Xaml.Controls.Data.ListView;
using Telerik.UI.Xaml.Controls.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DataForm.FirstLook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Example : Page
    {
        public bool IsMobileLayout
        {
            get { return (bool) GetValue(IsMobileLayoutProperty); }
            set { SetValue(IsMobileLayoutProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsMobileLayout.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsMobileLayoutProperty =
            DependencyProperty.Register("IsMobileLayout", typeof(bool), typeof(Example), new PropertyMetadata(false));

        public Example()
        {
            this.InitializeComponent();

            this.DataForm.RegisterPropertyEditor("Date", typeof(DateTimeEditor));
            this.DataForm.RegisterPropertyEditor("PhoneNumber", typeof(PhoneEditor));
            this.Date.Value = DateTime.Now;
            this.DataContext = ViewModel.Reservations;
        }

        private void AddReservationHandler(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ViewModel.Reservations.Insert(0, new Reservation() { Date = this.Date.Value.Value, IsNewItem = true });
            this.ReservationsView.MoveCurrentTo(ViewModel.Reservations[0]);
            if (this.IsMobileLayout)
            {
                this.OpenFlyoutDataForm();
            }
        }

        private void CancelReservationHandler(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ViewModel.Reservations.Remove(this.ReservationsView.CurrentItem as Reservation);
            if (ViewModel.Reservations.Count > 0)
            {
                this.ReservationsView.MoveCurrentTo(ViewModel.Reservations[0]);
            }
        }

        private void Date_ValueChanged(object sender, EventArgs e)
        {
            (this.ReservationsView.FilterDescriptors[0] as DateTimeFilterDescriptor).Value = (sender as RadDatePicker).Value;
        }

        private void FilterDayClicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Date.IsOpen = true;
        }

        private void ReservationsViewLoadedHandler(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
              {
                  ReservationsView.MoveCurrentTo(ViewModel.Reservations[0]);
              });
        }

        private void SaveButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var item = this.DataForm.Item as Reservation;

            if (item != null)
            {
                item.IsNewItem = false;
            }

            this.DataForm.TransactionService.CommitAll();
        }

        private void CancelButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var item = this.DataForm.Item as Reservation;

            if (item != null && item.IsNewItem)
            {
                ViewModel.Reservations.Remove(this.DataForm.Item as Reservation);
            }

            this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                if (ViewModel.Reservations.Count > 0)
                {

                 ReservationsView.MoveCurrentTo(ViewModel.Reservations[0]);

                }
            });
        }
        
        private void ReservationsView_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            var source = e.OriginalSource as FrameworkElement;
            if (source != null && this.IsMobileLayout)
            {
                var listViewItem = FindParentOfType<RadListViewItem>(source);
                if (listViewItem != null)
                {
                    this.OpenFlyoutDataForm();
                }
            }
        }

        private void OpenFlyoutDataForm()
        {
            var flyout = new FlyoutControl();
            flyout.Show(new DataFormUserControl { DataContext = this.ReservationsView }, null);
        }

        public static T FindParentOfType<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);
            
            if (parentObject == null) return null;

            T parent = parentObject as T;
            if (parent != null)
                return parent;
            else
                return FindParentOfType<T>(parentObject);
        }
    }
}
