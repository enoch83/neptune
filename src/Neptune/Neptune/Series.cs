using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
        /// Get or set object by key
        /// </summary>
        /// <param name="key">key of object to get or set</param>
        /// <returns></returns>
        public object this[string key]
        {
            get
            {
                return _data[key];
            }
            set
            {
                _data[key] = value;
            }
        }

        /// <summary>
        /// Get or set object by index
        /// </summary>
        /// <param name="i">index of object to get or set</param>
        /// <returns>object</returns>
        public object this[int index]
        {
            get
            {
                string key = _data.Keys.ToArray()[index];
                return _data[key];
            }
            set
            {
                string key = _data.Keys.ToArray()[index];
                _data[key] = value;
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
