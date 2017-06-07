using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QSF.Model;

namespace QSF.Infrastructure.Search
{
    /// <summary>
    /// Interface representing a search strategy for finding a model object using a specified query. <br/>
    /// This is an implementation of the Strategy design pattern.
    /// </summary>
    public interface ISearchStrategy
    {
        /// <summary>
        /// Search in the provided QuickStart data for objects with properties, matching the specified query.
        /// </summary>
        /// <param name="searchQuery">Query to search for.</param>
        /// <param name="data">The <see cref="QSF.Model.IQuickStartData">IQuickStartData</see> object to search in.</param>
        /// <returns>Returns an <see cref="QSF.Model.ICommonModelObject">ICommonModelObject</see> collection that represent the search results.</returns>
        IEnumerable<ICommonModelObject> Search(string searchQuery, IQuickStartData data);
    }
}
