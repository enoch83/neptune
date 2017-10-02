using System;
using System.Collections.Generic;
using System.Text;

namespace Neptune
{
    public partial class DataFrame
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="df1"></param>
        /// <param name="df2"></param>
        /// <returns></returns>
        public static DataFrame operator +(DataFrame df1, DataFrame df2)
        {
            ValidateData(df1, df2);

            Series[] series = new Series[df1.Array.GetLength(0)];

            for (int i = 0; i < df1.Array.GetLength(0); i++)
            {
                double df1Value = 0, df2Value = 0;
                double.TryParse(df1.Array[i][0].ToString(), out df1Value);
                double.TryParse(df2.Array[i][0].ToString(), out df2Value);

                series[i] = new Series(new object[] { Math.Round(df1Value + df2Value, 2) });
            }

            string[] headers = new string[] { "null" };

            SeriesArray seriesArray = new SeriesArray(series);

            return new DataFrame(seriesArray, headers, df1.Indexers);
        }

        public static DataFrame operator -(DataFrame df1, DataFrame df2)
        {
            ValidateData(df1, df2);

            Series[] series = new Series[df1.Array.GetLength(0)];

            for (int i = 0; i < df1.Array.GetLength(0); i++)
            {
                double df1Value = 0, df2Value = 0;
                double.TryParse(df1.Array[i][0].ToString(), out df1Value);
                double.TryParse(df2.Array[i][0].ToString(), out df2Value);

                series[i] = new Series(new object[] { Math.Round(df1Value - df2Value, 2) });
            }

            string[] headers = new string[] { "null" };

            SeriesArray seriesArray = new SeriesArray(series);

            return new DataFrame(seriesArray, headers, df1.Indexers);
        }

        public static DataFrame operator *(DataFrame df1, DataFrame df2)
        {
            Series[] series = new Series[df1.Array.GetLength(0)];

            for (int i = 0; i < df1.Array.GetLength(0); i++)
            {
                double df1Value = 0, df2Value = 0;
                double.TryParse(df1.Array[i][0].ToString(), out df1Value);
                double.TryParse(df2.Array[i][0].ToString(), out df2Value);

                series[i] = new Series(new object[] { Math.Round(df1Value * df2Value, 2) });
            }

            string[] headers = new string[] { "null" };

            SeriesArray seriesArray = new SeriesArray(series);

            return new DataFrame(seriesArray, headers, df1.Indexers);
        }

        public static DataFrame operator /(DataFrame df1, DataFrame df2)
        {
            Series[] series = new Series[df1.Array.GetLength(0)];

            for (int i = 0; i < df1.Array.GetLength(0); i++)
            {
                double df1Value = 0, df2Value = 0;
                double.TryParse(df1.Array[i][0].ToString(), out df1Value);
                double.TryParse(df2.Array[i][0].ToString(), out df2Value);

                series[i] = new Series(new object[] { Math.Round(df1Value / df2Value, 2) });
            }

            string[] headers = new string[] { "null" };

            SeriesArray seriesArray = new SeriesArray(series);

            return new DataFrame(seriesArray, headers, df1.Indexers);
        }

        public static implicit operator double(DataFrame df)
        {
            if (df.Array.GetLength(0) > 1)
                throw new ArgumentOutOfRangeException("Length of DataFrame must by 1, try double[].");

            double value = 0;
            double.TryParse(df.Array[0][0].ToString(), out value);

            return value;
        }

        public static implicit operator double[](DataFrame df)
        {
            double[] values = new double[df.Array.GetLength(0)];
            for (int i = 0; i < df.Array.GetLength(0); i++)
            {
                double value = 0;
                double.TryParse(df.Array[i][0].ToString(), out value);

                values[i] = value;
            }

            return values;
        }

        private static void ValidateData(DataFrame df1, DataFrame df2)
        {
            if (df1.Array.GetLength(1) != 1)
                throw new Exception("The column count on df1 != 1");

            if (df2.Array.GetLength(1) != 1)
                throw new Exception("The column count on df2 != 1");

            if (df1.Array[0][0].GetType() != df2.Array[0][0].GetType())
                throw new ArgumentException("Type of df1 not equal to type of df2");
        }
    }
}
