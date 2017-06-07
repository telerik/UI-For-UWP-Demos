using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Core;
using Windows.UI.Xaml;

namespace Rating.FirstLook
{
    public class TemplateSet :ViewModelBase
    {
        private DataTemplate filled;

        public DataTemplate Filled
        {
            get { return filled; }
            set 
            { 
                if(this.filled != value){
                     filled = value;
                     OnPropertyChanged();
                }
                
            }
        }

        private DataTemplate empty;

        public DataTemplate Empty
        {
            get { return empty; }
            set 
            {
                if (this.empty != value)
                {
                    empty = value;
                    OnPropertyChanged();
                }
                
            }
        }

    }
}
