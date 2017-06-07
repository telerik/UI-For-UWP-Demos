using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace HexView.FirstLook
{
    public class ViewModel : ViewModelBase
    {
        private static readonly Random rand = new Random();

        private ObservableCollection<Item> items;

        public ViewModel()
        {
            this.items = GetItems(100);
        }

        public ObservableCollection<Item> Items
        {
            get
            {
                return this.items;
            }
            set
            {
                if (this.items != value)
                {
                    this.items = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public static ObservableCollection<Item> GetItems(int count)
        {
            var data = new ObservableCollection<Item>();

            for (int i = 0; i < count; i++)
            {
                data.Add(new Item
                {
                    Title = string.Format("item {0}", i),
                    Image = string.Format("ms-appx:///HexView/Images/contacts-{0}.jpg", rand.Next(count) % 10 + 1),
                    BackImage = string.Format("ms-appx:///HexView/Images/back-{0}.png", rand.Next(count) % 3 + 1)
                });
            }

            return data;
        }
    }
}
