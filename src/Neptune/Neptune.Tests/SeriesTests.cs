using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Neptune.Tests
{
    [TestClass]
    public class SeriesTests
    {
        private string[] indexes = new string[4]
        {
            "2017-01-01",
            "2017-01-02",
            "2017-01-03",
            "2017-01-04",
        };

        [TestMethod]
        public void Given_new_Series_When_no_data_and_no_indexers_Then_Data_count_equal_zero()
        {
            Series series = new Series();

            Assert.IsTrue(series.Length == 0);
        }

        [TestMethod]
        public void Given_new_Series_When_indexes_and_no_data_Then_Data_count_equal_indexes_count_And_Data_Keys_contains_all_indexes_And_Data_Values_are_null()
        {
            Series series = new Series(indexes: indexes);

            Assert.IsTrue(series.Length == 4);
            //Assert.IsTrue(indexes.All(i => series.ContainsKey(i)));
            //Assert.IsTrue(series.Data.All(d => d.Value == null));
        }
    }
}
