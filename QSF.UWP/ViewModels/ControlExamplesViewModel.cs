using System;
using System.Collections.Generic;
using System.Linq;
using QSF.Controls;
using QSF.Infrastructure;
using QSF.Model;
using Windows.UI.ViewManagement;

namespace QSF.ViewModel
{
    public class ControlExamplesViewModel : NavigatingViewModel
    {
        private IControlInfo currentControlInfo;

        public ControlExamplesViewModel()
        {
            
        }

        public IControlInfo CurrentControlInfo
        {
            get
            {
                return this.currentControlInfo;
            }
            set
            {
                this.currentControlInfo = value;
                this.OnPropertyChanged("CurrentControlInfo");
                this.OnPropertyChanged("HighlightedExampleItems");
                this.OnPropertyChanged("AllExampleItems");
                this.OnPropertyChanged("AllItems");
            }
        }

        public IEnumerable<IControlInfo> QuickStartData
        {
            get
            {
                return ModelFactory.GetQuickStartDataSingleton().AllControls;
            }
        }

        public IEnumerable<CustomGridViewItemInfo> HighlightedExampleItems
        {
            get
            {
                List<CustomGridViewItemInfo> list = new List<CustomGridViewItemInfo>();

                foreach (var example in this.currentControlInfo.Examples)
                {
                    foreach (var highlight in example.Highlights)
                    {
                        var gridViewItemInfo = new CustomGridViewItemInfo();
                        gridViewItemInfo.ExampleHighlightInfo = highlight;
                        gridViewItemInfo.Example = example;
                        gridViewItemInfo.ColumnSpan = highlight.WidthMultiplier;
                        gridViewItemInfo.RowSpan = highlight.HeightMultiplier;

                        list.Add(gridViewItemInfo);
                    }
                }

                // sort the highlighted items by the Width multiplier
                list.Sort();

                return list;
            }
        }

        public IEnumerable<CustomGridViewItemInfo> AllExampleItems
        {
            get
            {
                return from all in this.currentControlInfo.Examples select new CustomGridViewItemInfo { Example = all, ColumnSpan = 2, RowSpan = 1 };
            }
        }

        public IEnumerable<dynamic> AllItems
        {
            get
            {
                List<GroupInfoList<object>> groups = new List<GroupInfoList<object>>();

                if (this.HighlightedExampleItems.Count() > 0)
                {
                    GroupInfoList<object> highlightedControlsGroup = new GroupInfoList<object>();
                    highlightedControlsGroup.Key = "Highlight";
                    highlightedControlsGroup.AddRange(this.HighlightedExampleItems);
                    groups.Add(highlightedControlsGroup);
                }

                GroupInfoList<object> allExamplesGroup = new GroupInfoList<object>();
                allExamplesGroup.Key = "All Examples";
                allExamplesGroup.AddRange(this.AllExampleItems);

                groups.Add(allExamplesGroup);

                return groups;
            }
        }
    }
}
