using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AD.Xml.Tests
{
    [TestClass]
    public class ToLongExtensionsTests
    {
        [TestMethod]
        public void ToLongTest0()
        {
            // Arrange
            XElement element = new XElement("test", "1");

            // Act
            double? result = element.ToLong();

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void ToLongTest1()
        {
            // Arrange
            XElement element = new XElement("test", "1.1");

            // Act
            double? result = element.ToLong();

            // Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void ToLongTest2()
        {
            // Arrange
            XElement element = new XElement("test", "$1,000");

            // Act
            double? result = element.ToLong();

            // Assert
            Assert.AreEqual(1000, result);
        }
    }
}