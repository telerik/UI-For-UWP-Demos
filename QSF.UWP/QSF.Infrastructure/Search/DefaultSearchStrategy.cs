using System;
using System.Collections.Generic;
using System.Linq;
using QSF.Model;
using QSF.Infrastructure;

namespace QSF.Infrastructure.Search
{
    internal class DefaultSearchStrategy : ISearchStrategy
    {
        public IEnumerable<ICommonModelObject> Search(string searchQuery, IQuickStartData data)
        {
            if (string.IsNullOrEmpty(searchQuery) || data == null)
            {
                return null;
            }

            IEnumerable<ICommonModelObject> controls = data.AllControls;
            IEnumerable<ICommonModelObject> examples = data.Examples;
            IEnumerable<ICommonModelObject> allControlsAndExamples = controls.Union(examples);

            Func<ICommonModelObject, bool> searchPredicate = (ICommonModelObject item) =>
            {
                var nameMatches = item.Name.ContainsLowerCase(searchQuery);
                var keywordsMatch = item.Keywords.ContainsLowerCase(searchQuery);
                var textMatches = item.Text.ContainsLowerCase(searchQuery);
                return nameMatches || keywordsMatch || textMatches;
            };

            var results = allControlsAndExamples.Where(searchPredicate);

            if (results.Count() == 0)
            {
                return Enumerable.Empty<ICommonModelObject>();
            }

            return results;
        }
    }
}