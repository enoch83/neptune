using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neptune.Tests
{
    [TestClass]
    public class DataFrameShiftTests
    {
        DataFrame df;

        [TestInitialize]
        public void Setup()
        {
            Series s1 = new Series(new object[] { 10, 20 });
            Series s2 = new Series(new object[] { 20, 40 });
            Series s3 = new Series(new object[] { 30, 60 });
            Series s4 = new Series(new object[] { 40, 80 });
            Series s5 = new Series(new object[] { 50, 100 });
            SeriesArray series = new SeriesArray(new Series[] { s1, s2, s3, s4, s5 });
            df = new DataFrame(series);
        }

        [TestMethod]
        public void Given_DataSet_When_ShiftOne_Then_ReturnExpectedValue()
        {
            // Arrange
            double expected = 10;

            // Act
            var dfShift = df[0].Shift(1);
            double actual = ((double[])(dfShift[0][0]))[1];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_DataSet_When_ShiftMinusOne_Then_ReturnExpectedValue()
        {
            // Arrange
            double expected = 20;

            // Act
            var dfShift = df[0].Shift(-1);
            double actual = ((double[])(dfShift[0][0]))[0];

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
