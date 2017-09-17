using Neptune.Helpers;
using System;

namespace Neptune.ReadCsvExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "ALFA.ST.csv";

            // To import a DataFrame from a csv file, use the function ReadCsv.
            // The only thing we need to pass to the function is a file path.
            DataFrame df = ReadFile.ReadCsv(filePath);
            Console.WriteLine(df);

            // It's possible to get A DataFrame with only some columns using the indexer with a column index. If we want the 'Open' column, pass 1 to the indexer
            // We can also get specific rows using the ILoc function. To select the second row, pass 1
            // Remeber, both the indexer and ILoc is zero-based
            var open = df[1];
            Console.WriteLine(open);

            var secondRow = df.ILoc(1);
            Console.WriteLine(secondRow);

            // If we want to use any of the rows in the file as headers, pass the param 
            DataFrame df2 = ReadFile.ReadCsv(filePath, headerRow: 0);
            Console.WriteLine(df2);

            // We just added the ability to select columns by headers.
            // This is not possible without the headers, it would throw IndexOutOfRangeException
            DataFrame open2 = df2["Open"];
            Console.WriteLine(open2);

            // By passing 


            Console.ReadKey();
        }
    }
}
