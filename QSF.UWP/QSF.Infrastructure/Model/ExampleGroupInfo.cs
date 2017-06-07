using System;
using System.Collections.Generic;
using System.Linq;

namespace QSF.Model
{
	public class ExampleGroupInfo : IExampleGroupInfo
	{
		public IControlInfo Control { get; internal set; }

		public string Name { get; set; }

		public List<IExampleInfo> Examples { get; internal set; }

        public bool IsEmpty
        {
            get
            {
                return this.Examples == null || this.Examples.Count == 0;
            }
        }

		public override int GetHashCode()
		{
			return this.Control.GetHashCode() * 233 + (this.Name == null ? 0 : this.Name.GetHashCode());
		}

		public override bool Equals(object obj)
		{
			ExampleGroupInfo egi = obj as ExampleGroupInfo;
			if (egi == null)
			{
				return false;
			}
			else
			{
				return object.Equals(this.Control, egi.Control) && object.Equals(this.Name, egi.Name);
			}
		}

	}
}
