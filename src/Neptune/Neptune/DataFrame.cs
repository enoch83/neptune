using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neptune
{
    public class DataFrame : DataFrameBase<SeriesArray>
    {
        public DataFrame(SeriesArray array, string[] headers = null, string[] indexes = null)
            : base(array, headers, indexes)
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
                        {
                            throw new IndexOutOfRangeException(string.Format("Headers dose not contain the index {0}", indexArray[i]));
                        }

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

        public DataFrame this[string header]
        {
            get
            {
                return this[new string[1] { header }];
            }
        }

        /// <summary>
        /// Get a DataFrame with only the columns specified by column header
        /// </summary>
        /// <param name="columnNames">Array of strings representing the colums</param>
        /// <returns>A DataFrame</returns>
        public DataFrame this[string[] headers]
        {
            get
            {
                int[] indexArray = new int[headers.Length];

                for (int i = 0; i < headers.Length; i++)
                {
                    var index = System.Array.FindIndex(Headers, x => x == headers[i]);
                    indexArray[i] = index;
                    if (!Headers.Contains(headers[i]))
                    {
                        throw new IndexOutOfRangeException(string.Format("Headers dose not contain the index {0}", headers[i]));
                    }
                }

                string[] headerArray = new string[indexArray.Length];
                for (int i = 0; i < indexArray.Length; i++)
                {
                    headerArray[i] = Headers[indexArray[i]];
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
