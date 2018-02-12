using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;
using Xunit;

namespace AD.Xml.Tests
{
    [UsedImplicitly]
    public class OrderByExtensionsTests
    {
        [Fact]
        public void OrderByTest0()
        {
            // Arrange
            XDocument document = new XDocument(new XElement("root", new XElement("record", new XElement("A", "a")), new XElement("record", new XElement("A", "b"))));

            // Act
            IDictionary<XName, SortOrderType> dictionary = new Dictionary<XName, SortOrderType>();
            dictionary.Add("A", SortOrderType.Descending);
            XDocument result = document.OrderBy(dictionary);
            string value = result.Root?.Elements().First().Value;

            // Assert
            Assert.Equal("b", value);
        }

        [Fact]
        public void OrderByTest1()
        {
            // Arrange
            XDocument document = new XDocument(new XElement("root", new XElement("record", new XElement("A", "a")), new XElement("record", new XElement("A", "b"))));

            // Act
            XDocument result = document.OrderBy(new string[] { "A|desc" });
            string value = result.Root?.Elements().First().Value;

            // Assert
            Assert.Equal("b", value);
        }

        [Fact]
        public void OrderByTest2()
        {
            // Arrange
            XDocument document =
                new XDocument(
                    new XElement("root",
                        new XElement("record",
                            new XElement("A", "a"),
                            new XElement("B", "b")),
                        new XElement("record",
                            new XElement("A", "b"),
                            new XElement("B", "c")),
                        new XElement("record",
                            new XElement("A", "c"),
                            new XElement("B", "a"))));

            // Act
            IDictionary<XName, SortOrderType> dictionary = new Dictionary<XName, SortOrderType>();
            dictionary.Add("A", SortOrderType.Descending);
            dictionary.Add("B", SortOrderType.Ascending);
            XDocument result = document.OrderBy(dictionary);
            string name = result.Root?.Elements().First().Elements().First().Name.ToString();
            string value = result.Root?.Elements().First().Elements().First().Value;

            // Assert
            Assert.Equal("A", name);
            Assert.Equal("c", value);
        }

        [Fact]
        public void OrderByTest3()
        {
            // Arrange
            XDocument document =
                new XDocument(
                    new XElement("root",
                        new XElement("record",
                            new XElement("A", "a"),
                            new XElement("B", "b")),
                        new XElement("record",
                            new XElement("A", "b"),
                            new XElement("B", "c")),
                        new XElement("record",
                            new XElement("A", "c"),
                            new XElement("B", "a"))));
            // Act
            XDocument result = document.OrderBy(new string[] { "A|desc", "B|asc" });
            string name = result.Root?.Elements().First().Elements().First().Name.ToString();
            string value = result.Root?.Elements().First().Elements().First().Value;

            // Assert
            Assert.Equal("A", name);
            Assert.Equal("c", value);
        }

        [Fact]
        public void OrderByTest4()
        {
            // Arrange
            XDocument document =
                new XDocument(
                    new XElement("root",
                        new XElement("record",
                            new XElement("A", "a"),
                            new XElement("B", "b")),
                        new XElement("record",
                            new XElement("A", "b"),
                            new XElement("B", "c")),
                        new XElement("record",
                            new XElement("A", "c"),
                            new XElement("B", "a"))));
            // Act
            XDocument result = document.OrderBy(new string[0]);
            string name = result.Root?.Elements().First().Elements().First().Name.ToString();
            string value = result.Root?.Elements().First().Elements().First().Value;

            // Assert
            Assert.Equal("A", name);
            Assert.Equal("a", value);
        }

