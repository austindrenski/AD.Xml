using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;
using Xunit;

namespace AD.Xml.Tests
{
    [UsedImplicitly]
    public class RemoveByExtensionsTests
    {
        [Fact]
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
            ParallelQuery<XElement> _ = elements.AsParallel().RemoveBy("B");

            // Assert
            Assert.True(!elements.Elements("B").Any());
        }

        [Fact]
        public void RemoveByTest1()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void RemoveByTest2()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void RemoveByTest3()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void RemoveByTest4()
        {
            throw new NotImplementedException();
        }
    }
}