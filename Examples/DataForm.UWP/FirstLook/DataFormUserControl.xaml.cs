using DataForm.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Telerik.UI.Xaml.Controls.Data;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace DataForm.FirstLook
{
    public sealed partial class DataFormUserControl : UserControl
    {
        public DataFormUserControl()
        {
            this.InitializeComponent();

            this.secondDataForm.RegisterPropertyEditor("Date", typeof(DateTimeEditor));
            this.secondDataForm.RegisterPropertyEditor("PhoneNumber", typeof(PhoneEditor));
        }

        private void CancelReservationHandler(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var listView = this.secondDataForm.DataContext as RadListView;
            if (listView != null)
            {
                ViewModel.Reservations.Remove(listView.CurrentItem as Reservation);
                if (ViewModel.Reservations.Count > 0)
                {
                    listView.MoveCurrentTo(ViewModel.Reservations[0]);
                }             
            }          
        }

        private void SaveButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var item = this.secondDataForm.Item as Reservation;

            if (item != null)
            {
                item.IsNewItem = false;
            }

            this.secondDataForm.TransactionService.CommitAll();
        }

        private void CancelButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var item = this.secondDataForm.Item as Reservation;

            if (item != null && item.IsNewItem)
            {
                ViewModel.Reservations.Remove(this.secondDataForm.Item as Reservation);
            }

            this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                var listView = this.secondDataForm.DataContext as RadListView;
                if (listView != null && ViewModel.Reservations.Count > 0)
                {
                    listView.MoveCurrentTo(ViewModel.Reservations[0]);
                }
            });
        }
    }
}
