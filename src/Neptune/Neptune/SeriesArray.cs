using System;
using System.Collections.Generic;
using System.Text;

namespace Neptune
{
    public class SeriesArray
    {
        private readonly Series[] _array;

        public SeriesArray(int length)
        {
            _array = new Series[length];
        }

        public SeriesArray(Series[] array)
        {
            _array = array;
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
            if (index == 0)
                return _array.Length; 
            else if(index == 1)
                return _array[0].Length;

            throw new ArgumentException("Possible values is 0 and 1");
        }
    }
}
