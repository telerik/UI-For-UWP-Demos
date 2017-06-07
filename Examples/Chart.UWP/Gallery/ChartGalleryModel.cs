using System;
using System.Collections;
using System.Collections.Generic;
using QSF.Common.Examples;
using System.Reflection;
using System.IO;
using System.Globalization;

namespace Chart.Gallery
{
    public class ChartGalleryModel : GalleryModel
    {
        private static Random random = new Random();

        private static string[] countries = new string[] { "France", "Belguim", "Germany" };

        private static string[] Categories = new string[] { "Greenings", "Perfecto", "NearBy", "Family Store", "Fresh & Green" };

        public IEnumerable Data1
        {
            get;
            set;
        }

        public IEnumerable Data2
        {
            get;
            set;
        }

        public IEnumerable Data3
        {
            get;
            set;
        }

        public static List<PolarData> GetPolarData(int count, double scale)
        {
            List<PolarData> data = new List<PolarData>();
            double angleStep = 2 * Math.PI / count;

            for (int i = 0; i < count; i++)
            {
                double angle = i * angleStep;
                double c1 = 1.0 * Math.Sin(angle * 3);
                double c2 = 0.3 * Math.Sin(angle * 1.5);
                double c3 = 0.05 * Math.Cos(angle * 26);
                double c4 = 0.05 * (0.5 - random.NextDouble());
                double value = scale * (Math.Abs(c1 + c2 + c3) + c4);

                if (value < 0)
                {
                    value = 0;
                }

                data.Add(new PolarData() { Angle = angle * 180 / Math.PI, Value = value });
            }

            return data;
        }

        public static List<CategoricalData> GetCategoricalData()
        {
            List<CategoricalData> data = new List<CategoricalData>();
            for (int i = 0; i < Categories.Length; i++)
            {
                data.Add(new CategoricalData() { Value = random.Next(50, 100), Category = Categories[i] });
            }

            return data;
        }

        public static List<FinancialData> GetFinancialData()
        {
            List<FinancialData> data = new List<FinancialData>();

            data.Add(new FinancialData() { Open = 6.92, High = 10, Low = 5.78, Close = 8.85, Date = DateTime.Today });
            data.Add(new FinancialData() { Open = 8.85, High = 10.92, Low = 7.63, Close = 9.71, Date = DateTime.Today.AddDays(1) });
            data.Add(new FinancialData() { Open = 9.71, High = 10.98, Low = 8.92, Close = 9.98, Date = DateTime.Today.AddDays(2) });
            data.Add(new FinancialData() { Open = 9.98, High = 9.98, Low = 7.85, Close = 9.98, Date = DateTime.Today.AddDays(3) });
            data.Add(new FinancialData() { Open = 9.98, High = 9.98, Low = 7.77, Close = 8.70, Date = DateTime.Today.AddDays(4) });
            data.Add(new FinancialData() { Open = 8.70, High = 9.05, Low = 8.36, Close = 8.52, Date = DateTime.Today.AddDays(5) });
            data.Add(new FinancialData() { Open = 8.52, High = 8.52, Low = 8.52, Close = 8.52, Date = DateTime.Today.AddDays(6) });
            data.Add(new FinancialData() { Open = 8.52, High = 11.52, Low = 8.52, Close = 8.52, Date = DateTime.Today.AddDays(7) });
            data.Add(new FinancialData() { Open = 8.52, High = 11.52, Low = 7.52, Close = 8.52, Date = DateTime.Today.AddDays(8) });
            data.Add(new FinancialData() { Open = 8.52, High = 10.5, Low = 8.52, Close = 9.22, Date = DateTime.Today.AddDays(9) });

            data.Add(new FinancialData() { Open = 9.22, High = 10, Low = 5.78, Close = 6.85, Date = DateTime.Today.AddDays(10) });
            data.Add(new FinancialData() { Open = 6.85, High = 8.92, Low = 5.63, Close = 7.71, Date = DateTime.Today.AddDays(11) });
            data.Add(new FinancialData() { Open = 7.71, High = 8.98, Low = 6.92, Close = 7.98, Date = DateTime.Today.AddDays(12) });
            data.Add(new FinancialData() { Open = 7.98, High = 7.98, Low = 5.85, Close = 7.98, Date = DateTime.Today.AddDays(13) });
            data.Add(new FinancialData() { Open = 7.98, High = 7.98, Low = 5.77, Close = 6.70, Date = DateTime.Today.AddDays(14) });
            data.Add(new FinancialData() { Open = 6.70, High = 7.05, Low = 6.36, Close = 6.52, Date = DateTime.Today.AddDays(15) });
            data.Add(new FinancialData() { Open = 6.52, High = 6.52, Low = 6.52, Close = 6.52, Date = DateTime.Today.AddDays(16) });
            data.Add(new FinancialData() { Open = 6.52, High = 9.52, Low = 6.52, Close = 6.52, Date = DateTime.Today.AddDays(17) });
            data.Add(new FinancialData() { Open = 6.52, High = 9.52, Low = 5.52, Close = 6.52, Date = DateTime.Today.AddDays(18) });
            data.Add(new FinancialData() { Open = 6.52, High = 8.5, Low = 6.52, Close = 7.22, Date = DateTime.Today.AddDays(19) });

            return data;
        }

        public static List<NumericalData> GetNumericData(int dataCount, int xDispersion, int yDispersion, Func<int, double> xFunc, Func<int, double> yFunc)
        {
            List<NumericalData> data = new List<NumericalData>();
            for (int i = 0; i < dataCount; i++)
            {
                data.Add(new NumericalData() { XData = xFunc(i) + random.Next(0, xDispersion), YData = yFunc(i) + random.Next(0, yDispersion) });
            }

            return data;
        }

