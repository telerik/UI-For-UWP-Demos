using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSF.ViewModel
{
    public class GroupInfoList<T> : List<object>
    {
        public object Key { get; set; }

        public new IEnumerator<object> GetEnumerator()
        {
            return (System.Collections.Generic.IEnumerator<object>)base.GetEnumerator();
        }

        public GroupInfoList()
        {

        }

        public GroupInfoList(object key, IEnumerable<object> items)
        {
            this.Key = key;
            this.AddRange(items);
        }
    }
}
