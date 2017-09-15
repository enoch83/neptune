using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neptune
{
    public class DataFrame : DataFrameBase<SeriesArray>
    {
        public DataFrame(SeriesArray series, string[] headers = null, string[] indexers = null)
            : base(series, headers, indexers)
        { }

        /// <summary>
        /// Get a DataFram with only one column specified by index
        /// </summary>
        /// <param name="index">Int reprisenting the index</param>
        /// <returns>A DataFrame</returns>
        public DataFrame this[int index]
        {
            get
            {
                return this[new int[1] { index }];
            }
        }

        /// <summary>
        /// Get a DataFrame with only the columns specified by index
        /// </summary>
        /// <param name="indexArray">Array of ints representing the indexes</param>
        /// <returns>A DataFrame</returns>
        public DataFrame this[int[] indexArray]
        {
            get
            {
                string[] headerArray = null;

                // If headers of this DataFrame not null, we should add the correspoing headers to the new Dataframe
                if (Headers != null)
                {
                    // Instantiates a new array of string
                    // Array should hold the headers
                    headerArray = new string[indexArray.Length];

                    // There should be an equal number of headers as there are columns selecting
                    // Loop throug all columns selecting
                    // If the index selecting is grader then the length of current headers, throw an IndexOutOfRangeException
                    for (int i = 0; i < indexArray.Length; i++)
                    {
                        if (indexArray[i] > Headers.Length)
                            throw new IndexOutOfRangeException(string.Format("Headers dose not contain the index {0}", indexArray[i]));

                        headerArray[i] = Headers[indexArray[i]];
                    }
                }

                // Instantiates a new SeriesArray that should hold the series.
                // The length should be the same as the length of indexes
                SeriesArray seriesArray = new SeriesArray(indexArray.Length);

                // for each index that we wanna get, point the old series to the new array
                for (int i = 0; i < indexArray.Length; i++)
                {
                    seriesArray[i] = Array[indexArray[i]];                 
                }

                return new DataFrame(seriesArray, headerArray, Indexers);
            }
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
                string indexer = Indexers[indexArray[i]];
                if (!Indexers.Contains(indexer))
                    throw new IndexOutOfRangeException(string.Format("Indexers dose not contain the index {0}", indexArray[i]));

                indexers[i] = indexer;
            }

            Series[] series = new Series[Array.GetLength(1)];
            for (int i = 0; i < indexers.Length; i++)
            {
                object[] data = new object[indexers.Length];
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    data[j] = Array[i][indexers[j]];
                }

                series[i] = new Series(indexers, data);
            }

            SeriesArray seriesArray = new SeriesArray(series);

            return new DataFrame(seriesArray, Headers, indexers);
        }

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
            for (int i = 0; i < indexerArray.Length; i++)
            {
                if (!Indexers.Contains(indexerArray[i]))
                    throw new IndexOutOfRangeException(string.Format("Indexers dose not contain the index {0}", indexerArray[i]));
            }

            Series[] series = new Series[Array.GetLength(1)];
            for (int i = 0; i < indexerArray.Length; i++)
            {
                object[] data = new object[indexerArray.Length];
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    data[j] = Array[i][indexerArray[j]];
                }

                series[i] = new Series(indexerArray, data);
            }

            SeriesArray seriesArray = new SeriesArray(series);

            return new DataFrame(seriesArray, Headers, indexerArray);
        }

        /// <summary>
        /// Get a DataFrame with only the column specified by header
        /// </summary>
        /// <param name="header">String representing the column by header</param>
        /// <returns>A DataFrame</returns>
        public DataFrame this[string header]
        {
            get
            {
                return this[new string[1] { header }];
            }
        }

        /// <summary>
        /// Get a DataFrame with only the columns specified by headers
        /// </summary>
        /// <param name="headerArray">Array of strings representing the colums by headers</param>
        /// <returns>A DataFrame</returns>
        public DataFrame this[string[] headerArray]
        {
            get
            {
                int[] indexArray = new int[headerArray.Length];

                for (int i = 0; i < headerArray.Length; i++)
                {
                    if (!Headers.Contains(headerArray[i]))
                        throw new IndexOutOfRangeException(string.Format("Headers dose not contain the index {0}", headerArray[i]));

                    var index = System.Array.FindIndex(Headers, x => x == headerArray[i]);
                    indexArray[i] = index;
                }

                string[] headers = new string[indexArray.Length];
                for (int i = 0; i < indexArray.Length; i++)
                {
                    headers[i] = Headers[indexArray[i]];
                }

                // Instantiates a new SeriesArray that should hold the series.
                // The length should be the same as the length of indexes
                SeriesArray seriesArray = new SeriesArray(indexArray.Length);

                // for each index that we wanna get, point the old series to the new array
                for (int i = 0; i < indexArray.Length; i++)
                {
                    seriesArray[i] = Array[indexArray[i]];
                }

                return new DataFrame(seriesArray, headers, Indexers);
            }
        }

        /// <summary>
        /// Overridden ToStrint()
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            int padLeft = 12;

            if (Headers != null)
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
                    string s = Indexers != null ? Indexers[i] : i.ToString();
                    sb.Append(string.Format("{0}", Array[j][s]).PadLeft(padLeft));
                }

                sb.Append("\n");
            }

            return sb.ToString();
        }
    }
}
