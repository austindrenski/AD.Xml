using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AD.Xml.Tests
{
    [TestClass]
    public class ToXNameExtensionsTests
    {
        [TestMethod]
        public void ToXNameTest()
        {
            // Arrange
            const string name = "TestName";
            XDocument document = new XDocument(new XElement("root", new XElement("record", new XElement("testName", "testing"))));

            // Act
            XName xName = name.ToXName(document);

            // Assert
            Assert.AreEqual(name.ToLower(), xName.ToString().ToLower());
        }
    }
}