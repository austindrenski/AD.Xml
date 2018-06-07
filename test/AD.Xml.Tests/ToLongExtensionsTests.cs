using System.Xml.Linq;
using JetBrains.Annotations;
using Xunit;

namespace AD.Xml.Tests
{
    [UsedImplicitly]
    public class ToLongExtensionsTests
    {
        [Fact]
        public void ToLongTest0()
        {
            // Arrange
            XElement element = new XElement("test", "1");

            // Act
            double? result = element.ToLong();

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void ToLongTest1()
        {
            // Arrange
            XElement element = new XElement("test", "1.1");

            // Act
            double? result = element.ToLong();

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void ToLongTest2()
        {
            // Arrange
            XElement element = new XElement("test", "$1,000");

            // Act
            double? result = element.ToLong();

            // Assert
            Assert.Equal(1000, result);
        }
    }
}