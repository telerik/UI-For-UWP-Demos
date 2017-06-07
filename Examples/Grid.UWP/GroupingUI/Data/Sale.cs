using System;

namespace Grid.GroupingUI
{
    public class Sale
    {
        public string PictureSource
        {
            get
            {
                return "ms-appx:///Grid/GroupingUI/Data/Images/p" + this.PictureId + ".gif";
            }
        }

        public int PictureId
        {
            get;
            set;
        }

        public string ProductCategory
        {
            get;
            set;
        }

        public string ProductName
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }

        public string Region
        {
            get;
            set;
        }

        public string OrderId
        {
            get;
            set;
        }

        public string Person
        {
            get;
            set;
        }

        public double UnitPrice
        {
            get;
            set;
        }

        public double Total
        {
            get
            {
                return this.Quantity * this.UnitPrice;
            }
        }
    }
}
