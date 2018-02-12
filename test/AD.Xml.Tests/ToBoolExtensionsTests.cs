using System.Xml.Linq;
using JetBrains.Annotations;
using Xunit;

namespace AD.Xml.Tests
{
    [UsedImplicitly]
    public class ToBoolExtensionsTests
    {
        [Fact]
        public void ToBoolTest0()
        {
            // Arrange
            XElement element = new XElement("record", "0");

            // Act
            bool? result = element.ToBool();

            // Assert
            Assert.Equal(false, result);
        }

        [Fact]
        public void ToBoolTest1()
        {
            // Arrange
            XElement element = new XElement("record", "1");

            // Act
            bool? result = element.ToBool();

            // Assert
            Assert.Equal(true, result);
        }

        [Fact]
        public void ToBoolTest2()
        {
            // Arrange
            XElement element = new XElement("record", "a");

            // Act
            bool? result = element.ToBool();

            // Assert
            Assert.Equal(null, result);
        }

        [Fact]
        public void ToBoolTest3()
        {
            // Arrange
            XElement element = new XElement("record", "true");

            // Act
            bool? result = element.ToBool();

            // Assert
            Assert.Equal(true, result);
        }
         
        [Fact]
        public void ToBoolTest4()
        {
            // Arrange
            XElement element = new XElement("record", "false");

            // Act
            bool? result = element.ToBool();

            // Assert
            Assert.Equal(false, result);
        }
    }
}