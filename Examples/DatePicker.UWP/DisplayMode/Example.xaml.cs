using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace DatePicker.DisplayMode
{
    public sealed partial class Example : UserControl
    {
        private DisplayInformation displayInfo;

        public Example()
        {
            this.InitializeComponent();

            this.Loaded += Example_Loaded;
            this.Unloaded += Example_Unloaded;
        }

        void Example_Loaded(object sender, RoutedEventArgs e)
        {
            this.displayInfo = DisplayInformation.GetForCurrentView();
            this.displayInfo.OrientationChanged += this.displayInfo_OrientationChanged;

            this.SetPickersHeight();
        }

        void Example_Unloaded(object sender, RoutedEventArgs e)
        {
            this.displayInfo.OrientationChanged -= this.displayInfo_OrientationChanged;
        }

        void displayInfo_OrientationChanged(DisplayInformation sender, object args)
        {
            this.SetPickersHeight();
        }

        private void SetPickersHeight()
        {
            string currentOrientation = this.displayInfo.CurrentOrientation.ToString();
            double height = (currentOrientation == "Landscape") || (currentOrientation == "LandscapeFlipped") ? 300 : 200;

            this.DatePicker.Height = height;
            this.TimePicker.Height = height;
        }
        private void OnRadioButtonTodayClick(object sender, RoutedEventArgs e)
        {
            this.DatePicker.Value = DateTime.Today;
            if (this.DatePicker.Visibility == Visibility.Collapsed)
            {
                this.DatePickerCloseButton.Content = "more";
            }
        }

        private void OnRadioButtonTomorrowClick(object sender, RoutedEventArgs e)
        {
            this.DatePicker.Value = DateTime.Now.AddDays(1);
            if (this.DatePicker.Visibility == Visibility.Collapsed)
            {
                this.DatePickerCloseButton.Content = "more";
            }
        }

        private void OnCheckCloseDatePickerButton(object sender, RoutedEventArgs e)
        {
            if (this.DatePicker.Visibility == Visibility.Collapsed)
            {
                this.DatePicker.Visibility = Visibility.Visible;
                this.DatePickerCloseButton.Content = "\uE0A4";
            }
            else
            {
                this.DatePicker.Visibility = Visibility.Collapsed;

                this.DatePickerCloseButton.Content = 
                    this.RadioButtonTomorrow.IsChecked == false && this.RadioButtonToday.IsChecked == false ?
                    this.DatePicker.Value.Value.Date.ToString("d") :
                    "more";
            }
        }

        private void OnRadioButtonNowClick(object sender, RoutedEventArgs e)
        {
            this.TimePicker.Value = DateTime.Now;
            if (this.TimePicker.Visibility == Visibility.Collapsed)
            {
                this.TimePickerCloseButton.Content = "more";
            }

        }

        private void OnCheckCloseTimePickerButton(object sender, RoutedEventArgs e)
        {
            if (this.TimePicker.Visibility == Visibility.Collapsed)
            {
                this.TimePicker.Visibility = Visibility.Visible;
                this.TimePickerCloseButton.Content = "\uE0A4";
            }
            else
            {
                this.TimePicker.Visibility = Visibility.Collapsed;

                this.TimePickerCloseButton.Content = this.RabioButtonNow.IsChecked == false ?
                    this.TimePicker.Value.Value.ToString("t") :
                    "more";
            }
        }

        private void DatePickerValueChanged(object sender, EventArgs e)
        {
            var date = this.DatePicker.Value.Value.Date;
            this.RadioButtonTomorrow.IsChecked = date == DateTime.Now.AddDays(1).Date;
            this.RadioButtonToday.IsChecked = date == DateTime.Today.Date;

        }

        private void TimePickerValueChanged(object sender, EventArgs e)
        {
            TimeSpan now = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0);
            TimeSpan pickerValue = new TimeSpan(this.TimePicker.Value.Value.Hour, this.TimePicker.Value.Value.Minute, 0);

            this.RabioButtonNow.IsChecked = pickerValue == now;
        }
    }
}
