﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neptune
{
    public partial class DataFrame : DataFrameBase
    {
        public DataFrame(SeriesArray series, string[] headers = null, string[] indexers = null)
            : base(series, headers, indexers)
        { }

        /// <summary>
        /// Get a DataFrame with only one row specified by indexer
        /// </summary>
        /// <param name="indexer">String representing indexer of row to get</param>
        /// <returns>A DataFrame</returns>
        public DataFrame Loc(string indexer)
        {
            return Loc(new string[] { indexer });
        }

        /// <summary>
        /// Get a DataFrame woth only the rows specified by indexers
        /// </summary>
        /// <param name="indexerArray">Array of strings representing indexers of rows to get</param>
        /// <returns>A DataFrame</returns>
        public DataFrame Loc(string[] indexerArray)
        {
            int[] indexArray = new int[indexerArray.Length];
            for (int i = 0; i < indexerArray.Length; i++)
            {
                if (!Indexers.Contains(indexerArray[i]))
                    throw new IndexOutOfRangeException(string.Format("Indexers dose not contain the index {0}", indexerArray[i]));

                indexArray[i] = System.Array.FindIndex(Indexers, x => x ==indexerArray[i]);
            }

            return ILoc(indexArray);
        }

        /// <summary>
        /// Get a DataFrame with one row specified with index
        /// </summary>
        /// <param name="index">Int representing the index of the row to get</param>
        /// <returns>A DataFrame</returns>
        public DataFrame ILoc(int index)
        {
            return ILoc(new int[] { index });
        }

        /// <summary>
        /// Get a DataFrame with multiple rows specified by an array of indexes
        /// </summary>
        /// <param name="indexes">Array of int representing the indexes of the rows to get</param>
        /// <returns>A DataFrame</returns>
        public DataFrame ILoc(int[] indexArray)
        {
            // Create an array of stings that holds the indexers
            string[] indexers = new string[indexArray.Length];
            for (int i = 0; i < indexArray.Length; i++)
            {
                if (Indexers.Length < indexArray[i])
                    throw new IndexOutOfRangeException(string.Format("Indexers dose not contain the index {0}", indexArray[i]));

                indexers[i] = Indexers[indexArray[i]];
            }

            Series[] series = new Series[indexers.Length];
            for (int i = 0; i < indexers.Length; i++)
            {
                object[] data = new object[Array.GetLength(1)];
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    data[j] = Array[indexArray[i]][j];
                }

                series[i] = new Series(data);
            }

            SeriesArray seriesArray = new SeriesArray(series);

            return new DataFrame(seriesArray, Headers, indexers);
        }

        public DataFrame Shift(int shift)
        {
            if (shift == 0)
                throw new ArgumentOutOfRangeException("Shift must be positive or negative, not zero");

            Series[] series = new Series[Array.GetLength(0)];
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                object[] data = new object[1];
                if (shift < 0)
                {
                    data[0] = (i - shift < Array.GetLength(0)) ? Array[i - shift][0] : 0;
                }
                else
                {
                    data[0] = (i >= shift) ? Array[i- shift][0] : 0;
                }
                    
                series[i] = new Series(data);
            }

            SeriesArray seriesArray = new SeriesArray(series);

            return new DataFrame(seriesArray, Headers, Indexers);
        }

        /// <summary>
        /// Overridden ToStrint()
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            int padLeft = 12;

            if (Headers.Length > 0)
            {
                padLeft = Headers.Max(a => a.Length) + 2 > 12 ? Headers.Max(a => a.Length) + 2 : 12;
                
                if (Indexers != null)
                {
                    sb.Append(string.Format("", "").PadLeft(padLeft));
                }

                for (int i = 0; i < Headers.Length; i++)
                {
                    sb.Append(string.Format("{0}", Headers[i]).PadLeft(padLeft));
                }

                sb.Append("\n");
            }

            for (int i = 0; i < Array.GetLength(0); i++)
            {
                if (Indexers != null)
                {
                    sb.Append(string.Format("{0}", Indexers[i]).PadLeft(padLeft));
                }

                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    sb.Append(string.Format("{0}", Array[i][j]).PadLeft(padLeft));
                }

                sb.Append("\n");
            }

            return sb.ToString();
        }

        public DataFrame Tail(int count = 5)
        {
            string[] indexers = new string[count];
            Series[] series = new Series[count];
            for (int i = Array.GetLength(0) - count; i < Array.GetLength(0); i++)
            {
                object[] data = new object[Array.GetLength(1)];
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    data[j] = Array[i][j];
                }

                series[i - Array.GetLength(0) + count] = new Series(data);
                indexers[i - Array.GetLength(0) + count] = Indexers[i];
            }

            SeriesArray seriesArray = new SeriesArray(series);

            return new DataFrame(seriesArray, Headers, indexers);
        }

        public DataFrame Head(int count = 5)
        {
            string[] indexers = new string[count];
            Series[] series = new Series[count];
            for (int i = 0; i < count; i++)
            {
                object[] data = new object[Array.GetLength(1)];
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    data[j] = Array[i][j]; 
                }

                series[i] = new Series(data);
                indexers[i] = Indexers[i];
            }

            SeriesArray seriesArray = new SeriesArray(series);

            return new DataFrame(seriesArray, Headers, indexers);
        }
    }
}
