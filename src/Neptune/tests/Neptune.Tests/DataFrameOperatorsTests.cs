using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neptune.Tests
{
    [TestClass]
    public class DataFrameOperatorsTests
    {
        DataFrame df1, df2, df3, df4 = null;

        [TestInitialize]
        public void Setup()
        {
            Series s1 = new Series(new object[] { 10 });
            SeriesArray series1 = new SeriesArray(new Series[] { s1 });
            df1 = new DataFrame(series1);

            Series s2 = new Series(new object[] { 20 });
            SeriesArray series2 = new SeriesArray(new Series[] { s2 });
            df2 = new DataFrame(series2);

            Series s3 = new Series(new object[] { 20 });
            Series s4 = new Series(new object[] { 40 });
            SeriesArray series3 = new SeriesArray(new Series[] { s1, s3 });
            df3 = new DataFrame(series3);

            SeriesArray series4 = new SeriesArray(new Series[] { s2, s4 });
            df4 = new DataFrame(series4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Given_TwoDataFramesWithTwoColumns_When_AdditionAndCastToDouble_Then_ThrowsException()
        {
            // Act
            double actual = df3 + df4;
        }

        [TestMethod]
        public void Given_TwoDataFramesWithOneColumn_When_Addition_Then_ReturnExpectedValue()
        {
            // Arrange
            double expected = 30;

            // Act
            double actual = df1 + df2;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_OneDataFrame_When_AdditionWithDouble_Then_ReturnExpectedValue()
        {
            // Arrange
            double expected = 30;
            double value = 20;

            // Act
            double actual = df1 + value;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_TwoDataFramesWithTwoColumns_When_Addition_Then_ReturnExpectedValue()
        {
            // Arrange
            double[] expected = new double[] { 30, 60 };

            // Act
            double[] actual = df3 + df4;

            // Assert
            Assert.AreEqual(expected.Length, actual.Length);
            Assert.AreEqual(expected[0], actual[0]);
        }
    }
}
