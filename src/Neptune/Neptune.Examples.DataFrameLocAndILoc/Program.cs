using System;

namespace Neptune.Examples.DataFrameLocAndILoc
{
    class Program
    {
        static void Main(string[] args)
        {
            // open and close prices for ALFA.ST for the dates 2017-01-02 to 2017-01-05
            // creates four series, one for each date with open and close prices
            Series _2017_01_02 = new Series(new object[] { "151.40", "155.40", "151.00", "154.10" });
            Series _2017_01_03 = new Series(new object[] { "154.50", "155.90", "154.10", "155.40" });
            Series _2017_01_04 = new Series(new object[] { "155.50", "156.70", "154.10", "154.90" });
            Series _2017_01_05 = new Series(new object[] { "154.90", "155.00", "152.90", "153.20" });

            SeriesArray seriesArray = new SeriesArray(new Series[] { _2017_01_02, _2017_01_03, _2017_01_04, _2017_01_05 });

            // indexers representing the different dates
            string[] indexes = new string[] { "2017-01-02", "2017-01-03", "2017-01-04", "2017-01-05" };

            // create a datafram and print it out
            DataFrame dataFrame = new DataFrame(seriesArray, indexers: indexes);
            Console.WriteLine("Fill and print a DataFrame");
            Console.WriteLine(dataFrame);

            // We can select rows by index and indexes
            // Use the methods ILoc to get rows by index
            DataFrame thirdRowByILocDataFrame = dataFrame.ILoc(2);
            Console.WriteLine("Third row using ILoc (dataFrame.ILoc(2))");
            Console.WriteLine(thirdRowByILocDataFrame);

            // It's also possible to select multiple rows nysing an array of indexes
            DataFrame thirdFourthRowByILocDataFrame = dataFrame.ILoc(new int[] { 2, 3 });
            Console.WriteLine("Third  and fourth row using ILoc (dataFrame.ILoc(new int[] { 2, 3 }))");
            Console.WriteLine(thirdFourthRowByILocDataFrame);
            
            // Use the method Loc to get rows by indexes
            DataFrame secondRowByLocDataFrame = dataFrame.Loc("2017-01-03");
            Console.WriteLine("Row 2017-01-03 using Loc (dataFrame.Loc(\"2017-01-03\"))");
            Console.WriteLine(secondRowByLocDataFrame);

            // Use the method Loc to get rows by indexes
            DataFrame secondAndFourthRowByLocDataFrame = dataFrame.Loc(new string[] { "2017-01-03", "2017-01-05" });
            Console.WriteLine("Rows 2017-01-03 and 2017-01-05 using Loc (dataFrame.Loc(new string[] { \"2017-01-03\", \"2017-01-05\" }))");
            Console.WriteLine(secondAndFourthRowByLocDataFrame);

            Console.ReadKey();
        }
    }
}
