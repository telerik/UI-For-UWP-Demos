using System;
using System.Linq;
using Telerik.Data.Core;

namespace Grid.Grouping
{
    public class AlpabeticGroupKeyLookup : IKeyLookup
    {
        public object GetKey(object instance)
        {
            return ((Person)instance).LastName[0];
        }
    }
}
