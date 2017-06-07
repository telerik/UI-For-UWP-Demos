using System;
using QSF.Model;

namespace QSF.Controls
{
    /// <summary>
    /// A class used as a proxy between a data item and a CustomGridView
    /// </summary>
    public class CustomGridViewItemInfo : IComparable<CustomGridViewItemInfo>
    {
        public int ColumnSpan { get; set; }

        public IExampleInfo Example { get; set; }

        public IControlInfo Control { get; set; }

        public ICommonModelObject NavigationTarget
        {
            get
            {
                if (this.Example != null)
                {
                    return this.Example;
                }

                return this.Control;
            }
        }

        public ExampleHighlightInfo ExampleHighlightInfo { get; set; }

        public string Text { get; set; }

        public int RowSpan { get; set; }

        public int CompareTo(CustomGridViewItemInfo other)
        {
            if (this.ExampleHighlightInfo == null || other.ExampleHighlightInfo == null)
            {
                return 0;
            }

            return this.ExampleHighlightInfo.WidthMultiplier.CompareTo(other.ExampleHighlightInfo.WidthMultiplier) * -1 /* Descending order */;
        }
    }
}