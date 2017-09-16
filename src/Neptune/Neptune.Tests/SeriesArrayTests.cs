using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neptune.Tests
{
    [TestClass]
    public class SeriesArrayTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Given_Initiating_When_ArrayIsNull_Then_ThrowsException()
        {
            // Arrange , Act, Assert
            SeriesArray sa = new SeriesArray(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Given_Initiating_When_ArrayObjectHaveDifferentLengths_Then_ThrowsException()
        {
            // Arrange 
            Series s1 = new Series(new object[] { 151.40, 155.40, 151.00, 154.10 });
            Series s2 = new Series(new object[] { 154.50, 155.90 });
            Series[] array = new Series[] { s1, s2 };

            // Act, Assert
            SeriesArray sa = new SeriesArray(array);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Given_InitiatingWithData_When_GetLengthLessThenZero_Then_ThrowsException()
        {
            // Arrange
            Series s = new Series(new object[] { 151.40, 155.40, 151.00, 154.10 });
            Series[] array = new Series[] { s };

            // Act
            SeriesArray sa = new SeriesArray(array);
            sa.GetLength(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Given_InitiatingWithData_When_GetLengthMoreThenOne_Then_ThrowsException()
        {
            // Arrange
            Series s = new Series(new object[] { 151.40, 155.40, 151.00, 154.10 });
            Series[] array = new Series[] { s };

            // Act
            SeriesArray sa = new SeriesArray(array);
            sa.GetLength(2);
        }

        [TestMethod]
        public void Given_InitiatingWithData_When_GetLengthZero_Then_ValueEqualTheNumberOfObjectsInArray()
        {
            // Arrange
            Series s1 = new Series(new object[] { 151.40, 155.40, 151.00, 154.10 });
            Series s2 = new Series(new object[] { 154.50, 155.90, 154.10, 155.40 });
            Series[] array = new Series[] { s1, s2 };

            // Act
            SeriesArray sa = new SeriesArray(array);
            var length = sa.GetLength(0);

            // Assert
            Assert.AreEqual(length, array.Length);
        }

        [TestMethod]
        public void Given_InitiatingWithData_When_GetLengthOne_Then_ValueEqualTheNumberOfObjectsInSeries()
        {
            // Arrange
            Series s = new Series(new object[] { 151.40, 155.40, 151.00, 154.10 });
            Series[] array = new Series[] { s };

            // Act
            SeriesArray sa = new SeriesArray(array);
            var length = sa.GetLength(1);

            // Assert
            Assert.AreEqual(length, s.Length);
        }

        [TestMethod]
        public void Given_InitiatingWithData_When_GetSeriesByIndexer_Then_SeriesEqualSeries()
        {
            // Arrange
            Series s1 = new Series(new object[] { 151.40, 155.40, 151.00, 154.10 });
            Series s2 = new Series(new object[] { 154.50, 155.90, 154.10, 155.40 });
            Series[] array = new Series[] { s1, s2 };

            // Act
            SeriesArray sa = new SeriesArray(array);
            var obj = sa[1];

            // Assert
            Assert.AreEqual(obj, array[1]);
        }
    }
}
