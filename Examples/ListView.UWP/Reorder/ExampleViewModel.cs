using QSF.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Telerik.Core;
using Telerik.UI.Xaml.Controls.Data.ListView;
using Telerik.UI.Xaml.Controls.Data.ListView.Commands;

namespace ListView.Reorder
{
    public class ExampleViewModel : ViewModelBase
    {
        private ItemsList selectedList;

        public ExampleViewModel()
        {
            Lists = new ObservableCollection<ItemsList>() { 
                new ItemsList { Title = "TO DO LIST", 
                                Items = new ObservableCollection<ListItem>{
                                   new ListItem{ Description = "Check weather forecast for London" },
                                   new ListItem{ Description = "Call Brain Ingram for the Hotel reservations"},
                                   new ListItem{ Description = "Check the childrens’ documents" }, 
                                   new ListItem{ Description = "Check if Jonah will take care of the dog" }, 
                                   new ListItem{ Description = "Airplane tickets reschedule for the morning plane" },
                                   new ListItem{ Description = "Check the trains schedule London - Paris" }, 
                                   new ListItem{ Description = "Bills due: Alissa’s ballet class fee tomorrow" }, 
                                   new ListItem{ Description = "Weekly organic basket" }
                                }
                }, 

                new ItemsList { Title= "SHOPPING LIST",
                    Items = new ObservableCollection<ListItem>{
                       new ListItem{ Description = "Cinnamon"},
                       new ListItem{ Description = "Milk"},
                       new ListItem{ Description = "10 eggs"} ,
                       new ListItem{ Description = "Butter"} , 
                       new ListItem{ Description = "Flour" }, 
                       new ListItem{ Description = "Wine" }, 
                       new ListItem{ Description = "Coffee"}
                    } 
                } 
            };

            SelectedList = Lists[0];
            this.ItemActionCommand = new DelegateCommand(this.PerformItemAction);
            this.ReorderListCommand = new DelegateCommand(this.ReorderItems);
        }

        public ObservableCollection<ItemsList> Lists { get; set; }

        public ICommand ItemActionCommand { get; set; }

        public ICommand ReorderListCommand { get; set; }

        public ItemsList SelectedList
        {
            get
            {
                return selectedList;
            }
            set
            {
                if (selectedList != value)
                {
                    selectedList = value;
                    OnPropertyChanged();
                }
            }
        }

        private void PerformItemAction(object parameter)
        {
            var context = parameter as ItemActionTapContext;
            var item = context.Item as ListItem;

            if (context.Offset > 0)
            {
                item.IsCompleted = !item.IsCompleted;
            }
            else
            {
                this.selectedList.Items.Remove(item);
            }
        }

        private void ReorderItems(object parameter)
        {
            ItemReorderCompleteContext context = parameter as ItemReorderCompleteContext;

            int sourceIndex = this.selectedList.Items.IndexOf(context.Item as ListItem);
            int targetIndex = this.selectedList.Items.IndexOf(context.DestinationItem as ListItem);

            var movedItem = context.Item as ListItem;
            this.selectedList.Items.RemoveAt(sourceIndex);
            this.selectedList.Items.Insert(targetIndex, movedItem);
        }
    }

    public class ItemsList
    {
        public string Title { get; set; }

        public ObservableCollection<ListItem> Items { get; set; }
    }

    public class ListItem : ViewModelBase
    {
        public string Description { get; set; }

        private bool isCompleted;

        public bool IsCompleted
        {
            get
            {
                return isCompleted;
            }
            set
            {
                if (isCompleted != value)
                {
                    isCompleted = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
