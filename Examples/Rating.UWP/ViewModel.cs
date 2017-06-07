using QSF.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Telerik.Core;
using Windows.UI.Xaml;

namespace Rating.FirstLook
{
    public class ViewModel : ViewModelBase
    {

        private TemplateSet selectedTemplateSet;
        public ViewModel()
        {
            this.ChangeTemplateCommand = new DelegateCommand(ChangeTemplate);
        }

        private void ChangeTemplate(object obj)
        {
            var template = obj as TemplateSet;
            if (template != null)
            {
                this.SelectedTemplateSet.Empty = template.Empty;
                this.SelectedTemplateSet.Filled = template.Filled;
            }
        }

        public TemplateSet SelectedTemplateSet
        {
            get {
                return selectedTemplateSet; 
            }
            set
            {
                if (selectedTemplateSet != value)
                {
                    selectedTemplateSet = value;
                    OnPropertyChanged();
                }
            }
        }

       

        private Double value;

        public Double Value
        {
            get { return value; }
            set 
            {
                if (this.value != value)
                {
                    this.value = value;
                    OnPropertyChanged();
                }
            }
        }
        

        public ICommand ChangeTemplateCommand { get; set; }

    }
}
