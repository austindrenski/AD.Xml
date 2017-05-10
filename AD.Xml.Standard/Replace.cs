using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml.Standard
{
    /// <summary>
    /// Extension methods to replace nodes in an XML tree.
    /// </summary>
    [PublicAPI]
    public static class ReplaceExtensions
    {
        /// <summary>
        /// Replaces descendants with a name equal to <paramref name="oldName"/> with the element created from <paramref name="name"/> and <paramref name="content"/>.
        /// This method works on the existing <see cref="XElement"/> and returns a reference to it for a fluent syntax.
        /// </summary>
        /// <param name="element">The element to search for descendants whose names are equal to <paramref name="oldName"/>.</param>
        /// <param name="oldName">The element name for which to search.</param>
        /// <param name="name">The name of the replacement node.</param>
        /// <param name="content">The content of the replacement node.</param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        /// <exception cref="System.ArgumentNullException"/>
        public static XElement Replace(this XElement element, XName oldName, XName name, object content)
        {
            IEnumerable<XElement> nodesToRemove = element.Descendants(oldName)
                                                         .ToArray();
            IEnumerable<XElement> parents = nodesToRemove.Select(x => x.Parent)
                                                         .ToArray();
            nodesToRemove.Remove();
            foreach (XElement item in parents)
            {
                item.Add(new XElement(name, content));
            }
            return element;
        }
    }
}
