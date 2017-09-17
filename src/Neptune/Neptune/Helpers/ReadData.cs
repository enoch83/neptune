using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Neptune.Helpers
{
    public static class ReadFile
    {
        /// <summary>
        /// Get a DataSet from a file
        /// </summary>
        /// <param name="filePath">File to read data from</param>
        /// <param name="separator">char representing seperator used to define columns</param>
        /// <param name="skipRows">Number of rows to skip when reading, start at 1</param>
        /// <param name="headerRow">Index pointing at what row to use as header</param>
        /// <param name="indexerColumn">Index pointing at what column to use as indexers</param>
        /// <param name="includeNullRows">True/False if rows where all values is null should be included</param>
        /// <returns>A DataFrame</returns>
        public static DataFrame ReadCsv(string filePath, int? headerRow = null, int? indexerColumn = null, char separator = ';', int skipRows = 0, bool includeNullRows = true)
        {
            int numerOfRows = 0;
            var AllLines = new string[10000]; //only allocate memory here

            using (StreamReader sr = File.OpenText(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (numerOfRows >= skipRows)
                    {
                        AllLines[numerOfRows - skipRows] = line;
                    }

                    numerOfRows += 1;
                }
            }

            // Get the number of columns
            int numberOfColumns = AllLines[headerRow != null ? (int)headerRow : 0].Split(separator).Length - (indexerColumn != null ? 1 : 0);

            string[] headers = null;
            string[] indexes = indexerColumn != null ? new string[numerOfRows - skipRows - 1] : null;

            Series[] series = new Series[headerRow != null ? numerOfRows - 1 : numerOfRows];

            for (int i = 0; i < numerOfRows - skipRows; i++)
            {
                var line = AllLines[i].Split(separator);

                if (i == headerRow && headerRow != null)
                {
                    headers = line;

                    if (indexerColumn != null)
                    {
                        headers = headers.Where((source, index) => index != (int)indexerColumn).ToArray();
                    }
                }
                else
                {
                    object[] data = new object[numberOfColumns];
                    for (int j = 0; j < line.Length; j++)
                    {
                        if (indexerColumn != null && j == indexerColumn)
                        {
                            indexes[headerRow != null ? i - 1 : i] = line[j];
                        }
                        else
                        {
                            data[indexerColumn != null ? j - 1 : j] = line[j];
                        }
                    }

                    if (!includeNullRows && data.All(d => d == null))
                        continue;

                    series[headerRow != null ? i - 1 : i] = new Series(data);
                }
            }

            SeriesArray array = new SeriesArray(series);

            return new DataFrame(array, headers, indexes);
        }
    }
}
