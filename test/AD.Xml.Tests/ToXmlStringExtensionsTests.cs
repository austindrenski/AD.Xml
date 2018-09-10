using System;
using System.Collections;
using System.Xml.Linq;
using JetBrains.Annotations;
using Xunit;

namespace AD.Xml.Tests
{
    [UsedImplicitly]
    public class ToXmlStringExtensionsTests
    {
        [Fact]
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
            Assert.Equal($"<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>{Environment.NewLine}<root>{Environment.NewLine}  <record>{Environment.NewLine}    <A>a</A>{Environment.NewLine}    <B>b</B>{Environment.NewLine}  </record>{Environment.NewLine}</root>", result);
        }

        [Fact]
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
            Assert.Equal($"<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>{Environment.NewLine}<root>{Environment.NewLine}  <record>{Environment.NewLine}    <A>aa</A>{Environment.NewLine}    <B>b</B>{Environment.NewLine}  </record>{Environment.NewLine}</root>", result);
        }

        [Fact]
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
            Assert.Equal($"<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>{Environment.NewLine}<root>{Environment.NewLine}  <A>a</A>{Environment.NewLine}  <B>b</B>{Environment.NewLine}</root>", result);
        }
    }
}