        public static IEnumerable GetSimpleData(int itemsCount, int selectedIndex)
        {
            List<SimpleData> items = new List<SimpleData>();
            for (int i = 0; i < itemsCount; i++)
            {
                SimpleData data = new SimpleData();
                data.Title = countries[i];
                data.Value = random.Next(20, 60);

                if (i == selectedIndex)
                {
                    data.IsSelected = true;
                }

                items.Add(data);
            }

            return items;
        }

        public static IEnumerable<PointData> LoadData(string dataPath)
        {           
            List<PointData> chartData = new List<PointData>();

            Assembly assembly = typeof(ChartGalleryModel).GetTypeInfo().Assembly;
            string path = "Chart.Gallery." + dataPath;
            int i = 0;
            using (StreamReader reader = new StreamReader(assembly.GetManifestResourceStream(path)))
            {
                string line = string.Empty;
                while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                {
                    i++;
                    if (i < 2000)
                    {
                        PointData dataItem = new PointData();
                        string[] data = line.Split(',');

                        dataItem.Date = DateTime.Parse(data[0], CultureInfo.InvariantCulture);
                        dataItem.Magnitude = double.Parse(data[1], CultureInfo.InvariantCulture);

                        chartData.Add(dataItem);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return chartData;
        }

        public static IEnumerable<LowHighMeasurementWeatherData> GetTemperatureData()
        {
            return new List<LowHighMeasurementWeatherData>()
			{
				new LowHighMeasurementWeatherData(new DateTime(2011, 1, 1), -14, 12),
				new LowHighMeasurementWeatherData(new DateTime(2011, 2, 1), -9, 19),
				new LowHighMeasurementWeatherData(new DateTime(2011, 3, 1), -7, 25),
				new LowHighMeasurementWeatherData(new DateTime(2011, 4, 1), 2, 28),
				new LowHighMeasurementWeatherData(new DateTime(2011, 5, 1), 8, 32),
				new LowHighMeasurementWeatherData(new DateTime(2011, 6, 1), 13, 35),
				new LowHighMeasurementWeatherData(new DateTime(2011, 7, 1), 17, 40),
				new LowHighMeasurementWeatherData(new DateTime(2011, 8, 1), 15, 34),
				new LowHighMeasurementWeatherData(new DateTime(2011, 9, 1), 11, 30),
				new LowHighMeasurementWeatherData(new DateTime(2011, 10, 1), 1, 29),
				new LowHighMeasurementWeatherData(new DateTime(2011, 11, 1), 2, 21),
				new LowHighMeasurementWeatherData(new DateTime(2011, 12, 1), -1, 17),
				new LowHighMeasurementWeatherData(new DateTime(2012, 1, 1), -11, 17),
				new LowHighMeasurementWeatherData(new DateTime(2012, 2, 1), -7, 17),
				new LowHighMeasurementWeatherData(new DateTime(2012, 3, 1), -4, 25),
				new LowHighMeasurementWeatherData(new DateTime(2012, 4, 1), 3, 31),
				new LowHighMeasurementWeatherData(new DateTime(2012, 5, 1), 9, 32),
				new LowHighMeasurementWeatherData(new DateTime(2012, 6, 1), 11, 34),
				new LowHighMeasurementWeatherData(new DateTime(2012, 7, 1), 16, 38),
				new LowHighMeasurementWeatherData(new DateTime(2012, 8, 1), 16, 33),
				new LowHighMeasurementWeatherData(new DateTime(2012, 9, 1), 12, 33),
				new LowHighMeasurementWeatherData(new DateTime(2012, 10, 1), 3, 26),
			};
        }

        public static IEnumerable<CategoricalData> GetStepSeriesData(bool isFurst)
        {
            if (isFurst)
            {
                List<CategoricalData> collection = new List<CategoricalData>();
                collection.Add(new CategoricalData { Category = "January", Value = 3.5 });
                collection.Add(new CategoricalData { Category = "February", Value = 2.8 });
                collection.Add(new CategoricalData { Category = "March", Value = 3.4 });
                collection.Add(new CategoricalData { Category = "April", Value = 3.2 });
                collection.Add(new CategoricalData { Category = "May", Value = 3.4 });
                collection.Add(new CategoricalData { Category = "June", Value = 3.7 });
                collection.Add(new CategoricalData { Category = "July", Value = 3.1 });
                collection.Add(new CategoricalData { Category = "August", Value = 2.9 });
                collection.Add(new CategoricalData { Category = "September", Value = 3.3 });
                collection.Add(new CategoricalData { Category = "October", Value = 3.1 });
                collection.Add(new CategoricalData { Category = "November", Value = 3.6 });
                collection.Add(new CategoricalData { Category = "December", Value = 3.7 });

                return collection;
            }
            else
            {
                List<CategoricalData> collection = new List<CategoricalData>();
                collection.Add(new CategoricalData{Category = "January", Value = 1.5});
                collection.Add(new CategoricalData{Category = "February", Value = 1.7});
                collection.Add(new CategoricalData{Category = "March", Value = 1.6});
                collection.Add(new CategoricalData{Category = "April", Value = 1.6});
                collection.Add(new CategoricalData{Category = "May", Value = 1.7});
                collection.Add(new CategoricalData{Category = "June", Value = 1.5});
                collection.Add(new CategoricalData{Category = "July", Value = 1.5});
                collection.Add(new CategoricalData{Category = "August", Value = 1.7});
                collection.Add(new CategoricalData{Category = "September", Value = 2.1});
                collection.Add(new CategoricalData{Category = "October", Value = 1.6});
                collection.Add(new CategoricalData{Category = "November", Value = 2});
                collection.Add(new CategoricalData { Category = "December", Value = 1.6 });

                return collection;
            }
        }
    }
}
