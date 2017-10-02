using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neptune.Tests
{
    [TestClass]
    public class DataFrameTests
    {
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Given_DataFrameWithNoHeaders_When_LocWithString_Then_ThrowsException()
        {
            // Arrange
            Series s1 = new Series(new object[] { 151.40, 155.40, 151.00, 154.10 });
            SeriesArray series = new SeriesArray(new Series[] { s1 });
            DataFrame df = new DataFrame(series);

            // Act
            var assert = df.Loc("test");
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Given_DataFrameWithNoHeaders_When_LocWithStringArray_Then_ThrowsException()
        {
            // Arrange
            Series s1 = new Series(new object[] { 151.40, 155.40, 151.00, 154.10 });
            SeriesArray series = new SeriesArray(new Series[] { s1 });
            DataFrame df = new DataFrame(series);

            // Act
            var assert = df.Loc(new string[2] { "test1", "test2" });
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Given_DataFrameWithNoHeaders_When_IndexingWithString_Then_ThrowsException()
        {
            // Arrange
            Series s1 = new Series(new object[] { 151.40, 155.40, 151.00, 154.10 });
            SeriesArray series = new SeriesArray(new Series[] { s1 });
            DataFrame df = new DataFrame(series);

            // Act
           var assert = df["test"];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Given_DataFrameWithNoHeaders_When_IndexingWithStringArray_Then_ThrowsException()
        {
            // Arrange
            Series s1 = new Series(new object[] { 151.40, 155.40, 151.00, 154.10 });
            SeriesArray series = new SeriesArray(new Series[] { s1 });
            DataFrame df = new DataFrame(series);

            // Act
            var assert = df[new string[2] { "test1", "test2"}];
        }
    }
}
