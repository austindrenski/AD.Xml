using System.Xml.Linq;
using JetBrains.Annotations;
using Xunit;

namespace AD.Xml.Tests
{
    [UsedImplicitly]
    public class ToDoubleExtensionsTests
    {
        [Fact]
        public void ToDoubleTest0()
        {
            // Arrange
            XElement element = new XElement("test", "1");

            // Act
            double? result = element.ToDouble();

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void ToDoubleTest1()
        {
            // Arrange
            XElement element = new XElement("test", "1.1");

            // Act
            double? result = element.ToDouble();

            // Assert
            Assert.Equal(1.1, result);
        }

        [Fact]
        public void ToDoubleTest2()
        {
            // Arrange
            XElement element = new XElement("test", "$1,000.1");

            // Act
            double? result = element.ToDouble();

            // Assert
            Assert.Equal(1000.1, result);
        }
    }
}