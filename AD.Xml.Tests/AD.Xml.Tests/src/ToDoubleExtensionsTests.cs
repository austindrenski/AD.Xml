using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AD.Xml.Tests
{
    [TestClass]
    public class ToDoubleExtensionsTests
    {
        [TestMethod]
        public void ToDoubleTest0()
        {
            // Arrange
            XElement element = new XElement("test", "1");

            // Act
            double? result = element.ToDouble();

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void ToDoubleTest1()
        {
            // Arrange
            XElement element = new XElement("test", "1.1");

            // Act
            double? result = element.ToDouble();

            // Assert
            Assert.AreEqual(1.1, result);
        }

        [TestMethod]
        public void ToDoubleTest2()
        {
            // Arrange
            XElement element = new XElement("test", "$1,000.1");

            // Act
            double? result = element.ToDouble();

            // Assert
            Assert.AreEqual(1000.1, result);
        }
    }
}