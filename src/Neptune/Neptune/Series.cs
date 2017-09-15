﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Neptune
{
    public class Series
    {
        private object[] _data;
        
        public Series()
        {
            _data = new object[0];
        }

        public Series(object[] data = null)
            : this()
        {
            if (data != null)
            {
                _data = data;
            }
        }
        
        /// <summary>
        /// Get or set object by index
        /// </summary>
        /// <param name="index">key of object to get or set</param>
        /// <returns></returns>
        public object this[int index]
        {
            get
            {
                return _data[index];
            }
            set
            {
                _data[index] = value;
            }
        }

        /// <summary>
        /// Get the total number of objects in the dictionary
        /// </summary>
        public int Length
        {
            get
            {
                return _data.Length;
            }
        }
    }
}
