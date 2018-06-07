using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;
using Xunit;

namespace AD.Xml.Tests
{
    [UsedImplicitly]
    public class ModifyExtensionsTests
    {
        [Fact]
        public void ModifyNameTest0()
        {
            // Arrange
            IEnumerable<XElement> elements = new XElement[]
            {
                new XElement("root",
                    new XElement("A", 0),
                    new XElement("B", 1),
                    new XElement("C", 2),
                    new XElement("A", 3))
            };

            // Act
            ParallelQuery<XElement> t = elements.AsParallel().ChangeXNames(x => x.Value == "3", "AA");
            string test = string.Join("|", t.Select(x => x.Name));

            // Assert
            Assert.True(elements.Count(x => x.Name == "AA") == 1);
            Assert.Equal("A|B|C|AA", test);
        }

        [Fact]
        public void ModifyNameTest1()
        {
            // Arrange
            IEnumerable<XElement> elements = new XElement[]
            {
                new XElement("root",
                    new XElement("A", 0),
                    new XElement("B", 1),
                    new XElement("C", 2),
                    new XElement("A", 3))
            };

            // Act
            ParallelQuery<XElement> t = elements.AsParallel().ChangeXNames("A", "AA");
            string test = string.Join("|", t.Select(x => x.Name));

            // Assert
            Assert.True(elements.Count(x => x.Name == "AA") == 2);
            Assert.Equal("AA|B|C|AA", test);
        }
    }
}