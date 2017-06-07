using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSF.Common.Examples
{
    public interface ISubExample
    {
        string Name { get; }
        string PackageName { get; }
        string Title { get; }
        object NavigationParameter { get; }
    }
}