        [Fact]
        public void OrderByTest5()
        {
            // Arrange
            XDocument document =
                new XDocument(
                    new XElement("root",
                        new XElement("record",
                            new XElement("A", "a"),
                            new XElement("B", "b")),
                        new XElement("record",
                            new XElement("A", "b"),
                            new XElement("B", "c")),
                        new XElement("record",
                            new XElement("A", "c"),
                            new XElement("B", "a"))));
            // Act
            XDocument result = document.OrderBy(new string[0]);
            string name = result.Root?.Elements().First().Elements().First().Name.ToString();
            string value = result.Root?.Elements().First().Elements().First().Value;

            // Assert
            Assert.Equal("A", name);
            Assert.Equal("a", value);
        }

        [Fact]
        public void OrderByTest6()
        {
            // Arrange
            XDocument document =
                new XDocument(
                    new XElement("root",
                        new XElement("record",
                            new XElement("A", "a"),
                            new XElement("B", "b")),
                        new XElement("record",
                            new XElement("A", "b"),
                            new XElement("B", "c")),
                        new XElement("record",
                            new XElement("A", "c"),
                            new XElement("B", "a"))));

            // Act
            IDictionary<XName, SortOrderType> dictionary = new Dictionary<XName, SortOrderType>();
            dictionary.Add("B", SortOrderType.Ascending);
            dictionary.Add("A", SortOrderType.Ascending);
            XDocument result = document.OrderBy(dictionary);
            string name = result.Root?.Elements().First().Elements().First().Name.ToString();
            string value = result.Root?.Elements().First().Elements().First().Value;

            // Assert
            Assert.Equal("A", name);
            Assert.Equal("c", value);
        }

        [Fact]
        public void OrderByTest7()
        {
            // Arrange
            XDocument document =
                new XDocument(
                    new XElement("root",
                        new XElement("record",
                            new XElement("A", "a"),
                            new XElement("B", "b")),
                        new XElement("record",
                            new XElement("A", "b"),
                            new XElement("B", "c")),
                        new XElement("record",
                            new XElement("A", "c"),
                            new XElement("B", "a"))));

            // Act
            IDictionary<XName, SortOrderType> dictionary = new Dictionary<XName, SortOrderType>();
            dictionary.Add("B", SortOrderType.Ascending);
            dictionary.Add("A", SortOrderType.Descending);
            XDocument result = document.OrderBy(dictionary);
            string name = result.Root?.Elements().First().Elements().First().Name.ToString();
            string value = result.Root?.Elements().First().Elements().First().Value;

            // Assert
            Assert.Equal("A", name);
            Assert.Equal("c", value);
        }

        [Fact]
        public void OrderByTest8()
        {
            // Arrange
            XDocument document =
                new XDocument(
                    new XElement("root",
                        new XElement("record",
                            new XElement("A", "a"),
                            new XElement("B", "b")),
                        new XElement("record",
                            new XElement("A", "b"),
                            new XElement("B", "c")),
                        new XElement("record",
                            new XElement("A", "c"),
                            new XElement("B", "a"))));

            // Act
            IDictionary<XName, SortOrderType> dictionary = new Dictionary<XName, SortOrderType>();
            dictionary.Add("B", SortOrderType.DoNotUse);
            dictionary.Add("A", SortOrderType.Ascending);

            // Assert
            Assert.Throws<NotImplementedException>(() => document.OrderBy(dictionary));
        }

        [Fact]
        public void OrderByTest9()
        {
            // Arrange
            XDocument document =
                new XDocument(
                    new XElement("root",
                        new XElement("record",
                            new XElement("A", "a"),
                            new XElement("B", "b")),
                        new XElement("record",
                            new XElement("A", "b"),
                            new XElement("B", "c")),
                        new XElement("record",
                            new XElement("A", "c"),
                            new XElement("B", "a"))));

            // Act
            IDictionary<XName, SortOrderType> dictionary = new Dictionary<XName, SortOrderType>();
            dictionary.Add("B", SortOrderType.Ascending);
            dictionary.Add("A", SortOrderType.DoNotUse);

            // Assert
            Assert.Throws<NotImplementedException>(() => document.OrderBy(dictionary));
        }
    }
}