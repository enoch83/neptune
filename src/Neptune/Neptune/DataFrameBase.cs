using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neptune
{
    public abstract class DataFrameBase
    {
        private SeriesArray _array;
        private string[] _headers;
        private string[] _indexers;

        public DataFrameBase(SeriesArray array, string[] headers = null, string[] indexers = null)
        {
            _array = array;
            _headers = headers ?? new string[0];
            _indexers = indexers ?? Enumerable.Range(0, array.GetLength(0)).Select(s => s.ToString()).ToArray();
        }

        /// <summary>
        /// Get the arrays of the DataFrame
        /// </summary>
        internal SeriesArray Array
        {
            get
            {
                return _array;
            }
        }

        /// <summary>
        /// Get the headers of the DataFrame
        /// </summary>
        internal string[] Headers
        {
            get
            {
                return _headers;
            }        
        }

        /// <summary>
        /// Get the indexers of the DataFrame
        /// </summary>
        internal string[] Indexers
        {
            get
            {
                return _indexers;
            }
        }
    }
}
