using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AD.Xml.Tests
{
    [TestClass]
    public class ToXElementExensionsTests
    {
        [TestMethod]
        public void ToXElementTest0() 
        {
            // Arrange
            IEnumerable enumerable = new XElement[]
            {
                new XElement("record", new XElement("a", "A"), new XElement("b", "B"), new XElement("c", "C"), new XElement("HTS10", "0123456789"), new XElement("z"), new XElement("zz", "0")),
                new XElement("record", new XElement("a", "D"), new XElement("b", "E"), new XElement("c", "F"), new XElement("HTS10", "0123456789"), new XElement("z"), new XElement("zz", "0")),
                new XElement("record", new XElement("a", "G"), new XElement("b", "H"), new XElement("c", "I"), new XElement("HTS10", "0123456789"), new XElement("z"), new XElement("zz", "0"))
            };

            // Act
            XElement element = enumerable.ToXElement();

            // Assert
            Assert.IsTrue(element.Elements().Count() == new XElement("root", enumerable).Elements().Count());
        }

        [TestMethod]
        [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
        public void ToXElementTest1()
        {
            // Arrange
            XElement element = new XElement("TestElement", "content");

            // Act
            XElement result = element.ToXElement();

            // Assert
            Assert.IsTrue(result.Value == element.Value);
        }

        [TestMethod]
        public void ToXElementTest2()
        {
            // Arrange
            char a = 'a';

            // Act
            XElement result = a.ToXElement();

            // Assert
            Assert.IsTrue(result.Value == a.ToString());
        }

        [TestMethod]
        public void ToXElementTest3()
        {
            // Arrange
            IEnumerable<XElement> elements = new XElement[]
            {
                new XElement("record", new XElement("a", "A"), new XElement("b", "B"), new XElement("c", "C"), new XElement("HTS10", "0123456789"), new XElement("z"), new XElement("zz", "0")),
                new XElement("record", new XElement("a", "D"), new XElement("b", "E"), new XElement("c", "F"), new XElement("HTS10", "0123456789"), new XElement("z"), new XElement("zz", "0")),
                new XElement("record", new XElement("a", "G"), new XElement("b", "H"), new XElement("c", "I"), new XElement("HTS10", "0123456789"), new XElement("z"), new XElement("zz", "0"))
            };

            // Act
            XElement result = elements.ToXElement();

            // Assert
            Assert.IsTrue(result.Elements().Any());
        }


        [TestMethod]
        public void ToXElementTest5()
        {
            // Arrange
            IEnumerable classes = new TestClass[]
            {
                new TestClass { Hts10 = "0123456789" },
                new TestClass { Hts10 = "0123456789" },
                new TestClass { Hts10 = "0123456789" }
            };

            // Act
            XElement result = classes.ToXElement();

            // Assert
            Assert.IsTrue(result.Descendants("Hts10").Any());
        }

        private class TestClass
        {
            public string Hts10 { [UsedImplicitly] get; set; }
        }

    }
}