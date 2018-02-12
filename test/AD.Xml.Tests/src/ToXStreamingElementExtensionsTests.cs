using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AD.Xml.Tests
{
    [TestClass]
    public class ToXStreamingElementExtensionsTests
    {
        [TestMethod]
        public void ToXStreamingElementTest0()
        {
            // Arrange
            IEnumerable enumerable = new int[] {0, 1, 2, 3, 4};

            // Act
            XStreamingElement element = enumerable.ToXStreamingElement();
            XElement result = XElement.Parse(element.ToString());

            // Assert
            Assert.IsTrue(result.Elements().Count() == ((IEnumerable<int>) enumerable).Count());
        }

        [TestMethod]
        public void ToXStreamingElementTest1()
        {
            // Arrange
            IEnumerable enumerable = new XElement[]
            {
                new XElement("A", "a"),
                new XElement("B", "b"),
                new XElement("C", "c"),
            };

            // Act
            XStreamingElement element = enumerable.ToXStreamingElement();
            XElement result = XElement.Parse(element.ToString());
            XElement expected = new XElement("root", enumerable);

            // Assert
            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        [TestMethod]
        public void ToXStreamingElementTest2()
        {
            // Arrange
            XElement elements = new XElement("root", 
                new XElement("A", "a"), 
                new XElement("B", "b"),
                new XElement("C", "c")
            );

            // Act
            XStreamingElement element = elements.ToXStreamingElement();
            XElement result = XElement.Parse(element.ToString());

            // Assert
            Assert.AreEqual(elements.ToString(), result.ToString());
        }

        [TestMethod]
        public void ToXStreamingElementTest3()
        {
            // Arrange
            XDocument elements = new XDocument(
                new XElement("root",
                    new XElement("A", "a"),
                    new XElement("B", "b"),
                    new XElement("C", "c")
                )
            );

            // Act
            XStreamingElement element = elements.ToXStreamingElement();
            XElement result = XElement.Parse(element.ToString());

            // Assert
            Assert.AreEqual(elements.ToString(), result.ToString());
        }
    }
}