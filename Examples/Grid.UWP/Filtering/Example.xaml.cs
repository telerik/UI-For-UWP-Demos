using Grid.Grouping;
using System;
using System.Collections.Specialized;
using Telerik.Data.Core;
using Telerik.UI.Xaml.Controls.Grid;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Grid.Filtering
{
    public sealed partial class Example : UserControl
    {
        public Example()
        {
            this.InitializeComponent();

            var warningSuppression = this.Dispatcher.RunAsync(CoreDispatcherPriority.Low, () => this.InitializeSelectedColumnListSelection());
            this.dataGrid.Columns.CollectionChanged += this.Columns_CollectionChanged;
        }

        private void Columns_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var warningSuppression = this.Dispatcher.RunAsync(CoreDispatcherPriority.Low, () => this.InitializeSelectedColumnListSelection());
        }

        private void InitializeSelectedColumnListSelection()
        {
            if (selectedColumnList.Items.Count > 0)
            {
                selectedColumnList.SelectedIndex = 0;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.dataGrid.FilterDescriptors.Clear();
            string text = ((TextBox)sender).Text;

            if (!string.IsNullOrEmpty(text))
            {
                this.dataGrid.FilterDescriptors.Add(new DelegateFilterDescriptor() { Filter = new EmployeeSearchFilter(text, selectedColumnList.SelectedItem as DataGridTypedColumn) });
            }
        }

        private class EmployeeSearchFilter : IFilter
        {
            private string matchString;

            private DataGridTypedColumn column;

            public EmployeeSearchFilter(string match, DataGridTypedColumn column)
            {
                this.matchString = match;
                this.column = column;
            }

            public bool PassesFilter(object item)
            {
                var model = item as Person;

                if (column == null)
                {
                    return false;
                }

                switch (column.PropertyName)
                {
                    case "FirstName":
                        return model.FirstName.Contains(this.matchString, StringComparison.OrdinalIgnoreCase);
                    case "LastName":
                        return model.LastName.Contains(this.matchString, StringComparison.OrdinalIgnoreCase);
                    case "CountryName":
                        return model.CountryName.Contains(this.matchString, StringComparison.OrdinalIgnoreCase);
                    case "City":
                        return model.City.Contains(this.matchString, StringComparison.OrdinalIgnoreCase);
                    case "PostalCode":
                        return model.PostalCode.Contains(this.matchString, StringComparison.OrdinalIgnoreCase);
                    case "PhoneNumber":
                        return model.PhoneNumber.Contains(this.matchString, StringComparison.OrdinalIgnoreCase);
                    default:
                        break;
                }

                return false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FilterText.Text = string.Empty;
        }

        private void selectedColumnList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.dataGrid.FilterDescriptors.Clear();
            string text = FilterText.Text;

            if (!string.IsNullOrEmpty(text))
            {
                this.dataGrid.FilterDescriptors.Add(new DelegateFilterDescriptor() { Filter = new EmployeeSearchFilter(text, selectedColumnList.SelectedItem as DataGridTypedColumn) });
            }
        }
    }

    public static class StringUtils
    {
        public static bool Contains(this string source, string subString, StringComparison options)
        {
            return source.IndexOf(subString, options) >= 0;
        }
    }
}
