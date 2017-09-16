using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Neptune.Tests
{
    [TestClass]
    public class SeriesTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Given_Initiating_When_DataIsNull_Then_ThrowsException()
        {
            // Arrange , Act, Assert
            Series s = new Series(null);
        }

        [TestMethod]
        public void Given_Initiating_When_DataIsNotNull_Then_SeriesLengthToEqualDataLength()
        {
            // Arrange
            object[] data = new object[] { 151.40, 155.40, 151.00, 154.10 };

            // Act
            Series s = new Series(data);
            var length = s.Length;

            // Assert
            Assert.AreEqual(length, data.Length);
        }

        [TestMethod]
        public void Given_InitiatingWithData_When_GetObjectByIndexer_Then_SeriesObjectEqualDataObject()
        {
            // Arrange
            object[] data = new object[] { 151.40, 155.40, 151.00, 154.10 };

            // Act
            Series s = new Series(data);
            var obj = s[1];

            // Assert
            Assert.AreEqual(obj, data[1]);
        }
    }
}
