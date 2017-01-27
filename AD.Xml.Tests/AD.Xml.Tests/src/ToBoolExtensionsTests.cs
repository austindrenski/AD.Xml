using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AD.Xml.Tests
{
    [TestClass]
    public class ToBoolExtensionsTests
    {
        [TestMethod]
        public void ToBoolTest0()
        {
            // Arrange
            XElement element = new XElement("record", "0");

            // Act
            bool? result = element.ToBool();

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ToBoolTest1()
        {
            // Arrange
            XElement element = new XElement("record", "1");

            // Act
            bool? result = element.ToBool();

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ToBoolTest2()
        {
            // Arrange
            XElement element = new XElement("record", "a");

            // Act
            bool? result = element.ToBool();

            // Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void ToBoolTest3()
        {
            // Arrange
            XElement element = new XElement("record", "true");

            // Act
            bool? result = element.ToBool();

            // Assert
            Assert.AreEqual(true, result);
        }
         
        [TestMethod]
        public void ToBoolTest4()
        {
            // Arrange
            XElement element = new XElement("record", "false");

            // Act
            bool? result = element.ToBool();

            // Assert
            Assert.AreEqual(false, result);
        }
    }
}