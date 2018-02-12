using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AD.Xml.Tests
{
    [TestClass]
    public class RemoveByExtensionsTests
    {
        [TestMethod]
        public void RemoveByTest()
        {
            // Arrange
            XElement element0 =
                new XElement("root",
                    new XElement("A", "a"),
                    new XElement("B", "b"),
                    new XElement("B", "c")
                );
            XElement element1 =
                new XElement("root",
                    new XElement("A", "a"),
                    new XElement("B", "b"),
                    new XElement("B", "c")
                );
            IEnumerable<XElement> elements = new XElement[] {element0, element1};

            // Act
            elements.AsParallel().RemoveBy("B");

            // Assert
            Assert.IsTrue(!elements.Elements("B").Any());
        }

        [TestMethod]
        public void RemoveByTest1()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void RemoveByTest2()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void RemoveByTest3()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void RemoveByTest4()
        {
            throw new NotImplementedException();
        }
    }
}