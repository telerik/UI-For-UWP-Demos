using System;
using System.Collections;

namespace Grid.FirstLook
{
    public class ProductStatistic
    {
        public string Product
        {
            get;
            set;
        }

        public string Category
        {
            get;
            set;
        }

        public string SubCategory
        {
            get;
            set;
        }

        public double? Actual2010
        {
            get;
            set;
        }

        public double? Actual2011
        {
            get;
            set;
        }

        public double? Actual2012
        {
            get;
            set;
        }

        public double? Target2010
        {
            get;
            set;
        }

        public double? Target2011
        {
            get;
            set;
        }

        public double? Target2012
        {
            get;
            set;
        }

        public double TotalActual
        {
            get
            {
                return this.Actual2010.GetValueOrDefault() + this.Actual2011.GetValueOrDefault() + this.Actual2012.GetValueOrDefault();
            }
        }

        public double TotalTarget
        {
            get
            {
                return this.Target2010.GetValueOrDefault() + this.Target2011.GetValueOrDefault() + this.Target2012.GetValueOrDefault();
            }
        }

        public IEnumerable Actual
        {
            get
            {
                if (this.Actual2010 == 0)
                {
                    yield return null;
                }
                else
                {
                    yield return Actual2010;
                }

                if (this.Actual2011 == 0)
                {
                    yield return null;
                }
                else
                {
                    yield return Actual2011;
                }

                if (this.Actual2012 == 0)
                {
                    yield return null;
                }
                else
                {
                    yield return Actual2012;
                }
            }
        }

        public IEnumerable Target
        {
            get
            {
                if (this.Target2010 == 0)
                {
                    yield return null;
                }
                else
                {
                    yield return this.Target2010;
                }

                if (this.Target2011 == 0)
                {
                    yield return null;
                }
                else
                {
                    yield return this.Target2011;
                }

                if (this.Target2012 == 0)
                {
                    yield return null;
                }
                else
                {
                    yield return this.Target2012;
                }
            }
        }
    }
}
