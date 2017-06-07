using System;

namespace Chart.Gallery.Point
{
    public class PointSeriesGalleryModel : ChartGalleryModel
    {
        public static DateTime HighestEQ1
        {
            get
            {
                return new DateTime(2009, 9, 23, 10, 00, 00);
            }
        }
        public static DateTime HighestEQ2
        {
            get
            {
                return new DateTime(2009, 9, 26);
            }
        }

        public DateTime EQ1
        {
            get
            {
                return new DateTime(2009, 10, 19);
            }
        }
        public DateTime EQ2
        {
            get
            {
                return new DateTime(2009, 10, 21, 10,00,00);
            }
        }
    }
}
