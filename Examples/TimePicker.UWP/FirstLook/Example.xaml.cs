using QSF.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TimePicker.FirstLook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Example : UserControl, INotifyPropertyChanged
    {
        private Consultant selectedConsultant;
        private DateTime selectedDateTime;

        public Example()
        {
            this.InitializeComponent();
            this.Consultants = this.GetConsultants();
            this.SelectedConsultant = this.Consultants.FirstOrDefault();
            this.SelectedDateTime = DateTime.Today.AddDays(1).AddHours(10);
            this.AddAppointmentCommand = new DelegateCommand(this.AddAppointment);
            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime SelectedDateTime
        {
            get
            {
                return this.selectedDateTime;
            }
            set
            {
                if (this.selectedDateTime != value)
                {
                    this.selectedDateTime = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Consultant> Consultants { get; set; }

        public Consultant SelectedConsultant
        {
            get
            {
                return this.selectedConsultant;
            }
            set
            {
                if (this.selectedConsultant != value)
                {
                    this.selectedConsultant = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public ICommand AddAppointmentCommand { get; set; }

        private void AddAppointment(object parameter)
        {
            this.SelectedConsultant.Appointments.Add(new Appointment { Date = this.SelectedDateTime });
            this.SelectedDateTime = DateTime.Today.AddDays(1).AddHours(10);
        }

        private ObservableCollection<Consultant> GetConsultants()
        {
            var data = new ObservableCollection<Consultant>();

            data.Add(
                new Consultant { Name = "Jake Connely", Title = "it operations", Description = "Developing IT strategies, IT architectures and ID govenrance", Image = "Images/2.png" });
            data.Add(
                new Consultant { Name = "Daniela Andreasson", Title = "E-mobility", Description = "Making electric cars a future reality involves different lead markets and value chain positions", Image = "Images/1.png" });
            data.Add(
                new Consultant { Name = "Claire Macintosh", Title = "Telecommunications", Description = "From IPTV launches to supporting recent major acquisitions; from strategy to restructuring", Image = "Images/3.png" });
            data.Add(
                new Consultant { Name = "Andrew Fox", Title = "Risk", Description = "Strategic business planning, controlling and reporting", Image = "Images/4.png" });

            return data;
        }

        private void OnPropertyChanged([CallerMemberName]
                                       string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public class Consultant
        {
            public Consultant()
            {
                this.Appointments = new ObservableCollection<Appointment>();
            }

            public ObservableCollection<Appointment> Appointments { get; set; }

            public string Name { get; set; }

            public string Title { get; set; }

            public string Description { get; set; }

            public string Image { get; set; }
        }

        public class Appointment
        {
            public DateTime Date { get; set; }
        }
    }

}
