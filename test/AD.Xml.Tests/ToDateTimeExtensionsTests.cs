using System;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AD.Xml.Tests
{
    [TestClass]
    public class ToDateTimeExtensionsTests
    {
        [TestMethod]
        public void ToDateTimeTest0()
        {
            // Arrange
            XElement element = new XElement("Date", "01/01/2017");

            // Act
            DateTime? result = element.ToDateTime();

            // Assert
            Assert.AreEqual(new DateTime(2017, 1, 1), result);
        }

        [TestMethod]
        public void ToDateTimeTest1()
        {
            // Arrange
            XElement element = new XElement("Date", "01/01/201717");

            // Act
            DateTime? result = element.ToDateTime();

            // Assert
            Assert.AreEqual(null, result);
        }
    }
}