using System;

namespace Neptune.DataFrameExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // indexes representing the first four trading days of the year
            string[] indexes = new string[] { "2017-01-02", "2017-01-03", "2017-01-04", "2017-01-05" };
            
            // open and close prices for ALFA.ST for the dates
            object[] open = new object[] { "151.40", "154.50", "155.50", "154.90" };
            object[] close = new object[] { "154.10", "155.40", "154.90", "153.20" };

            // creates two series, one for open and one for close
            Series openSeries = new Series(indexes, open);
            Series closeSeries = new Series(indexes, close);

            SeriesArray seriesArray = new SeriesArray(new Series[] { openSeries, closeSeries });

            // headers representing the different prices
            string[] headers = new string[] { "Open", "Close" };

            // create a datafram and print it out
            DataFrame dataFrame = new DataFrame(seriesArray, headers, indexes);
            Console.WriteLine(dataFrame);

            Console.ReadKey();
        }
    }
}
