using System;
using System.Collections.Generic;
using System.Text;

namespace Neptune
{
    public class Series
    {
        private Dictionary<string, object> _data;
        
        public Series()
        {
            _data = new Dictionary<string, object>();
        }

        public Series(string[] indexes = null, object[] data = null)
            : this()
        {
            if (indexes != null && data != null && indexes.Length != data.Length)
            {
                throw new ArgumentException("The length of indexes is not equeal to the length of data");
            }

            if (indexes != null)
            {
                for (int i = 0; i < indexes.Length; i++)
                {
                    _data.Add(indexes[i], data != null ? data[i] : null);
                }
            }
            else if (data != null)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    _data.Add(i.ToString(), data[i]);
                }
            }
        }
        
        /// <summary>
        /// Get item by key
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public object this[string s]
        {
            get
            {
                return _data[s];
            }
        }

        /// <summary>
        /// Get the total number of objects in the dictionary
        /// </summary>
        public int Length
        {
            get
            {
                return _data.Count;
            }
        }
    }
}
