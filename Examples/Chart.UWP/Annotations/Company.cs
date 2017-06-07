using System.Collections.Generic;

namespace Chart.Annotations
{
    public class Company
    {
        private IEnumerable<CompanyData> _data;
        private string _name;
        private string _shortName;
        private IEnumerable<CompanyEvent> _significantEvents;

        public Company(string fullName, string shortName, IEnumerable<CompanyData> data)
        {
            this._name = fullName;
            this._shortName = shortName;
            this._data = data;
        }

        public IEnumerable<CompanyData> Data
        {
            get
            {
                return _data;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string ShortName
        {
            get
            {
                return _shortName;
            }
        }

        public IEnumerable<CompanyEvent> SignificantEvents
        {
            get
            {
                return this._significantEvents;
            }
            set
            {
                this._significantEvents = value;
            }
        }
    }
}
