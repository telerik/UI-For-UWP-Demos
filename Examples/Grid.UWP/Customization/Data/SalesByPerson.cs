using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;

namespace Grid.Customization
{
    public class SalesByPerson
    {
        private List<SalesPerson> salesPersons = new List<SalesPerson>();
        private Dictionary<int, List<double>> salesChartData = new Dictionary<int, List<double>>();

        public SalesByPerson()
        {
            this.LoadChartData();
            this.LoadSalesData();
        }

        public IEnumerable Sales
        {
            get
            {
                return this.salesPersons;
            }
        }

        private void LoadChartData()
        {
            Action<XElement, SaleQuota> childElementAction = (el, q) =>
                {
                    string value = el.Value;

                    switch (el.Name.LocalName)
                    {
                        case "BusinessEntityID":
                            q.BusinessEntityId = int.Parse(value, CultureInfo.InvariantCulture);
                            break;
                        case "SalesQuota":
                            q.Quota = double.Parse(value, CultureInfo.InvariantCulture);
                            break;
                    }
                };

            Action<SaleQuota> elementAction = (q) =>
                {
                    List<double> sales;
                    if (!this.salesChartData.TryGetValue(q.BusinessEntityId, out sales))
                    {
                        sales = new List<double>();
                        this.salesChartData[q.BusinessEntityId] = sales;
                    }
                    sales.Add(q.Quota);
                };

            var path = "Grid.Customization.Data.ChartData.xml";
            XmlDataParser.Parse<SaleQuota>(path, elementAction, childElementAction);
        }

        private void LoadSalesData()
        {
            Action<XElement, SalesPerson> childElementAction = (el, p) =>
            {
                string value = el.Value;

                switch (el.Name.LocalName)
                {
                    case "BusinessEntityID":
                        p.SalesChartData = this.salesChartData[int.Parse(value, CultureInfo.InvariantCulture)];
                        break;
                    case "Country":
                        p.Country = value;
                        break;
                    case "Name":
                        p.Name = value;
                        break;
                    case "Region":
                        p.Region = value;
                        break;
                    case "SalesLastYear":
                        p.SalesLastYear = double.Parse(value, CultureInfo.InvariantCulture);
                        break;
                    case "SalesQuota":
                        p.SalesQuota = double.Parse(value, CultureInfo.InvariantCulture);
                        break;
                    case "SalesYTD":
                        p.SalesYTD = double.Parse(value, CultureInfo.InvariantCulture);
                        break;
                    case "TerritorySalesLastYear":
                        p.TerritorySalesLastYear = double.Parse(value, CultureInfo.InvariantCulture);
                        break;
                    case "TerritorySalesYTD":
                        p.TerritorySalesYTD = double.Parse(value, CultureInfo.InvariantCulture);
                        break;
                }
            };

            Action<SalesPerson> elementAction = (q) =>
            {
                this.salesPersons.Add(q);
            };

            var path = "Grid.Customization.Data.GridData.xml";
            XmlDataParser.Parse<SalesPerson>(path, elementAction, childElementAction);
        }
    }
}
