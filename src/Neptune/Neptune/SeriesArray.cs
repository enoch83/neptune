using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Neptune
{
    public class SeriesArray
    {
        private readonly Series[] _array;

        public SeriesArray(Series[] array)
        {
            if (array.Any(a => a.Length != array[0].Length))
                throw new ArgumentException("arrays cn't have different lengths");
            
            _array = array ?? throw new ArgumentNullException("array can't be null");
        }

        /// <summary>
        /// Get Series by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Series this[int index]
        {
            get
            {
                return _array[index];
            }
            set
            {
                _array[index] = value;
            }
        }

        /// <summary>
        /// Get the length of the array
        /// </summary>
        /// <param name="index">0 = vertical, 1 = horizontal</param>
        /// <returns>Length of array</returns>
        public int GetLength(int index)
        {
            if (index < 0 || index > 1)
                throw new IndexOutOfRangeException("possible values of index is 0 and 1");

            if (index == 0)
                return _array.Length; 
            else 
                return _array[0].Length;
        }
    }
}
