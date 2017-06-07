using System;
using System.Collections.Generic;
using System.Linq;
using QSF.Infrastructure;
using QSF.Model;
using Windows.UI.Xaml.Data;

namespace QSF.ViewModel
{
    public class SearchResultsViewModel : NavigatingViewModel
    {
        private CollectionViewSource cvs;
        private CollectionViewSource filteredCvs;
        private CollectionViewSource groupsCvs;
        private string queryText;
        private object selectedGroup;

        /// <summary>
        /// Contains all search results
        /// </summary>
        public CollectionViewSource Cvs
        {
            get
            {
                return this.cvs;
            }
            set
            {
                this.cvs = value;
                this.OnPropertyChanged("Cvs");
            }
        }

        /// <summary>
        /// Contains the results in Cvs filtered by SelectedGroup
        /// </summary>
        public CollectionViewSource FilteredCvs
        {
            get
            {
                return this.filteredCvs;
            }
            set
            {
                this.filteredCvs = value;
                this.OnPropertyChanged("FilteredCvs");
            }
        }

        /// <summary>
        /// Contains the groups of results diplayed in snapped view
        /// </summary>
        public CollectionViewSource GroupsCvs
        {
            get
            {
                return this.groupsCvs;
            }
            set
            {
                this.groupsCvs = value;
                this.OnPropertyChanged("GroupsCvs");
            }
        }

        public string QueryText
        {
            get
            {
                return this.queryText;
            }
            set
            {
                this.queryText = value;
                this.OnPropertyChanged("QueryText");
            }
        }

        public object SelectedGroup
        {
            get
            {
                return this.selectedGroup;
            }
            set
            {
                this.selectedGroup = value;

                bool isResultFiltered = this.selectedGroup is GroupInfoList<IExampleInfo> && ((GroupInfoList<IExampleInfo>)this.selectedGroup).Key is IControlInfo;
                
                if (isResultFiltered)
                {
                    this.FilteredCvs.Source = (this.Cvs.Source as List<GroupInfoList<IExampleInfo>>).Where(gil => gil.Equals(this.selectedGroup));
                }
                else
                {
                    this.FilteredCvs.Source = this.Cvs.Source;
                }

                this.OnPropertyChanged("SelectedGroup");
            }
        }

        public void UpdateSearchInfo(string searchQuery)
        {
            var searchStrategy = ModelFactory.CreateDefaultSearchStrategy();
            var allResults = searchStrategy.Search(searchQuery, ModelFactory.GetQuickStartDataSingleton());

            this.QueryText = string.Format("\"{0}\"", searchQuery);

            if (allResults == null)
            {
                this.Cvs = new CollectionViewSource();
                this.FilteredCvs = new CollectionViewSource();
                return;
            }

            var exampleResults = allResults.OfType<IExampleInfo>().ToArray();

            List<GroupInfoList<IExampleInfo>> groupedResults =
                (from r in exampleResults
                 group r by r.ExampleGroup.Control
                 into g select new GroupInfoList<IExampleInfo>(g.Key, g)).OrderByDescending(i => i.Count).ToList();

            this.Cvs = new CollectionViewSource() { Source = groupedResults, IsSourceGrouped = true };
            this.FilteredCvs = new CollectionViewSource() { Source = groupedResults, IsSourceGrouped = true };

            // copy groupedResults to another list to add a dummy item later showing "All" group in snapped view
            GroupInfoList<IExampleInfo>[] groupedResultsCopy = new GroupInfoList<IExampleInfo>[groupedResults.Count];
            groupedResults.CopyTo(groupedResultsCopy);
            var groupedResultsCopyToList = groupedResultsCopy.ToList();

            // Add a dummy item for the filtering ComboBox in snapped state 
            // to display group for all found entries like "All (32)"
            var dummyItem = new
            {
                Name = "All"
            };

            var dummyResultEntry = new GroupInfoList<IExampleInfo>();
            dummyResultEntry.InsertRange(0, groupedResultsCopyToList.ToList().SelectMany(gil => gil.ToList()));
            dummyResultEntry.Key = dummyItem;
            groupedResultsCopyToList.Insert(0, dummyResultEntry);

            this.GroupsCvs = new CollectionViewSource() { Source = groupedResultsCopyToList };
        }
    }
}