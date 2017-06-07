using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace HubTile.FirstLook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Example : ExampleBase
    {
        public Example()
        {
            this.InitializeComponent();
            this.lineChart.DataContext = new int[] { 5, 3, 4, 7, 9, 6, 7, 2, 3 };
            this.barChart.DataContext = this.lineChart.DataContext;
            this.mosaicTile.DataContext = CommonHelper.LoadMosaicImages();
            this.statisticsTile.DataContext = CommonHelper.LoadStatisticsImages();
            this.companiesTile.DataContext = CommonHelper.LoadCompaniesImages();
        }

        public override string GroupTag
        {
            get
            {
                return "FirstLook";
            }
        }
    }
}
