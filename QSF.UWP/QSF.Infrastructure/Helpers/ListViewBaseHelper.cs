using System;
using System.Linq;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace QSF.Infrastructure.Helpers
{
    /// <summary>
    /// A class that helps ListViewBase controls fire command on item click 
    /// and puts the ItemClickCommandParameter or ClickedItem (if the first is null) as command parameter.
    /// </summary>
    public class ListViewBaseHelper
    {
        // Using a DependencyProperty as the backing store for ItemClickCommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemClickCommandParameterProperty =
            DependencyProperty.RegisterAttached("ItemClickCommandParameter", typeof(object), typeof(ListViewBaseHelper), new PropertyMetadata(null));

        // Using a DependencyProperty as the backing store for ItemClickCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemClickCommandProperty =
            DependencyProperty.RegisterAttached("ItemClickCommand", typeof(ICommand), typeof(ListViewBaseHelper), new PropertyMetadata(null, OnItemClickCommandPropertyChanged));

        public static ICommand GetItemClickCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(ItemClickCommandProperty);
        }

        public static object GetItemClickCommandParameter(DependencyObject obj)
        {
            return obj.GetValue(ItemClickCommandParameterProperty);
        }

        public static void SetItemClickCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(ItemClickCommandProperty, value);
        }

        public static void SetItemClickCommandParameter(DependencyObject obj, object value)
        {
            obj.SetValue(ItemClickCommandParameterProperty, value);
        }

        private static void OnItemClickCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var listViewBase = d as ListViewBase;
            ICommand command = e.NewValue as ICommand;

            if (listViewBase != null)
            {
                listViewBase.IsItemClickEnabled = true;

                ItemClickEventHandler clickHandler = null;
                clickHandler = (s, args) =>
                {
                    // update the selected item to the lastly clicked one
                    listViewBase.SelectedItem = args.ClickedItem;
                    // if there is ItemClickCommandParameter set, take it as parameter, else, pass the clicked item
                    var commandParameter = listViewBase.GetValue(ListViewBaseHelper.ItemClickCommandParameterProperty) ?? args.ClickedItem;
                    
                    if(command != null)
                    {
                        command.Execute(commandParameter);
                    }
                };

                listViewBase.ItemClick -= clickHandler;
                listViewBase.ItemClick += clickHandler;
            }
        }
    }
}