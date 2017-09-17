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
            DataFrame open = df[1];
            Console.WriteLine(open);

            DataFrame secondRow = df.ILoc(1);
            Console.WriteLine(secondRow);

            // If we want to use any of the rows in the file as headers, pass the param 
            DataFrame df2 = ReadFile.ReadCsv(filePath, headerRow: 0);
            Console.WriteLine(df2);

            // We just added the ability to select columns by headers.
            // This is not possible without the headers, it would throw IndexOutOfRangeException
            DataFrame open2 = df2["Open"];
            Console.WriteLine(open2);

            // The ability to use the function Loc requires some indexers.
            // By passing a parameter indexerColumn we can selecte one column to be used as indexer.
            DataFrame df3 = ReadFile.ReadCsv(filePath, headerRow: 0, indexerColumn: 0);
            DataFrame secondRow2 = df3.Loc("2002-05-21");
            Console.WriteLine(secondRow2);

            // Other parameters that can be useful,
            // seperator, what symbol to use to seperate the data into columns. ; us used as default
            // skipRows, number of rows to skip befor start reading data. if a file starts with some rows that should not be included in the data
            // includeNullRows, if all values of a row is null and you don't want them to be included, set includedNullRows to false

            Console.ReadKey();
        }
    }
}
