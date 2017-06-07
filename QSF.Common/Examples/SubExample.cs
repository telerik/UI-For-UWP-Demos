using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSF.Common.Examples
{
    public class SubExample : ISubExample
    {
        private string name;
        private string title;
        private string packageName;
        private object parameter;

        public SubExample(string packageName, string exampleTypeName, string title, object parameter)
        {
            this.name = exampleTypeName;
            this.title = title;
            this.parameter = parameter;
            this.packageName = packageName;
        }

        public string Name
        {
            get { return this.name; }
        }

        public string PackageName
        {
            get { return this.packageName; }
        }

        public string Title
        {
            get { return this.title; }
        }

        public object NavigationParameter
        {
            get { return this.parameter; }
        }
    }
}
