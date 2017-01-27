using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AD.Xml.Tests
{
    [TestClass]
    public class ModifyExtensionsTests
    {
        [TestMethod]
        public void ModifyNameTest0()
        {
            // Arrange
            IEnumerable<XElement> elements = new XElement[]
            {
                new XElement("A", 0),
                new XElement("B", 1),
                new XElement("C", 2),
                new XElement("A", 3)
            };

            // Act
            elements.AsParallel().ChangeXNames(x => x.Value == "3", "AA");
            string test = string.Join("|", elements.Select(x => x.Name));

            // Assert
            Assert.IsTrue(elements.Count(x => x.Name == "AA") == 1);
            Assert.AreEqual("A|B|C|AA", test);
        }

        [TestMethod]
        public void ModifyNameTest1()
        {
            // Arrange
            IEnumerable<XElement> elements = new XElement[]
            {
                new XElement("A", 0),
                new XElement("B", 1),
                new XElement("C", 2),
                new XElement("A", 3)
            };

            // Act
            elements.AsParallel().ChangeXNames("A", "AA");
            string test = string.Join("|", elements.Select(x => x.Name));

            // Assert
            Assert.IsTrue(elements.Count(x => x.Name == "AA") == 2);
            Assert.AreEqual("AA|B|C|AA", test);
        }
    }
}