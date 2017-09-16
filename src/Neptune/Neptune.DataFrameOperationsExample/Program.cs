using System;

namespace Neptune.DataFrameOperatorsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // open and close prices for ALFA.ST for the dates 2017-01-02 to 2017-01-05
            // creates four series, one for each date with open and close prices
            Series _2017_01_02 = new Series(new object[] { 151.40, 155.40, 151.00, 154.10 });
            Series _2017_01_03 = new Series(new object[] { 154.50, 155.90, 154.10, 155.40 });
            Series _2017_01_04 = new Series(new object[] { 155.50, 156.70, 154.10, 154.90 });
            Series _2017_01_05 = new Series(new object[] { 154.90, 155.00, 152.90, 153.20 });

            SeriesArray seriesArray = new SeriesArray(new Series[] { _2017_01_02, _2017_01_03, _2017_01_04, _2017_01_05 });

            // headers representing the different prices
            string[] headers = new string[] { "Open", "High", "Low", "Close" };
            // indexers representing the different dates
            string[] indexes = new string[] { "2017-01-02", "2017-01-03", "2017-01-04", "2017-01-05" };

            // create a datafram and print it out
            DataFrame dataFrame = new DataFrame(seriesArray, headers, indexes);
            Console.WriteLine(dataFrame);

            // addition 
            // It's possible to add two columns together
            // Lets sum up Open and Close for all the rows
            var open = dataFrame["Open"];
            var close = dataFrame["Close"];

            var addition = open + close;
            Console.WriteLine(addition);

            // subtraction 
            var subtraction = close - open;
            Console.WriteLine(subtraction); ;

            // multiplication 
            var multiplication = open * close;
            Console.WriteLine(multiplication);

            //division
            var division = close / open;
            Console.WriteLine(division);

            Console.ReadKey();
        }
    }
}
