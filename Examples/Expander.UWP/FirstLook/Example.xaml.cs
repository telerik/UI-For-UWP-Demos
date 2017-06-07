using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Telerik.Data.Core;
using Telerik.UI.Xaml.Controls.Primitives.LoopingList;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Expander.FirstLook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Example : Page
    {
        public Example()
        {
            this.InitializeComponent();

            this.Attraction1.DataContext = new Attraction
             {
                 MainImage = this.GetImagePath("Eiffel-Tower_Attraction.jpg"),
                 Description = "Paris is located on the Seine River in northern part of France and with more iconic landmarks than almost any city in the world.",
                 Image1 = this.GetImagePath("Arc-de-Triomphe_Attraction.jpg"),
                 Image2 = this.GetImagePath("Concorde-Square-Paris-France.jpg"),
                 Image3 = this.GetImagePath("Eiffel-Tower-Paris-France.jpg"),
                 MainColor = new SolidColorBrush(Color.FromArgb(255, 21, 115, 230)),
                 Title = "Grand tour of France",
             };

            this.Attraction2.DataContext = new Attraction
          {
              MainImage = this.GetImagePath("Featherbed-Nature-Reserve_Attraction.jpg"),
              Description = "Africa provides some of the most epic wildlife diversity on the planet combining it with great sightseeing.",
              Image1 = this.GetImagePath("Kruger-National-Park-South-Africa.jpg"),
              Image2 = this.GetImagePath("Kruger-National-Park_Attraction.jpg"),
              Image3 = this.GetImagePath("The-Cape-of-Good-Hope_Attraction.jpg"),
              MainColor = new SolidColorBrush(Color.FromArgb(255, 1, 140, 176)),
              Title = "Highlights of South Africa",
          };

            this.Attraction3.DataContext = new Attraction
           {
               MainImage = this.GetImagePath("Grand-Canal_Attraction.jpg"),
               Description = "Italian Republic is a history lover's paradise with thousands of museums, churches and archeological sites dating back to Roman and Greek times.",
               Image1 = this.GetImagePath("Roman-Colosseum_Attraction.jpg"),
               Image2 = this.GetImagePath("Leaning-Tower-of-Venice.jpg"),
               Image3 = this.GetImagePath("San-Giacomo-di-Rialto.jpg"),
               MainColor = new SolidColorBrush(Color.FromArgb(255, 208, 103, 68)),
               Title = "Wonders of Italy",
           };

        }

        public string GetImagePath(string imageName)
        {
            return "ms-appx:///Expander/FirstLook/Images/" + imageName;
        }
    }

    public class Attraction
    {
        public string MainImage { get; set; }

        public Brush MainColor { get; set; }

        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }


}
