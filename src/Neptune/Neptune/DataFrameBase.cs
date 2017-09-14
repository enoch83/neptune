using System;
using System.Collections.Generic;
using System.Text;

namespace Neptune
{
    public abstract class DataFrameBase<T>
    {
        private T _array;
        private string[] _headers;
        private string[] _indexes;

        public DataFrameBase(T array, string[] headers = null, string[] indexes = null)
        {
            _array = array;
            _headers = headers;
            _indexes = indexes;
        }

        /// <summary>
        /// Get the arrays of the DataFrame
        /// </summary>
        internal T Array
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
                return _indexes;
            }
        }
    }
}
