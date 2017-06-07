using System;
using System.Collections.Generic;
using System.Linq;

namespace QSF.Model
{
    public class QuickStartData : IQuickStartData
    {
        public IEnumerable<IControlInfo> AllControls { get; internal set; }

        public IEnumerable<IExampleInfo> Examples { get; internal set; }

        public IEnumerable<AppHighlightInfo> HighlightedApps { get; set; }

        public IEnumerable<IControlInfo> HighlightedControls { get; internal set; }

        public IEnumerable<HomePageExampleHighlightInfo> HighlightedExamples { get; internal set; }

        public HomePageInfo HomePage { get; internal set; }

        public ICommonModelObject FindObject(Guid id)
        {
            return ((IEnumerable<ICommonModelObject>)this.AllControls).Concat((IEnumerable<ICommonModelObject>)this.Examples).First(o => o.UniqueId == id);
        }

        public ICommonModelObject FindObject(string guid)
        {
            Guid id = Guid.Parse(guid);
            ICommonModelObject result = this.FindObject(id);
            return result;
        }
    }
}