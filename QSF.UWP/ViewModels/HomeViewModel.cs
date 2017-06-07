using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using QSF.Infrastructure;
using QSF.Model;
using QSF.Views;
using QSF.Controls;

namespace QSF.ViewModel
{
    public class HomeViewModel : NavigatingViewModel
    {
        private readonly ICanShowSpecificRegion allControlsLocator;

        private IEnumerable<IControlInfo> allControlsInfo;

        private IEnumerable<IExampleInfo> favorites;

        private IEnumerable<AppHighlightInfo> highlightedApps;

        private ObservableCollection<IControlInfo> highlightedControls = new ObservableCollection<IControlInfo>();

        private IEnumerable<CustomGridViewItemInfo> highlightedExamples;

        private IEnumerable<HighlightInfo> whatIsNewHighlights;

        public HomeViewModel()
        {
            this.InitializeControlInfos();
        }

        public HomeViewModel(ICanShowSpecificRegion regionLocator)
        {
            this.allControlsLocator = regionLocator;
            this.InitializeControlInfos();
            this.InitializeHighlightedApps();
        }

        public IEnumerable<IControlInfo> AllControlsInfo
        {
            get
            {
                return this.allControlsInfo;
            }
            set
            {
                this.allControlsInfo = value;
                this.OnPropertyChanged("AllControlsInfo");
            }
        }

        public IEnumerable<AppHighlightInfo> HighlightedApps
        {
            get
            {
                return this.highlightedApps;
            }
            set
            {
                this.highlightedApps = value;
                this.OnPropertyChanged("HighlightedApps");
            }
        }

        public ObservableCollection<IControlInfo> HighlightedControls
        {
            get
            {
                return this.highlightedControls;
            }
            set
            {
                if (this.highlightedControls != value)
                {
                    this.highlightedControls = value;
                }
                this.OnPropertyChanged("HighlightedControls");
            }
        }

        public IEnumerable<CustomGridViewItemInfo> HighlightedExamples
        {
            get
            {
                if (this.highlightedExamples == null)
                {
                    var examples = ModelFactory.GetQuickStartDataSingleton().HighlightedExamples;
                    if (examples == null)
                    {
                        this.highlightedExamples = new List<CustomGridViewItemInfo>();
                    }
                    else
                    {
                        var result = ModelFactory.GetQuickStartDataSingleton().HighlightedExamples.Select(h =>
                        {
                            var info = new CustomGridViewItemInfo();
                            info.ExampleHighlightInfo = h;
                            info.Example = h.Example;
                            info.ColumnSpan = h.WidthMultiplier;
                            info.RowSpan = h.HeightMultiplier;
                            info.Text = h.Text ?? h.Example?.HeaderText;
                            return info;
                        }).ToList();

                        result.Sort();
                        this.highlightedExamples = result;
                    }
                }

                return this.highlightedExamples;
            }
        }

        public IEnumerable<object> AllHighlitedItems
        {
            get
            {
                List<GroupInfoList<object>> groups = new List<GroupInfoList<object>>();

                if (this.HighlightedExamples.Count() > 0)
                {
                    GroupInfoList<object> highlightedExamplesGroup = new GroupInfoList<object>();
                    highlightedExamplesGroup.Key = "Featured Examples";
                    highlightedExamplesGroup.AddRange(this.HighlightedExamples);
                    groups.Add(highlightedExamplesGroup);
                }

                if (this.HighlightedControls.Count > 0)
                {
                    GroupInfoList<object> highlightedControlsGroup = new GroupInfoList<object>();
                    highlightedControlsGroup.Key = "Featured Controls";
                    highlightedControlsGroup.AddRange(this.HighlightedControls.Select(c => new CustomGridViewItemInfo { Control = c, RowSpan = 2, ColumnSpan = 2 }));
                    groups.Add(highlightedControlsGroup);
                }

                return groups;
            }
        }

        public ObservableCollection<object> HighlightedControlsItems
        {
            get
            {
                var allControlsItem = "All Controls";
                var collectionToReturn = new ObservableCollection<object>();

                collectionToReturn.Add(allControlsItem);
                foreach (var item in this.highlightedControls)
                {
                    collectionToReturn.Add(item);
                }

                return collectionToReturn;
            }
        }

        public IEnumerable<HighlightInfo> WhatIsNewHighlights
        {
            get
            {
                return this.whatIsNewHighlights;
            }
            set
            {
                this.whatIsNewHighlights = value;
                this.OnPropertyChanged("WhatIsNewHighlights");
            }
        }

        public void InitializeControlInfos()
        {
            var quickStartData = ModelFactory.GetQuickStartDataSingleton();
            this.whatIsNewHighlights = (quickStartData as QuickStartData).HomePage.Highlights;

            this.favorites = ModelFactory.GetQuickStartDataSingleton().Examples.Where(e => e.IsFavourite);

            foreach (var control in quickStartData.HighlightedControls)
            {
                this.HighlightedControls.Add(control);
            }

            this.AllControlsInfo = quickStartData.AllControls;
        }

        protected override void OnNavigateCommandExecuted(object parameter)
        {
            if (parameter != null && parameter.ToString() == "All Controls")
            {
                // scroll to all controls    
                this.allControlsLocator.ShowSpecificRegion(parameter.ToString());
            }
            else
            {
                base.OnNavigateCommandExecuted(parameter);
            }
        }

        private void InitializeHighlightedApps()
        {
            var quickStartData = ModelFactory.GetQuickStartDataSingleton();
            this.HighlightedApps = quickStartData.HighlightedApps;
        }
    }
}