using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neptune
{
    public partial class DataFrame
    {
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
                if (Headers.Length > 0)
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

                // Create an array of series thet should hold the data
                // The number of Series should equal the number of rows in Array
                Series[] series = new Series[Array.GetLength(0)];

                // For each row in the array
                for (int i = 0; i < Array.GetLength(0); i++)
                {
                    // Store the data of the columns we wan't, based on the indexArray passed to function
                    object[] data = new object[indexArray.Length];
                    for (int j = 0; j < indexArray.Length; j++)
                    {
                        data[j] = Array[i][indexArray[j]];
                    }

                    // Instanceate a new series(row) with the data(columns),
                    series[i] = new Series(data);
                }

                // Instantiates a new SeriesArray with the series.
                SeriesArray seriesArray = new SeriesArray(series);

                return new DataFrame(seriesArray, headerArray, Indexers);
            }
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
                if (Headers.Length == 0)
                    throw new IndexOutOfRangeException("Headers dose not contain the index");

                int[] indexArray = new int[headerArray.Length];

                for (int i = 0; i < headerArray.Length; i++)
                {
                    if (!Headers.Contains(headerArray[i]))
                        throw new IndexOutOfRangeException(string.Format("Headers dose not contain the index {0}", headerArray[i]));

                    var index = System.Array.FindIndex(Headers, x => x == headerArray[i]);
                    indexArray[i] = index;
                }

                return this[indexArray];
            }
        }
    }
}
