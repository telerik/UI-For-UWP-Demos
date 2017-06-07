using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace Grid.FirstLook
{
    public class SalesStatistics
    {
        private ProductCategory bikes;
        private ProductCategory components;
        private ProductCategory accessories;
        private ProductCategory clothing;

        public SalesStatistics()
        {
            this.bikes = new ProductCategory() { IconPath = "ms-appx:///Grid/FirstLook/Images/bike.png", Name = "Bikes", DeviationGlyph = DeviationGlyphToBrushConverter.DownGlyph, Percent = "3%" };
            this.components = new ProductCategory() { IconPath = "ms-appx:///Grid/FirstLook/Images/components.png", Name = "Components", DeviationGlyph = DeviationGlyphToBrushConverter.UpGlyph, Percent = "17%" };
            this.accessories = new ProductCategory() { IconPath = "ms-appx:///Grid/FirstLook/Images/accessories.png", Name = "Accessories", DeviationGlyph = DeviationGlyphToBrushConverter.UpGlyph, Percent = "2%" };
            this.clothing = new ProductCategory() { IconPath = "ms-appx:///Grid/FirstLook/Images/clothing.png", Name = "Clothing", DeviationGlyph = DeviationGlyphToBrushConverter.DownGlyph, Percent = "26%" };
        }

        public IEnumerable Products
        {
            get
            {
                yield return this.bikes;
                yield return this.components;
                yield return this.accessories;
                yield return this.clothing;
            }
        }

        public void AddProduct(ProductStatistic product)
        {
            var category = product.Category;
            if (category == "Bikes")
            {
                this.bikes.Items.Add(product);
            }
            else if (category == "Accessories")
            {
                this.accessories.Items.Add(product);
            }
            else if (category == "Components")
            {
                this.components.Items.Add(product);
            }
            else if (category == "Clothing")
            {
                this.clothing.Items.Add(product);
            }
        }

        public static SalesStatistics Load()
        {
            SalesStatistics statistics = new SalesStatistics();
            double doubleValue;

            Action<ProductStatistic> rootElementAction = (el) =>
                {
                    statistics.AddProduct(el);
                };
            Action<XElement, ProductStatistic> childElementAction = (el, product) =>
            {
                string value = el.Value;

                switch (el.Name.LocalName)
                {
                    case "Category":
                        product.Category = value;
                        break;
                    case "Product":
                        product.Product = value;
                        break;
                    case "SubCategory":
                        product.SubCategory = value;
                        break;
                    case "target2010":
                        if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out doubleValue))
                        {
                            doubleValue = Math.Round(doubleValue);
                            product.Target2010 = doubleValue;
                        }
                        break;
                    case "target2011":
                        if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out doubleValue))
                        {
                            doubleValue = Math.Round(doubleValue);
                            product.Target2011 = doubleValue;
                        }
                        break;
                    case "target2012":
                        if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out doubleValue))
                        {
                            doubleValue = Math.Round(doubleValue);
                            product.Target2012 = doubleValue;
                        }
                        break;
                    case "total2010":
                        if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out doubleValue))
                        {
                            doubleValue = Math.Round(doubleValue);
                            product.Actual2010 = doubleValue;
                        }
                        break;
                    case "total2011":
                        if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out doubleValue))
                        {
                            doubleValue = Math.Round(doubleValue);
                            product.Actual2011 = doubleValue;
                        }
                        break;
                    case "total2012":
                        if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out doubleValue))
                        {
                            doubleValue = Math.Round(doubleValue);
                            product.Actual2012 = doubleValue;
                        }
                        break;
                }
            };

            XmlDataParser.Parse("Grid.FirstLook.Data.ProductSales.xml", rootElementAction, childElementAction);

            return statistics;
        }
    }
}
