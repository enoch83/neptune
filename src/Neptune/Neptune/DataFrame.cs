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
        {}

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
