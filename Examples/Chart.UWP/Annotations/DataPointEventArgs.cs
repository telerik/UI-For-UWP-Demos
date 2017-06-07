using System;
using Telerik.Charting;

namespace Chart.Annotations
{
    public class DataPointEventArgs : EventArgs
    {
        private CategoricalDataPoint _dataPoint;

        public DataPointEventArgs(CategoricalDataPoint dataPoint)
        {
            this._dataPoint = dataPoint;
        }

        public CategoricalDataPoint DataPoint
        {
            get
            {
                return _dataPoint;
            }
        }
    }
}
