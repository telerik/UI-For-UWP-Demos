using System;
using System.Collections.Generic;

namespace Grid.FirstLook
{
    public class ProductCategory
    {
        private List<ProductStatistic> items = new List<ProductStatistic>();

        public List<ProductStatistic> Items
        {
            get
            {
                return this.items;
            }
        }

        public string IconPath
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Percent
        {
            get;
            set;
        }

        public string DeviationGlyph
        {
            get;
            set;
        }
    }
}
