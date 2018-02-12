using System.Collections.Generic;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    /// <summary>
    /// Extension methods for locating sibling nodes.
    /// </summary>
    [PublicAPI]
    public static class SiblingExtensions
    {
        /// <summary>
        /// Returns the sibling node with the specified name.
        /// </summary>
        /// <param name="element">The source element.</param>
        /// <param name="name">The name of the sibling element to find.</param>
        /// <returns>The sibling element with the specified name.</returns>
        [CanBeNull]
        public static XElement Sibling(this XElement element, XName name)
        {
            return element.Parent?.Element(name);
        }

        /// <summary>
        /// Returns the sibling nodes with the specified name.
        /// </summary>
        /// <param name="element">The source element.</param>
        /// <param name="name">The name of the sibling elements to find.</param>
        /// <returns>An <see cref="IEnumerable{XElement}"/> of siblings with the specified name.</returns>
        [CanBeNull]
        public static IEnumerable<XElement> Siblings(this XElement element, XName name)
        {
            return element.Parent?.Elements(name);
        }
    }
}
