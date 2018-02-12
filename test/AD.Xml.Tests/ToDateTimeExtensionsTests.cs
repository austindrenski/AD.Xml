using System;
using System.Xml.Linq;
using JetBrains.Annotations;
using Xunit;

namespace AD.Xml.Tests
{
    [UsedImplicitly]
    public class ToDateTimeExtensionsTests
    {
        [Fact]
        public void ToDateTimeTest0()
        {
            // Arrange
            XElement element = new XElement("Date", "01/01/2017");

            // Act
            DateTime? result = element.ToDateTime();

            // Assert
            Assert.Equal(new DateTime(2017, 1, 1), result);
        }

        [Fact]
        public void ToDateTimeTest1()
        {
            // Arrange
            XElement element = new XElement("Date", "01/01/201717");

            // Act
            DateTime? result = element.ToDateTime();

            // Assert
            Assert.Equal(null, result);
        }
    }
}