using System;

namespace Neptune.Examples.DataFrameIndexers
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

            // headers representing the different prices
            string[] headers = new string[] { "Open", "High", "Low", "Close" };

            // create a datafram and print it out
            DataFrame dataFrame = new DataFrame(seriesArray, headers: headers);
            Console.WriteLine("Fill and print a DataFrame");
            Console.WriteLine(dataFrame);

            // Based on dataFrame, select only column at index 0, the "Open" column
            DataFrame openDataFrame = dataFrame[0];
            Console.WriteLine("First column by index (dataFrame[0])");
            Console.WriteLine(openDataFrame);

            // Based on dataFrame, select the columns at index 0 and 1, "Open" and "High" columns
            DataFrame closeHighDataFrame = dataFrame[new int[] { 0, 1}];
            Console.WriteLine("First and second column by index (dataFrame[new int[] { 0, 1}])");
            Console.WriteLine(closeHighDataFrame);

            // It's also posible to select by header
            DataFrame highDataFrame = dataFrame["High"];
            Console.WriteLine("Column High by header (dataFrame[\"High\"])");
            Console.WriteLine(highDataFrame);

            // It's also posible to select by header
            DataFrame highLowDataFrame = dataFrame[new string[] { "High", "Low" }];
            Console.WriteLine("Columns High and Low by header (dataFrame[new string[] { \"High\", \"Low\" }])");
            Console.WriteLine(highLowDataFrame);

            Console.ReadKey();
        }
    }
}
