using System.Xml.Linq;
using JetBrains.Annotations;
using Xunit;

namespace AD.Xml.Tests
{
    [UsedImplicitly]
    public class ToXNameExtensionsTests
    {
        [Fact]
        public void ToXNameTest()
        {
            // Arrange
            const string name = "TestName";
            XDocument document = new XDocument(new XElement("root", new XElement("record", new XElement("testName", "testing"))));

            // Act
            XName xName = name.ToXName(document);

            // Assert
            Assert.Equal(name.ToLower(), xName.ToString().ToLower());
        }
    }
}