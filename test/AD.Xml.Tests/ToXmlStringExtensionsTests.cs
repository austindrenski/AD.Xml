using System.Collections;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AD.Xml.Tests
{
    [TestClass]
    public class ToXmlStringExtensionsTests
    {
        [TestMethod]
        public void ToXmlStringTest0()
        {
            // Arrange 
            XDocument document =
                new XDocument(
                    new XElement("root",
                        new XElement("record",
                            new XElement("A", "a"),
                            new XElement("B", "b"))));

            // Act
            string result = document.ToXmlString();

            // Assert
            Assert.AreEqual("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>\r\n<root>\r\n  <record>\r\n    <A>a</A>\r\n    <B>b</B>\r\n  </record>\r\n</root>", result);
        }

        [TestMethod]
        public void ToXmlStringTest1()
        {
            // Arrange 
            XDocument document =
                new XDocument(
                    new XElement("root",
                        new XElement("record",
                            new XElement("A", "a\v\f\0a"),
                            new XElement("B", "b"))));

            // Act
            string result = document.ToXmlString();

            // Assert
            Assert.AreEqual("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>\r\n<root>\r\n  <record>\r\n    <A>aa</A>\r\n    <B>b</B>\r\n  </record>\r\n</root>", result);
        }

        [TestMethod]
        public void ToXmlStringTest2()
        {
            // Arrange 
            IEnumerable elements = new XElement[]
            {
                new XElement("A", "a"),
                new XElement("B", "b")
            };

            // Act
            string result = elements.ToXmlString();

            // Assert
            Assert.AreEqual("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>\r\n<root>\r\n  <A>a</A>\r\n  <B>b</B>\r\n</root>", result);
        }

    }
}