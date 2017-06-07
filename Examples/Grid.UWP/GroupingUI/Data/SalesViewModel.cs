using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;

namespace Grid.GroupingUI
{
    public class SalesViewModel
    {
        private List<Sale> sales;

        public SalesViewModel()
        {
            this.sales = new List<Sale>();
            this.LoadData();
        }

        public IEnumerable Sales
        {
            get
            {
                return this.sales;
            }
        }

        private void LoadData()
        {
            Action<XElement, Sale> childElementAction = (el, p) =>
            {
                string value = el.Value;

                switch (el.Name.LocalName)
                {
                    case "PhotoID":
                        p.PictureId = int.Parse(value, CultureInfo.InvariantCulture);
                        break;
                    case "ProductCategory":
                        p.ProductCategory = value;
                        break;
                    case "ProductName":
                        p.ProductName = value;
                        break;
                    case "Region":
                        p.Region = value;
                        break;
                    case "Quantity":
                        p.Quantity = int.Parse(value, CultureInfo.InvariantCulture);
                        break;
                    case "SalesOrderNumber":
                        p.OrderId = value;
                        break;
                    case "SalesPerson":
                        p.Person = value;
                        break;
                    case "UnitPrice":
                        p.UnitPrice = double.Parse(value, CultureInfo.InvariantCulture);
                        break;
                }
            };

            Action<Sale> elementAction = (q) =>
            {
                this.sales.Add(q);
            };

            var path = "Grid.GroupingUI.Data.SalesData.xml";
            XmlDataParser.Parse<Sale>(path, elementAction, childElementAction);
        }
    }
}
