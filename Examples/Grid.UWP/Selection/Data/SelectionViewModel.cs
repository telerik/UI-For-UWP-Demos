using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grid.Grouping;
using System.Reflection;
using System.Xml.Linq;
using System.IO;
using Telerik.UI.Xaml.Controls.Grid;

namespace Grid.Selection
{
    public class SelectionViewModel
    {
        private static List<Person> staticData;

        static SelectionViewModel()
        {
            Load();
        }

        public SelectionViewModel()
        {
            SelectionUnits = new List<DataGridSelectionUnit> { DataGridSelectionUnit.Cell, DataGridSelectionUnit.Row };
        }

        public IList<Person> Data
        {
            get
            {
                return staticData;
            }
        }

        public IList<DataGridSelectionUnit> SelectionUnits
        {
            get;
            set;
        }
        private static void Load()
        {
            var assembly = typeof(PeopleViewModel).GetTypeInfo().Assembly;
            var path = "Grid.Selection.Data.SelectionData.xml";

            staticData = new List<Person>();

            using (Stream stream = assembly.GetManifestResourceStream(path))
            {
                XDocument document = XDocument.Load(stream);
                foreach (XElement element in document.Root.Elements())
                {
                    var employee = new Person();

                    foreach (var childElement in element.Elements())
                    {
                        string value = childElement.Value;

                        switch (childElement.Name.LocalName)
                        {
                            case "AddressLine1":
                                employee.AddressLine = value;
                                break;
                            case "City":
                                employee.City = value;
                                break;
                            case "CountryCode":
                                employee.CountryCode = value;
                                break;
                            case "CountryName":
                                employee.CountryName = value;
                                break;
                            case "FirstName":
                                employee.FirstName = value;
                                break;
                            case "LastName":
                                employee.LastName = value;
                                break;
                            case "PhoneNumber":
                                employee.PhoneNumber = value;
                                break;
                            case "PostalCode":
                                employee.PostalCode = value;
                                break;
                        }
                    }

                    staticData.Add(employee);
                }
            }
        }
    }
}
