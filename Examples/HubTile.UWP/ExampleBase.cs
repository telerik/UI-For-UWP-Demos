using System;
using System.Collections;
using QSF.Common.Examples;
using Telerik.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Controls;

namespace HubTile
{
    public abstract class ExampleBase : UserControl, ITrackIntoView
    {
        public virtual void OnDisplayed()
        {
            HubTileService.UnfreezeGroup(this.GroupTag);
        }

        public virtual void OnHidden()
        {
            HubTileService.FreezeGroup(this.GroupTag);
        }

        public abstract string GroupTag
        {
            get;
        }
    }
}
