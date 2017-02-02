using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Xml.Schema;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AD.Xml.Tests
{
    [TestClass]
    public class XmlSchemaExtensionsTests
    {
        [TestMethod]
        public void XmlSchemaTest0()
        {
            // Arrange
            XDocument document =
                new XDocument(
                    new XElement("root",
                        new XElement("record",
                            new XElement("A", "a"),
                            new XElement("B", "b"))));

            // Act
            XmlSchema schema = document.XmlSchema();
            bool valid = document.Validate(schema);

            // Assert
            Assert.AreEqual(true, valid);
        }

        [TestMethod]
        public void XmlSchemaTest1()
        {
            // Arrange
            XDocument document0 =
                new XDocument(
                    new XElement("root",
                        new XElement("record",
                            new XElement("A", "a"),
                            new XElement("B", "b"))));

            XDocument document1 =
                new XDocument(
                    new XElement("root",
                        new XElement("record",
                            new XElement("A", "a"))));

            // Act
            bool valid;
            string output;
            using (MemoryStream stream = new MemoryStream())
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    XmlSchema schema = document0.XmlSchema(writer);
                    valid = document1.Validate(schema, writer);
                }
                output = Encoding.UTF8.GetString(stream.ToArray());
            }

            // Assert
            Assert.IsNotNull(output);
            Assert.AreEqual(false, valid);
        }
    }
}